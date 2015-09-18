VERSION 5.00
Begin {C62A69F0-16DC-11CE-9E98-00AA00574A4F} frmProfiler 
   Caption         =   "ELEVATION PROFILER"
   ClientHeight    =   9720
   ClientLeft      =   45
   ClientTop       =   330
   ClientWidth     =   3465
   OleObjectBlob   =   "frmProfiler.frx":0000
   ShowModal       =   0   'False
   StartUpPosition =   1  'CenterOwner
End
Attribute VB_Name = "frmProfiler"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False

' Date: 24/06/2013
' ELEVATION PROFILER
' form "frmProfiler" (i.e. the form interface of the Elevation Profiler)
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
Option Explicit

Private pMxDoc As IMxDocument
'Private pActiveView As IActiveView
Private pMap As IMap
Private pEnumLayers As IEnumLayer



Private Sub cmdRefresh_Click()
    ' refresh the comboxes and Ienumlayers, remembering the last selected layers
    updateCBOs
End Sub

Private Sub cmdCancel_Click()
  Unload frmProfiler
End Sub

Private Sub Label3_Click()

End Sub

Public Sub UserForm_Initialize()
    
  updateCBOs
  txtOUTPUT.Text = CurDir

End Sub

Public Sub updateCBOs()
  Dim pFLayer As IFeatureLayer2
  Dim pLayer As ILayer
  Dim z1, z2 As Integer
  
  Set pMxDoc = Application.Document
  Set pMap = pMxDoc.FocusMap
  
  '--- populate layer dropdowns ---
  
  Set pEnumLayers = pMap.Layers
  Set pLayer = pEnumLayers.Next
  z1 = 0
  z2 = 0
  cboINPUT.Clear
  
  Do Until pLayer Is Nothing
    If Not TypeOf pLayer Is IRasterLayer And Not TypeOf pLayer Is IGroupLayer Then
      Set pFLayer = pLayer
      If pFLayer.ShapeType = esriGeometryPoint Then
        cboINPUT.AddItem pLayer.Name, z1
        z1 = z1 + 1
      End If
    ElseIf TypeOf pLayer Is IRasterLayer Then
      cboDEM.AddItem pLayer.Name, z2
      z2 = z2 + 1
    End If
    Set pLayer = pEnumLayers.Next
  Loop
   
End Sub

Private Sub cmdSubmit_Click()
  Dim myMouse As IMouseCursor
 
  If cboINPUT.Value = "" Or cboDEM.Value = "" Or txtOUTPUT.Text = "" Then
    MsgBox ("Fill in all required parameters.")
    Exit Sub
  End If
  
  Process.Process
  
  MsgBox ("PROFILER processing complete.")

  pMxDoc.ActiveView.Refresh
  cmdRefresh_Click
End Sub

Private Sub CommandButton1_Click()
    Dim file As String
    Dim fileName As String
    Dim fileFolder As String
    Dim fileSplit() As String

    file = GetBrowseDirectory()
    If Len(file) = 0 Then Exit Sub
    
    txtOUTPUT.Text = file

End Sub
Public Function getOutputDir() As String
    
     If (Right(txtOUTPUT.Text, 1) = "\") Then
        getOutputDir = txtOUTPUT.Text
     Else
        getOutputDir = txtOUTPUT.Text & "\"
     End If
    
End Function


