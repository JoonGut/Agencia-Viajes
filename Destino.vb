Imports System.Reflection

Public Class Destino
    'CERRAMOS VENTANA
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()
    End Sub
    'CARGAMOS DATOS
    Private Sub btAlta_Click(sender As Object, e As EventArgs) Handles btAlta.Click
        Dim bandera As Boolean = comprobacionCampos()
        If bandera = False Then
            txtDestino.Text = ""
            txtGuia.Text = ""
        Else
            Dim viaje As New ClaseDestino(txtDestino.Text, txtGuia.Text)
            viaje.aniadirRegistro(viaje)
            txtDestino.Text = ""
            txtGuia.Text = ""
            lblCorrecto.Text = "Destino añadido correctamente"
        End If
    End Sub

    'FUNCION PARA COMPROBAR DATOS
    Private Function comprobacionCampos() As Boolean
        Dim bandera As Boolean = True
        If txtDestino.Text = "" Or txtGuia.Text = "" Then
            lblRespuesta.Text = ("Rellene todos los campos")
            bandera = False
        ElseIf IsNumeric(txtDestino.Text) Or IsNumeric(txtGuia.Text) Then
            lblRespuesta.Text = "El tipo de datos Nombre y Apellido es erroneo"
            bandera = False
        End If
        Return bandera
    End Function

    Private Sub Viaje_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class