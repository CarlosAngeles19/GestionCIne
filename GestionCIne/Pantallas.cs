using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCine
{
    internal class Pantallas
    {
        // Diccionarios para almacenar los usuarios por rol
        static Dictionary<string, string> usuarios = new Dictionary<string, string>();       // Clientes
        static Dictionary<string, string> trabajadores = new Dictionary<string, string>();  // Trabajadores
        static Dictionary<string, string> administradores = new Dictionary<string, string>(); // Administradores


        // Pantalla principal con las opciones de rol
        public static int PantallaPrincipal()
        {
            Console.Clear();
            string texto = "=====================\n" +
                           "CINE MAX\n" +
                           "=====================\n" +
                           "1: Rol de cliente\n" +
                           "2: Rol de trabajador\n" +
                           "3: Rol de administrador\n" +
                           "4: Salir\n" +
                           "=====================";
            Console.WriteLine(texto);
            return Operaciones.getEntero("Ingrese su rol: ", texto);
        }

        // Método para registrar un nuevo administrador
        public static void RegistrarAdministracion()
        {
            Console.Clear();
            Console.WriteLine("================================\n" +
                              "Registro de Administrador\n" +
                              "================================");

            string nombreAdmin = Operaciones.getTextoPantalla("Ingrese el nombre del administrador: ");
            if (string.IsNullOrWhiteSpace(nombreAdmin) || administradores.ContainsKey(nombreAdmin))
            {
                Console.WriteLine("El nombre del administrador no es válido o ya existe.");
                Console.ReadKey();
                return;
            }

            string contraseña = Operaciones.getTextoPantalla("Ingrese la contraseña: ");
            if (string.IsNullOrWhiteSpace(contraseña))
            {
                Console.WriteLine("La contraseña no puede estar vacía.");
                Console.ReadKey();
                return;
            }

            // Agregar al diccionario de administradores
            administradores.Add(nombreAdmin, contraseña);
            Console.WriteLine("Administrador registrado con éxito.");
            Console.ReadKey();
        }


        // Método para iniciar sesión de administrador
        public static void IniciarSesionAdmin()
        {
            Console.Clear();
            Console.WriteLine("================================\n" +
                              "Iniciar Sesión (Administrador)\n" +
                              "================================");

            string nombreAdmin = Operaciones.getTextoPantalla("Ingrese su nombre de administrador: ");
            if (administradores.ContainsKey(nombreAdmin))
            {
                string contraseña = Operaciones.getTextoPantalla("Ingrese su contraseña: ");
                if (administradores[nombreAdmin] == contraseña)
                {
                    Console.WriteLine("Inicio de sesión exitoso.");

                }
                else
                {
                    Console.WriteLine("Contraseña incorrecta.");
                }
            }

            else
            {
                Console.WriteLine("El administrador no existe.");
            }

            Console.WriteLine("Presione cualquier tecla para regresar al menú.");
            Console.ReadKey();
        }

        // Método para agregar una película

        static List<Pelicula> peliculas = new List<Pelicula>();

        public static void AgregarPelicula()
        {
            Console.Clear();
            Console.WriteLine("================================\n" +
                              "Agregar Película\n" +
                              "================================");

            string nombrePelicula = Operaciones.getTextoPantalla("Ingrese el nombre de la película: ");
            bool existe = false;
            for (int i = 0; i < peliculas.Count; i++)
            {
                if (peliculas[i].Nombre == nombrePelicula)
                {
                    existe = true;
                    break;
                }
            }

            if (string.IsNullOrWhiteSpace(nombrePelicula) || existe)
            {
                Console.WriteLine("El nombre de la película no es válido o ya existe.");
                Console.ReadKey();
                return;
            }

            string horario = Operaciones.getTextoPantalla("Ingrese el horario de la película: ");
            if (string.IsNullOrWhiteSpace(horario))
            {
                Console.WriteLine("El horario no puede estar vacío.");
                Console.ReadKey();
                return;
            }

            decimal precio = Operaciones.getDecimal("Ingrese el precio de la película: ");

            peliculas.Add(new Pelicula(nombrePelicula, horario, precio));
            Console.WriteLine("Película agregada con éxito.");
            Console.ReadKey();
        }

        static List<Pelicula> peliculasSeleccionadas = new List<Pelicula>(); //Seleccion de Pelicula

        public static void SeleccionarPelicula()
        {
            Console.Clear();
            Console.WriteLine("================================\n" +
                              "Seleccionar Película\n" +
                              "================================");

            ListarPeliculas(); // Mostrar la lista de películas disponibles

            Console.WriteLine("\nSeleccione el número de la película que desea seleccionar o 0 para volver al menú:");
            int opcion = Operaciones.getEntero("Ingrese su opción: ", "Opción no válida. Intente nuevamente.");

            if (opcion == 0)
                return;

            if (opcion > 0 && opcion <= peliculas.Count)
            {
                peliculasSeleccionadas.Add(peliculas[opcion - 1]);
                Console.WriteLine("Película seleccionada con éxito.");
            }
            else
            {
                Console.WriteLine("Opción no válida.");
            }

            Console.ReadKey();
        }

        // Método para actualizar una película
        public static void ActualizarPelicula()
        {
            Console.Clear();
            Console.WriteLine("================================\n" +
                              "Actualizar Película\n" +
                              "================================");

            string nombrePelicula = Operaciones.getTextoPantalla("Ingrese el nombre de la película a actualizar: ");
            Pelicula peliculaActualizar = null;

            for (int i = 0; i < peliculas.Count; i++)
            {
                if (peliculas[i].Nombre == nombrePelicula)
                {
                    peliculaActualizar = peliculas[i];
                    break;
                }
            }

            if (peliculaActualizar == null)
            {
                Console.WriteLine("La película no existe.");
                Console.ReadKey();
                return;
            }

            string nuevoHorario = Operaciones.getTextoPantalla("Ingrese el nuevo horario de la película: ");
            decimal nuevoPrecio = Operaciones.getDecimal("Ingrese el nuevo precio de la película: ");

            peliculaActualizar.Horario = nuevoHorario;
            peliculaActualizar.Precio = nuevoPrecio;
            Console.WriteLine("Película actualizada con éxito.");
            Console.ReadKey();
        }


        // Método para eliminar una película
        public static void EliminarPelicula()
        {
            Console.Clear();
            Console.WriteLine("================================\n" +
                              "Eliminar Película\n" +
                              "================================");

            string nombrePelicula = Operaciones.getTextoPantalla("Ingrese el nombre de la película a eliminar: ");
            Pelicula peliculaEliminar = null;

            for (int i = 0; i < peliculas.Count; i++)
            {
                if (peliculas[i].Nombre == nombrePelicula)
                {
                    peliculaEliminar = peliculas[i];
                    break;
                }
            }

            if (peliculaEliminar != null)
            {
                peliculas.Remove(peliculaEliminar);
                Console.WriteLine("Película eliminada con éxito.");
            }
            else
            {
                Console.WriteLine("La película no existe.");
            }

            Console.ReadKey();
        }

        //Eliminar pelicula seleccionada
        public static void EliminarSeleccion()
        {
            Console.Clear();
            Console.WriteLine("================================\n" +
                              "Eliminar Selección\n" +
                              "================================");

            if (peliculasSeleccionadas.Count == 0)
            {
                Console.WriteLine("No hay películas seleccionadas.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Películas seleccionadas:");
            for (int i = 0; i < peliculasSeleccionadas.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {peliculasSeleccionadas[i].Nombre}");
            }

            Console.WriteLine("\nSeleccione el número de la película que desea eliminar o 0 para volver al menú:");
            int opcion = Operaciones.getEntero("Ingrese su opción: ", "Opción no válida. Intente nuevamente.");

            if (opcion == 0)
                return;

            if (opcion > 0 && opcion <= peliculasSeleccionadas.Count)
            {
                peliculasSeleccionadas.RemoveAt(opcion - 1);
                Console.WriteLine("Película eliminada de la selección con éxito.");
            }
            else
            {
                Console.WriteLine("Opción no válida.");
            }

            Console.ReadKey();
        }

        private static void CambiarSeleccion()
        {
            Console.Clear();
            Console.WriteLine("===============================\n" +
                              "Consultar o Eliminar Selección\n" +
                              "===============================");

            // Verifica si hay películas seleccionadas
            if (peliculasSeleccionadas.Count > 0)
            {
                Console.WriteLine("Películas seleccionadas:");
                for (int i = 0; i < peliculasSeleccionadas.Count; i++)
                {
                    Pelicula pelicula = peliculasSeleccionadas[i];
                    Console.WriteLine($"{i + 1}: {pelicula.Nombre}, Horario: {pelicula.Horario}, Precio: {pelicula.Precio:C}");
                }

                Console.WriteLine("\nSeleccione el número de la película que desea consultar o eliminar (0 para regresar):");

                int opcion = -1;
                while (opcion < 0 || opcion > peliculasSeleccionadas.Count)
                {
                    if (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 0 || opcion > peliculasSeleccionadas.Count)
                    {
                        Console.WriteLine("Opción no válida, intente de nuevo:");
                    }
                }

                if (opcion == 0)
                {
                    return; // Regresar al menú
                }

                // Eliminar la selección
                peliculasSeleccionadas.RemoveAt(opcion - 1);
                Console.WriteLine("Película eliminada correctamente.");
            }
            else
            {
                Console.WriteLine("No hay películas seleccionadas.");
            }

            Console.WriteLine("Presione cualquier tecla para regresar al menú.");
            Console.ReadKey();
        }

        // Método para listar todas las películas
        public static void ListarPeliculas(List<Pelicula> peliculas)
        {
            Console.Clear();
            Console.WriteLine("================================\n" +
                              "Listado de Películas\n" +
                              "================================");

            if (peliculas.Count > 0)
            {
                int i = 0;
                while (i < peliculas.Count)
                {
                    Pelicula pelicula = peliculas[i];
                    Console.WriteLine($"Nombre: {pelicula.Nombre}, Horario: {pelicula.Horario}, Precio: {pelicula.Precio:C}");
                    i++;
                }
            }
            else
            {
                Console.WriteLine("No hay películas registradas.");
            }

            Console.WriteLine("==============================");
            Console.WriteLine("Presione cualquier tecla para regresar al menú.");
            Console.ReadKey();
        }
        public static void ListarPeliculas()
        {
            Console.Clear();
            Console.WriteLine("================================\n" +
                              "Listado de Películas\n" +
                              "================================");

            if (peliculas.Count > 0)
            {
                for (int i = 0; i < peliculas.Count; i++)
                {
                    Pelicula pelicula = peliculas[i];
                    Console.WriteLine($"{i + 1}. Nombre: {pelicula.Nombre}, Horario: {pelicula.Horario}, Precio: {pelicula.Precio:C}");
                }

                Console.WriteLine("\nSeleccione el número de la película que desea ver o 0 para volver al menú:");

                // Validar la entrada del usuario
                int opcion = -1;
                while (opcion < 0 || opcion > peliculas.Count)
                {
                    if (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 0 || opcion > peliculas.Count)
                    {
                        Console.WriteLine("Opción no válida, intente de nuevo:");
                    }
                }

                // Opción es 0, si el usuario quiere regresar al menú
                if (opcion == 0)
                {
                    return;
                }

                // Mostrar detalles de la película seleccionada
                Pelicula peliculaSeleccionada = peliculas[opcion - 1];
                peliculasSeleccionadas.Add(peliculaSeleccionada); // Guardar la selección
                Console.Clear();
                Console.WriteLine($"Has seleccionado: \n" +
                                  $"Nombre: {peliculaSeleccionada.Nombre}\n" +
                                  $"Horario: {peliculaSeleccionada.Horario}\n" +
                                  $"Precio: {peliculaSeleccionada.Precio:C}\n" +
                                  "Elija su asiento");


                // Llamamos al método para seleccionar asiento
                SeleccionarAsiento(peliculaSeleccionada.Nombre, peliculaSeleccionada.Horario);

                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("No hay películas registradas.");

                Console.ReadKey();
            }
        }
        private static void SeleccionarAsiento(string pelicula, string horario)
        {
            Console.WriteLine("\n================================\n" +
                              $"Selecciona tu asiento para la película {pelicula} a las {horario}\n" +
                              "================================\n" +
                              "Asientos disponibles:\n" +
                              "================================");

            // Lista con 20 asientos disponibles organizados en filas
            List<string> asientos = new List<string>
            {
                  "A1", "A2", "A3", "A4", "A5",
                  "B1", "B2", "B3", "B4", "B5",
                  "C1", "C2", "C3", "C4", "C5",
                  "D1", "D2", "D3", "D4", "D5"
            };

            // Asignar un único color diferente al texto para todas las filas de asientos
            Console.ForegroundColor = ConsoleColor.Yellow; // Todas las filas de asientos en color amarillo

            // Mostrar los asientos en 4 columnas de 5 asientos
            for (int i = 0; i < asientos.Count; i++)
            {
                // Mostrar el número de asiento de forma organizada
                Console.Write($"{i + 1}: {asientos[i]} \t");

                // Después de cada 5 asientos, hacer un salto de línea
                if ((i + 1) % 5 == 0)
                {
                    Console.WriteLine();
                }
            }

            // Resetear el color de la consola a su estado original
            Console.ForegroundColor = ConsoleColor.Cyan;

            // Selección de asiento
            int asientoSeleccionado = -1;
            while (asientoSeleccionado < 1 || asientoSeleccionado > asientos.Count)
            {
                Console.Write("\nIngrese el número del asiento que desea: ");
                if (!int.TryParse(Console.ReadLine(), out asientoSeleccionado) || asientoSeleccionado < 1 || asientoSeleccionado > asientos.Count)
                {
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                }
            }

            // Confirmación del asiento seleccionado
            Console.Clear();
            Console.WriteLine("===============================\n" +
                              $"Asiento seleccionado: {asientos[asientoSeleccionado - 1]}\n" +
                              $"Película: {pelicula}\n" +
                              $"Horario: {horario}\n" +
                              "===============================\n" +
                              "Presione cualquier botón para regresar al menú.");
            Console.ReadKey(); // Pausa para que el usuario pueda leer antes de regresar al menú
        }

        // Método para gestionar películas
        public static void GestionarPeliculas()
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("=====================\n" +
                                  "Gestión de Películas\n" +
                                  "=====================\n" +
                                  "1: Agregar película\n" +
                                  "2: Actualizar película\n" +
                                  "3: Eliminar película\n" +
                                  "4: Listar películas\n" +
                                  "5: Regresar al menú de administrador\n");

                opcion = Operaciones.getEntero("Seleccione una opción: ", "Opción no válida. Intente nuevamente.");

                switch (opcion)
                {
                    case 1:
                        AgregarPelicula();
                        break;
                    case 2:
                        ActualizarPelicula();
                        break;
                    case 3:
                        EliminarPelicula();
                        break;
                    case 4:
                        ListarPeliculas();
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Opción no válida. Presione cualquier tecla para regresar al menú.");
                        Console.ReadKey();
                        break;
                }
            } while (opcion != 5);
        }
        // Menú del rol de cliente
        public static void MenuRolCliente()
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("=====================\n" +
                                  "Menú de Cliente\n" +
                                  "=====================\n" +
                                  "1: Registro Cliente\n" +   // Crear cuenta
                                  "2: Selección de Películas y Horarios\n" +
                                  "3: Eliminar Selección de Película\n" +
                                  "4: Regresar al menú principal\n");

                opcion = Operaciones.getEntero("Seleccione una opción: ", "Opción no válida. Intente nuevamente.");

                switch (opcion)
                {
                    case 1:
                        MenuClienteOpciones(); // Crear cuenta de cliente
                        break;
                    case 2:
                        ListarPeliculas(); // Mostrar información de las películas
                        break;
                    case 3:
                        CambiarSeleccion(); // Eliminar selección de película
                        break;
                    case 4:
                        return; // Regresar al menú principal
                    default:
                        Console.WriteLine("Opción no válida. Presione cualquier tecla para regresar al menú.");
                        Console.ReadKey();
                        break;
                }
            } while (opcion != 4);
        }
        
        // Submenú para la gestión de cuentas de clientes
        public static void MenuClienteOpciones()
        {
            while (true)
            {
                Console.Clear();
                string texto = "=====================\n" +
                               "Registro Cliente\n" +
                               "=====================\n" +
                               "1: Crear cuenta\n" +
                               "2: Iniciar sesión\n" +
                               "3: Actualizar cuenta\n" +
                               "4: Eliminar cuenta\n" +
                               "5: Volver al menú de Clientes\n" +
                               "=====================";
                Console.WriteLine(texto);

                int opcion = Operaciones.getEntero("Seleccione una opción: ", texto);

                switch (opcion)
                {
                    case 1:
                        RegistrarUsuario();
                        break;
                    case 2:
                        IniciarSesionCliente();
                        break;
                    case 3:
                        ActualizarUsuario();
                        break;
                    case 4:
                        EliminarUsuario();
                        break;
                    case 5:
                        return; // Volver al menú inicial de cliente
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        // Método para registrar un nuevo usuario (cliente)
        public static void RegistrarUsuario()
        {
            Console.Clear();
            Console.WriteLine("================================\n" +
                              "Registro de Usuario\n" +
                              "================================");

            string nombreUsuario = Operaciones.getTextoPantalla("Ingrese su nombre de usuario: ");
            if (string.IsNullOrWhiteSpace(nombreUsuario) || usuarios.ContainsKey(nombreUsuario))
            {
                Console.WriteLine("El nombre de usuario no es válido o ya existe.");
                Console.ReadKey();
                return;
            }

            string contraseña = Operaciones.getTextoPantalla("Ingrese su contraseña: ");
            if (string.IsNullOrWhiteSpace(contraseña))
            {
                Console.WriteLine("La contraseña no puede estar vacía.");
                Console.ReadKey();
                return;
            }

            // Agregar al diccionario de usuarios
            usuarios.Add(nombreUsuario, contraseña);
            Console.WriteLine("Usuario registrado con éxito.");
            Console.ReadKey();
        }

        // Método para iniciar sesión de cliente
        public static void IniciarSesionCliente()
        {
            Console.Clear();
            Console.WriteLine("================================\n" +
                              "Iniciar Sesión (Cliente)\n" +
                              "================================");

            string nombreUsuario = Operaciones.getTextoPantalla("Ingrese su nombre de usuario: ");
            if (usuarios.ContainsKey(nombreUsuario))
            {
                string contraseña = Operaciones.getTextoPantalla("Ingrese su contraseña: ");
                if (usuarios[nombreUsuario] == contraseña)
                {
                    Console.WriteLine("Inicio de sesión exitoso.");
                }
                else
                {
                    Console.WriteLine("Contraseña incorrecta.");
                }
            }
            else
            {
                Console.WriteLine("El usuario no existe.");
            }

            Console.WriteLine("Presione cualquier tecla para regresar al menú.");
            Console.ReadKey();
        }

        // Método para actualizar la cuenta de un usuario (cliente)
        public static void ActualizarUsuario()
        {
            Console.Clear();
            Console.WriteLine("================================\n" +
                              "Actualizar Usuario\n" +
                              "================================");

            string nombreUsuario = Operaciones.getTextoPantalla("Ingrese su nombre de usuario: ");
            if (usuarios.ContainsKey(nombreUsuario))
            {
                string nuevaContraseña = Operaciones.getTextoPantalla("Ingrese su nueva contraseña: ");
                if (string.IsNullOrWhiteSpace(nuevaContraseña))
                {
                    Console.WriteLine("La contraseña no puede estar vacía.");
                    Console.ReadKey();
                    return;
                }

                usuarios[nombreUsuario] = nuevaContraseña;
                Console.WriteLine("Cuenta actualizada con éxito.");
            }
            else
            {
                Console.WriteLine("El usuario no existe.");
            }

            Console.ReadKey();
        }

        // Método para eliminar la cuenta de un usuario (cliente)
        public static void EliminarUsuario()
        {
            Console.Clear();
            Console.WriteLine("================================\n" +
                              "Eliminar Usuario\n" +
                              "================================");

            string nombreUsuario = Operaciones.getTextoPantalla("Ingrese su nombre de usuario: ");
            if (usuarios.ContainsKey(nombreUsuario))
            {
                usuarios.Remove(nombreUsuario);
                Console.WriteLine("Usuario eliminado con éxito.");
            }
            else
            {
                Console.WriteLine("El usuario no existe.");
            }

            Console.ReadKey();
        }

        // Menú del rol de trabajador
        public static void MenuRolTrabajador()
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("=====================\n" +
                                  "Menú de Trabajador\n" +
                                  "=====================\n" +
                                  "1: Registro Trabajador\n" +              // Crear cuenta de trabajador
                                  "2: Selección de Películas y Horarios\n" + // Mostrar y seleccionar películas
                                  "3: Eliminar Selección de Película\n" + // Eliminar selección previa
                                  "4: Regresar al menú principal\n");

                opcion = Operaciones.getEntero("Seleccione una opción: ", "Opción no válida. Intente nuevamente.");

                switch (opcion)
                {
                    case 1:
                        MenuTrabajadorOpciones(); // Aquí el trabajador registra a un cliente
                        break;
                    case 2:
                        ListarPeliculas(); // Mostrar y seleccionar películas
                        break;
                    case 3:
                        CambiarSeleccion(); // Eliminar selección de película
                        break;
                    case 4:
                        return; // Regresar al menú principal
                    default:
                        Console.WriteLine("Opción no válida. Presione cualquier tecla para regresar al menú.");
                        Console.ReadKey();
                        break;
                }
            } while (opcion != 4);
        }

        // Submenú para la gestión de cuentas de trabajadores
        public static void MenuTrabajadorOpciones()
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("=====================\n" +
                                  "Registro Trabajador\n" +
                                  "=====================\n" +
                                  "1: Crear cuenta\n" +
                                  "2: Iniciar sesión\n" +
                                  "3: Actualizar cuenta\n" +
                                  "4: Eliminar cuenta\n" +
                                  "5: Volver al menú de Trabajador\n");

                opcion = Operaciones.getEntero("Seleccione una opción: ", "Opción no válida. Intente nuevamente.");

                switch (opcion)
                {
                    case 1:
                        RegistrarTrabajador(); // Crear cuenta de trabajador
                        break;
                    case 2:
                        IniciarSesionTrabajador(); // Iniciar sesión de trabajador
                        break;
                    case 3:
                        ActualizarTrabajador(); // Actualizar cuenta de trabajador
                        break;
                    case 4:
                        EliminarTrabajador(); // Eliminar cuenta de trabajador
                        break;
                    case 5:
                        return; // Volver al menú de trabajador
                    default:
                        Console.WriteLine("Opción no válida. Presione cualquier tecla para regresar al menú.");
                        Console.ReadKey();
                        break;
                }
            } while (opcion != 5);
        }

        // Método para registrar un nuevo trabajador
        public static void RegistrarTrabajador()
        {
            Console.Clear();
            Console.WriteLine("================================\n" +
                              "Registro de Trabajador\n" +
                              "================================");

            string nombreTrabajador = Operaciones.getTextoPantalla("Ingrese el nombre del trabajador: ");
            if (string.IsNullOrWhiteSpace(nombreTrabajador) || trabajadores.ContainsKey(nombreTrabajador))
            {
                Console.WriteLine("El nombre del trabajador no es válido o ya existe.");
                Console.ReadKey();
                return;
            }

            string contraseña = Operaciones.getTextoPantalla("Ingrese la contraseña: ");
            if (string.IsNullOrWhiteSpace(contraseña))
            {
                Console.WriteLine("La contraseña no puede estar vacía.");
                Console.ReadKey();
                return;
            }

            // Agregar al diccionario de trabajadores
            trabajadores.Add(nombreTrabajador, contraseña);
            Console.WriteLine("Trabajador registrado con éxito.");
            Console.ReadKey();
        }

        // Método para iniciar sesión de trabajador
        public static void IniciarSesionTrabajador()
        {
            Console.Clear();
            Console.WriteLine("================================\n" +
                              "Iniciar Sesión (Trabajador)\n" +
                              "================================");

            string nombreTrabajador = Operaciones.getTextoPantalla("Ingrese su nombre de trabajador: ");
            if (trabajadores.ContainsKey(nombreTrabajador))
            {
                string contraseña = Operaciones.getTextoPantalla("Ingrese su contraseña: ");
                if (trabajadores[nombreTrabajador] == contraseña)
                {
                    Console.WriteLine("Inicio de sesión exitoso.");
                }
                else
                {
                    Console.WriteLine("Contraseña incorrecta.");
                }
            }
            else
            {
                Console.WriteLine("El trabajador no existe.");
            }

            Console.WriteLine("Presione cualquier tecla para regresar al menú.");
            Console.ReadKey();
        }

        // Método para actualizar la cuenta de un trabajador
        public static void ActualizarTrabajador()
        {
            Console.Clear();
            Console.WriteLine("================================\n" +
                              "Actualizar Trabajador\n" +
                              "================================");

            string nombreTrabajador = Operaciones.getTextoPantalla("Ingrese su nombre de trabajador: ");
            if (trabajadores.ContainsKey(nombreTrabajador))
            {
                string nuevaContraseña = Operaciones.getTextoPantalla("Ingrese su nueva contraseña: ");
                if (string.IsNullOrWhiteSpace(nuevaContraseña))
                {
                    Console.WriteLine("La contraseña no puede estar vacía.");
                    Console.ReadKey();
                    return;
                }

                trabajadores[nombreTrabajador] = nuevaContraseña;
                Console.WriteLine("Cuenta de trabajador actualizada con éxito.");
            }
            else
            {
                Console.WriteLine("El trabajador no existe.");
            }

            Console.ReadKey();
        }

        // Método para eliminar la cuenta de un trabajador
        public static void EliminarTrabajador()
        {
            Console.Clear();
            Console.WriteLine("================================\n" +
                              "Eliminar Trabajador\n" +
                              "================================");

            string nombreTrabajador = Operaciones.getTextoPantalla("Ingrese el nombre del trabajador: ");
            if (trabajadores.ContainsKey(nombreTrabajador))
            {
                trabajadores.Remove(nombreTrabajador);
                Console.WriteLine("Trabajador eliminado con éxito.");
            }
            else
            {
                Console.WriteLine("El trabajador no existe.");
            }

            Console.ReadKey();
        }

        // Menú del rol de administrador
        public static void MenuRolAdminFun()
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("=====================\n" +
                                  "Menú de Administrador\n" +
                                  "=====================\n" +
                                  "1: Registrar administradores\n" +
                                  "2: Iniciar sesión\n" +
                                  "3: Mostrar usuarios registrados\n" +
                                  "4: Gestionar Películas, Horarios y Precios\n" +
                                  "5: Regresar al menú principal\n");

                opcion = Operaciones.getEntero("Seleccione una opción: ", "Opción no válida. Intente nuevamente.");

                switch (opcion)
                {
                    case 1:
                        RegistrarAdministracion();
                        break;
                    case 2:
                        IniciarSesionAdmin();
                        break;
                    case 3:
                        MostrarUsuarios();
                        break;
                    case 4:
                        GestionarPeliculas();
                        break;
                    case 0:
                       break;
                    
                      
                }
            } while (opcion != 5);
        }

        // Método para mostrar todos los usuarios registrados
        public static void MostrarUsuarios()
        {
            Console.Clear();
            Console.WriteLine("==============================");
            Console.WriteLine("USUARIOS REGISTRADOS");
            Console.WriteLine("==============================");

            // Mostrar lista de usuarios (clientes)
            Console.WriteLine("CLIENTES:");
            if (usuarios.Count > 0)
            {
                foreach (var usuario in usuarios.Keys)
                {
                    Console.WriteLine($"- {usuario}");
                }
            }
            else
            {
                Console.WriteLine("No hay usuarios registrados.");
            }

            // Mostrar lista de administradores
            Console.WriteLine("\nADMINISTRADORES:");
            if (administradores.Count > 0)
            {
                foreach (var admin in administradores.Keys)
                {
                    Console.WriteLine($"- {admin}");
                }
            }
            else
            {
                Console.WriteLine("No hay administradores registrados.");
            }

            // Mostrar lista de trabajadores
            Console.WriteLine("\nTRABAJADORES:");
            if (trabajadores.Count > 0)
            {
                foreach (var trabajador in trabajadores.Keys)
                {
                    Console.WriteLine($"- {trabajador}");
                }
            }
            else
            {
                Console.WriteLine("No hay trabajadores registrados.");
            }

            Console.WriteLine("==============================");
            Console.WriteLine("Presione cualquier tecla para regresar al menú.");
            Console.ReadKey();

           
        }
    }
}
