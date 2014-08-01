Public Interface IFmtoColumn
    Function tieneConf(NomTabla As String, NomCam As String) As Integer
    Function getAncho(NomTabla As String, NomCam As String) As Integer
    Function getTipoDato(NomTabla As String, NomCam As String) As String
    Function getDescripcion(NomTabla As String, NomCam As String) As String
End Interface

