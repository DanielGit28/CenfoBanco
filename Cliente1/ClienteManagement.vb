
Public Class ClienteManagement

    Private crudCliente As AccesoDatos.Crud.ClienteCrudFactory

    Public Sub ClienteManagement()
        crudCliente = New AccesoDatos.Crud.ClienteCrudFactory()
    End Sub

    Public Function Create(cliente As Entidades.Cliente)
        crudCliente.Create(cliente)
    End Function

    Public Function RetrieveAll() As List(Of Entidades.Cliente)
        Return crudCliente.RetrieveAll(Of Entidades.Cliente)
    End Function

    Public Function RetrieveById(cliente As Entidades.Cliente) As Entidades.Cliente
        Return crudCliente.Retrieve(Of Entidades.Cliente)
    End Function

    Friend Function Update(cliente As Entidades.Cliente)
        crudCliente.Update(cliente)
    End Function

    Friend Function Delete(cliente As Entidades.Cliente)
        crudCliente.Delete(cliente)
    End Function

End Class
