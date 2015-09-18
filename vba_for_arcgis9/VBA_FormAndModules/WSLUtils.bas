Attribute VB_Name = "WSLUtils"
' Date: 24/06/2013
' ELEVATION PROFILER
' module "WSLUtils"
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
' Given a map object, the method returns the layer object that is named as in the constant LOCATIONS_LAYER_NAME
Public Function FindLocationsLayer(map As IMap) As IFeatureLayer
    Dim layer As ILayer
    Dim ret As IFeatureLayer
    
    For i = 0 To map.LayerCount - 1
        Set layer = map.layer(i)
        
        If (UCase(frmProfiler.cboINPUT) = (UCase(layer.Name))) Then
            Set ret = layer
            Exit For
        End If
    Next i

    Set FindLocationsLayer = ret
End Function

' Return the Digital Elevation Model (DEM) raster layer
Public Function FindDEMLayer(map As IMap) As IRasterLayer
    Dim ret As IRasterLayer
    Dim layer As ILayer
    
    For i = 0 To map.LayerCount - 1
        Set layer = map.layer(i)
        
        If (UCase(frmProfiler.cboDEM) = (UCase(layer.Name))) Then
            Set ret = layer
            Exit For
        End If
    Next i
    
    Set FindDEMLayer = ret
End Function

' Given a point return its elevation from the DEM raster
' Public Function GetElevationByPoint(point As IPoint, demRaster As IRaster2, interpolation As Boolean) As Double
' GetElevationByPoint = WSLUtils.GetElevationByCoord(point.x, point.y, demRaster, False)
' End Function

