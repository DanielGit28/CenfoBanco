﻿Imports AccesoDatos
Imports Entidades
Public Class DireccionManagement
    Public crudDireccion As Crud.DireccionCrudFactory
    Public Sub CreditoManagement()
        crudDireccion = New Crud.DireccionCrudFactory()
    End Sub

    Public Function Create(direccion As Entidades.Direccion)
        crudDireccion.Create(direccion)
    End Function

    Public Function RetrieveAll() As List(Of Entidades.Direccion)
        Return crudDireccion.RetrieveAll(Of Entidades.Direccion)
    End Function

    Public Function RetrieveById(direccion As Entidades.Direccion) As Entidades.Direccion
        Return crudDireccion.Retrieve(Of Entidades.Direccion)
    End Function

    Friend Function Update(direccion As Entidades.Direccion)
        crudDireccion.Update(direccion)
    End Function

    Friend Function Delete(direccion As Entidades.Direccion)
        crudDireccion.Delete(direccion)
    End Function

End Class

