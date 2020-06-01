using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

using System.Data.SqlClient;
namespace practica1
{
    public class Suplidoresrepositorio : Isuplidores
    {
        string connstr = ConfigurationManager.ConnectionStrings["MSSQL"].ConnectionString;
        public Operationresult Create(Suplidores suplidores)
        {
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = $"INSERT INTO suplidor VALUES ('{suplidores.nombre}','{suplidores.representante}','{suplidores.rnc}','{suplidores.direccion}','{suplidores.estado}')";
                    cmd.Connection = conn;
                    conn.Open();
                    try
                    {
                        
                        cmd.ExecuteNonQuery();
                        return new Operationresult() { Resultado = true, Mensaje = "Se ha insertado correctamente" };
                    }
                    catch (Exception ex)
                    {

                        return new Operationresult(false, $"Ha ocurrido un error. {ex.Message}") ;
                    }

                }
            }
        }

        public Operationresult eliminar(string rnc)
        {
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = $"UPDATE suplidor SET estado={0} WHERE rnc={rnc}";
                    cmd.Connection = conn;
                    conn.Open();
                    try
                    {

                        cmd.ExecuteNonQuery();
                        return new Operationresult() { Resultado = true, Mensaje = "Se ha borrado correctamente" };
                    }
                    catch (Exception ex)
                    {

                        return new Operationresult(false, $"Ha ocurrido un error. {ex.Message}");
                    }

                }
            }
        }

        public Operationresult findbyrnc(string rnc)
        {
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    
                    cmd.CommandText = $"SELECT nombre,representante,rnc,estado FROM suplidor WHERE rnc={rnc} AND  estado={1} ";
                    cmd.Connection = conn;
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    try
                    {
                        reader.Read();
                        Console.WriteLine($"Nombre: {reader["nombre"]}\nRepresentante: {reader["representante"]}\nRNC:{reader["rnc"]}");
                        reader.Close();
                        cmd.ExecuteNonQuery();
                        
                            return new Operationresult() { Resultado = true, Mensaje = "Completo" };

                       
                       
                        
                        

                        

                    }
                    catch (Exception ex)
                    {

                        return new Operationresult(false, $"No se ha encontrado. {ex.Message}");
                    }


                }

            }
        }

        public Operationresult GetAll()
        {
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = $"SELECT nombre,representante,estado FROM suplidor Where estado={1} ";
                    cmd.Connection = conn;
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    Console.Clear();
                    while (reader.Read())
                    {
                        Console.WriteLine($"Nombre: {reader["nombre"]}\nRepresentante: {reader["representante"]}\n");
                    }
                    try
                    {
                        cmd.ExecuteNonQuery();
                        return new Operationresult() { Resultado = true, Mensaje = "Completo" };
                    }
                    catch (Exception ex)
                    {

                        return new Operationresult(false, $"Ha ocurrido un error. {ex.Message}");
                    }


                }
               
            }
        }

        public Operationresult upd(string nombre, string direccion, string rnc)
        {
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = $"UPDATE suplidor SET representante='{nombre}',direccion='{direccion}' WHERE rnc={rnc}";
                    cmd.Connection = conn;
                    conn.Open();
                    try
                    {
                        
                        cmd.ExecuteNonQuery();
                        return new Operationresult() { Resultado = true, Mensaje = "Se ha actualizado correctamente" };
                    }
                    catch (Exception ex)
                    {

                        return new Operationresult(false, $"Ha ocurrido un error. {ex.Message}");
                    }

                }
            }

        }
    }
}
