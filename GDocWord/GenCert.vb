Public Class GenCert

    Dim mDoc_DOC As Byte()
    Dim mDoc_PDF As Byte()

    Public Property Doc_Doc As Byte()
        Get
            Return mDoc_DOC
        End Get
        Set(ByVal value As Byte())
            mDoc_DOC = value
        End Set
    End Property

    Public Property Doc_PDF As Byte()
        Get
            Return mDoc_PDF
        End Get
        Set(ByVal value As Byte())
            mDoc_PDF = value
        End Set
    End Property
    Function GenDocumento(DocPlantilla As Byte(), datos As DataTable, dtPlantillasCampos As DataTable) As String
        Dim Msg As String = ""
        Dim dtDatos As New DataTable
        Dim dtPlantilla As New DataTable
        Dim ListaNomTablas As New List(Of String)
        Dim ListaTablas As New List(Of DataTable)
        Dim ListaGrupoNomTabla As New List(Of String)
        Dim ListaGrupoTabla As New List(Of DataTable)
        'Generar el Documento Word
        If dtPlantillasCampos.Rows.Count > 0 Then
            dtDatos = datos
            'Dim dtTabla As DataTable = GetCertificadoL() ' LISTA DEL CONTRATO
            'If dtTabla.Rows.Count > 0 Then
            '    ListaTablas.Add(dtTabla)
            '    ListaNomTablas.Add("VLSTCONTRATOS")
            'End If
            Dim Documento As Byte()
            Dim DocumentoPDF As Byte()
            Dim oWord As New GDWord

            If Not IsNothing(DocPlantilla) Then
                'If dtPlantilla.Rows(0)("EDITABLE").ToString = "1" Then
                '    oWord.DocProtegido = True
                '    'oWord.ClavePlantilla = Publico.Clave_Minuta
                'Else
                '    oWord.DocProtegido = False
                'End If
                oWord.IdPlantilla = "37" ' ide de plantillas
                oWord.ListaNomTablas = ListaNomTablas
                oWord.ListaTablas = ListaTablas
                Documento = oWord.GenerarDocumento(DocPlantilla, dtPlantillasCampos, dtDatos)
                DocumentoPDF = oWord.Documento_Pdf
                If Not oWord.lErrorG Then
                    If Not IsNothing(Documento) Then
                        Doc_Doc = oWord.Documento_Word
                        Doc_PDF = oWord.Documento_Pdf
                        Msg = "Se Generó el Documento N°"
                    End If
                End If
            Else
                Msg = "La plantilla no esta definida. Por favor verifique"
            End If
        End If
        Return Msg
    End Function
End Class
