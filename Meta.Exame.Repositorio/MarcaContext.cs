using Meta.Exame.Entidade;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;

namespace Meta.Exame.Repositorio
{
    public class MarcaContext
    {
        public MarcaContext()
        {
        }
        string _ConnectionString = "Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = 127.0.0.1)(PORT = 1521))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = XE)));Password=123456;User ID = system";

        public List<Marca> ToList()
        {
            List<Marca> marca = new List<Marca>();
            using (OracleConnection connection = new OracleConnection(_ConnectionString))
            {
                try
                {
                    connection.Open();
                    string sql = "SELECT * FROM MARCA";
                    OracleCommand cmd = new OracleCommand(sql, connection);
                    cmd.Connection = connection;
                    OracleDataReader dr = cmd.ExecuteReader();
                    while (dr.Read()) 
                    {
                            marca.Add(new Marca()
                            {
                                Id = Convert.ToInt32(dr["ID"]),
                                Nome = dr["NOME"].ToString()
                            });
                    }
                    dr.Close();
                    return marca;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public void Add(Marca marca)
        {
            using (OracleConnection connection = new OracleConnection(_ConnectionString))
            {
                try
                {
                        connection.Open();
                        OracleParameter[] prm = new OracleParameter[2];
                        OracleCommand command = connection.CreateCommand();
                        command.CommandText = "SELECT MAX(ID) FROM MARCA";
                        int maxno = int.Parse(command.ExecuteScalar().ToString());
                        prm[0] = command.Parameters.Add("ID", OracleDbType.Decimal, maxno + 1, ParameterDirection.Input);
                        prm[1] = command.Parameters.Add("NOME", OracleDbType.Varchar2, marca.Nome, ParameterDirection.Input);
                        command.CommandText = "INSERT INTO MARCA (ID, NOME) values(:1, :2)";
                        command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public Marca FindById(int id)
        {
            var marca = new Marca();
            using (OracleConnection connection = new OracleConnection(_ConnectionString))
            {
                try
                {
                    connection.Open();
                    OracleParameter[] prm = new OracleParameter[1];
                    OracleCommand command = connection.CreateCommand();
                    prm[0] = command.Parameters.Add("ID", OracleDbType.Decimal, id, ParameterDirection.Input);
                    command.CommandText = "SELECT * FROM MARCA WHERE ID = :1";
                    command.ExecuteNonQuery();
                    OracleDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        marca.Id = Convert.ToInt32(dr["ID"]);
                        marca.Nome = dr["NOME"].ToString();
                    }
                    dr.Close();
                    return marca;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public void Remove(int id)
        {
            using (OracleConnection connection = new OracleConnection(_ConnectionString))
            {
                try
                {
                    connection.Open();
                    OracleParameter[] prm = new OracleParameter[2];
                    OracleCommand command = connection.CreateCommand();
                    prm[0] = command.Parameters.Add("ID", OracleDbType.Decimal, id, ParameterDirection.Input);
                    command.CommandText = "DELETE FROM MARCA WHERE ID = :1";
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public void Update(Marca marca)
        {
            using (OracleConnection connection = new OracleConnection(_ConnectionString))
            {
                try
                {
                    connection.Open();
                    OracleParameter[] prm = new OracleParameter[2];
                    OracleCommand command = connection.CreateCommand();
                    prm[0] = command.Parameters.Add("NOME", OracleDbType.Varchar2, marca.Nome, ParameterDirection.Input);
                    prm[1] = command.Parameters.Add("ID", OracleDbType.Decimal, marca.Id, ParameterDirection.Input);
                    command.CommandText = "UPDATE MARCA SET NOME = :1 WHERE ID = :2";
                    command.Connection = connection;
                    command.ExecuteReader();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

    }
}