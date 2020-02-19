using Meta.Exame.WebApplication.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
namespace Meta.Exame.WebApplication.Dal
{
    public class ModeloContext
    {
        public ModeloContext()
        {
        }
        string _ConnectionString = "Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = 127.0.0.1)(PORT = 1521))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = XE)));Password=123456;User ID = system";

        public List<Modelo> ToList()
        {
            List<Modelo> modelo = new List<Modelo>();
            using (OracleConnection connection = new OracleConnection(_ConnectionString))
            {
                try
                {
                    connection.Open();
                    string sql = "SELECT * FROM MODELO";
                    OracleCommand cmd = new OracleCommand(sql, connection);
                    cmd.Connection = connection;
                    OracleDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        modelo.Add(new Modelo()
                        {
                            Id = Convert.ToInt32(dr["ID"]),
                            Nome = dr["NOME"].ToString()
                        });
                    }
                    dr.Close();
                    return modelo;
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
        public void Add(Modelo modelo)
        {
            using (OracleConnection connection = new OracleConnection(_ConnectionString))
            {
                try
                {
                    connection.Open();
                    OracleParameter[] prm = new OracleParameter[2];
                    OracleCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT MAX(ID) FROM MODELO";
                    string resp = command.ExecuteScalar().ToString();
                    if (resp == "")
                    {
                        int maxno = 0;
                        prm[0] = command.Parameters.Add("ID", OracleDbType.Decimal, maxno + 1, ParameterDirection.Input);
                        prm[1] = command.Parameters.Add("NOME", OracleDbType.Varchar2, modelo.Nome, ParameterDirection.Input);
                        command.CommandText = "INSERT INTO MODELO (ID, NOME) values(:1, :2)";
                        command.ExecuteNonQuery();
                    }
                    else
                    {
                        int maxno = Convert.ToInt32(resp);
                        prm[0] = command.Parameters.Add("ID", OracleDbType.Decimal, maxno + 1, ParameterDirection.Input);
                        prm[1] = command.Parameters.Add("NOME", OracleDbType.Varchar2, modelo.Nome, ParameterDirection.Input);
                        command.CommandText = "INSERT INTO MODELO (ID, NOME) values(:1, :2)";
                        command.ExecuteNonQuery();
                    }
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
        public Modelo FindById(int id)
        {
            var modelo = new Modelo();
            using (OracleConnection connection = new OracleConnection(_ConnectionString))
            {
                try
                {
                    connection.Open();
                    OracleParameter[] prm = new OracleParameter[1];
                    OracleCommand command = connection.CreateCommand();
                    prm[0] = command.Parameters.Add("ID", OracleDbType.Decimal, id, ParameterDirection.Input);
                    command.CommandText = "SELECT * FROM MODELO WHERE ID = :1";
                    command.ExecuteNonQuery();
                    OracleDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        modelo.Id = Convert.ToInt32(dr["ID"]);
                        modelo.Nome = dr["NOME"].ToString();
                    }
                    dr.Close();
                    return modelo;
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
                    command.CommandText = "DELETE FROM MODELO WHERE ID = :1";
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
        public void Update(Modelo modelo)
        {
            using (OracleConnection connection = new OracleConnection(_ConnectionString))
            {
                try
                {
                    connection.Open();
                    OracleParameter[] prm = new OracleParameter[2];
                    OracleCommand command = connection.CreateCommand();
                    prm[0] = command.Parameters.Add("NOME", OracleDbType.Varchar2, modelo.Nome, ParameterDirection.Input);
                    prm[1] = command.Parameters.Add("ID", OracleDbType.Decimal, modelo.Id, ParameterDirection.Input);
                    command.CommandText = "UPDATE MODELO SET NOME = :1 WHERE ID = :2";
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