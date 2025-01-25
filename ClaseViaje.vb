Imports System.IO

Public Class ClaseViaje
    Private _nombre As String
    Private _apellido As String
    Private _destino As String
    ' 4 CONSTRUCTOES
    Public Sub New(nombre As String, apellido As String, destino As String)
        _nombre = nombre
        _apellido = apellido
        _destino = destino
    End Sub
    Public Sub New()
        _nombre = ""
        _apellido = ""
        _destino = ""
    End Sub
    Public Sub New(nombre As String, apellido As String)
        _nombre = nombre
        _apellido = apellido
        _destino = ""

    End Sub
    Public Sub New(destino As String)
        _nombre = ""
        _apellido = ""
        _destino = destino
    End Sub
    'GETTERS Y SETTERS
    Public Property nombre() As String
        Get
            Return _nombre
        End Get
        Set(value As String)
            _nombre = value
        End Set
    End Property

    Public Property apellido() As String
        Get
            Return _apellido
        End Get
        Set(value As String)
            _apellido = value
        End Set
    End Property
    Public Property destino() As String
        Get
            Return _destino
        End Get
        Set(value As String)
            _destino = value
        End Set
    End Property
    Public Shared Function cargarRuta()
        Dim nomFich As String = "RutasViajes.txt"
        If File.Exists(nomFich) Then
            Dim alineas As String() = File.ReadAllLines(nomFich)
            Dim ruta As String = alineas(0)
            Return ruta

        Else
            MessageBox.Show("No se ha encontrado el archivo de viajes.")
        End If
    End Function

    'AÑADIMOS REGISTRO DONDE QUIERAS
    Public Sub aniadirRegistro()
        Dim nomFich As String = cargarRuta()
        Try
            Using swEscritor As New StreamWriter(nomFich, True)
                swEscritor.WriteLine(nombre & "-" & apellido & "-" & destino)
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al escribir en el archivo: " & ex.Message)
        End Try
    End Sub
    'CARGAMOS VIAJES

    Public Shared Function CargarViajes() As List(Of ClaseViaje)
        Dim listaViajes As New List(Of ClaseViaje)
        Dim nomFich As String = cargarRuta()

        If File.Exists(nomFich) Then
            Dim lineas As String() = File.ReadAllLines(nomFich)
            For Each linea As String In lineas
                If Not String.IsNullOrWhiteSpace(linea) Then
                    Dim info_viaje() As String = linea.Split("-"c)

                    Dim nombre As String = info_viaje(0).Trim()
                    Dim apellidos As String = info_viaje(1).Trim()
                    Dim destino As String = info_viaje(2).Trim()
                    listaViajes.Add(New ClaseViaje(nombre, apellidos, destino))

                End If
            Next
        End If

        Return listaViajes
    End Function


End Class
