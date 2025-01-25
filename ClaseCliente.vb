Imports System.IO

Public Class ClaseCliente
    Private _nombre As String
    Private _apellido As String
    Private _telefono As Integer
    Private _euroReserva As Integer

    Public Sub New(nombre As String, apellido As String, telefono As Integer, dineroInvertido As Integer)
        _nombre = nombre
        _apellido = apellido
        _telefono = telefono
        _euroReserva = dineroInvertido
    End Sub
    Public Sub New()
        _nombre = ""
        _apellido = ""
        _telefono = 0
        _euroReserva = 0
    End Sub
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
    Public Property telefono() As Integer
        Get
            Return _telefono
        End Get
        Set(value As Integer)
            _telefono = value
        End Set
    End Property
    Public Property euroReserva() As Integer
        Get
            Return _euroReserva
        End Get
        Set(value As Integer)
            _euroReserva = value
        End Set
    End Property
    Public Shared Function cargarRuta()
        Dim nomFich As String = "RutasClientes.txt"
        If File.Exists(nomFich) Then
            Dim alineas As String() = File.ReadAllLines(nomFich)
            Dim ruta As String = alineas(0)
            Return ruta

        Else
            MessageBox.Show("No se ha encontrado el archivo de viajes.")
        End If
    End Function
    'METODO PARA AÑADIR REGISTROS
    Public Sub aniadirRegistro(cliente As ClaseCliente)
        Dim nomFich As String = cargarRuta()

        Try
            Using swEscritor As New StreamWriter(nomFich, True)
                swEscritor.Write(cliente.nombre & "€" & cliente.apellido & "€" & cliente.telefono & "€" & cliente.euroReserva & "#")
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al escribir en el archivo: " & ex.Message)
        End Try
    End Sub
    Public Sub aniadirRegistroN()
        Dim nomFich As String = cargarRuta()

        Try
            Using swEscritor As New StreamWriter(nomFich, True)
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al escribir en el archivo: " & ex.Message)
        End Try
    End Sub
    'METODO ESTATICO PARA CARGAR LA LISTA DE CLIENTES
    Public Shared Function CargarClientes() As List(Of ClaseCliente)
        Dim listaClientes As New List(Of ClaseCliente)
        Dim nomFich As String = cargarRuta()

        If File.Exists(nomFich) Then
            Dim contenido As String = File.ReadAllText(nomFich).Trim()
            Dim clientes() As String = contenido.Split("#"c)

            For Each cliente As String In clientes

                If Not String.IsNullOrWhiteSpace(cliente) Then

                    Dim clienteLimpio As String = cliente.Trim()
                    Dim info_cliente() As String = clienteLimpio.Split("€"c)
                    Dim nombre As String = info_cliente(0).Trim()
                    Dim apellido As String = info_cliente(1).Trim()
                    Dim telefono As Integer = info_cliente(2).Trim()
                    Dim gastos As Integer = info_cliente(3).Trim()

                    listaClientes.Add(New ClaseCliente(nombre, apellido, telefono, gastos))
                End If
            Next
        End If

        Return listaClientes
    End Function

    'METODO ESTATICO PARA ELIMINAR UN CLIENTE
    Public Shared Sub EliminarCliente(clienteAEliminar As String)
        Dim nomFich As String = cargarRuta()
        Try
            Dim fichero As String = File.ReadAllText(nomFich)
            Dim nuevoFich As String = fichero.Replace(clienteAEliminar, "")
            File.WriteAllText(nomFich, nuevoFich)
        Catch ex As Exception
            MessageBox.Show("No se ha podido eliminar del archivo")
        End Try

    End Sub

    'METODO PARA UPDATEAR EL PRECIO DE MIS CLIENTES
    Public Shared Sub updatearPrecio(nombre As String, nuevoPrecio As Integer)
        Try
            Dim nomFich As String = cargarRuta()
            If File.Exists(nomFich) Then
                Dim fichero As String = File.ReadAllText(nomFich)
                Dim aLineas As String() = fichero.Split("#"c)
                Dim encontrado As Boolean = False

                Dim registroOriginal As String = ""
                Dim registroNuevo As String = ""
                'Dim nuevoFich As String = ""
                For i As Integer = 0 To aLineas.Length - 1
                    If aLineas(i).Contains(nombre) Then
                        Dim aPartes As String() = aLineas(i).Split("€"c)

                        Dim dinero As Integer
                        Integer.TryParse(aPartes(3), dinero)
                        dinero += nuevoPrecio

                        'nuevoFich = fichero.Replace(aPartes(3), dinero)

                        registroOriginal = aLineas(i)
                        registroNuevo = $"{aPartes(0)}€{aPartes(1)}€{aPartes(2)}€{dinero}#"

                        MessageBox.Show("Precio actualizado")
                        encontrado = True
                    End If
                Next
                If encontrado = True Then
                    fichero = fichero.Replace(registroOriginal, registroNuevo)
                End If
                File.WriteAllText(nomFich, fichero)
            Else
                MessageBox.Show("Ruta no encontrada")
            End If
        Catch ex As Exception
            MessageBox.Show("No se ha podido eliminar del archivo")
        End Try
    End Sub


End Class
