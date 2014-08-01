'Require SaveAsPDFandXPS y Office 2007
'
Imports Microsoft.VisualBasic
Imports System.Data
Imports MSWord = Microsoft.Office.Interop.Word
'Imports Microsoft.Office.Core
Imports System.IO
Imports System.Collections.Generic
''' <summary>
''' Clase para Cruzar Documentos en Word basados en Una plantilla''' 
''' </summary>
''' <remarks></remarks>
Public Class GDWord
#Region "Propiedades de Salida"
    Public ReadOnly Property Path_Plantilla() As String
        Get
            Return PathPlantilla
        End Get
    End Property
    Public ReadOnly Property Path_NuevoDocumento() As String
        Get
            Return PathNuevoDocumento
        End Get
    End Property
    Public ReadOnly Property Path_NuevoDocumentoPDF() As String
        Get
            Return PathNuevoDocumentoPDF
        End Get
    End Property
    Public ReadOnly Property Path_Correspondencia() As String
        Get
            Return PathCorrespondencia
        End Get
    End Property
    Public ReadOnly Property Documento_Pdf() As Byte()
        Get
            Return DocumentoPdf
        End Get
    End Property
    Public ReadOnly Property Documento_Word() As Byte()
        Get
            Return DocumentoWord
        End Get
    End Property
    Public ReadOnly Property Documento_Base() As Byte()
        Get
            Return DocumentoBase
        End Get
    End Property
#End Region
    Public lErrorG As Boolean = False
    Public Msg As String
    'Propiedades de Entrada
    Public ListaNomTablas As List(Of String)
    Public ListaTablas As List(Of DataTable)
    Public DocProtegido As Boolean
    Public ClavePlantilla As String
    Public IdPlantilla As String
    'Variables de la Clase
    Protected NomTabla As String
    Protected ColTabla As Integer = 0
    Protected Tagrupada As String = "N"
    Protected Tgrupo As String = ""
    Protected oMissing As [Object] = System.Reflection.Missing.Value
    Protected PathPlantilla As String
    Protected PathNuevoDocumento As String
    Protected PathNuevoDocumentoPDF As String
    Protected PathCorrespondencia As String
    Protected DocumentoPdf As Byte()
    Protected DocumentoWord As Byte()
    Protected DocumentoBase As Byte()
    Property pfm As IFmtoColumn

    Public Function CopiarDocumento(ByVal oPathPlantilla As String, ByVal oPathNuevoDocumento As String) As Boolean
        Dim ok As Boolean
        Try
            File.Copy(oPathPlantilla, oPathNuevoDocumento)
            ok = True
        Catch ex As Exception
            Msg = ex.Message
            ok = False
        End Try
        Return ok
    End Function

    Protected Function AbrirAplicacionWord() As MSWord.Application
        Dim oWord As MSWord.Application
        oWord = New MSWord.Application()
        Return oWord
    End Function

    Protected Sub CerrarAplicacionWord(ByRef oWord As MSWord.Application)
        Try
            oWord.Application.Quit()
            oWord = Nothing
        Catch ex As Exception

        End Try

    End Sub

    Protected Function AbrirDocumentoWord(ByRef oWord As MSWord.Application) As MSWord._Document
        Dim oDoc As MSWord._Document
        oMissing = System.Reflection.Missing.Value
        oDoc = oWord.Documents.Open(PathPlantilla, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing)
        Return oDoc
    End Function

    Protected Sub ProtegerDocumento(ByRef oDoc As MSWord._Document, ByVal proteger As Boolean)
        If DocProtegido Then
            If proteger Then
                oDoc.Protect(Type:=MSWord.WdProtectionType.wdAllowOnlyReading, Password:=ClavePlantilla)
            Else
                oDoc.Unprotect(ClavePlantilla)
            End If
        End If
    End Sub

    Protected Sub Remplazar(ByRef oWord As MSWord.Application, ByVal oBuscar As String)
        Dim replaceAll As Object = MSWord.WdReplace.wdReplaceAll
        oWord.Selection.Find.ClearFormatting()
        oWord.Selection.Find.Text = oBuscar
        oWord.Selection.Find.Replacement.ClearFormatting()
    End Sub

    Protected Overridable Sub CrearTabla(ByRef oWord As MSWord.Application, ByRef oDoc As MSWord._Document, ByVal dtValoresTabla As DataTable, ByVal MostrarHeader As Boolean, ByVal MostrarBorde As Boolean)
        Dim oTable As MSWord.Table
        Dim wrdRng As MSWord.Range = oWord.Selection.Range()
        Dim Cols As Integer
        Dim Fila As Integer = dtValoresTabla.Rows.Count
        Dim nuevaFila As Integer = 0
        Dim GrupoActual As String
        Dim f As Integer, c As Integer
        Dim dtFiltro As New DataTable

        'No. de Columnas que se Quieren mostrar de la tabla
        If ColTabla = 0 Then
            Cols = dtValoresTabla.Columns.Count
        Else
            Cols = ColTabla
        End If

        If MostrarHeader Then
            nuevaFila = 1
        End If

        If Tagrupada = "S" Then
            'para agregar tantas filas como grupos existan
            dtFiltro = dtValoresTabla.DefaultView.ToTable(True, Tgrupo)
        End If

        oTable = oDoc.Tables.Add(wrdRng, Fila + nuevaFila + (dtFiltro.Rows.Count * 2), Cols, oMissing, oMissing)


        'Dim dtConcepto As DataTable
        Dim dtConsulta As New DataTable

        'Dim oPlantilla As New PPlantillas
        'dtConsulta = oPlantilla.GetFormatoTabla(NomTabla, IdPlantilla)


        For c = 1 To Cols
            If MostrarHeader Then
                If pfm.tieneConf(NomTabla, dtValoresTabla.Columns(c - 1).ColumnName) Then
                    oTable.Cell(1, c).Range.Text = pfm.getDescripcion(NomTabla, dtValoresTabla.Columns(c - 1).ColumnName)
                Else
                    oTable.Cell(1, c).Range.Text = dtValoresTabla.Columns(c - 1).ColumnName
                End If

                oTable.Cell(1, c).Range.Font.Bold = True
                oTable.Cell(1, c).Range.Paragraphs.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphCenter
            End If
            'dtConcepto = oPlantilla.GetFormatoTabla(NomTabla, IdPlantilla, dtValoresTabla.Columns(c - 1).ColumnName)
            If pfm.tieneConf(NomTabla, dtValoresTabla.Columns(c - 1).ColumnName) Then
                Dim a As Integer = pfm.getAncho(NomTabla, dtValoresTabla.Columns(c - 1).ColumnName)
                oTable.Columns(c).SetWidth(a, MSWord.WdRulerStyle.wdAdjustNone)
                oTable.Columns(c).Cells.VerticalAlignment = MSWord.WdCellVerticalAlignment.wdCellAlignVerticalCenter
            End If
            'If dtConcepto.Rows.Count > 0 Then
            '    oTable.Columns(c).SetWidth(CInt(dtConcepto.Rows(0)("ANCHO").ToString), MSWord.WdRulerStyle.wdAdjustNone)
            '    oTable.Columns(c).Cells.VerticalAlignment = MSWord.WdCellVerticalAlignment.wdCellAlignVerticalCenter
            'End If
        Next
        'Llenar Tabla
        Dim tipoDato As String
        GrupoActual = ""
        For f = 0 To Fila - 1
            Dim encontrado As Boolean = False
            For c = 1 To Cols
                tipoDato = "C"
                'dtConcepto = oPlantilla.GetFormatoTabla(NomTabla, IdPlantilla, dtValoresTabla.Columns(c - 1).ColumnName)
                'If dtConsulta.Rows.Count > 0 And dtConcepto.Rows.Count > 0 Then
                'tipoDato = dtConcepto.Rows(0)("TIP_DAT").ToString
                'End If
                If pfm.tieneConf(NomTabla, dtValoresTabla.Columns(c - 1).ColumnName) Then
                    tipoDato = pfm.getAncho(NomTabla, dtValoresTabla.Columns(c - 1).ColumnName)
                End If
                Dim valor As String
                valor = dtValoresTabla.Rows(f)(c - 1).ToString
                valor = FormatearCampo(valor, tipoDato)
                If tipoDato = "M" Then
                    oTable.Cell(f + 1 + nuevaFila, c).Range.Paragraphs.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphRight
                End If
                If Tagrupada = "S" Then
                    If Not encontrado Then
                        If dtValoresTabla.Rows(f)(Tgrupo).ToString <> GrupoActual Then
                            encontrado = True
                            GrupoActual = dtValoresTabla.Rows(f)(Tgrupo).ToString
                            oTable.Cell(f + 1 + nuevaFila, c).Range.Text = ""
                            nuevaFila = nuevaFila + 1
                            oTable.Rows(f + 1 + nuevaFila).Select()
                            oTable.Cell(f + 1 + nuevaFila, c).Merge(oTable.Cell(f + 1 + nuevaFila, Cols))
                            oTable.Cell(f + 1 + nuevaFila, c).Range.Text = Tgrupo + ": " + GrupoActual
                            oTable.Cell(f + 1 + nuevaFila, c).Range.Font.Bold = True
                            nuevaFila = nuevaFila + 1
                        End If
                        oTable.Cell(f + 1 + nuevaFila, c).Range.Text = valor
                    Else
                        oTable.Cell(f + 1 + nuevaFila, c).Range.Text = valor
                    End If
                Else
                    oTable.Cell(f + 1 + nuevaFila, c).Range.Font.Bold = False
                    oTable.Cell(f + 1 + nuevaFila, c).Range.Text = valor
                End If
            Next
        Next
        oTable.Borders.Enable = MostrarBorde
    End Sub


    Protected Sub CrearTablaV(ByRef oWord As MSWord.Application, ByRef oDoc As MSWord._Document, ByVal dtValoresTabla As DataTable, ByVal MostrarHeader As Boolean, ByVal MostrarBorde As Boolean)

        'Dim wrdRng As MSWord.Range = oWord.Selection.Range()
        'Dim Cols As Integer
        'Dim Fila As Integer = dtValoresTabla.Rows.Count
        'Dim nuevaFila As Integer = 0
        'Dim GrupoActual As String
        'Dim f As Integer, c As Integer
        'Dim dtFiltro As New DataTable

        ''No. de Columnas que se Quieren mostrar de la tabla
        'If ColTabla = 0 Then
        '    Cols = dtValoresTabla.Columns.Count
        'Else
        '    Cols = ColTabla
        'End If

        'If MostrarHeader Then
        '    nuevaFila = 1
        'End If

        'If Tagrupada = "S" Then
        '    'para agregar tantas filas como grupos existan
        '    dtFiltro = dtValoresTabla.DefaultView.ToTable(True, Tgrupo)
        'End If
        'Dim oTable As MSWord.Table
        ''Fila + nuevaFila + (dtFiltro.Rows.Count * 2)
        'oTable = oDoc.Tables.Add(wrdRng, (Cols) * Fila - 1, 2, oMissing, oMissing)
        'Dim iReg As Integer = 0
        'For f = 0 To Fila - 1

        '    Dim oPlantilla As New PPlantillas
        '    Dim dtConcepto As DataTable
        '    Dim dtConsulta As New DataTable
        '    dtConsulta = oPlantilla.GetFormatoTabla(NomTabla, IdPlantilla)

        '    'Llenar Tabla
        '    Dim tipoDato As String
        '    'Cargar Formato de Tabla

        '    dtConcepto = oPlantilla.GetFormatoTabla(NomTabla, IdPlantilla, "COLUMN1")
        '    oTable.Columns(1).SetWidth(CInt(dtConcepto.Rows(0)("ANCHO").ToString), MSWord.WdRulerStyle.wdAdjustNone)
        '    dtConcepto = oPlantilla.GetFormatoTabla(NomTabla, IdPlantilla, "COLUMN2")
        '    oTable.Columns(2).SetWidth(CInt(dtConcepto.Rows(0)("ANCHO").ToString), MSWord.WdRulerStyle.wdAdjustNone)

        '    'Ancho de Columna  
        '    'oTable.Columns(1).SetWidth(120, MSWord.WdRulerStyle.wdAdjustNone)
        '    Dim encontrado As Boolean = False
        '    GrupoActual = ""
        '    For c = 1 To Cols - 1
        '        tipoDato = "C"
        '        dtConcepto = oPlantilla.GetFormatoTabla(NomTabla, IdPlantilla, dtValoresTabla.Columns(c - 1).ColumnName)
        '        If dtConsulta.Rows.Count > 0 And dtConcepto.Rows.Count > 0 Then
        '            tipoDato = dtConcepto.Rows(0)("TIP_DAT").ToString
        '        End If
        '        Dim valor As String
        '        valor = dtValoresTabla.Rows(f)(c - 1).ToString
        '        'valor = FormatearCampo(valor, tipoDato)
        '        If tipoDato = "M" Then
        '            oTable.Cell(iReg + 1, 2).Range.Paragraphs.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphRight
        '        End If
        '        oTable.Cell(iReg + 1, 1).Range.Font.Bold = True
        '        oTable.Cell(iReg + 1, 2).Range.Font.Bold = False
        '        oTable.Cell(iReg + 1, 1).Range.Text = dtValoresTabla.Columns(c - 1).ColumnName.ToUpper
        '        oTable.Cell(iReg + 1, 2).Range.Text = valor
        '        iReg += 1
        '        'End If
        '    Next
        '    iReg += 1
        'Next
        'oTable.Borders.Enable = MostrarBorde
    End Sub

    Public Sub EliminarTemporales()
        Try
            If Not String.IsNullOrEmpty(PathCorrespondencia) Then
                File.Delete(PathCorrespondencia)
            End If
            If Not String.IsNullOrEmpty(PathNuevoDocumento) Then
                File.Delete(PathNuevoDocumento)
            End If
            If Not String.IsNullOrEmpty(PathPlantilla) Then
                File.Delete(PathPlantilla)
            End If
        Catch ex As Exception
            lErrorG = True
            Msg = ex.Message
        End Try

    End Sub

    Protected Function CreaPlantillaTemporal(ByVal DocByte As [Byte]()) As String

        PathPlantilla = Path.ChangeExtension(Path.GetTempFileName(), ".doc")
        PathNuevoDocumento = Path.ChangeExtension(Path.GetTempFileName(), ".doc")
        PathNuevoDocumentoPDF = Path.ChangeExtension(Path.GetTempFileName(), ".pdf")
        Dim oFileStream As FileStream = Nothing
        If File.Exists(PathPlantilla) Then
            File.Delete(PathPlantilla)
        End If
        oFileStream = New FileStream(PathPlantilla, FileMode.Create)
        oFileStream.Write(DocByte, 0, DocByte.Length)
        oFileStream.Close()
        oFileStream = Nothing
        Return PathPlantilla
    End Function

    Public Function GenerarDocumento(ByVal PlantillaByte As [Byte](), ByVal dtConfiguracion As DataTable, ByVal dtDatosImprimir As DataTable) As Byte()
        CreaPlantillaTemporal(PlantillaByte)
        Dim b() As Byte = {}
        Dim oWrdApp As MSWord.Application = Nothing
        Dim oWrdDoc As MSWord._Document
        Dim iniciada As Boolean
        iniciada = False
        
        Dim imgLogo As String = ""
        Try
            oWrdApp = AbrirAplicacionWord()
            oWrdApp.Visible = False
            iniciada = True
            oWrdDoc = AbrirDocumentoWord(oWrdApp)
            ProtegerDocumento(oWrdDoc, False)

            Dim NFilas As Integer = 1, NColumnas As Integer = 2
            Dim Nom_Pla As String
            Dim Nom_Campo As String
            Dim Tip_Dato As String
            Dim Genera_Tabla As String
            Dim Nom_Mark As String
            Dim j As Integer = 1

            ''PIE Y ENCABEZADO DE DOCUMENTO
            '' CONTROL DE ENCABEZADO
            Dim logoCustom As MSWord.InlineShape = Nothing
            Dim vista As New List(Of MSWord.WdSeekView)
            vista.Add(MSWord.WdSeekView.wdSeekCurrentPageFooter)
            vista.Add(MSWord.WdSeekView.wdSeekCurrentPageHeader)
            For Each s In vista
                oWrdApp.ActiveWindow.ActivePane.View.SeekView = s 'MSWord.WdSeekView.wdSeekCurrentPageHeader
                Dim inicio As String = IIf(s = MSWord.WdSeekView.wdSeekCurrentPageFooter, "P_", "E_")
                For k As Integer = 0 To dtConfiguracion.Rows.Count - 1
                    Nom_Pla = dtConfiguracion.Rows(k)("Nom_Pla").ToString.Trim
                    Nom_Campo = dtConfiguracion.Rows(k)("Nom_Cam").ToString
                    Tip_Dato = dtConfiguracion.Rows(k)("Tip_Dat").ToString
                    Genera_Tabla = dtConfiguracion.Rows(k)("GTabla").ToString
                    j = 1
                    Nom_Mark = inicio + Nom_Pla + "_" + j.ToString.Trim
                    Do While oWrdDoc.Bookmarks.Exists(Nom_Mark)
                        oWrdDoc.Bookmarks.Item(Nom_Mark).Range.Text = (dtDatosImprimir.Rows(0)(Nom_Campo).ToString)
                        j = j + 1
                        Nom_Mark = inicio + Nom_Pla + "_" + j.ToString.Trim
                    Loop
                Next
                'BUSCAR LOGO
                j = 1
                Nom_Mark = inicio + "LOGO_" + j.ToString.Trim
                Do While oWrdDoc.Bookmarks.Exists(Nom_Mark)
                    logoCustom = oWrdDoc.Bookmarks.Item(Nom_Mark).Range.InlineShapes.AddPicture(imgLogo)
                    logoCustom.Width = 50
                    logoCustom.Height = 50
                    j = j + 1
                    Nom_Mark = inicio + "LOGO_" + j.ToString.Trim
                Loop
            Next

            oWrdApp.ActiveWindow.ActivePane.View.SeekView = MSWord.WdSeekView.wdSeekMainDocument
            '' CONTROL DE CONTENIDO
            For i As Integer = 0 To dtConfiguracion.Rows.Count - 1
                Dim Es_Marcador As String
                Msg = Msg + " i= " & i.ToString & " " & dtConfiguracion.Rows(i)("NOM_CAM").ToString
                Tip_Dato = dtConfiguracion.Rows(i)("TIP_DAT").ToString
                Es_Marcador = dtConfiguracion.Rows(i)("MARCADOR").ToString

                If dtConfiguracion.Rows(i)("NOM_CAM").ToString = "VSS" Then
                    Dim aqui As Integer = 1
                End If
                Select Case Es_Marcador
                    Case "NO"
                        Select Case Tip_Dato
                            Case "T"
                                EsTabla(oWrdApp, oWrdDoc, dtConfiguracion, i)
                            Case "TV"
                                EsTablaV(oWrdApp, oWrdDoc, dtConfiguracion, i)
                            Case "I"
                                EsImagen(oWrdApp, oWrdDoc, dtDatosImprimir, dtConfiguracion, i)
                            Case Else
                                EsOtroCaso(oWrdApp, oWrdDoc, dtDatosImprimir, dtConfiguracion, i)
                        End Select
                    Case "SI"
                        Select Case Tip_Dato
                            Case "I"
                                EsMarcadorImagen(oWrdDoc, dtDatosImprimir, dtConfiguracion, i)
                            Case Else
                                EsMarcadorOtroCaso(oWrdDoc, dtDatosImprimir, dtConfiguracion, i)
                        End Select
                End Select
            Next


            ProtegerDocumento(oWrdDoc, True)
            oWrdDoc.SaveAs(PathNuevoDocumento)
            oWrdDoc.SaveAs(PathNuevoDocumentoPDF, MSWord.WdExportFormat.wdExportFormatPDF)
            oWrdDoc.Saved = True
            oWrdDoc.Close(False)
            oWrdDoc = Nothing
            CerrarAplicacionWord(oWrdApp)
            b = GetNuevoDocumento(PathNuevoDocumento)
            DocumentoWord = b
            DocumentoPdf = GetNuevoDocumento(PathNuevoDocumentoPDF)
            EliminarTemporales()
            lErrorG = False

        Catch ex As Exception
            lErrorG = True
            Msg = ex.Message ' + "<br/>" + ex.StackTrace + ex.Source + "</br>"
            If iniciada Then
                CerrarAplicacionWord(oWrdApp)
            End If
        End Try
        Return b
    End Function

    Public Function CombinarCorrespondencia(ByVal PlantillaByte As [Byte](), ByVal dtConfiguracion As DataTable, ByVal dtDatosImprimir As DataTable) As Byte()
        Dim b() As Byte = {}
        Dim oWrdApp As MSWord.Application = Nothing
        Dim oWrdDoc As MSWord._Document
        Dim iniciada As Boolean
        Dim wrdSelection As MSWord.Selection
        Dim wrdMailMerge As MSWord.MailMerge
        Dim wrdMergeFields As MSWord.MailMergeFields

        iniciada = False
        Try
            oWrdApp = AbrirAplicacionWord()
            oWrdApp.Visible = True
            iniciada = True
            CreaPlantillaTemporal(PlantillaByte)
            oWrdDoc = AbrirDocumentoWord(oWrdApp)
            ProtegerDocumento(oWrdDoc, False)
            oWrdDoc.Select()
            wrdSelection = oWrdApp.Selection
            wrdMailMerge = oWrdDoc.MailMerge
            PathCorrespondencia = CrearBDCorrespondencia(oWrdDoc, oWrdApp, dtConfiguracion, dtDatosImprimir)

            wrdMergeFields = wrdMailMerge.Fields()
            'Llenar los Campos para la combinacion 
            For k As Integer = 0 To dtConfiguracion.Rows.Count - 1
                If dtConfiguracion.Rows(k)("TIP_DAT").ToString <> "I" Then
                    Dim replaceAll As Object = MSWord.WdReplace.wdReplaceAll
                    Dim wdFindStop As Object = MSWord.WdFindWrap.wdFindStop

                    oWrdApp.Selection.Find.ClearFormatting()
                    oWrdApp.Selection.Find.Text = "{" + dtConfiguracion.Rows(k)("NOM_PLA").ToString + "}"
                    oWrdApp.Selection.Find.Replacement.ClearFormatting()
                    oWrdApp.Selection.Find.Wrap = wdFindStop
                    oWrdApp.Selection.Find.Forward = True ' Hacia Adelante

                    Dim tip_find As Integer = 1
                    Dim no_encontrado As Integer = 0
                    'Primero busca hacia adelante
                    Do While no_encontrado < 3
                        oWrdApp.Selection.Find.Execute()
                        If oWrdApp.Selection.Find.Found() Then

                            Dim wrdRng As MSWord.Range = oWrdApp.Selection.Range()
                            wrdMergeFields.Add(wrdRng, dtConfiguracion.Rows(k)("NOM_PLA").ToString)
                        Else
                            oWrdApp.Selection.Find.Forward = Not oWrdApp.Selection.Find.Forward
                            no_encontrado = no_encontrado + 1
                        End If
                        tip_find += 1
                    Loop
                End If
            Next
            wrdMailMerge.Destination = MSWord.WdMailMergeDestination.wdSendToNewDocument
            wrdMailMerge.Execute(False)
            For k As Integer = 0 To dtConfiguracion.Rows.Count - 1
                If dtConfiguracion.Rows(k)("TIP_DAT").ToString = "I" Then
                    EsImagen(oWrdApp, oWrdDoc, dtDatosImprimir, dtConfiguracion, k)
                End If
            Next
            ProtegerDocumento(oWrdDoc, True)
            oWrdDoc.Saved = True
            oWrdDoc.Close(False)
            oWrdApp.ActiveDocument.SaveAs(PathNuevoDocumento)
            oWrdApp.ActiveDocument.SaveAs(PathNuevoDocumentoPDF, MSWord.WdExportFormat.wdExportFormatPDF)
            oWrdApp.ActiveDocument.Saved = True
            oWrdApp.ActiveDocument.Close()
            wrdSelection = Nothing
            wrdMailMerge = Nothing
            wrdMergeFields = Nothing
            oWrdDoc = Nothing
            CerrarAplicacionWord(oWrdApp)
            b = GetNuevoDocumento(PathNuevoDocumento)
            DocumentoWord = b
            DocumentoPdf = GetNuevoDocumento(PathNuevoDocumentoPDF)
            Return b
        Catch ex As Exception
            lErrorG = True
            Msg = ex.Message
            If iniciada Then
                CerrarAplicacionWord(oWrdApp)
            End If
        End Try
        Return b
    End Function

    Public Function GetNuevoDocumento(ByVal Path As String) As Byte()
        Dim b() As Byte = {}
        Try
            Dim oFileStream As FileStream = New FileStream(Path, FileMode.Open)
            Dim bR As New BinaryReader(oFileStream)
            b = bR.ReadBytes(oFileStream.Length)
            oFileStream.Close()
            oFileStream = Nothing
        Catch ex As Exception
            Msg = ex.Message
        End Try
        Return b
    End Function

    Protected Function CrearBDCorrespondencia(ByRef oWrdDoc As MSWord._Document, ByRef oWrdApp As MSWord.Application, ByVal dtConfiguracion As DataTable, ByVal dtDatosImprimir As DataTable) As String

        Dim k As Integer
        Dim Campos As String
        Dim PathTemporal, msg As String
        Dim oWrdBD As MSWord._Document
        Dim numCol As Integer
        numCol = 0
        Campos = ""
        PathTemporal = ""
        Try
            For k = 0 To dtConfiguracion.Rows.Count - 1
                If dtConfiguracion.Rows(k)("TIP_DAT").ToString <> "I" Then
                    If String.IsNullOrEmpty(Campos) Then
                        Campos = dtConfiguracion.Rows(k)("NOM_PLA").ToString
                    Else
                        Campos = Campos + ", " + dtConfiguracion.Rows(k)("NOM_PLA").ToString
                    End If
                End If
            Next
            PathTemporal = Path.ChangeExtension(Path.GetTempFileName(), ".doc")
            oWrdDoc.MailMerge.CreateDataSource(Name:=PathTemporal, HeaderRecord:=Campos)
            oWrdBD = oWrdApp.Documents.Open(PathTemporal)

            'Se llenan los datos a Combinar
            Dim fila As Integer = 2
            For k = 0 To dtDatosImprimir.Rows.Count - 1

                Dim Lista As New List(Of String)
                For i As Integer = 0 To dtConfiguracion.Rows.Count - 1
                    If dtConfiguracion.Rows(i)("TIP_DAT").ToString <> "I" Then
                        Lista.Add(FormatearCampo(dtDatosImprimir.Rows(k)(dtConfiguracion.Rows(i)("NOM_CAM").ToString).ToString, dtConfiguracion.Rows(i)("TIP_DAT").ToString))
                    End If
                Next
                oWrdBD.Tables.Item(1).Rows.Add()
                FillRow(oWrdBD, fila, Lista)
                fila = fila + 1
            Next
            oWrdBD.Tables.Item(1).Rows(fila).Delete()
            oWrdBD.Save()
            oWrdBD.Close(False)
        Catch ex As Exception
            msg = ex.Message
        End Try
        Return PathTemporal
    End Function

    Protected Sub FillRow(ByVal Doc As MSWord._Document, ByVal Row As Integer, ByVal Lista As List(Of String))
        ' Inserta el dato en una Celda Especifica.
        For i As Integer = 0 To Lista.Count - 1
            Doc.Tables.Item(1).Cell(Row, i + 1).Range.InsertAfter(Lista(i))
        Next
    End Sub
    Protected Sub EsTabla(ByRef oWrdApp As MSWord.Application, ByRef oWrdDoc As MSWord._Document, ByRef dtConfiguracion As DataTable, ByVal posicion As Integer)
        Dim i As Integer
        i = posicion

        Dim nom_Pla As String = dtConfiguracion.Rows(i)("NOM_PLA").ToString.Trim
        Dim Nom_Campo As String = dtConfiguracion.Rows(i)("NOM_CAM").ToString
        Dim Tip_Dato As String = dtConfiguracion.Rows(i)("TIP_DAT").ToString
        Dim Genera_Tabla As String = dtConfiguracion.Rows(i)("GTABLA").ToString
        Dim Es_Marcador As String = dtConfiguracion.Rows(i)("MARCADOR").ToString

        If Genera_Tabla = "S" Then
            Dim wdFindStop As Object = MSWord.WdFindWrap.wdFindStop
            oWrdApp.Selection.Find.ClearFormatting()
            oWrdApp.Selection.Find.Text = "{" + nom_Pla + "}"
            oWrdApp.Selection.Find.Wrap = wdFindStop
            oWrdApp.Selection.Find.Forward = True
            Dim tip_find As Integer = 1
            Dim no_encontrado As Integer = 0
            'Primero busca hacia adelante
            Do While no_encontrado < 3
                oWrdApp.Selection.Find.Execute()
                If oWrdApp.Selection.Find.Found() Then
                    Dim Tabla As String = dtConfiguracion.Rows(i)("NTabla").ToString
                    'Buscar La posicion de La tabla en la lista de Tabla
                    Dim indice As Integer
                    indice = -1
                    NomTabla = ""
                    ColTabla = 0
                    For k As Integer = 0 To ListaNomTablas.Count - 1
                        If ListaNomTablas.Item(k).ToString = Tabla Then
                            NomTabla = Tabla
                            ColTabla = dtConfiguracion.Rows(i)("COL_FINAL").ToString
                            Tagrupada = dtConfiguracion.Rows(i)("TAGRUPADA").ToString
                            Tgrupo = dtConfiguracion.Rows(i)("COLS_GRUPO").ToString
                            indice = k
                            Exit For
                        End If
                    Next
                    If indice >= 0 Then
                        ' Aqui llenear la Tabla
                        Dim dtt As DataTable = New DataTable()
                        dtt = ListaTablas.Item(indice)
                        CrearTabla(oWrdApp, oWrdDoc, dtt, IIf(dtConfiguracion.Rows(i)("Mostrar_Titulos").ToString = "SI", True, False), IIf(dtConfiguracion.Rows(i)("Mostrar_Borde").ToString = "SI", True, False))
                    End If

                Else
                    oWrdApp.Selection.Find.Forward = Not oWrdApp.Selection.Find.Forward
                    no_encontrado = no_encontrado + 1
                End If
                tip_find += 1
            Loop
            oWrdApp.Selection.MoveDown()
            oWrdApp.ActiveDocument.Select()
            oWrdApp.Selection.MoveDown()
        End If

    End Sub

    Protected Sub EsTablaV(ByRef oWrdApp As MSWord.Application, ByRef oWrdDoc As MSWord._Document, ByRef dtConfiguracion As DataTable, ByVal posicion As Integer)
        Dim i As Integer
        i = posicion

        Dim nom_Pla As String = dtConfiguracion.Rows(i)("NOM_PLA").ToString.Trim
        Dim Nom_Campo As String = dtConfiguracion.Rows(i)("NOM_CAM").ToString
        Dim Tip_Dato As String = dtConfiguracion.Rows(i)("TIP_DAT").ToString
        Dim Genera_Tabla As String = dtConfiguracion.Rows(i)("GTABLA").ToString
        Dim Es_Marcador As String = dtConfiguracion.Rows(i)("MARCADOR").ToString

        If Genera_Tabla = "S" Then
            Dim wdFindStop As Object = MSWord.WdFindWrap.wdFindStop
            oWrdApp.Selection.Find.ClearFormatting()
            oWrdApp.Selection.Find.Text = "{" + nom_Pla + "}"
            oWrdApp.Selection.Find.Wrap = wdFindStop
            oWrdApp.Selection.Find.Forward = True
            Dim tip_find As Integer = 1
            Dim no_encontrado As Integer = 0
            'Primero busca hacia adelante
            Do While no_encontrado < 3
                oWrdApp.Selection.Find.Execute()
                If oWrdApp.Selection.Find.Found() Then
                    Dim Tabla As String = dtConfiguracion.Rows(i)("NTabla").ToString
                    'Buscar La posicion de La tabla en la lista de Tabla
                    Dim indice As Integer
                    indice = -1
                    NomTabla = ""
                    ColTabla = 0

                    For k As Integer = 0 To ListaNomTablas.Count - 1
                        If ListaNomTablas.Item(k).ToString = Tabla Then
                            NomTabla = Tabla
                            ColTabla = dtConfiguracion.Rows(i)("COL_FINAL").ToString
                            Tagrupada = dtConfiguracion.Rows(i)("TAGRUPADA").ToString
                            Tgrupo = dtConfiguracion.Rows(i)("COLS_GRUPO").ToString
                            indice = k
                            Exit For
                        End If
                    Next
                    If indice >= 0 Then
                        ' Aqui llenear la Tabla
                        Dim dtt As DataTable = New DataTable()
                        dtt = ListaTablas.Item(indice)
                        CrearTablaV(oWrdApp, oWrdDoc, dtt, IIf(dtConfiguracion.Rows(i)("Mostrar_Titulos").ToString = "SI", True, False), IIf(dtConfiguracion.Rows(i)("Mostrar_Borde").ToString = "SI", True, False))
                    End If

                Else
                    oWrdApp.Selection.Find.Forward = Not oWrdApp.Selection.Find.Forward
                    no_encontrado = no_encontrado + 1
                End If
                tip_find += 1
            Loop
            oWrdApp.Selection.MoveDown()
            oWrdApp.ActiveDocument.Select()
            oWrdApp.Selection.MoveDown()
        End If

    End Sub

    Protected Sub EsImagen(ByRef oWrdApp As MSWord.Application, ByRef oWrdDoc As MSWord._Document, ByRef dtDatosImprimir As DataTable, ByRef dtConfiguracion As DataTable, ByVal posicion As Integer)
        Dim i As Integer = posicion
        Dim nom_Pla As String = dtConfiguracion.Rows(i)("NOM_PLA").ToString.Trim
        Dim Nom_Campo As String = dtConfiguracion.Rows(i)("NOM_CAM").ToString
        Dim RutaImagen As String
        Dim logoCustom As MSWord.InlineShape = Nothing
        Try
            RutaImagen = Util.Byte2ImagePath(DirectCast(dtDatosImprimir.Rows(0)(Nom_Campo), Byte()))
        Catch ex As Exception
            Msg = "No se encontro la imagen para: " + Nom_Campo
            lErrorG = True
            Return
        End Try

        Dim wdFindStop As Object = MSWord.WdFindWrap.wdFindStop
        oWrdApp.Selection.Find.ClearFormatting()
        oWrdApp.Selection.Find.Text = "{" + nom_Pla + "}"
        oWrdApp.Selection.Find.Wrap = wdFindStop
        oWrdApp.Selection.Find.Forward = True
        Dim tip_find As Integer = 1
        Dim no_encontrado As Integer = 0
        'Primero busca hacia adelante
        Do While no_encontrado < 3
            oWrdApp.Selection.Find.Execute()
            If oWrdApp.Selection.Find.Found() Then
                oWrdApp.Selection.Range.Text = ""
                logoCustom = oWrdApp.Selection.Range.InlineShapes.AddPicture(RutaImagen)
            Else
                oWrdApp.Selection.Find.Forward = Not oWrdApp.Selection.Find.Forward
                no_encontrado = no_encontrado + 1
                tip_find += 1
            End If
        Loop

    End Sub

    Protected Sub EsOtroCaso(ByRef oWrdApp As MSWord.Application, ByRef oWrdDoc As MSWord._Document, ByRef dtDatosImprimir As DataTable, ByRef dtConfiguracion As DataTable, ByVal posicion As Integer)
        Dim i As Integer = posicion



        Dim nom_Pla As String = dtConfiguracion.Rows(i)("NOM_PLA").ToString.Trim.ToUpper()
        Dim Nom_Campo As String = dtConfiguracion.Rows(i)("NOM_CAM").ToString
        Dim Tip_Dato As String = dtConfiguracion.Rows(i)("TIP_DAT").ToString

        If (dtDatosImprimir.Columns.Contains(Nom_Campo)) Then
            Remplazar(oWrdApp, "{" + nom_Pla + "}")
            Dim strRemp As String = FormatearCampo(dtDatosImprimir.Rows(0)(Nom_Campo).ToString, Tip_Dato)
            If strRemp.Length <= 255 Then
                Dim replaceAll As Object = MSWord.WdReplace.wdReplaceAll
                oWrdApp.Selection.Find.Replacement.Text = strRemp
                oWrdApp.Selection.Find.Execute(Replace:=replaceAll)
            End If
        End If
    End Sub

    Protected Sub EsMarcadorImagen(ByRef oWrdDoc As MSWord._Document, ByRef dtDatosImprimir As DataTable, ByRef dtConfiguracion As DataTable, ByVal posicion As Integer)
        Dim j As Integer = 1
        Dim Nom_Mark As String
        Dim i As Integer = posicion
        Dim nom_Pla As String = dtConfiguracion.Rows(i)("NOM_PLA").ToString.Trim
        Dim Nom_Campo As String = dtConfiguracion.Rows(i)("NOM_CAM").ToString
        Dim logoCustom As MSWord.InlineShape = Nothing
        Dim RutaImagen As String
        RutaImagen = Util.Byte2ImagePath(DirectCast(dtDatosImprimir.Rows(0)(Nom_Campo), Byte()))
        Nom_Mark = "E_LOGO_" + j.ToString.Trim
        Do While oWrdDoc.Bookmarks.Exists(Nom_Mark)
            logoCustom = oWrdDoc.Bookmarks.Item(Nom_Mark).Range.InlineShapes.AddPicture(RutaImagen)
            logoCustom.Width = 50
            logoCustom.Height = 50
            j = j + 1
            Nom_Mark = "E_LOGO_" + j.ToString.Trim
        Loop
    End Sub

    Protected Sub EsMarcadorOtroCaso(ByRef oWrdDoc As MSWord._Document, ByRef dtDatosImprimir As DataTable, ByRef dtConfiguracion As DataTable, ByVal posicion As Integer)
        Dim i As Integer = posicion
        Dim nom_Pla As String = dtConfiguracion.Rows(i)("NOM_PLA").ToString.Trim
        Dim Nom_Campo As String = dtConfiguracion.Rows(i)("NOM_CAM").ToString

        If oWrdDoc.Bookmarks.Exists(nom_Pla) Then
            oWrdDoc.Bookmarks.Item(nom_Pla).Range.Text = dtDatosImprimir.Rows(0)(Nom_Campo).ToString
        End If
        Dim j As Integer = 1
        Dim Nom_Mark As String = nom_Pla + "_" + j.ToString.Trim
        Do While oWrdDoc.Bookmarks.Exists(Nom_Mark)
            oWrdDoc.Bookmarks.Item(Nom_Mark).Range.Text = dtDatosImprimir.Rows(0)(Nom_Campo).ToString
            j = j + 1
            Nom_Mark = nom_Pla + "_" + j.ToString.Trim
        Loop
    End Sub

    Protected Function FormatearCampo(ByVal Valor As String, ByVal Tipo As String) As String
        Dim Ret As String = Valor
        Msg = Msg + " formateando "
        If Not String.IsNullOrEmpty(Valor) Then
            Select Case Tipo
                Case "M"
                    Ret = FormatCurrency(Valor)
                Case "N"
                    Ret = FormatNumber(Valor)
                Case "n"
                    Ret = FormatNumber(Valor, 0)
                Case "C"
                    Ret = Trim(Valor)
                Case "D"
                    Dim fecha As Date
                    fecha = CDate(Valor)
                    Ret = Str(Day(fecha)).PadLeft(2, "0") + " DE " + UCase(MonthName(Month(fecha))) + " DE " + Year(fecha).ToString
                Case "DL"
                    Dim fecha As Date
                    fecha = CDate(Valor)
                    Ret = Str(Day(fecha)).PadLeft(2, "0") + " días del mes de " + UCase(MonthName(Month(fecha))) + " de " + Year(fecha).ToString
                Case "d"
                    Dim fecha As Date
                    fecha = CDate(Valor)
                    Ret = Str(Day(fecha)).PadLeft(2, "0") + " de " + (MonthName(Month(fecha))).ToLower + " de " + Year(fecha).ToString
                Case "dl"
                    Dim fecha As Date
                    fecha = CDate(Valor)
                    Ret = Str(Day(fecha)).PadLeft(2, "0") + " dias del mes de " + LCase(MonthName(Month(fecha))) + " de " + Year(fecha).ToString
                Case "dc"
                    Dim fecha As Date
                    fecha = CDate(Valor)
                    Ret = Str(Day(fecha)).PadLeft(2, "0") + " - " + LCase(MonthName(Month(fecha))).Substring(0, 3) + " - " + Year(fecha).ToString
                Case "dn"
                    Dim fecha As Date
                    fecha = CDate(Valor)
                    Ret = Str(Day(fecha)).PadLeft(2, "0") + "/" + Str(Month(fecha)).PadLeft(2, "0") + "/" + Year(fecha).ToString
            End Select
        End If
        Return Ret
    End Function

End Class