' Given xy coordinate information return its evelation from the DEM raster
' This method performs a bilinear interpolation (see http://www.geocomputation.org/1999/082/gc_082.htm)
Public Function GetElevationByCoord(xPointCoord As Double, yPointCoord As Double, demRaster As IRaster2, interpolation As Boolean) As Double
    Dim col, row As Long
    Dim xTest, yTest As Double
    ' h1 = lower-left vertice
    ' h2 = lower-right vertice
    ' h3 = upper-left vertice
    ' h4 = upper-right vertice
    Dim h1, h2, h3, h4 As Double
    Dim z, za, zb As Double
    Dim x, y As Double
    Dim str As String
    
    If interpolation Then
        col = demRaster.ToPixelColumn(xPointCoord)
        row = demRaster.ToPixelRow(yPointCoord)
        
        xTestCoord = demRaster.ToMapX(col)
        yTestCoord = demRaster.ToMapY(row)
        
        If (xPointCoord <= xTestCoord) Then
            ' Right vertice
            If (yPointCoord <= yTestCoord) Then
                ' Upper-right vertice
                h4 = demRaster.GetPixelValue(0, col, row)
                h1 = demRaster.GetPixelValue(0, col - 1, row + 1)
                h2 = demRaster.GetPixelValue(0, col, row + 1)
                h3 = demRaster.GetPixelValue(0, col - 1, row)
                x = (xPointCoord - demRaster.ToMapX(col - 1)) / (demRaster.ToMapX(col) - demRaster.ToMapX(col - 1))
                y = (yPointCoord - demRaster.ToMapY(row + 1)) / (demRaster.ToMapY(row) - demRaster.ToMapY(row + 1))
               
                ' Linear interpolation on x-axis
                za = h1 + x * (h2 - h1)
                zb = h3 + x * (h4 - h3)
        
                ' Linear interpolation on y-axis
                z = za + y * (zb - za)
        
                str = xPointCoord & "; " & yPointCoord & "; " & z & "; " & x & "; " & y & vbCrLf
                str = str & demRaster.ToMapX(col - 1) & "; " & demRaster.ToMapY(row + 1) & "; " & h1 & vbCrLf
                str = str & demRaster.ToMapX(col) & "; " & demRaster.ToMapY(row + 1) & "; " & h2 & vbCrLf
                str = str & demRaster.ToMapX(col - 1) & "; " & demRaster.ToMapY(row) & "; " & h3 & vbCrLf
                str = str & demRaster.ToMapX(col) & "; " & demRaster.ToMapY(row) & "; " & h4
                
                ' WSLUtils.log (str)
            Else
                ' Lower-right vertice
                h2 = demRaster.GetPixelValue(0, col, row)
                h1 = demRaster.GetPixelValue(0, col - 1, row)
                h3 = demRaster.GetPixelValue(0, col - 1, row - 1)
                h4 = demRaster.GetPixelValue(0, col, row - 1)
                x = (xPointCoord - demRaster.ToMapX(col - 1)) / (demRaster.ToMapX(col) - demRaster.ToMapX(col - 1))
                y = (yPointCoord - demRaster.ToMapY(row)) / (demRaster.ToMapY(row) - demRaster.ToMapY(row + 1))
                
                
                ' Linear interpolation on x-axis
                za = h1 + x * (h2 - h1)
                zb = h3 + x * (h4 - h3)
        
                ' Linear interpolation on y-axis
                z = za + y * (zb - za)
                
                str = xPointCoord & "; " & yPointCoord & "; " & z & "; " & x & "; " & y & vbCrLf
                str = str & demRaster.ToMapX(col - 1) & "; " & demRaster.ToMapY(row) & "; " & h1 & vbCrLf
                str = str & demRaster.ToMapX(col) & "; " & demRaster.ToMapY(row) & "; " & h2 & vbCrLf
                str = str & demRaster.ToMapX(col - 1) & "; " & demRaster.ToMapY(row - 1) & "; " & h3 & vbCrLf
                str = str & demRaster.ToMapX(col) & "; " & demRaster.ToMapY(row - 1) & "; " & h4
                
                'WSLUtils.log (str)
            End If
        Else
            ' Left vertice
            If (yPointCoord <= yTestCoord) Then
                ' Upper-left vertice
                h3 = demRaster.GetPixelValue(0, col, row)
                h1 = demRaster.GetPixelValue(0, col, row + 1)
                h2 = demRaster.GetPixelValue(0, col + 1, row + 1)
                h4 = demRaster.GetPixelValue(0, col + 1, row)
                x = (xPointCoord - demRaster.ToMapX(col)) / (demRaster.ToMapX(col) - demRaster.ToMapX(col - 1))
                y = (yPointCoord - demRaster.ToMapY(row + 1)) / (demRaster.ToMapY(row) - demRaster.ToMapY(row + 1))
                
                ' Linear interpolation on x-axis
                za = h1 + x * (h2 - h1)
                zb = h3 + x * (h4 - h3)
        
                ' Linear interpolation on y-axis
                z = za + y * (zb - za)
                
                str = xPointCoord & "; " & yPointCoord & "; " & z & "; " & x & "; " & y & vbCrLf
                str = str & demRaster.ToMapX(col) & "; " & demRaster.ToMapY(row + 1) & "; " & h1 & vbCrLf
                str = str & demRaster.ToMapX(col + 1) & "; " & demRaster.ToMapY(row + 1) & "; " & h2 & vbCrLf
                str = str & demRaster.ToMapX(col) & "; " & demRaster.ToMapY(row) & "; " & h3 & vbCrLf
                str = str & demRaster.ToMapX(col + 1) & "; " & demRaster.ToMapY(row) & "; " & h4
                
                'WSLUtils.log (str)
            Else
                ' Lower-left vertice
                h1 = demRaster.GetPixelValue(0, col, row)
                h2 = demRaster.GetPixelValue(0, col + 1, row)
                h3 = demRaster.GetPixelValue(0, col, row - 1)
                h4 = demRaster.GetPixelValue(0, col + 1, row - 1)
                x = (xPointCoord - demRaster.ToMapX(col)) / (demRaster.ToMapX(col) - demRaster.ToMapX(col - 1))
                y = (yPointCoord - demRaster.ToMapY(row)) / (demRaster.ToMapY(row) - demRaster.ToMapY(row + 1))
                
                ' Linear interpolation on x-axis
                za = h1 + x * (h2 - h1)
                zb = h3 + x * (h4 - h3)
        
                ' Linear interpolation on y-axis
                z = za + y * (zb - za)
                
                str = xPointCoord & "; " & yPointCoord & "; " & z & "; " & x & "; " & y & vbCrLf
                str = str & demRaster.ToMapX(col) & "; " & demRaster.ToMapY(row) & "; " & h1 & vbCrLf
                str = str & demRaster.ToMapX(col + 1) & "; " & demRaster.ToMapY(row) & "; " & h2 & vbCrLf
                str = str & demRaster.ToMapX(col) & "; " & demRaster.ToMapY(row - 1) & "; " & h3 & vbCrLf
                str = str & demRaster.ToMapX(col + 1) & "; " & demRaster.ToMapY(row - 1) & "; " & h4
                
                ' WSLUtils.log (str)
            End If
        End If
        
        ' Linear interpolation on x-axis
        ' za = h1 + x * (h2 - h1)
        ' zb = h3 + x * (h4 - h3)
        
        ' Linear interpolation on y-axis
        ' z = za + y * (zb - za)
    Else
        z = demRaster.GetPixelValue(0, demRaster.ToPixelColumn(xPointCoord), demRaster.ToPixelRow(yPointCoord))
    End If
    
    GetElevationByCoord = z
