﻿Imports Entidades
Module Program

    Sub Main()

    End Sub

    Public Function Run()
        Try
            Dim cliente_mng = New ClienteManagement()
            Dim cuenta_mng = New CuentaManagement()
            Dim credito_mng = New CreditoManagement()
            Dim direccion_mng = New DireccionManagement()

            Dim cliente = New Cliente()
            Dim cuenta = New Cuenta()
            Dim credito = New Credito()
            Dim direccion = New Direccion()
            Console.WriteLine("Menu de manejo de objetos CRUD")
            Console.WriteLine("1. Menu cliente")
            Console.WriteLine("2. Menu credito")
            Console.WriteLine("3. Menu cuenta")
            Console.WriteLine("4. Menu direccion")
            Console.WriteLine("5. Salir")

            Console.WriteLine("Seleccione una opcion: ")
            Dim opcion As String = Console.ReadLine()

            Select Case opcion
                Case 1
                    MenuCliente(direccion_mng, cliente_mng, direccion, cliente)
                Case 2
                    MenuCredito()
                Case 3
                    MenuCuenta()
                Case 4
                    MenuDireccion()
                Case 5
                    Exit Select
                Case Else
                    Debug.WriteLine("No selecciono una opcion valida")
            End Select
        Catch ex As Exception
            Console.WriteLine("***************************")
            Console.WriteLine("ERROR: " + ex.Message)
            Console.WriteLine(ex.StackTrace)
            Console.WriteLine("***************************")
        End Try



    End Function

    '---FUNCIONES DE CLIENTE---
    Public Function MenuCliente(mng As DireccionManagement, mngCliente As ClienteManagement, direccion As Direccion, cliente As Cliente)
        Console.WriteLine("Menu de cliente")
        Console.WriteLine("1. Crear cliente")
        Console.WriteLine("2. Obtener clientes")
        Console.WriteLine("3. Obtener cliente por id")
        Console.WriteLine("4. Actualizar cliente")
        Console.WriteLine("5. Eliminar cliente")
        Console.WriteLine("6. Salir")

        Console.WriteLine("Seleccione una opcion: ")
        Dim opcion As String = Console.ReadLine()

        Select Case opcion
            Case 1
                CrearCliente(mng, mngCliente, direccion, cliente)
            Case 2
                ObtenerClientes(mngCliente)
            Case 3
                ObtenerClienteXId(mngCliente)
            Case 4
                ActualizarCliente(mngCliente)
            Case 5
                EliminarCliente(mngCliente)
            Case 6
                Exit Select
            Case Else
                Debug.WriteLine("No selecciono una opcion valida")
        End Select

    End Function

    Public Function CrearCliente(mng As DireccionManagement, mngCliente As ClienteManagement, direccion As Direccion, cliente As Cliente)
        Console.WriteLine("--------Crear cliente--------")
        Console.WriteLine("Digite la provincia, canton y distrito separados por coma")
        Dim infoDireccion = Console.ReadLine()
        Dim arrayDireccion = infoDireccion.Split(",")
        direccion = New Entidades.Direccion(arrayDireccion)
        mng.Create(direccion)

        Dim idDireccion As Integer = mng.RetrieveIdentity()

        Console.WriteLine("Digite la cedula, nombre, apellido, fechaNac(YYYY-MM-DD), edad, estado civil y genero separados por coma y sin espacios")
        Dim infoCliente = Console.ReadLine()
        Dim arrayCliente = infoCliente.Split(",")
        arrayCliente.Append("," + idDireccion)
        cliente = New Entidades.Cliente(arrayCliente)
        mngCliente.Create(cliente)

        Console.WriteLine("Cliente creado")

    End Function

    Public Function ObtenerClientes(mng As ClienteManagement)
        Console.WriteLine("--------Obtener clientes--------")
        Dim clientes = mng.RetrieveAll()
        Dim count = 0
        Dim c As Cliente

        For Each c In clientes
            count += 1
            Console.WriteLine(count + " - " + c.GetEntityInformation())
        Next

    End Function

    Public Function ObtenerClienteXId(mng As ClienteManagement)
        Console.WriteLine("--------Obtener cliente por id--------")
        Console.WriteLine("Digite el id del cliente: ")
        Dim id = Console.ReadLine()
        Dim cliente As Cliente
        cliente.Id_Cliente = id
        cliente = mng.RetrieveById(cliente)
        If cliente IsNot Nothing Then
            Console.WriteLine(cliente.GetEntityInformation())
        Else
            Console.WriteLine("No se encontró un cliente con ese id")
        End If

    End Function

    Public Function ReturnClienteXId(mng As ClienteManagement) As Cliente
        Console.WriteLine("--------Obtener cliente por id--------")
        Console.WriteLine("Digite el id del cliente: ")
        Dim id = Console.ReadLine()
        Dim cliente As Cliente
        cliente.Id_Cliente = id
        cliente = mng.RetrieveById(cliente)
        If cliente IsNot Nothing Then
            Return cliente
        Else
            Console.WriteLine("No se encontró un cliente con ese id")
        End If

    End Function

    Public Function ActualizarCliente(mng As ClienteManagement)
        Console.WriteLine("------Actualizar cliente------")
        Console.WriteLine("Puede actualizar todos los datos o solo los que desee. Si no desea cambiar un dato, digite el dato registrado")
        Console.WriteLine("Digite el id del cliente: ")
        Dim id = Console.ReadLine()
        Dim cliente As Cliente
        cliente.Id_Cliente = id
        cliente = mng.RetrieveById(cliente)
        If cliente IsNot Nothing Then
            Console.WriteLine(cliente.GetEntityInformation())
            Console.WriteLine("Digite una nueva cédula, la cedula actual es " + cliente.Cedula)
            cliente.Cedula = Console.ReadLine()
            Console.WriteLine("Digite un nuevo nombre, el actual es " + cliente.Nombre)
            cliente.Nombre = Console.ReadLine()
            Console.WriteLine("Digite un nuevo apellido, el actual es " + cliente.Apellido)
            cliente.Apellido = Console.ReadLine()
            Console.WriteLine("Digite una nueva fecha de nacimiento (YYYY-MM-DD), la fecha actual es " + cliente.FechaNac)
            Dim fechaNac = Console.ReadLine()
            cliente.FechaNac = Convert.ToDateTime(fechaNac)
            Console.WriteLine("Digite una edad nueva, la edad actual es " + cliente.Edad)
            Dim edad = Console.ReadLine()
            cliente.Edad = Convert.ToInt32(edad)
            Console.WriteLine("Digite un nuevo estado civil, el actual es " + cliente.EstadoCivil)
            cliente.EstadoCivil = Console.ReadLine()
            Console.WriteLine("Digite un nuevo genero, el actual es " + cliente.Genero)
            cliente.Genero = Console.ReadLine()

            mng.Update(cliente)
            Console.WriteLine("Cliente actualizado")

        Else
            Console.WriteLine("No se encontró un cliente con ese id")
        End If

    End Function

    Public Function EliminarCliente(mng As ClienteManagement)
        Console.WriteLine("--------Eliminar cliente--------")
        Console.WriteLine("Digite el id del cliente: ")
        Dim id = Console.ReadLine()
        Dim cliente As Cliente
        cliente.Id_Cliente = id
        cliente = mng.RetrieveById(cliente)

        If cliente IsNot Nothing Then

            Console.WriteLine(cliente.GetEntityInformation())
            Console.WriteLine("Desea eliminarlo? S/N")
            Dim delete = Console.ReadLine()

            If delete.Equals("S", StringComparison.CurrentCultureIgnoreCase) Then
                mng.Delete(cliente)
                Console.WriteLine("Cliente eliminado")
            End If

        Else
            Console.WriteLine("No se encontró un cliente con ese id")
        End If

    End Function

    '---FIN FUNCIONES CLIENTE---

    '---FUNCIONES CREDITO---
    Public Function MenuCredito(mngCliente As ClienteManagement, mng As CreditoManagement, credito As Credito)
        Console.WriteLine("Menu de creditos")
        Console.WriteLine("1. Crear credito")
        Console.WriteLine("2. Obtener todos los creditos")
        Console.WriteLine("3. Obtener credito por id")
        Console.WriteLine("4. Actualizar credito")
        Console.WriteLine("5. Eliminar credito")
        Console.WriteLine("6. Salir")

        Console.WriteLine("Seleccione una opcion: ")
        Dim opcion As String = Console.ReadLine()

        Select Case opcion
            Case 1
                CrearCredito(mng, mngCliente, credito)
            Case 2
                ObtenerCreditos(mng)
            Case 3
                ObtenerCreditoXId()
            Case 4
                ActualizarCredito()
            Case 5
                EliminarCredito()
            Case 6
                Exit Select
            Case Else
                Debug.WriteLine("No selecciono una opcion valida")
        End Select

    End Function

    Public Function CrearCredito(mng As CreditoManagement, mngCliente As ClienteManagement, credito As Credito)
        Console.WriteLine("--------Crear credito--------")
        Dim cliente = ReturnClienteXId(mngCliente)


        Console.WriteLine("Digite el monto, tasa, nombre, cuota, fecha inicio(YYYY-MM-DD), estado y saldo de operacion separados por coma y sin espacio")
        Dim infoCredito = Console.ReadLine()
        Dim arrayCredito = infoCredito.Split(",")
        arrayCredito.Append("," + cliente.Id_Cliente)
        credito = New Entidades.Credito(arrayCredito)
        mng.Create(credito)

        Console.WriteLine("Credito creado")

    End Function

    Public Function ObtenerCreditos(mng As CreditoManagement)
        Console.WriteLine("--------Obtener creditos--------")
        Dim creditos = mng.RetrieveAll()
        Dim count = 0
        Dim c As Credito

        For Each c In creditos
            count += 1
            Console.WriteLine(count + " - " + c.GetEntityInformation())
        Next

    End Function

    Public Function ObtenerCreditoXId(mng As ClienteManagement)
        Console.WriteLine("--------Obtener cliente por id--------")
        Console.WriteLine("Digite el id del cliente: ")
        Dim id = Console.ReadLine()
        Dim cliente As Cliente
        cliente.Id_Cliente = id
        cliente = mng.RetrieveById(cliente)
        If cliente IsNot Nothing Then
            Console.WriteLine(cliente.GetEntityInformation())
        Else
            Console.WriteLine("No se encontró un cliente con ese id")
        End If

    End Function

    Public Function ActualizarCredito(mng As ClienteManagement)
        Console.WriteLine("------Actualizar cliente------")
        Console.WriteLine("Puede actualizar todos los datos o solo los que desee. Si no desea cambiar un dato, digite el dato registrado")
        Console.WriteLine("Digite el id del cliente: ")
        Dim id = Console.ReadLine()
        Dim cliente As Cliente
        cliente.Id_Cliente = id
        cliente = mng.RetrieveById(cliente)
        If cliente IsNot Nothing Then
            Console.WriteLine(cliente.GetEntityInformation())
            Console.WriteLine("Digite una nueva cédula, la cedula actual es " + cliente.Cedula)
            cliente.Cedula = Console.ReadLine()
            Console.WriteLine("Digite un nuevo nombre, el actual es " + cliente.Nombre)
            cliente.Nombre = Console.ReadLine()
            Console.WriteLine("Digite un nuevo apellido, el actual es " + cliente.Apellido)
            cliente.Apellido = Console.ReadLine()
            Console.WriteLine("Digite una nueva fecha de nacimiento (YYYY-MM-DD), la fecha actual es " + cliente.FechaNac)
            Dim fechaNac = Console.ReadLine()
            cliente.FechaNac = Convert.ToDateTime(fechaNac)
            Console.WriteLine("Digite una edad nueva, la edad actual es " + cliente.Edad)
            Dim edad = Console.ReadLine()
            cliente.Edad = Convert.ToInt32(edad)
            Console.WriteLine("Digite un nuevo estado civil, el actual es " + cliente.EstadoCivil)
            cliente.EstadoCivil = Console.ReadLine()
            Console.WriteLine("Digite un nuevo genero, el actual es " + cliente.Genero)
            cliente.Genero = Console.ReadLine()

            mng.Update(cliente)
            Console.WriteLine("Cliente actualizado")

        Else
            Console.WriteLine("No se encontró un cliente con ese id")
        End If

    End Function

    Public Function EliminarCredito(mng As ClienteManagement)
        Console.WriteLine("--------Eliminar cliente--------")
        Console.WriteLine("Digite el id del cliente: ")
        Dim id = Console.ReadLine()
        Dim cliente As Cliente
        cliente.Id_Cliente = id
        cliente = mng.RetrieveById(cliente)

        If cliente IsNot Nothing Then

            Console.WriteLine(cliente.GetEntityInformation())
            Console.WriteLine("Desea eliminarlo? S/N")
            Dim delete = Console.ReadLine()

            If delete.Equals("S", StringComparison.CurrentCultureIgnoreCase) Then
                mng.Delete(cliente)
                Console.WriteLine("Cliente eliminado")
            End If

        Else
            Console.WriteLine("No se encontró un cliente con ese id")
        End If

    End Function
    '---FIN FUNCIONES CREDITO---

    '---FUNCIONES CUENTA---
    Public Function MenuCuenta(mngCliente As ClienteManagement)
        Console.WriteLine("Menu de cuentas")
        Console.WriteLine("1. Crear cuenta")
        Console.WriteLine("2. Obtener todos los cuentas")
        Console.WriteLine("3. Obtener cuenta por id")
        Console.WriteLine("4. Actualizar cuenta")
        Console.WriteLine("5. Eliminar cuenta")
        Console.WriteLine("6. Salir")

        Console.WriteLine("Seleccione una opcion: ")
        Dim opcion As String = Console.ReadLine()

        Select Case opcion
            Case 1
                CrearCuenta(mngCliente)
            Case 2
                ObtenerCuentas()
            Case 3
                ObtenerCuentaXId()
            Case 4
                ActualizarCuenta()
            Case 5
                EliminarCuenta()
            Case 6
                Exit Select
            Case Else
                Debug.WriteLine("No selecciono una opcion valida")
        End Select

    End Function

    '---FIN FUNCIONES CUENTA

    '---FUNCIONES DIRECCION---
    Public Function MenuDireccion()
        Console.WriteLine("Menu de direcciones")
        Console.WriteLine("1. Obtener todos las direcciones")
        Console.WriteLine("2. Obtener direccion por id")
        Console.WriteLine("3. Actualizar direccion")
        Console.WriteLine("4. Eliminar direccion")
        Console.WriteLine("5. Salir")

        Console.WriteLine("Seleccione una opcion: ")
        Dim opcion As String = Console.ReadLine()

        Select Case opcion
            Case 1
                ObtenerDirecciones()
            Case 2
                ObtenerDireccionXId()
            Case 3
                ActualizarDireccion()
            Case 4
                EliminarDireccion
            Case 5
                Exit Select
            Case Else
                Debug.WriteLine("No selecciono una opcion valida")
        End Select

    End Function

    '---FIN FUNCIONES DIRECCION---

End Module
