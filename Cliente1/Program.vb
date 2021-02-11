Imports Entidades
Module Program

    Sub Main()

    End Sub

    Public Shared Function Run()
        cliente_mng = New ClienteManagement()
        cuenta_mng = New CuentaManagement()
        credito_mng = New CreditoManagement()
        direccion_mng = New DireccionManagement()

        cliente = New Entidades.Cliente()
        cuenta = New Entidades.Cuenta()
        credito = New Entidades.Credito()
        direccion = New Entidades.Direccion()
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
                MenuCliente(direccion_mng, cliente_mng)
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


    End Function

    '---FUNCIONES DE CLIENTE---
    Public Function MenuCliente(mng As DireccionManagement, mngCliente As ClienteManagement)
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
                CrearCliente(direccion_mng, mngCliente)
            Case 2
                ObtenerClientes()
            Case 3
                ObtenerClienteXId()
            Case 4
                ActualizarCliente()
            Case 5
                EliminarCliente()
            Case 6
                Exit Select
            Case Else
                Debug.WriteLine("No selecciono una opcion valida")
        End Select

    End Function

    Public Function CrearCliente(mng As DireccionManagement, mngCliente As ClienteManagement)
        Console.WriteLine("--------Crear cliente--------")
        Console.WriteLine("Digite la provincia, canton y distrito separados por coma")
        Dim infoDireccion As String = Console.ReadLine()
        Dim arrayDireccion As String = infoDireccion.Split(",")
        direccion = New Entidades.Direccion(arrayDireccion)
        mng.Create(direccion)

        Dim idDireccion As Integer = mng.RetrieveIdentity()

        Console.WriteLine("Digite la cedula, nombre, apellido, fechaNac(YYYY-MM-DD), edad, estado civil y genero separados por coma")
        Dim infoCliente As String = Console.ReadLine()
        Dim arrayCliente As String = infoDireccion.Split(",")
        arrayCliente.Append("," + idDireccion)
        cliente = New Entidades.Cliente(arrayCliente)
        mngCliente.Create(cliente)

        Console.WriteLine("Cliente creado")

    End Function

    '---FIN FUNCIONES CLIENTE---

    '---FUNCIONES CREDITO---
    Public Function MenuCredito(mngCliente As ClienteManagement)
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
                CrearCredito(mngCliente)
            Case 2
                ObtenerCreditos()
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
