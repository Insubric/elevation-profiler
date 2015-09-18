Imports System.Windows.Forms

''' <summary>
''' Designer class of the dockable window add-in. It contains user interfaces that
''' make up the dockable window.
''' </summary>
Public Class frmProfiler

    Public Sub New(ByVal hook As Object)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Hook = hook

        updateCBOs()
        cboSeparator.Items.AddRange(New String() {",", ";", "tab"})
        cboSeparator.SelectedIndex = 0

    End Sub


    Private m_hook As Object
    ''' <summary>
    ''' Host object of the dockable window
    ''' </summary> 
    Public Property Hook() As Object
        Get
            Return m_hook
        End Get
        Set(ByVal value As Object)
            m_hook = value
        End Set
    End Property

    ''' <summary>
    ''' Implementation class of the dockable window add-in. It is responsible for
    ''' creating and disposing the user interface class for the dockable window.
    ''' </summary>
    Public Class AddinImpl
        Inherits ESRI.ArcGIS.Desktop.AddIns.DockableWindow

        Private m_windowUI As frmProfiler

        Protected Overrides Function OnCreateChild() As System.IntPtr
            m_windowUI = New frmProfiler(Me.Hook)
            Return m_windowUI.Handle
        End Function

        Protected Overrides Sub Dispose(ByVal Param As Boolean)
            If m_windowUI IsNot Nothing Then
                m_windowUI.Dispose(Param)
            End If

            MyBase.Dispose(Param)
        End Sub

    End Class




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


    Private pMxDoc As IMxDocument
    'Private pActiveView As IActiveView
    Private pMap As IMap
    Private pEnumLayers As IEnumLayer


    Public Sub updateCBOs()
        Dim pFLayer As IFeatureLayer2
        Dim pLayer As ILayer
        Dim z1, z2 As Integer

        pMxDoc = CType(Me.Hook.Document, ESRI.ArcGIS.ArcMapUI.IMxDocument) ' Explicit Cast

        pMap = pMxDoc.FocusMap

        '--- populate layer dropdowns ---

        pEnumLayers = pMap.Layers
        pLayer = pEnumLayers.Next
        z1 = 0
        z2 = 0
        cboINPUT.Items.Clear()
        cboDEM.Items.Clear()

        Do Until pLayer Is Nothing
            If Not TypeOf pLayer Is IRasterLayer And Not TypeOf pLayer Is IGroupLayer Then
                pFLayer = pLayer
                If pFLayer.ShapeType = ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPoint Then
                    cboINPUT.Items.Insert(z1, pLayer.Name)
                    z1 = z1 + 1
                End If
            ElseIf TypeOf pLayer Is IRasterLayer Then
                cboDEM.Items.Insert(z2, pLayer.Name)
                z2 = z2 + 1
            End If
            pLayer = pEnumLayers.Next
        Loop

    End Sub

    Public Function getOutputDir() As String

        If (Strings.Right(txtOUTPUT.Text, 1) = "\") Then
            getOutputDir = txtOUTPUT.Text
        Else
            getOutputDir = txtOUTPUT.Text & "\"
        End If

    End Function

    Private Sub cmdRefresh_Click(sender As Object, e As EventArgs) Handles cmdRefresh.Click
        ' refresh the comboxes and Ienumlayers, remembering the last selected layers

        Dim selINPUT, selDEM As Object

        selINPUT = cboINPUT.SelectedItem
        selDEM = cboDEM.SelectedItem

        updateCBOs()

        If Not IsNothing(selINPUT) Then cboINPUT.SelectedItem = selINPUT
        If Not IsNothing(selDEM) Then cboDEM.SelectedItem = selDEM

    End Sub



    Private Sub cmdSubmit_Click(sender As Object, e As EventArgs) Handles cmdSubmit.Click

        Dim separator As String

        separator = cboSeparator.SelectedItem.ToString
        If separator = "tab" Then separator = vbTab


        'MsgBox("cboINPUT: " + cboINPUT.SelectedText + vbCrLf +
        '       "cboINPUT: " + cboINPUT.SelectedValue + vbCrLf +
        '       "cboINPUT: " + cboINPUT.SelectedItem.ToString + vbCrLf +
        '       "cboDEM: " + cboDEM.SelectedText + vbCrLf +
        '       "txtOUTPUT: " + txtOUTPUT.Text)

        If cboINPUT.SelectedItem.ToString = "" Or cboDEM.SelectedItem.ToString = "" Or txtOUTPUT.Text = "" Then
            MsgBox("Fill in all required parameters.")
            Exit Sub
        End If

        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        Process.Process(pMap, cboINPUT.SelectedItem.ToString, cboDEM.SelectedItem.ToString, CInt(txtMin.Text), CInt(txtMax.Text), CInt(txtInterval.Text), CInt(txtResolution.Text),
                        CInt(txtCirclePoints.Text), optTransversal.Checked, getOutputDir, separator)

        Me.Cursor = Windows.Forms.Cursors.Default

        MsgBox("PROFILER processing complete.")

        pMxDoc.ActiveView.Refresh()

        cmdRefresh_Click(sender, e)
    End Sub


    Private Sub cmdBrowse_Click(sender As Object, e As EventArgs) Handles cmdBrowse.Click
        Dim file As String
        '      Dim fileName As String
        '      Dim fileFolder As String
        '     Dim fileSplit() As String

        Dim dialog As New FolderBrowserDialog()
        dialog.RootFolder = Environment.SpecialFolder.Desktop
        dialog.SelectedPath = "C:\"
        dialog.Description = "Select Output folder Path"
        If dialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            file = dialog.SelectedPath
        Else
            Exit Sub
        End If

        txtOUTPUT.Text = file

    End Sub



End Class