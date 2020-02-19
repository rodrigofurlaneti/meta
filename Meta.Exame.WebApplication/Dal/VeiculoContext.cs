using Meta.Exame.WebApplication.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
namespace Meta.Exame.WebApplication.Dal
{
    public class VeiculoContext
    {
        public VeiculoContext()
        {
        }
        string _ConnectionString = "Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = 127.0.0.1)(PORT = 1521))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = XE)));Password=123456;User ID = system";
        public List<Veiculo> ToList()
        {
            List<Veiculo> veiculo = new List<Veiculo>();
            using (OracleConnection connection = new OracleConnection(_ConnectionString))
            {
                try
                {
                    connection.Open();
                    string sql = "SELECT * FROM VEICULO";
                    OracleCommand cmd = new OracleCommand(sql, connection);
                    cmd.Connection = connection;
                    OracleDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        veiculo.Add(new Veiculo()
                        {
                            Id = Convert.ToInt32(dr["ID"]),
                            IdMarca = Convert.ToInt32(dr["IDMARCA"]),
                            IdModelo = Convert.ToInt32(dr["IDMARCA"]),
                            Valor = Convert.ToDecimal(dr["VALOR"])
                        });
                    }
                    dr.Close();
                    return veiculo;
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
        public void Add(Veiculo veiculo)
        {
            using (OracleConnection connection = new OracleConnection(_ConnectionString))
            {
                try
                {
                    connection.Open();
                    OracleParameter[] prm = new OracleParameter[4];
                    OracleCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT MAX(ID) FROM VEICULO";
                    string resp = command.ExecuteScalar().ToString();
                    if (resp == "")
                    {
                        int maxno = 0;
                        prm[0] = command.Parameters.Add("ID", OracleDbType.Decimal, maxno + 1, ParameterDirection.Input);
                        prm[1] = command.Parameters.Add("IDMARCA", OracleDbType.Varchar2, veiculo.IdMarca, ParameterDirection.Input);
                        prm[2] = command.Parameters.Add("IDMODELO", OracleDbType.Varchar2, veiculo.IdModelo, ParameterDirection.Input);
                        prm[3] = command.Parameters.Add("VALOR", OracleDbType.Decimal, veiculo.Valor, ParameterDirection.Input);
                        command.CommandText = "INSERT INTO VEICULO (ID, IDMARCA, IDMODELO, VALOR) values(:1, :2, :3, :4)";
                        command.ExecuteNonQuery();
                    }
                    else
                    {
                        int maxno = Convert.ToInt32(resp);
                        prm[0] = command.Parameters.Add("ID", OracleDbType.Decimal, maxno + 1, ParameterDirection.Input);
                        prm[1] = command.Parameters.Add("IDMARCA", OracleDbType.Varchar2, veiculo.IdMarca, ParameterDirection.Input);
                        prm[2] = command.Parameters.Add("IDMODELO", OracleDbType.Varchar2, veiculo.IdModelo, ParameterDirection.Input);
                        prm[3] = command.Parameters.Add("VALOR", OracleDbType.Decimal, veiculo.Valor, ParameterDirection.Input);
                        command.CommandText = "INSERT INTO VEICULO (ID, IDMARCA, IDMODELO, VALOR) values(:1, :2, :3, :4)";
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
        public Veiculo FindById(int id)
        {
            var veiculo = new Veiculo();
            using (OracleConnection connection = new OracleConnection(_ConnectionString))
            {
                try
                {
                    connection.Open();
                    OracleParameter[] prm = new OracleParameter[1];
                    OracleCommand command = connection.CreateCommand();
                    prm[0] = command.Parameters.Add("ID", OracleDbType.Decimal, id, ParameterDirection.Input);
                    command.CommandText = "SELECT * FROM Veiculo WHERE ID = :1";
                    command.ExecuteNonQuery();
                    OracleDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        veiculo.Id = Convert.ToInt32(dr["ID"]);
                        veiculo.IdMarca = Convert.ToInt32(dr["IDMARCA"]);
                        veiculo.IdModelo = Convert.ToInt32(dr["IDMODELO"]);
                        veiculo.Valor = Convert.ToDecimal(dr["VALOR"]);
                    }
                    dr.Close();
                    return veiculo;
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
                    OracleParameter[] prm = new OracleParameter[1];
                    OracleCommand command = connection.CreateCommand();
                    prm[0] = command.Parameters.Add("ID", OracleDbType.Decimal, id, ParameterDirection.Input);
                    command.CommandText = "DELETE FROM VEICULO WHERE ID = :1";
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
        public void Update(Veiculo veiculo)
        {
            using (OracleConnection connection = new OracleConnection(_ConnectionString))
            {
                try
                {
                    connection.Open();
                    OracleParameter[] prm = new OracleParameter[4];
                    OracleCommand command = connection.CreateCommand();
                    prm[0] = command.Parameters.Add("IDMARCA", OracleDbType.Decimal, veiculo.IdMarca, ParameterDirection.Input);
                    prm[1] = command.Parameters.Add("IDMODELO", OracleDbType.Decimal, veiculo.IdModelo, ParameterDirection.Input);
                    prm[2] = command.Parameters.Add("VALOR", OracleDbType.Decimal, veiculo.Valor, ParameterDirection.Input);
                    prm[3] = command.Parameters.Add("ID", OracleDbType.Decimal, veiculo.Id, ParameterDirection.Input);
                    command.CommandText = "UPDATE VEICULO SET IDMARCA = :1 , IDMODELO = :2 , VALOR = :3 WHERE ID = :4";
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