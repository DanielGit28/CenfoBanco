using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AccesoDatos.DAO
{
    public class SqlDao
    {
        private string CONNECTION_STRING = "";

        private static SqlDao instance;

        private SqlDao()
        {
            CONNECTION_STRING = ConfigurationManager.ConnectionStrings["CONN_STRING"].ConnectionString;
        }

        //IMPLEMENTA EL PATRON LLAMADO SINGLETON
        //INVESTIGAR EL PATRON
        public static SqlDao GetInstance()
        {
            if (instance == null)
                instance = new SqlDao();

            return instance;
        }

        public void ExecuteProcedureIdentity(SqlOperation sqlOperation)
        {
            using (var conn = new SqlConnection(CONNECTION_STRING))
            using (var command = new SqlCommand(sqlOperation.ProcedureName, conn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {
                //Limpiar los parametros
                command.Parameters.Clear();

                foreach (var param in sqlOperation.Parameters)
                {
                    command.Parameters.Add(param);
                }
                if(command.Parameters != null)
                {
                    foreach (var param in sqlOperation.Parameters)
                    {
                        Console.WriteLine("Parametros: " + command.Parameters.ToString());
                    }
                }
                else
                {
                    Console.WriteLine("Vacío");
                }
                

                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void ExecuteProcedure(SqlOperation sqlOperation)
        {
            using (var conn = new SqlConnection(CONNECTION_STRING))
            using (var command = new SqlCommand(sqlOperation.ProcedureName, conn)
            {
                CommandType = CommandType.StoredProcedure

            })
            {
                //Limpiar los parametros
                command.Parameters.Clear();

                foreach (var param in sqlOperation.Parameters)
                {
                    command.Parameters.Add(param);
                }

                conn.Open();
                command.ExecuteNonQuery();

                conn.Close();   
                
            }
            
        }

        public List<Dictionary<string, object>> ExecuteQueryProcedure(SqlOperation sqlOperation)
        {
            var lstResult = new List<Dictionary<string, object>>();

            using (var conn = new SqlConnection(CONNECTION_STRING))

            using (var command = new SqlCommand(sqlOperation.ProcedureName, conn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {
                //Limpiar los parametros
                command.Parameters.Clear();

                foreach (var param in sqlOperation.Parameters)
                {
                    command.Parameters.Add(param);
                }

                conn.Open();
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var dict = new Dictionary<string, object>(); //Object es para que se pueda recibir cualquier tipo de dato de la BD
                        for (var lp = 0; lp < reader.FieldCount; lp++)
                        {
                            dict.Add(reader.GetName(lp), reader.GetValue(lp));
                        }
                        lstResult.Add(dict);
                    }
                }
                conn.Close();

            }

            
            return lstResult;
        }
    }
}
