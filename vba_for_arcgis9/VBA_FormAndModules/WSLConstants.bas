Attribute VB_Name = "WSLConstants"
' Date: 24/06/2013
' ELEVATION PROFILER
' module "WSLConstants"
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
' LOG file
Public Const LOG_FILE_NAME As String = "log.txt"

' Flag to tell the application to compute the profiles for random points (this might not always be required).
' If false, no profile data will be computed and returned as output for random points
' DEFAULT False
' ALTERNATIVE True
Public Const COMPUTE_RANDOM_POINTS As Boolean = False

' LOG LEVEL
' 0 = No logging
' 1 = Application output
' 2 = Verbose
Public Const LOG_LEVEL As Integer = 0

' The file contains the list of all segment points with xy and elevation data (easy to import in ArcGIS to visualize all points that define segments
Public Const SEGMENT_POINTS_DATA_FILE_NAME As String = "PointCoordinates" '.csv"

' Locations file, this file contains the distance differences of each segment point to the center (location) CSV formatted
Public Const LOCATION_DISTANCES_FILE_NAME As String = "ElevationProfiles" '.csv"

' The file contains the direction of the segments for each location in degrees
Public Const SEGMENT_DIRECTION_FILE_NAME As String = "ProfileDirections" '.csv"

' File with distances for random points
Public Const RANDOM_DISTANCES_FILE_NAME As String = "random_distances.csv"

Public Const HEADER_COL_LOCATION_ID As String = "LOCATION_ID"

Public Const HEADER_COL_SEGMENT_POINT_ID As String = "SEGMENT_POINT_ID"

Public Const HEADER_COL_DIRECTION_ANGLE As String = "DIRECTION_ANGLE"

Public Const HEADER_COL_DISTANCE_STRING As String = "Dist"

Public Const HEADER_COL_AVERAGE_STRING As String = "Avg"

Public Const HEADER_COL_XCOORD_STRING As String = "X"

Public Const HEADER_COL_YCOORD_STRING As String = "Y"

Public Const HEADER_COL_ELEVATION_STRING As String = "Z"

Public Const RND_XCOORD_LOWER As Double = 726200

Public Const RND_XCOORD_UPPER As Double = 728400

Public Const RND_YCOORD_LOWER As Double = 117600

Public Const RND_YCOORD_UPPER As Double = 118900

Public Const NUMBER_OF_RANDOM_POINTS As Integer = 100


