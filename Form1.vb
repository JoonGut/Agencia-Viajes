Public Class Form1
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        MessageBox.Show("Introduzca el lugar donde quieres gurdar los registros")
        Dim cliente As New ClaseCliente()
        Dim saveDialog As New SaveFileDialog With {
            .Filter = "Text Files (.txt)|.txt",
            .Title = "Seleccionar archivo de clientes"
        }
        If saveDialog.ShowDialog() = DialogResult.OK Then
            Using writer As New System.IO.StreamWriter("RutasClientes.txt", True)
                writer.WriteLine(saveDialog.FileName)
            End Using

            cliente.aniadirRegistroN()
        End If
        Dim clientes As New MostrarCliente
        clientes.Show()

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        MessageBox.Show("Introduzca el lugar donde quieres gurdar los registros")
        Dim cliente As New ClaseCliente()
        Dim saveDialog As New SaveFileDialog With {
            .Filter = "Text Files (.txt)|.txt",
            .Title = "Seleccionar archivo de clientes"
        }
        If saveDialog.ShowDialog() = DialogResult.OK Then
            Using writer As New System.IO.StreamWriter("RutasDestino.txt", True)
                writer.WriteLine(saveDialog.FileName)
            End Using

            cliente.aniadirRegistroN()
        End If
        Dim viaje As New MostrarDestino
        viaje.Show()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Dim objetoVacio As New ClaseViaje()
        Dim destino As New Viaje(objetoVacio)
        destino.Show()
    End Sub


    'MOSTRAMOS LOS LABELS CUANDO PASAMOS EL RATON POR ENCIMA
    Private Sub PictureBox1_MouseEnter(sender As Object, e As EventArgs) Handles PictureBox1.MouseEnter
        lblClientes.Visible = True
    End Sub

    Private Sub PictureBox1_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox1.MouseLeave
        lblClientes.Visible = False
    End Sub

    Private Sub PictureBox2_MouseEnter(sender As Object, e As EventArgs) Handles PictureBox2.MouseEnter
        lblDestinos.Visible = True
    End Sub

    Private Sub PictureBox2_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox2.MouseLeave
        lblDestinos.Visible = False
    End Sub

    Private Sub PictureBox3_MouseEnter(sender As Object, e As EventArgs) Handles PictureBox3.MouseEnter
        lblViajes.Visible = True
    End Sub

    Private Sub PictureBox3_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox3.MouseLeave
        lblViajes.Visible = False
    End Sub

    'ESTILOS TODAS LAS TABLAS
    Public Shared Sub estilosTablas(nombreTabla As DataGridView)
        With nombreTabla
            .Rows.Clear()
            .Columns.Clear()
            .DefaultCellStyle.Font = New Font("Segoe UI", 10)
            .DefaultCellStyle.BackColor = Color.AliceBlue
            .DefaultCellStyle.ForeColor = Color.Black
            .ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 11, FontStyle.Bold)
            .ColumnHeadersDefaultCellStyle.BackColor = Color.LightSteelBlue
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.Black
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .ReadOnly = True
            .BorderStyle = BorderStyle.Fixed3D
            .GridColor = Color.LightGray
        End With
    End Sub


    Private Sub lblDestino_Click(sender As Object, e As EventArgs) Handles lblViajes.Click

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
