Imports Microsoft.VisualBasic
Imports System.IO

Public Class Util
    Public Shared Function HEXCOL2RGB(ByVal HexColor As String) As System.Drawing.Color
        'The input at this point could be HexColor = "#00FF1F"
        Dim Red As String
        Dim Green As String
        Dim Blue As String

        HexColor = Replace(HexColor, "#", "")
        'Here HexColor = "00FF1F"

        Red = Val("&H" & Mid(HexColor, 1, 2))

        'The red value is now the long version of "00"

        Green = Val("&H" & Mid(HexColor, 3, 2))
        'The red value is now the long version of "FF"

        Blue = Val("&H" & Mid(HexColor, 5, 2))
        'The red value is now the long version of "1F"

        'The output is an RGB value
        Return Drawing.Color.FromArgb(Red, Green, Blue)

    End Function

    Public Shared Function AddFiltro(ByRef cFiltro As String, ByVal cCondicion As String) As String
        If cFiltro = String.Empty Then
            cFiltro = cCondicion
        Else
            cFiltro = cFiltro + " And " + cCondicion
        End If
        Return cFiltro
    End Function

    Public Shared Sub SaveJPG(ByVal image As Drawing.Image, ByVal szFileName As String)
        'Si ya existe una imagen se tendra que eliminar
        If System.IO.File.Exists(szFileName) = True Then
            System.IO.File.Delete(szFileName)
        End If
        'Despues de eliminar la imagen existe se crea otra con el Drawing.Image nuevo
        'Throw New Exception(szFileName)
        image.Save(szFileName)
    End Sub
    Public Shared Function Bytes2Image(ByVal bytes() As Byte) As Drawing.Bitmap

        If bytes Is Nothing Then Return Nothing
        Dim ms As New MemoryStream(bytes)
        Dim bm As Drawing.Bitmap = Nothing
        Try
            bm = New Drawing.Bitmap(ms)
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine(ex.Message)
        End Try
        Return bm
    End Function
    Public Function AppPath() As String
        Return System.AppDomain.CurrentDomain.BaseDirectory()
    End Function

    Public Shared Function SI_NO(ByVal Valor As String) As Boolean
        Return IIf(Valor = "SI", True, False)
    End Function

    Public Shared Function invSI_NO(ByVal Valor As Boolean) As String
        Return IIf(Valor = True, "SI", "NO")
    End Function
    Public Shared Function invN1_0(ByVal Valor As Boolean) As String
        Return IIf(Valor = True, "1", "0")
    End Function

    Public Shared Function N1_0(ByVal Valor As String) As Boolean
        Return IIf(Valor = "1", True, False)
    End Function
    ''' <summary>
    ''' pasa 1,2 a '1','2'
    ''' </summary>
    ''' <param name="Cad"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function FormatCVS(ByVal Cad As String) As String
        Dim s() As String = Cad.Split(",")
        Dim r As String = ""
        For i As Integer = 0 To s.Length - 1
            r = IIf(r = "", "'" + s(i) + "'", r + ",'" + s(i) + "'")
        Next
        Return r
    End Function


    Public Shared Function ValidarDigitoVerificacion(ByVal unNit As String) As String
        Dim miTemp As String
        Dim miContador As Integer
        Dim miResiduo As Integer
        Dim miChequeo As Integer
        Dim miArregloPA As Integer() = New Integer(14) {}
        miArregloPA(0) = 3
        miArregloPA(1) = 7
        miArregloPA(2) = 13
        miArregloPA(3) = 17
        miArregloPA(4) = 19
        miArregloPA(5) = 23
        miArregloPA(6) = 29
        miArregloPA(7) = 37
        miArregloPA(8) = 41
        miArregloPA(9) = 43
        miArregloPA(10) = 47
        miArregloPA(11) = 53
        miArregloPA(12) = 59
        miArregloPA(13) = 67
        miArregloPA(14) = 71
        miChequeo = 0
        miResiduo = 0
        For miContador = 0 To unNit.Length - 1
            miTemp = unNit((unNit.Length - 1) - miContador).ToString()
            miChequeo = miChequeo + (Convert.ToInt32(miTemp) * miArregloPA(miContador))
        Next
        miResiduo = miChequeo Mod 11
        If miResiduo > 1 Then
            Return Convert.ToString(11 - miResiduo)
        End If
        Return miResiduo.ToString()
    End Function

    ' agregado Shirly, proviene de Signus, administrador del tributo
    Public Shared Function Byte2ImagePath(ByVal bytes() As Byte) As String
        If bytes Is Nothing Then Return Nothing
        Dim ms As New MemoryStream(bytes)
        Dim bm As Drawing.Bitmap = Nothing
        Dim oPath As String = Path.ChangeExtension(Path.GetTempFileName(), ".JPG")
        Try
            bm = New Drawing.Bitmap(ms)
            SaveJPG(bm, oPath)
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine(ex.Message)
        End Try
        Return oPath
    End Function

    Public Shared Function Icono(tipo As String) As String
        Dim ic As String = ""
        Select Case tipo
            Case "image/jpeg", "image/png", "image/bmp"
                ic = "~/images/iconos/imagen.png"
                Exit Select
            Case "application/pdf"
                ic = "~/images/iconos/pdf.png"
                Exit Select
            Case "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "application/msword"
                ic = "~/images/iconos/word.png"
                Exit Select
            Case "application/octet-stream"
                ic = "~/images/iconos/rar.png"
                Exit Select
            Case "application/vnd.ms-excel", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
                ic = "~/images/iconos/excel.png"
                Exit Select
            Case "application/vnd.ms-powerpoint", "application/vnd.openxmlformats-officedocument.presentationml.presentation"
                ic = "~/images/iconos/ppoint.png"
                Exit Select
            Case Else
                ic = "~/images/iconos/Otro.png"
                Exit Select
        End Select
        Return ic
    End Function

End Class
