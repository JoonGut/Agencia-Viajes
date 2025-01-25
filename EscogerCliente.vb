Public Class EscogerCliente
    Private _viaje As ClaseViaje
    Public Property viaje As ClaseViaje
        Get
            Return _viaje
        End Get
        Set(value As ClaseViaje)
            _viaje = value
        End Set
    End Property
    'CONSTRUCTOR AL QUE NOS PASAMOS LOS VALORES DE LA OTRA VENTANA
    Public Sub New(objetoClase As ClaseViaje)
        InitializeComponent()
        _viaje = objetoClase

    End Sub
    'CARGAMOS DATOS
    Private Sub EscogerCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarClientesEnTabla()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        enviarDatos()
        MessageBox.Show("Cliente seleccionado correctamente")
        Me.Close()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()

    End Sub
    'CARGAMOS DATOS EN LA TABLA
    Private Sub CargarClientesEnTabla()
        Dim estilos As New Form1
        estilos.estilosTablas(tablaClientes)

        Dim clientes As List(Of ClaseCliente) = ClaseCliente.CargarClientes()

        tablaClientes.Rows.Clear()
        tablaClientes.Columns.Clear()

        tablaClientes.Columns.Add("Nombre", "Nombre")
        tablaClientes.Columns.Add("Apellido", "Apellido")
        tablaClientes.Columns.Add("Telefono", "Teléfono")
        tablaClientes.Columns.Add("Gastos", "Gastos")

        For Each cliente As ClaseCliente In clientes
            tablaClientes.Rows.Add(cliente.nombre, cliente.apellido, cliente.telefono, cliente.euroReserva)
        Next
    End Sub


    'ENVIAMOS OBJETO
    Private Sub enviarDatos()
        If tablaClientes.SelectedRows.Count > 0 Then
            Dim filaSeleccionada = tablaClientes.SelectedRows(0)
            Dim nombre = filaSeleccionada.Cells("Nombre").Value.ToString
            Dim apellido = filaSeleccionada.Cells("Apellido").Value.ToString

            _viaje.nombre = nombre
            _viaje.apellido = apellido

            'MessageBox.Show(_viaje.destino)
            Dim destino As New Viaje(_viaje)
            destino.Show()


        End If
    End Sub


End Class