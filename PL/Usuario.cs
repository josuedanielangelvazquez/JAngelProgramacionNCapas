namespace PL
{
    public class Usuario
    {
        static public void Add()
        {
           

            ML.Usuario alumno = new ML.Usuario();
            Console.WriteLine("Ingrese 1 para ingresar datos || Ingrese 2 para leer los datos || Ingrese 3 para actualizar los datos || INgrese 4 para eliminar Datos");
            Console.WriteLine("Ingrese 5 para buscar un dato || Ingrese 6 para leer los datos || Ingrese 7 para actualizar los datos || INgrese 4 para eliminar Datos");
            int validacion;
            Console.WriteLine("¿Que desea?");
             validacion = int.Parse(Console.ReadLine());
            if (validacion == 1) 
            {

                Console.WriteLine("Ingrese los datos del Alumno");
                Console.WriteLine("INgrese el nombre: ");
                alumno.Nombre = Console.ReadLine();
                Console.WriteLine("INgrese el ApellidoPaterno: ");
                alumno.ApellidoPaterno = Console.ReadLine();
                Console.WriteLine("INgrese el ApellidoMaterno ");
                alumno.ApellidoMaterno = Console.ReadLine();
                 ML.Result result = BL.Usuario.Add(alumno);
                if (result.Correct)
                {
                    Console.WriteLine("Alumno agregado");
                }
                else
                {
                    Console.WriteLine("Alumno no agregado");
                }
            }
            if (validacion == 2)
            {
                ML.Result result = BL.Usuario.Read();

                foreach (ML.Usuario usuario in  result.Objects)
                {
                    Console.WriteLine("IdAlumno es: " + usuario.IdUsuario);
                    Console.WriteLine("Nombre es:" + usuario.Nombre);
                    Console.WriteLine("El Apellido Paterno es: " + usuario.ApellidoPaterno);
                    Console.WriteLine("El Apellido Materno es " + usuario.ApellidoMaterno);
                    Console.WriteLine("El Grupo del alumno es " + usuario.grupo);
                     
                }
            }
            if (validacion == 3)
            {

                Console.WriteLine("Ingrese los datos del Alumno");
                Console.WriteLine("Ingrese el id: ");
                alumno.IdUsuario = int.Parse(Console.ReadLine());
                Console.WriteLine("INgrese el Nombre de Usuario ");
                alumno.UserName = Console.ReadLine();
                Console.WriteLine("INgrese el nombre: ");
                alumno.Nombre = Console.ReadLine();
                Console.WriteLine("INgrese el ApellidoPaterno: ");
                alumno.ApellidoPaterno = Console.ReadLine();
                Console.WriteLine("INgrese el ApellidoMaterno ");
                alumno.ApellidoMaterno = Console.ReadLine();
                Console.WriteLine("INgrese el Email ");
                alumno.Email = Console.ReadLine();
                Console.WriteLine("INgrese el Password ");
                 alumno.Password = Console.ReadLine();
                Console.WriteLine("INgrese la Fecha de Nacimiento ");
                alumno.FechaNacimiento = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("INgrese el Sexo ");
                alumno.Sexo = char.Parse(Console.ReadLine());
                Console.WriteLine("INgrese el Telefono ");
                alumno.Telefono = Console.ReadLine();
                Console.WriteLine("INgrese el Celular ");
                alumno.Celular = Console.ReadLine();
                Console.WriteLine("INgrese el Curp ");
                alumno.Curp = Console.ReadLine();
               

                // ML.Result result =  BL.Usuario.UPDATE(alumno);
                ML.Result result = BL.Usuario.UPDATESP(alumno);
                if (result.Correct)
                {
                    Console.WriteLine("Usuario Actualizado"); 
                }
                else
                {
                    Console.WriteLine("Usuario No Actualizado");
                }
            }
            if (validacion == 4) {
                Console.WriteLine("Ingrese el Id del alumno a eliminar");
                int idalumno = int.Parse(Console.ReadLine());
                // ML.Result result =  BL.Usuario.DELETE(idalumno);
                ML.Result result = BL.Usuario.DELETESP(idalumno);

                if (result.Correct)
                {
                    Console.WriteLine("Uusario Eliminado");
                }
                else
                {
                    Console.WriteLine("USUARIO no eliminado");
                }
           
            }
            if (validacion == 5)
            {

                Console.WriteLine("Ingrese el Id del Alumno: ");
                int IdAlumno = int.Parse(Console.ReadLine());

                ML.Result result = BL.Usuario.GetById(IdAlumno);

                if (result.Correct)
                {
                    ML.Usuario alumno1 = (ML.Usuario)result.Object;
                    Console.WriteLine("El IdAlumno del alumno es: " + alumno1.IdUsuario);
                    Console.WriteLine("El Nombre del alumno es: " + alumno1.Nombre);
                    Console.WriteLine("El ApellidoPaterno del alumno es: " + alumno1.ApellidoPaterno);
                    Console.WriteLine("El ApellidoMaterno del alumno es: " + alumno1.ApellidoMaterno);
                    Console.WriteLine("---------------------------------------------");
                }
                else
                {
                    Console.WriteLine("Ocurrio un error" + result.ErrorMessage);
                }
            }
            if(validacion == 6)
            {

                Console.WriteLine("Ingrese el Id del Alumno: ");
                int IdAlumno = int.Parse(Console.ReadLine());
                ML.Result result = BL.Usuario.GetByIdsp(IdAlumno);

                if (result.Correct)
                {
                    ML.Usuario alumno1 = (ML.Usuario)result.Object;
                    Console.WriteLine("El IdAlumno del alumno es: " + alumno1.IdUsuario);
                    Console.WriteLine("El Nombre del alumno es: " + alumno1.Nombre);
                    Console.WriteLine("El ApellidoPaterno del alumno es: " + alumno1.ApellidoPaterno);
                    Console.WriteLine("El ApellidoMaterno del alumno es: " + alumno1.ApellidoMaterno);
                    Console.WriteLine("---------------------------------------------");
                }
                else
                {
                    Console.WriteLine("Ocurrio un Error" + result.ErrorMessage);
                }

            }
            if(validacion == 7)
            {
                ML.Result result = BL.Usuario.GetSP();

                if (result.Correct)
                {

                    foreach (ML.Usuario usuario in result.Objects)
                    {
                        Console.WriteLine("IdAlumno es: " + usuario.IdUsuario);
                        Console.WriteLine("Nombre es:" + usuario.Nombre);
                        Console.WriteLine("El Apellido Paterno es: " + usuario.ApellidoPaterno);
                        Console.WriteLine("El Apellido Materno es " + usuario.ApellidoMaterno);

                    }
                }
                else
                {
                    Console.WriteLine("Ocurrio un Error" + result.ErrorMessage);
                }
            }
            if(validacion == 8)
            {
                      Console.WriteLine("Ingrese los datos del Alumno");
                Console.WriteLine("INgrese el Nombre de Usuario ");
                alumno.UserName = Console.ReadLine();
                Console.WriteLine("INgrese el nombre: ");
                alumno.Nombre = Console.ReadLine();
                Console.WriteLine("INgrese el ApellidoPaterno: ");
                alumno.ApellidoPaterno = Console.ReadLine();
                Console.WriteLine("INgrese el ApellidoMaterno ");
                alumno.ApellidoMaterno = Console.ReadLine();
                Console.WriteLine("INgrese el Email ");
                alumno.Email = Console.ReadLine();
                Console.WriteLine("INgrese el Password ");
                alumno.Password = Console.ReadLine();
                Console.WriteLine("INgrese la Fecha de Nacimiento ");
                alumno.FechaNacimiento =  DateTime.Parse(Console.ReadLine());
                Console.WriteLine("INgrese el Sexo ");
                alumno.Sexo = char.Parse(Console.ReadLine());
                Console.WriteLine("INgrese el Telefono ");
                alumno.Telefono = Console.ReadLine();
                Console.WriteLine("INgrese el Celular ");
                alumno.Celular = Console.ReadLine();
                Console.WriteLine("INgrese el Curp ");
                alumno.Curp = Console.ReadLine();
                ML.Result result = BL.Usuario.AddSP(alumno);

                if (result.Correct)
                {
                    Console.WriteLine("Alumno agregado");
                }
                else
                {
                    Console.WriteLine("Alumno no agregado");
                };


            }
          
        }
    }
}