End Function

' Compute the length of the circle chord
Public Function GetChordLength(locationSegmentLength As Double) As Double
    GetChordLength = locationSegmentLength * Sin(2 * WSLUtils.PI() / frmProfiler.txtCirclePoints / 2)
End Function

' Compute the chord angle
Public Function GetChordAngle() As Double
    GetChordAngle = 360 / frmProfiler.txtCirclePoints
End Function

' Compute right angle in radians
Public Function GetRightAngleInRadians() As Double
    GetRightAngleInRadians = WSLUtils.DegreesToRadians(90)
End Function

' Compute radians for the given degrees
Public Function DegreesToRadians(degrees As Double) As Double
    ' DegreesToRadians = degrees * 0.0174532925
    DegreesToRadians = degrees * PI() / 180
End Function

Public Function RadiansToDegrees(radians As Double) As Double
    RadiansToDegrees = radians / PI() * 180
End Function

' Return pi
Public Function PI() As Double
    PI = 4 * Atn(1)
End Function

' Log function
Public Function log(str As String)
    Dim fn As Integer
    fn = FreeFile
    Open WSLConstants.LOG_FILE_NAME For Append As #fn
    Print #fn, str
    Close #fn
End Function

' Compute the direction of a segment, defined by two points
Public Function GetSegmentDirectionDegrees(location As WSLPoint, extremePoint1 As WSLPoint, locationSegmentLength As Double) As Double
    ' The method computes the angle between the vertical north and the (half) segment between the
    ' location (center of a circle) and the extreme point east of the location (which should always
    ' be extremePoint1 due to how we calculate the points that approximate the circle around the location, i.e. anti-clockwise)
    ' The xy coordinate of the location
    Dim x1, y1 As Double
    ' The xy coordinate of the extreme point
    Dim x2, y2 As Double
    ' The fraction used to compute the arcsin
    Dim x As Double
    
    x1 = location.xcoord
    y1 = location.ycoord
    
    x2 = extremePoint1.xcoord
    y2 = extremePoint1.ycoord
    
    ' x = (x2 - x1) / (locationSegmentLength / 2)

    If (x1 = x2) Then
        If (x1 > x2) Then
            degrees = 180
        Else
            degrees = 0
        End If
    Else
        a = (y2 - y1) / (x2 - x1)
        
        ' If (x = 1) Then
        ' degrees = 90
        If (a = 0) Then
            If (x2 > x1) Then
                degrees = 270
            Else
                degrees = 90
            End If
    
        Else
            ' This should calculate the arcsin in VB6 (there doesn't seem to be an implementation)
            ' degrees = WSLUtils.RadiansToDegrees(Atn(x / Sqr(-x * x + 1)))
            degrees = 90 - WSLUtils.RadiansToDegrees(Atn(a))
        
            ' If (y1 > y2) Then
            ' Extreme point is in second quadrant
            ' degrees = 180 - degrees
            ' End If
        End If
    End If
    
    ' GetSegmentDirectionDegrees = 180 + degrees
    GetSegmentDirectionDegrees = degrees
