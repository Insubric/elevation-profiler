Attribute VB_Name = "ElevationProfiler"
' Date: 24/06/2013
' ELEVATION PROFILER
' module "ElevationProfiler"
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
Public Sub Main()
  
  Dim pMxDoc As IMxDocument
  Set pMxDoc = ThisDocument
  Dim pMap As IMap
  Set pMap = pMxDoc.FocusMap
  
  If pMap.LayerCount = 0 Then
    MsgBox ("No layers in active data view.")
    Exit Sub
  End If
  
  Dim pEnumLayers As IEnumLayer
  Set pEnumLayers = pMap.Layers
  Dim pLayer As ILayer
  Dim pFLayer As IFeatureLayer2
  Dim pPoint As Integer
  
  pPoint = 0
  
  Set pLayer = pEnumLayers.Next
  Do Until pLayer Is Nothing
    If (Not TypeOf pLayer Is IGroupLayer) And (TypeOf pLayer Is IFeatureLayer2) Then
      
      Set pFLayer = pLayer
   '   Set pFLayer = toIFeatureayer2(pLayer)
      If pFLayer.ShapeType = esriGeometryPoint Then
        pPoint = 1
      End If
    End If
    Set pLayer = pEnumLayers.Next
  Loop
  
  If pPoint < 1 Then
    MsgBox ("Requires one point layer in the active data view.")
    Exit Sub
  End If
 
  Load frmProfiler
  frmProfiler.Show

End Sub
