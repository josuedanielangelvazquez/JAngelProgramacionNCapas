using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace BL
{
    public class Usuario
    {

        static public ML.Result Add(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {

                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = context;

                    cmd.CommandText = "INSERT INTO [Usuario]([Nombre],[ApellidoPaterno],[ApellidoMaterno]) VALUES (@nombre,@apellidoPaterno,@apellidoMaterno)";

                    SqlParameter[] collection = new SqlParameter[3];
                    collection[0] = new SqlParameter("nombre", SqlDbType.VarChar);
                    collection[0].Value = usuario.Nombre;
                    collection[1] = new SqlParameter("apellidoPaterno", SqlDbType.VarChar);
                    collection[1].Value = usuario.ApellidoPaterno;
                    collection[2] = new SqlParameter("apellidomaterno", SqlDbType.VarChar);
                    collection[2].Value = usuario.ApellidoMaterno;


                    cmd.Parameters.AddRange(collection);
                    cmd.Connection.Open();
                    int RowsAffected = cmd.ExecuteNonQuery();

                    if (RowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error";
                    }
                }
            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = "Error";
                result.Ex = ex;
            }
            {

            }

            return result;

        }


        static public ML.Result Read()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = context;
                    cmd.CommandText = "SELECT [IdUsuario],[Nombre],[ApellidoPaterno],[ApellidoMaterno],[Grupo] FROM [Usuario]";

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable usuarioTable = new DataTable();

                    da.Fill(usuarioTable);

                    if (usuarioTable.Rows.Count > 0)
                    {
                        result.Objects = new List<object>();
                        foreach (DataRow row in usuarioTable.Rows)
                        {
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = int.Parse(row[0].ToString());
                            usuario.Nombre = row[1].ToString();
                            usuario.ApellidoPaterno = row[2].ToString();
                            usuario.ApellidoMaterno = row[3].ToString();
                            usuario.grupo = int.Parse(row[4].ToString());

                            result.Objects.Add(usuario);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No contiene registros la tabla usuario";
                    }

                }

            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        static public ML.Result UPDATE(ML.Usuario usuario)
        {

            ML.Result result = new ML.Result();
            try
            {

                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = context;

                    cmd.CommandText = "update[Usuario] set [Nombre] = @nombre,[ApellidoPaterno] = @apellidoPaterno ,[ApellidoMaterno] = @apellidoMaterno ,[Grupo] = @grupo where [Idusuario] = @usuarioId";

                    SqlParameter[] collection = new SqlParameter[5];
                    collection[0] = new SqlParameter("usuarioId", SqlDbType.Int);
                    collection[0].Value = usuario.IdUsuario;
                    collection[1] = new SqlParameter("nombre", SqlDbType.VarChar);
                    collection[1].Value = usuario.Nombre;
                    collection[2] = new SqlParameter("apellidoPaterno", SqlDbType.VarChar);
                    collection[2].Value = usuario.ApellidoPaterno;
                    collection[3] = new SqlParameter("apellidomaterno", SqlDbType.VarChar);
                    collection[3].Value = usuario.ApellidoMaterno;
                    collection[4] = new SqlParameter("grupo", SqlDbType.Int);
                    collection[4].Value = usuario.grupo;

                    cmd.Parameters.AddRange(collection);
                    cmd.Connection.Open();
                    int RowsAffected = cmd.ExecuteNonQuery();

                    if (RowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error";
                    }
                }
            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            {

            }

            return result;

        }

        static public ML.Result DELETE(int idusuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = context;
                    cmd.CommandText = "DELETE FROM [usuarios] WHERE [IdUsuario] = " + idusuario;


                    cmd.Connection.Open();
                    int RowsAffected = cmd.ExecuteNonQuery();


                    if (RowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;

        }

        static public ML.Result GetById(int Idusuario)
        {
            ML.Result result = new ML.Result();

            using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = context;
                cmd.CommandText = "SELECT [IdUsuario],[Nombre],[ApellidoPaterno],[ApellidoMaterno] FROM [Usuario] WHERE [IdUsuario] = @IdUsuario";

                SqlParameter[] collection = new SqlParameter[1];
                collection[0] = new SqlParameter("IdUsuario", SqlDbType.Int);
                collection[0].Value = Idusuario;

                cmd.Parameters.AddRange(collection);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable usuarioTable = new DataTable();

                da.Fill(usuarioTable);

                if (usuarioTable.Rows.Count > 0)
                {
                    DataRow row = usuarioTable.Rows[0];

                    ML.Usuario usuario = new ML.Usuario();
                    usuario.IdUsuario = int.Parse(row[0].ToString());
                    usuario.Nombre = row[1].ToString();
                    usuario.ApellidoPaterno = row[2].ToString();
                    usuario.ApellidoMaterno = row[3].ToString();
                    result.Object = usuario;
                    result.Correct = true;
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "Error";
                }
            }
            return result;
        }


        static public ML.Result GetByIdsp(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = context;
                    cmd.CommandText = "UsuarioReadById";
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter[] collection = new SqlParameter[1];
                    collection[0] = new SqlParameter("IdUsuario", SqlDbType.Int);
                    collection[0].Value = IdUsuario;

                    cmd.Parameters.AddRange(collection);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable usuarioTable = new DataTable();

                    da.Fill(usuarioTable);

                    if (usuarioTable.Rows.Count > 0)
                    {
                        DataRow row = usuarioTable.Rows[0];

                        ML.Usuario usuario = new ML.Usuario();
                        usuario.IdUsuario = int.Parse(row[0].ToString());
                        usuario.Nombre = row[1].ToString();
                        usuario.ApellidoPaterno = row[2].ToString();
                        usuario.ApellidoMaterno = row[3].ToString();

                        result.Object = usuario; //BOXING

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No contiene registros la tabla usuario";
                    }

                }
             }
             catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        static public ML.Result GetSP()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = context;
                    cmd.CommandText = "UsuarioRead";
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable usuarioTable = new DataTable();

                    da.Fill(usuarioTable);

                    if(usuarioTable.Rows.Count > 0)
                    {
                        result.Objects = new List<object>();
                        foreach(DataRow  row in usuarioTable.Rows)
                        {
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = int.Parse(row[0].ToString());
                            usuario.Nombre = row[2].ToString();
                            usuario.ApellidoPaterno = row[3].ToString();
                            usuario.ApellidoMaterno = row[4].ToString();

                            result.Objects.Add(usuario);
                        }
                        result.Correct = true;

                       
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error";
                    }


                }
            }
            catch(Exception ex)
            {
                result.Correct=false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }

        static  public ML.Result AddSP(ML.Usuario usuario)
        {
            ML.Result  result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = context;
                    cmd.CommandText = "UsuarioInsert";
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter[] collection = new SqlParameter[11];
                    collection[0] = new SqlParameter("UserName", SqlDbType.VarChar);
                    collection[0].Value = usuario.UserName;
                    collection[1] = new SqlParameter("Nombre", SqlDbType.VarChar);
                    collection[1].Value = usuario.Nombre;
                    collection[2] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                    collection[2].Value = usuario.ApellidoPaterno;
                    collection[3] = new SqlParameter("Apellidomaterno", SqlDbType.VarChar);
                    collection[3].Value = usuario.ApellidoMaterno;
                    collection[4] = new SqlParameter("Email", SqlDbType.VarChar);
                    collection[4].Value = usuario.Email;
                    collection[5] = new SqlParameter("Password", SqlDbType.VarChar);
                    collection[5].Value = usuario.Password;
                    collection[6] = new SqlParameter("FechaNacimiento", SqlDbType.DateTime);
                    collection[6].Value = usuario.FechaNacimiento;
                    collection[7] = new SqlParameter("Sexo", SqlDbType.Char);
                    collection[7].Value = usuario.Sexo;
                    collection[8] = new SqlParameter("Telefono", SqlDbType.VarChar);
                    collection[8].Value = usuario.Telefono;
                    collection[9] = new SqlParameter("Celular", SqlDbType.VarChar);
                    collection[9].Value = usuario.Celular;
                    collection[10] = new SqlParameter("Curp", SqlDbType.VarChar);
                    collection[10].Value = usuario.Curp;
                    

                    cmd.Parameters.AddRange(collection);
                    cmd.Connection.Open();
                    int RowsAffected = cmd.ExecuteNonQuery();

                    if (RowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error";
                    }

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                    result.ErrorMessage = "Error";
            }

            
            return result;
        }

        static public ML.Result UPDATESP(ML.Usuario usuario)
        {

            ML.Result result = new ML.Result();
            try
            {

                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = context;

                    cmd.CommandText = "UsuarioUpdate";
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter[] collection = new SqlParameter[12];
                    collection[0] = new SqlParameter("IdUsuario", SqlDbType.Int);
                    collection[0].Value = usuario.IdUsuario;
                    collection[1] = new SqlParameter("UserName", SqlDbType.VarChar);
                    collection[1].Value = usuario.UserName;
                    collection[2] = new SqlParameter("Nombre", SqlDbType.VarChar);
                    collection[2].Value = usuario.Nombre;
                    collection[3] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                    collection[3].Value = usuario.ApellidoPaterno;
                    collection[4] = new SqlParameter("Apellidomaterno", SqlDbType.VarChar);
                    collection[4].Value = usuario.ApellidoMaterno;
                    collection[5] = new SqlParameter("Email", SqlDbType.VarChar);
                    collection[5].Value = usuario.Email;
                    collection[6] = new SqlParameter("Password", SqlDbType.VarChar);
                    collection[6].Value = usuario.Password;
                    collection[7] = new SqlParameter("FechaNacimiento", SqlDbType.DateTime);
                    collection[7].Value = usuario.FechaNacimiento;
                    collection[8] = new SqlParameter("Sexo", SqlDbType.Char);
                    collection[8].Value = usuario.Sexo;
                    collection[9] = new SqlParameter("Telefono", SqlDbType.VarChar);
                    collection[9].Value = usuario.Telefono;
                    collection[10] = new SqlParameter("Celular", SqlDbType.VarChar);
                    collection[10].Value = usuario.Celular;
                    collection[11] = new SqlParameter("Curp", SqlDbType.VarChar);
                    collection[11].Value = usuario.Curp;

                    cmd.Parameters.AddRange(collection);
                    cmd.Connection.Open();
                    int RowsAffected = cmd.ExecuteNonQuery();

                    if (RowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error";
                    }
                }
            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            {

            }

            return result;

        }

        static public ML.Result DELETESP(int idusuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = context;
                    cmd.CommandText = "UsuarioDelete";
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter[] collection = new SqlParameter[1];
                    collection[0] = new SqlParameter("IdUsuario", SqlDbType.Int);
                    collection[0].Value = idusuario;

                    cmd.Parameters.AddRange(collection);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);


                    cmd.Connection.Open();
                    int RowsAffected = cmd.ExecuteNonQuery();


                    if (RowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;

        }




    }
}