End Function

' Save profile data (xy-coordinates and absolute elevations) for each location
Public Function SaveProfileData(o() As WSLPoint, m As Integer, n As Integer, fileName As String)
    Dim str As String
    Dim fn As Integer
    Dim point As WSLPoint
    
    fn = FreeFile
    
    ' ##################### SAVE x,y AND elevation DATA OF EVERY SEGMENT POINT #####################
    Open fileName For Output As #fn
    
    ' Header, first column is the distance
    str = WSLConstants.HEADER_COL_LOCATION_ID & ";"
    str = str & WSLConstants.HEADER_COL_SEGMENT_POINT_ID & ";"
    str = str & WSLConstants.HEADER_COL_XCOORD_STRING & ";"
    str = str & WSLConstants.HEADER_COL_YCOORD_STRING & ";"
    str = str & WSLConstants.HEADER_COL_ELEVATION_STRING
    
    Print #fn, str
    
    str = ""
    
    For i = 0 To m - 1
        For j = 0 To n
            point = o(i, j)
            Print #fn, i & ";" & j & ";" & point.xcoord & ";" & point.ycoord & ";" & point.elevation
        Next j
    Next i
    
    Close #fn
End Function

' The method stores the direction information for every location in degrees
Public Function SaveDirectionData(o() As WSLPoint, m As Integer, n As Integer, fileName As String, locationSegmentLength As Double)
    Dim str As String
    Dim fn As Integer
    Dim location As WSLPoint
    Dim extremePoint1 As WSLPoint
    
    fn = FreeFile
    radius = locationSegmentLength / 2
    
    Open fileName For Output As #fn
    
    ' Header, first column is the distance
    str = WSLConstants.HEADER_COL_LOCATION_ID & ";"
    str = str & WSLConstants.HEADER_COL_DIRECTION_ANGLE
    
    Print #fn, str
    
    ' For every location i = 0 .. 73
    For i = 0 To m - 1
        location = o(i, (locationSegmentLength - 1) / 2)
        ' The segment is defined by the two extreme points and we want the coordinates of the first,
        ' i.e. the one east of the location between 0..499 in the circle
        extremePoint1 = o(i, 0)
        direction = WSLUtils.GetSegmentDirectionDegrees(location, extremePoint1, locationSegmentLength)
        
        Print #fn, i & ";" & direction
    Next i
    
    Close #fn
End Function

Public Function SaveDistanceData(o() As WSLPoint, m As Integer, n As Integer, fileName As String)
    Dim sum As Double
    Dim dist As Double
    Dim str As String
    Dim fn As Integer
    Dim median As WSLPoint
    Dim point As WSLPoint
    
    fn = FreeFile
        
    ' ##################### FOR EACH LOCATION SAVE DISTANCES #####################
    Open fileName For Output As #fn
        
    ' Header, first column is the distance
    str = WSLConstants.HEADER_COL_DISTANCE_STRING & ";"
    For i = 0 To m - 1
        str = str & "P" & i + 1 & ";"
    Next i
    
    Print #fn, str & WSLConstants.HEADER_COL_AVERAGE_STRING
    
    str = ""
    
    ' j = 0 .. 100
    For j = 0 To n
        sum = 0
        str = Math.Abs(n / 2 - j) & ";"
        ' i = 0 .. 73
        For i = 0 To m - 1
            ' The distance is the difference between this point and the location ( j = 50 )
            point = o(i, j)
            median = o(i, n / 2)
            
            dist = point.elevation - median.elevation
            sum = sum + dist
            str = str & dist & ";"
        Next i
        Print #fn, str & sum / m
    Next j
    
    Close #fn
End Function

' Random real numbers generator
Public Function random(lower As Double, upper As Double) As Double
    Dim ret As Double

    ret = upper + 0.1
    Do Until ret >= lower And ret <= upper
        ret = (upper - lower + 1) * Rnd + lower
    Loop
    random = ret
End Function
