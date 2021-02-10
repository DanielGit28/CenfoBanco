Imports AccesoDatos
Imports Entidades
Public Class CreditoManagement
    Public crudCredito As AccesoDatos.Crud.CreditoCrudFactory
    Public Sub CreditoManagement()
        crudCredito = New AccesoDatos.Crud.CreditoCrudFactory()
    End Sub

    Public Function Create(credito As Entidades.Credito)
        crudCredito.Create(credito)
    End Function

    Public Function RetrieveAll() As List(Of Entidades.Credito)
        Return crudCredito.RetrieveAll(Of Entidades.Credito)
    End Function

    Public Function RetrieveById(credito As Entidades.Credito) As Entidades.Credito
        Return crudCredito.Retrieve(Of Entidades.Credito)
    End Function

    Friend Function Update(credito As Entidades.Credito)
        crudCredito.Update(credito)
    End Function

    Friend Function Delete(credito As Entidades.Credito)
        crudCredito.Delete(credito)
    End Function

End Class

