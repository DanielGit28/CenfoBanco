
Public Class CuentaManagement
    Private crudCuenta As AccesoDatos.Crud.CuentaCrudFactory
    Public Sub CreditoManagement()
        crudCuenta = New AccesoDatos.Crud.CuentaCrudFactory()
    End Sub

    Public Function Create(cuenta As Entidades.Cuenta)
        crudCuenta.Create(cuenta)
    End Function

    Public Function RetrieveAll() As List(Of Entidades.Cuenta)
        Return crudCuenta.RetrieveAll(Of Entidades.Cuenta)
    End Function

    Public Function RetrieveById(cuenta As Entidades.Cuenta) As Entidades.Cuenta
        Return crudCuenta.Retrieve(Of Entidades.Cuenta)
    End Function

    Friend Function Update(cuenta As Entidades.Cuenta)
        crudCuenta.Update(cuenta)
    End Function

    Friend Function Delete(cuenta As Entidades.Cuenta)
        crudCuenta.Delete(cuenta)
    End Function

End Class

