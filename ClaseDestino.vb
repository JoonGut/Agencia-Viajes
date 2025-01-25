Imports System.IO

Public Class ClaseDestino
    Private _destino As String
    Private _guia As String
    Public Sub New(destino As String, guia As String)
        _destino = destino
        _guia = guia
    End Sub
    Public Property destino() As String
        Get
            Return _destino
        End Get
        Set(value As String)
            _destino = value
        End Set
    End Property
    Public Property guia() As String
        Get
            Return _guia
        End Get
        Set(value As String)
            _guia = value
        End Set
    End Property
    Public Shared Function cargarRuta()
        Dim nomFich As String = "RutasDestino.txt"
        If File.Exists(nomFich) Then
            Dim alineas As String() = File.ReadAllLines(nomFich)
            Dim ruta As String = alineas(0)
            Return ruta

        Else
            MessageBox.Show("No se ha encontrado el archivo de viajes.")
        End If
    End Function
    Public Sub aniadirRegistro(viaje As ClaseDestino)
        Dim nomFich As String = cargarRuta()

        Try
            Using swEscritor As New StreamWriter(nomFich, True)
                swEscritor.WriteLine(viaje.destino & "," & viaje.guia)
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al escribir en el archivo: " & ex.Message)
        End Try
    End Sub
    Public Shared Function CargarDestinos() As List(Of ClaseDestino)
        Dim listaDestino As New List(Of ClaseDestino)
        Dim nomFich As String = cargarRuta()

        If File.Exists(nomFich) Then
            Dim lineas As String() = File.ReadAllLines(nomFich)
            For Each linea As String In lineas
                If Not String.IsNullOrWhiteSpace(linea) Then
                    Dim info_viaje() As String = linea.Split(","c)

                    Dim destino As String = info_viaje(0).Trim()
                    Dim guia As String = info_viaje(1).Trim()
                    listaDestino.Add(New ClaseDestino(destino, guia))

                End If
            Next

        End If

        Return listaDestino
    End Function

    Public Shared Sub EliminarCliente(viajeEliminar As String)
        Dim nomFich As String = cargarRuta()
        Try
            Dim fichero As String = File.ReadAllText(nomFich)
            Dim nuevoFich As String = fichero.Replace(viajeEliminar, "")
            File.WriteAllText(nomFich, nuevoFich)
        Catch ex As Exception
            MessageBox.Show("No se ha podido eliminar del archivo")
        End Try
    End Sub
End Class
