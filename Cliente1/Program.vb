Imports Entidades
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
                    MenuCredito(cliente_mng, credito_mng, credito)
                Case 3
                    MenuCuenta(cliente_mng, cuenta_mng, cuenta)
                Case 4
                    MenuDireccion(direccion_mng)
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
                ObtenerCreditoXId(mng)
            Case 4
                ActualizarCredito(mng)
            Case 5
                EliminarCredito(mng)
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

    Public Function ObtenerCreditoXId(mng As CreditoManagement)
        Console.WriteLine("--------Obtener credito por id--------")
        Console.WriteLine("Digite el id del credito: ")
        Dim id = Console.ReadLine()
        Dim credito As Credito
        credito.Id_Credito = id
        credito = mng.RetrieveById(credito)

        If credito IsNot Nothing Then
            Console.WriteLine(credito.GetEntityInformation())
        Else
            Console.WriteLine("No se encontró un credito con ese id")
        End If

    End Function

    Public Function ActualizarCredito(mng As CreditoManagement)
        Console.WriteLine("------Actualizar credito------")
        Console.WriteLine("Puede actualizar todos los datos o solo los que desee. Si no desea cambiar un dato, digite el dato registrado")
        Console.WriteLine("Digite el id del credito: ")
        Dim id = Console.ReadLine()
        Dim credito As Credito
        credito.Id_Credito = id
        credito = mng.RetrieveById(credito)

        If credito IsNot Nothing Then
            Console.WriteLine(credito.GetEntityInformation())
            Console.WriteLine("Digite un nuevo monto, el monto actual es " + credito.Monto)
            Dim monto = Console.ReadLine()
            credito.Monto = Convert.ToDouble(monto)
            Console.WriteLine("Digite una nueva tasa, la tasa actual es " + credito.Tasa)
            Dim tasa = Console.ReadLine()
            credito.Tasa = Convert.ToDouble(tasa)
            Console.WriteLine("Digite un nuevo nombre, el actual es " + credito.Nombre)
            credito.Nombre = Console.ReadLine()
            Console.WriteLine("Digite una nueva cuota, la cuota actual es " + credito.Cuota)
            Dim cuota = Console.ReadLine()
            credito.Cuota = Convert.ToDouble(cuota)
            Console.WriteLine("Digite una nueva fecha de inicio (YYYY-MM-DD), la fecha actual es " + credito.FechaInicio)
            Dim fechaInicio = Console.ReadLine()
            credito.FechaInicio = Convert.ToDateTime(fechaInicio)
            Console.WriteLine("Digite un nuevo estado, el actual es " + credito.Estado)
            credito.Estado = Console.ReadLine()
            Console.WriteLine("Digite un nuevo saldo de operacion, el saldo actual es " + credito.SaldoOperacion)
            Dim saldoOp = Console.ReadLine()
            credito.SaldoOperacion = Convert.ToDouble(saldoOp)

            mng.Update(credito)
            Console.WriteLine("Credito actualizado")

        Else
            Console.WriteLine("No se encontró un credito con ese id")
        End If

    End Function

    Public Function EliminarCredito(mng As CreditoManagement)
        Console.WriteLine("--------Eliminar credito--------")
        Console.WriteLine("Digite el id del credito: ")
        Dim id = Console.ReadLine()
        Dim credito As Credito
        credito.Id_Credito = id
        credito = mng.RetrieveById(credito)

        If credito IsNot Nothing Then

            Console.WriteLine(credito.GetEntityInformation())
            Console.WriteLine("Desea eliminarlo? S/N")
            Dim delete = Console.ReadLine()

            If delete.Equals("S", StringComparison.CurrentCultureIgnoreCase) Then
                mng.Delete(credito)
                Console.WriteLine("Credito eliminado")
            End If

        Else
            Console.WriteLine("No se encontró un credito con ese id")
        End If

    End Function
    '---FIN FUNCIONES CREDITO---

    '---FUNCIONES CUENTA---
    Public Function MenuCuenta(mngCliente As ClienteManagement, mng As CuentaManagement, cuenta As Cuenta)
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
                CrearCuenta(mng, mngCliente, cuenta)
            Case 2
                ObtenerCuentas(mng)
            Case 3
                ObtenerCuentaXId(mng)
            Case 4
                ActualizarCuenta(mng)
            Case 5
                EliminarCuenta(mng)
            Case 6
                Exit Select
            Case Else
                Debug.WriteLine("No selecciono una opcion valida")
        End Select

    End Function

    Public Function CrearCuenta(mng As CuentaManagement, mngCliente As ClienteManagement, cuenta As Cuenta)
        Console.WriteLine("--------Crear cuenta-------")
        Dim cliente = ReturnClienteXId(mngCliente)


        Console.WriteLine("Digite el nombre, moneda y saldo de la cuenta separados por coma y sin espacio")
        Dim infoCuenta = Console.ReadLine()
        Dim arrayCuenta = infoCuenta.Split(",")
        arrayCuenta.Append("," + cliente.Id_Cliente)
        cuenta = New Entidades.Cuenta(arrayCuenta)
        mng.Create(cuenta)

        Console.WriteLine("Cuenta creada")

    End Function

    Public Function ObtenerCuentas(mng As CuentaManagement)
        Console.WriteLine("--------Obtener cuentas--------")
        Dim cuentas = mng.RetrieveAll()
        Dim count = 0
        Dim c As Cuenta

        For Each c In cuentas
            count += 1
            Console.WriteLine(count + " - " + c.GetEntityInformation())
        Next

    End Function

    Public Function ObtenerCuentaXId(mng As CuentaManagement)
        Console.WriteLine("--------Obtener cuenta por id--------")
        Console.WriteLine("Digite el id de la cuenta: ")
        Dim id = Console.ReadLine()
        Dim cuenta As Cuenta
        cuenta.Id_Cuenta = id
        cuenta = mng.RetrieveById(cuenta)

        If cuenta IsNot Nothing Then
            Console.WriteLine(cuenta.GetEntityInformation())
        Else
            Console.WriteLine("No se encontró una cuenta con ese id")
        End If

    End Function

    Public Function ActualizarCuenta(mng As CuentaManagement)
        Console.WriteLine("------Actualizar cuenta------")
        Console.WriteLine("Puede actualizar todos los datos o solo los que desee. Si no desea cambiar un dato, digite el dato registrado")
        Console.WriteLine("Digite el id de la cuenta: ")
        Dim id = Console.ReadLine()
        Dim cuenta As Cuenta
        cuenta.Id_Cuenta = id
        cuenta = mng.RetrieveById(cuenta)

        If cuenta IsNot Nothing Then
            Console.WriteLine(cuenta.GetEntityInformation())
            Console.WriteLine("Digite un nuevo nombre, el actual es " + cuenta.Nombre)
            cuenta.Nombre = Console.ReadLine()
            Console.WriteLine("Digite una nueva moneda, la moneda actual es " + cuenta.Moneda)
            cuenta.Moneda = Console.ReadLine()
            Console.WriteLine("Digite un nuevo saldo, el saldo actual es " + cuenta.Saldo)
            Dim saldo = Console.ReadLine()
            cuenta.Saldo = Convert.ToDouble(saldo)

            mng.Update(cuenta)
            Console.WriteLine("Cuenta actualizada")

        Else
            Console.WriteLine("No se encontró una cuenta con ese id")
        End If

    End Function

    Public Function EliminarCuenta(mng As CuentaManagement)
        Console.WriteLine("--------Eliminar cuenta--------")
        Console.WriteLine("Digite el id de la cuenta: ")
        Dim id = Console.ReadLine()
        Dim cuenta As Cuenta
        cuenta.Id_Cuenta = id
        cuenta = mng.RetrieveById(cuenta)

        If cuenta IsNot Nothing Then

            Console.WriteLine(cuenta.GetEntityInformation())
            Console.WriteLine("Desea eliminarla? S/N")
            Dim delete = Console.ReadLine()

            If delete.Equals("S", StringComparison.CurrentCultureIgnoreCase) Then
                mng.Delete(cuenta)
                Console.WriteLine("Cuenta eliminado")
            End If

        Else
            Console.WriteLine("No se encontró un credito con ese id")
        End If

    End Function

    '---FIN FUNCIONES CUENTA

    '---FUNCIONES DIRECCION---
    Public Function MenuDireccion(mng As DireccionManagement)
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
                ObtenerDirecciones(mng)
            Case 2
                ObtenerDireccionXId(mng)
            Case 3
                ActualizarDireccion(mng)
            Case 4
                EliminarDireccion(mng)
            Case 5
                Exit Select
            Case Else
                Debug.WriteLine("No selecciono una opcion valida")
        End Select

    End Function


    Public Function ObtenerDirecciones(mng As DireccionManagement)
        Console.WriteLine("--------Obtener direcciones--------")
        Dim direcciones = mng.RetrieveAll()
        Dim count = 0
        Dim d As Direccion

        For Each d In direcciones
            count += 1
            Console.WriteLine(count + " - " + d.GetEntityInformation())
        Next

    End Function

    Public Function ObtenerDireccionXId(mng As DireccionManagement)
        Console.WriteLine("--------Obtener direccion por id--------")
        Console.WriteLine("Digite el id de la direccion: ")
        Dim id = Console.ReadLine()
        Dim direccion As Direccion
        direccion.Id_Direccion = id
        direccion = mng.RetrieveById(direccion)

        If direccion IsNot Nothing Then
            Console.WriteLine(direccion.GetEntityInformation())
        Else
            Console.WriteLine("No se encontró una direccion con ese id")
        End If

    End Function

    Public Function ActualizarDireccion(mng As DireccionManagement)
        Console.WriteLine("------Actualizar direccion------")
        Console.WriteLine("Puede actualizar todos los datos o solo los que desee. Si no desea cambiar un dato, digite el dato registrado")
        Console.WriteLine("Digite el id de la direccion: ")
        Dim id = Console.ReadLine()
        Dim direccion As Direccion
        direccion.Id_Direccion = id
        direccion = mng.RetrieveById(direccion)

        If direccion IsNot Nothing Then
            Console.WriteLine(direccion.GetEntityInformation())
            Console.WriteLine("Digite una nueva provincia, la provincia actual es " + direccion.Provincia)
            Dim provincia = Console.ReadLine()
            Console.WriteLine("Digite un nuevo canton, el actual es " + direccion.Canton)
            Dim canton = Console.ReadLine()
            Console.WriteLine("Digite un nuevo distrito, el actual es " + direccion.Distrito)
            Dim distrito = Console.ReadLine()

            mng.Update(direccion)
            Console.WriteLine("Direccion actualizada")

        Else
            Console.WriteLine("No se encontró una direccion con ese id")
        End If

    End Function

    Public Function EliminarDireccion(mng As DireccionManagement)
        Console.WriteLine("--------Eliminar direccion--------")
        Console.WriteLine("Digite el id de la direccion: ")
        Dim id = Console.ReadLine()
        Dim direccion As Direccion
        direccion.Id_Direccion = id
        direccion = mng.RetrieveById(direccion)

        If direccion IsNot Nothing Then

            Console.WriteLine(direccion.GetEntityInformation())
            Console.WriteLine("Desea eliminarla? S/N")
            Dim delete = Console.ReadLine()

            If delete.Equals("S", StringComparison.CurrentCultureIgnoreCase) Then
                mng.Delete(direccion)
                Console.WriteLine("Direccion eliminada")
            End If

        Else
            Console.WriteLine("No se encontró una direccion con ese id")
        End If

    End Function

    '---FIN FUNCIONES DIRECCION---

End Module
