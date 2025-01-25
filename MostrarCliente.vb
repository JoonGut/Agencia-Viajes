Imports System.IO
Public Class MostrarCliente
    'CARGAMOS CLIENTES
    Private Sub MostrarCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarClientesEnTabla()
    End Sub

    'ACTUALIZAMOS LA TABLA
    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        CargarClientesEnTabla()
    End Sub

    'OTRA PESTAÑA PARA CREAR CLIENTES
    Private Sub btNuevoCliente_Click(sender As Object, e As EventArgs) Handles btNuevoCliente.Click
        Dim cliente As New Cliente
        cliente.Show()
    End Sub

    'CERRAMOS LA VENTANA
    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Me.Close()
    End Sub


    'CARGAMOS LOS CLIENTES EN LA TABLA
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




    'ELIMINAMOS CLIENTES
    Private Sub btEliminar_Click(sender As Object, e As EventArgs) Handles btEliminar.Click
        If tablaClientes.SelectedRows.Count > 0 Then
            Dim filaSeleccionada = tablaClientes.SelectedRows(0)
            Dim nombre = filaSeleccionada.Cells("Nombre").Value.ToString
            Dim apellido = filaSeleccionada.Cells("Apellido").Value.ToString
            Dim telefono = filaSeleccionada.Cells("Telefono").Value.ToString
            Dim eurosReservaString = filaSeleccionada.Cells("Gastos").Value.ToString
            Dim eurosReserva As Integer
            tablaClientes.Rows.Remove(filaSeleccionada)

            Dim clienteAEliminar = $"{nombre}€{apellido}€{telefono}€{eurosReserva}#"

            ClaseCliente.EliminarCliente(clienteAEliminar)

        Else
            MessageBox.Show(" No has seleccionado una fila ")
        End If

    End Sub

    Private Sub tablaClientes_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles tablaClientes.CellContentClick

    End Sub
End Class