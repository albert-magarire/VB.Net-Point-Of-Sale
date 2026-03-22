Public Class waiters

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Hide()
        Supervisor.Show()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If String.IsNullOrWhiteSpace(txtWaiter.Text) Then
                MessageBox.Show("Please enter a waiter name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Save to database
            DataAccessLayer.AddWaiter(txtWaiter.Text.Trim())

            ' Also add to the Entries combo box if it's loaded
            Entries.cmbwaiter.Items.Add(txtWaiter.Text.Trim())

            MessageBox.Show(txtWaiter.Text.Trim() & " has successfully been added to the waiters list.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtWaiter.Clear()
            Me.Hide()
            Supervisor.Show()
        Catch ex As DataAccessException
            MessageBox.Show("Error saving waiter: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Unexpected error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        Try
            If String.IsNullOrWhiteSpace(txtWaiter.Text) Then
                MessageBox.Show("Please enter a waiter name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Remove from database
            DataAccessLayer.RemoveWaiter(txtWaiter.Text.Trim())

            ' Also remove from the Entries combo box if it's loaded
            Entries.cmbwaiter.Items.Remove(txtWaiter.Text.Trim())

            MessageBox.Show(txtWaiter.Text.Trim() & " has successfully been removed from the waiters list.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtWaiter.Clear()
            Me.Hide()
            Supervisor.Show()
        Catch ex As DataAccessException
            MessageBox.Show("Error removing waiter: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Unexpected error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
