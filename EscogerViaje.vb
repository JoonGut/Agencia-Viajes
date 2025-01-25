Public Class EscogerViaje

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
    Private Sub EscogerViaje_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarViajesEnTabla()
    End Sub
    'ENVIAMOS DATOS
    Private Sub btAceptar_Click(sender As Object, e As EventArgs) Handles btAceptar.Click
        enviarDatos()
        MessageBox.Show("Viaje seleccionado correctamente")
        Me.Close()
    End Sub
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()
    End Sub


    'EMVIAMOS DATOS A LAS TABLAS
    Private Sub enviarDatos()
        If tablaViajes.SelectedRows.Count > 0 Then
            Dim filaSeleccionada = tablaViajes.SelectedRows(0)
            Dim destino = filaSeleccionada.Cells("Destino").Value.ToString

            _viaje.destino = destino
            'MessageBox.Show(_viaje.nombre)
            Dim mover As New Viaje(_viaje)
            mover.Show()
        End If
    End Sub

    'CARGAMOS LOS VIAJES EN LA TABLA
    Private Sub CargarViajesEnTabla()
        Dim estilos As New Form1
        estilos.estilosTablas(tablaViajes)

        Dim destinos As List(Of ClaseDestino) = ClaseDestino.CargarDestinos()

        tablaViajes.Rows.Clear()
        tablaViajes.Columns.Clear()

        tablaViajes.Columns.Add("Destino", "Destino")
        tablaViajes.Columns.Add("Guia", "Guía")

        For Each destino As ClaseDestino In destinos
            tablaViajes.Rows.Add(destino.destino, destino.guia)
        Next
    End Sub


End Class