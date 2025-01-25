Public Class Cliente
    'CERRAMOS VENTANA
    Private Sub btVolver_Click(sender As Object, e As EventArgs)
        Close()
    End Sub
    'INSERTAMOS VALORES
    Private Sub btInsertar_Click(sender As Object, e As EventArgs) Handles btInsertar.Click
        Dim bandera As Boolean = comprobacionCampos()
        lblCorrecto.Text = ""

        If bandera = False Then
            txtNombre.Text = ""
            txtApellidos.Text = ""
            txtTelefono.Text = ""
            txtDinero.Text = 0
        Else
            Dim Cliente As New ClaseCliente(txtNombre.Text, txtApellidos.Text, Convert.ToInt32(txtTelefono.Text), Convert.ToInt32(txtDinero.Text))
            Cliente.aniadirRegistro(Cliente)
            txtNombre.Text = ""
            txtApellidos.Text = ""
            txtTelefono.Text = ""
            txtDinero.Text = 0
            lblCorrecto.Text = "Cliente añadido correctamente"
        End If


    End Sub

    'FUNCIONA PARA COMPROBAR DATOS
    Private Function comprobacionCampos() As Boolean
        Dim bandera As Boolean = True
        If txtTelefono.Text = "" Or txtDinero.Text = "" Or txtNombre.Text = "" Or txtApellidos.Text = "" Then
            lblRespuesta.Text = ("Rellene todos los campos")
            bandera = False
        ElseIf txtTelefono.Text.Length <> 9 Then
            lblRespuesta.Text = ("El teléfono debe tener 9 dígitos")
            bandera = False
        ElseIf txtDinero.Text.Length > 6 Then
            lblRespuesta.Text = ("El dinero invertido no puede ser mayor a 999999")
            bandera = False
        ElseIf IsNumeric(txtNombre.Text) Or IsNumeric(txtApellidos.Text) Then
            lblRespuesta.Text = "El tipo de datos Nombre y Apellido es erroneo"
            bandera = False
        ElseIf Not IsNumeric(txtTelefono.Text) Or Not IsNumeric(txtDinero.Text) Then
            lblRespuesta.Text = "El tipo de datos Telefono y Dinero es erroneo"
            bandera = False
        End If
        Return bandera
    End Function

    Private Sub Cliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Close()
    End Sub
End Class