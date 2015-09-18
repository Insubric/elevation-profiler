Imports ESRI.ArcGIS.Geodatabase

Module Process
    ' Date: 24/06/2013
    ' ELEVATION PROFILER
    ' module "Process"
    '
    ' Elevation profiler is a GIS tool that automatically calculate transverse or longitudinal elevation profiles starting from a shapefile of points and a digital elevation model (DEM)
    ' The tool il conceived as a VBA macro (composed by a form and 5 modules) that can be added and run from the visual basic editor in ArcMap
    '
    ' Authors:
    '
    ' University of Eastern Finland  and  University of Kuopio (Finland)
    ' Markus Stocker:  markus.stocker@gmail.com  or  markus.stocker@uef.fi
    '
    ' Swiss Federal Research Institute WSL (Switzerland)
    ' Boris Pezzatti:  boris.pezzatti@wsl.ch
    ' Patrik Krebs:  patrik.krebs@wsl.ch
    '
    ' Copyright 2013 by WSL
    '
    '


    ' A UDT for coordinate points
    Public Structure WSLPoint
        ' The X coordinate of the point
        Public xcoord As Double
        ' The Y coordinate of the point
        Public ycoord As Double
        ' The DEM elevation of the point
        Public elevation As Double
    End Structure


    Public Sub Process(map As IMap, pointLayer As String, demRaster As String, min As Integer, max As Integer, interval As Integer, resolution As Integer,
                       circlePoints As Integer, minimize As Boolean, outputDir As String, Optional separator As String = ",")
        'Dim map As IMap
        '      Dim MxDocument As IMxDocument
        Dim wslLocationsLayer As IFeatureLayer
        Dim wslLocationsFeatureClass As IFeatureClass
        Dim wslDEMLayer As IRasterLayer
        Dim wslDEMRaster As IRaster
        ' Contains the IPoint objects that are in the layer defined by frmProfiler.cboINPUT
        Dim wslLocations As IPointCollection

        Dim i As Integer

        Dim nr As Integer
        nr = CInt((max - min) / interval) + 1

        Dim segmLengths() As Double
        Dim segmPoints() As Integer

        ReDim segmLengths(nr)
        ReDim segmPoints(nr)



        ' The list of parameters used as segmLength
        For i = 0 To nr - 1
            segmLengths(i) = min + (interval * i)
        Next i

        ' The list of parameters used as segmPoints
        For i = 0 To UBound(segmPoints) - 1
            segmPoints(i) = segmLengths(i) / resolution + 1
        Next i


        '    MxDocument = ThisDocument
        '   map = MxDocument.FocusMap

        ' Get the layer with the locations, e.g. charcoal production places
        wslLocationsLayer = WSLUtils.FindLocationsLayer(map, pointLayer)
        wslLocationsFeatureClass = wslLocationsLayer.FeatureClass


        ' Get the Digital Elevation Model layer
        wslDEMLayer = WSLUtils.FindDEMLayer(map, demRaster)
        wslDEMRaster = wslDEMLayer.Raster

        ' Use bilinear interpolation on the raster
        wslDEMRaster.ResampleMethod = ESRI.ArcGIS.Geodatabase.rstResamplingTypes.RSP_BilinearInterpolation

        ' Check if the feature class is of type point
        If wslLocationsFeatureClass.ShapeType = ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPoint Then
            wslLocations = New Multipoint
            ' Extract the IPoint objects from the layer
            GetMapLocations(wslLocations, wslLocationsFeatureClass)
            ' Create segments that satisfy the minimality criterion
            ' CreateProfiles wslLocations, wslDEMRaster

            ' The following range ("1 To UBound") is the same of the one mentioned above
            For i = 0 To UBound(segmLengths) - 1
                ' sl = segmLengths(i)
                ' sp = segmPoints(i)     ' CInt(trunc(sl)+1)
                CreateProfiles(wslLocations, wslDEMRaster, segmLengths(i), segmPoints(i), outputDir, circlePoints, minimize, separator)
            Next i


        Else
            MsgBox(pointLayer & ": requires shapefile of type 'point'")

        End If

    End Sub

    ' The function creates the segments for all points such that they each satisfy the minimality criterion
    Private Function CreateProfiles(pointCollection As IPointCollection, demRaster As IRaster, locationSegmentLength As Double, locationNumOfSegmentPoints As Integer, outputDir As String,
                                    circlePoints As Integer, minimize As Boolean, Optional separator As String = ",")
        Dim i As Integer
        ' First extreme point of the segment
        Dim extremePoint1 As WSLPoint
        ' Second extreme point of the segment
        Dim extremePoint2 As WSLPoint
        ' The max index of the point collection array
        Dim maxLocations As Integer
        ' The max index of the segment points
        Dim maxPoints As Integer
        Dim output(,) As WSLPoint
        'Dim random(,) As WSLPoint

        maxLocations = pointCollection.PointCount
        maxPoints = locationNumOfSegmentPoints - 1

        ' Output Array of size # of locations times # of points for each segment
        ReDim output(maxLocations, maxPoints)

        For i = 0 To maxLocations - 1
            CreateSegment(i, pointCollection.Point(i).X, pointCollection.Point(i).Y, extremePoint1, extremePoint2, demRaster, locationSegmentLength, circlePoints, minimize)
            'MsgBox("extremePoint1: " + extremePoint1.xcoord.ToString)
            CreateProfile(i, extremePoint1, extremePoint2, demRaster, output, locationNumOfSegmentPoints)
        Next i

        'MsgBox(output.ToString)

        ' Write location data (relative elevation to the location) adding the segment length and the number of segment points to the file name
        ' for example "locations_distances_10_11.csv"
        WSLUtils.SaveDistanceData(output, maxLocations, maxPoints, outputDir & WSLConstants.LOCATION_DISTANCES_FILE_NAME & "_Length" & locationSegmentLength & "_Points" & locationNumOfSegmentPoints & ".csv", separator)
        ' Write profile data (absolute) adding the segment length and the number of segment points to the file name
        ' for example "segments_points_10_11.csv"
        WSLUtils.SaveProfileData(output, maxLocations, maxPoints, outputDir & WSLConstants.SEGMENT_POINTS_DATA_FILE_NAME & "_Length" & locationSegmentLength & "_Points" & locationNumOfSegmentPoints & ".csv", separator)
        ' Write direction data (direction of each segment) adding the segment length and the number of segment points to the file name
        ' for example "segments_directions_10_11.csv"
        WSLUtils.SaveDirectionData(output, maxLocations, maxPoints, outputDir & WSLConstants.SEGMENT_DIRECTION_FILE_NAME & "_Length" & locationSegmentLength & "_Points" & locationNumOfSegmentPoints & ".csv", locationSegmentLength, separator)

        ' Process random data
        'If WSLConstants.COMPUTE_RANDOM_POINTS Then
        '    ReDim random(WSLConstants.NUMBER_OF_RANDOM_POINTS, maxPoints)

        '    For i = 0 To WSLConstants.NUMBER_OF_RANDOM_POINTS
        '        CreateSegment(i, WSLUtils.random(WSLConstants.RND_XCOORD_LOWER, WSLConstants.RND_XCOORD_UPPER), WSLUtils.random(WSLConstants.RND_YCOORD_LOWER, WSLConstants.RND_YCOORD_UPPER),
        '                      extremePoint1, extremePoint2, demRaster, locationSegmentLength, circlePoints, minimize)
        '        CreateProfile(i, extremePoint1, extremePoint2, demRaster, random, locationNumOfSegmentPoints)
        '    Next i

        '    ' Write random data
        '    WSLUtils.SaveDistanceData(random, WSLConstants.NUMBER_OF_RANDOM_POINTS, maxPoints, WSLConstants.RANDOM_DISTANCES_FILE_NAME)
        'End If
    End Function

    ' Create the profile for a segment, defined by two points
    Private Function CreateProfile(i As Integer, extremePoint1 As WSLPoint, extremePoint2 As WSLPoint, demRaster As IRaster2, output(,) As WSLPoint, locationNumOfSegmentPoints As Integer)
        Dim xcoord As Double
        Dim ycoord As Double
        Dim dx As Double
        Dim dy As Double
        Dim elevation As Double
        Dim point As WSLPoint

        ' XY values for the point where to start
        xcoord = extremePoint1.xcoord
        ycoord = extremePoint1.ycoord

        dx = (extremePoint1.xcoord - extremePoint2.xcoord) / (locationNumOfSegmentPoints - 1)
        dy = (extremePoint1.ycoord - extremePoint2.ycoord) / (locationNumOfSegmentPoints - 1)

        'MsgBox("dx: " + dx.ToString)

        For j = 0 To locationNumOfSegmentPoints - 1
            elevation = WSLUtils.GetElevationByCoord(xcoord, ycoord, demRaster, True)

            point.xcoord = xcoord
            'MsgBox("xcoord: " + xcoord.ToString + vbCrLf +
            '       "point: " + point.xcoord.ToString)

            point.ycoord = ycoord
            point.elevation = elevation

            ' Save the result to the output array
            output(i, j) = point

            xcoord = xcoord - dx
            ycoord = ycoord - dy
        Next j



    End Function

    ' Create the segment for a single point such that it satisfies the minimality criterion
    Private Function CreateSegment(i As Integer, xCoordLocation As Double, yCoordLocation As Double, ByRef extremePoint1 As WSLPoint, ByRef extremePoint2 As WSLPoint, demRaster As IRaster2,
                                   locationSegmentLength As Double, circlePoints As Integer, minimize As Boolean)
        Dim firstPoint As WSLPoint
        Dim lastPoint As WSLPoint
        ' The DEM evelation of the location
        Dim demElevationLocation As Double
        Dim locationCirclePoints() As WSLPoint
        ReDim locationCirclePoints(circlePoints)

        demElevationLocation = WSLUtils.GetElevationByCoord(xCoordLocation, yCoordLocation, demRaster, True)

        If WSLConstants.LOG_LEVEL = 2 Then
            WSLUtils.log("Create segment for " & i & " point: x = " & xCoordLocation & ", y = " & yCoordLocation & ", z = " & demElevationLocation)
        End If

        ' Build the circle approximated by its points for the location
        BuildCircle(locationCirclePoints, xCoordLocation, yCoordLocation, demRaster, locationSegmentLength, circlePoints)

        firstPoint = locationCirclePoints(0)
        lastPoint = locationCirclePoints(circlePoints)

        'If firstPoint.xCoord = lastPoint.xCoord And firstPoint.yCoord = lastPoint.yCoord Then
        ' The segment is defined by the coordinates of the two extreme points
        FindSegment(minimize, extremePoint1, extremePoint2, locationCirclePoints, demRaster, circlePoints)
        'Else
        '    MsgBox "Error for circle with center x = " & xCoordLocation & ", y = " & yCoordLocation & " (see log file)"
        '    WSLUtils.log ("Error for circle with center x = " & xCoordLocation & ", y = " & yCoordLocation & ": first and last point coordinates do not match, (" & firstPoint.xCoord & ", " & firstPoint.yCoord & ") and (" & lastPoint.xCoord & ", " & lastPoint.yCoord & ")")
        'End If

        ' Print the resulting segment to the results
        ' WSLUtils.result leftPoint.xCoord & "," & leftPoint.yCoord & vbNewLine & rightPoint.xCoord & "," & rightPoint.yCoord
    End Function

    ' Given an array of points find the pair that satisfies the minimality or maximality criterion, i.e. the segment that minimizes or maximiyes the difference of the vertical distance for the two extreme points
    Private Function FindSegment(minimize As Boolean, ByRef extremePoint1 As WSLPoint, ByRef extremePoint2 As WSLPoint, locationCirclePoints() As WSLPoint, demRaster As IRaster2, circlePoints As Integer)
        ' For each point pair from 0 .. LOCATION_NUM_OF_CIRCLE_POINTS - 1 compute the differences and find the minimum
        Dim extreme1 As WSLPoint
        Dim extreme2 As WSLPoint
        Dim min As Double
        ' The absolute difference for the two distances of the left and right extreme points of the segment
        Dim diff As Double
        ' The middle point in the list of circle points, i.e. LOCATION_NUM_OF_CIRCLE_POINTS / 2
        Dim middle As Integer

        If (minimize) Then
            min = 1.79769313486232E+208
        Else
            min = 0
        End If

        middle = circlePoints / 2

        For i = 0 To middle - 1
            extreme1 = locationCirclePoints(i)
            extreme2 = locationCirclePoints(middle + i)

            diff = Math.Abs(extreme1.elevation - extreme2.elevation)

            ' Save the point as the new minimum if the difference is smaller than the temporary minima
            If (minimize And diff < min) Or (minimize = False And diff > min) Then
                extremePoint1 = extreme1
                extremePoint2 = extreme2
                min = diff
            End If
        Next i
    End Function

    ' Given the xy coordinates of a location build the array of points that approximate the circle
    Private Function BuildCircle(locationCirclePoints() As WSLPoint, xcoord As Double, ycoord As Double, demRaster As IRaster2, locationSegmentLength As Double, circlePoints As Integer)
        ' Dim chordLength As Double
        Dim rightAngleRadians As Double
        Dim betaDegrees As Double
        Dim betaRadians As Double

        Dim x As Double
        Dim y As Double
        ' DEM elevation
        Dim z As Double
        Dim p As WSLPoint


        rightAngleRadians = WSLUtils.GetRightAngleInRadians

        For i = 0 To circlePoints
            betaDegrees = i * WSLUtils.GetChordAngle(circlePoints)
            betaRadians = WSLUtils.DegreesToRadians(betaDegrees)

            ' In the previous version (v0.5.2) the following step was done in a much more complex manner
            ' Now the coordinates of the circle points are calculated as follow starting from the centre of the circle
            x = xcoord + Math.Sin(betaRadians) * locationSegmentLength / 2
            y = ycoord + Math.Cos(betaRadians) * locationSegmentLength / 2

            ' Compute elevation and save the point with xy coordinates
            ' The parameter "True" is for the bilinear interpolation: the altitude calculation is more time consuming but more precise
            ' With this bilinear interpolation and with a big number of CIRCLE_POINTS the orientation of the resulting segments is more accurate
            z = WSLUtils.GetElevationByCoord(x, y, demRaster, True)

            p.xcoord = x
            p.ycoord = y
            p.elevation = z

            locationCirclePoints(i) = p

            If WSLConstants.LOG_LEVEL = 2 Then
                WSLUtils.log(i & " circle point: x = " & x & ", y = " & y & ", z = " & z & ", beta = " & betaRadians)
                '               WSLUtils.log(i & " circle point: x = " & x & ", y = " & y & ", z = " & z & ", alpha = " & alphaRadians & ", beta = " & betaRadians)
            End If

        Next i

    End Function

    ' The function extracts the point locations from the layer to a collection which is then further processed by the application
    Private Function GetMapLocations(pointCollection As IPointCollection, featureClass As IFeatureClass)
        Dim featureCursor As IFeatureCursor
        Dim feature As IFeature

        featureCursor = featureClass.Search(Nothing, False)
        feature = featureCursor.NextFeature

        Do Until feature Is Nothing
            pointCollection.AddPoint(feature.Shape)

            feature = featureCursor.NextFeature
        Loop
    End Function


End Module
