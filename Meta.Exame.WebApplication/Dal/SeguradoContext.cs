using Meta.Exame.WebApplication.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
namespace Meta.Exame.WebApplication.Dal
{
    public class SeguradoContext
    {
        public SeguradoContext()
        {
        }
        string _ConnectionString = "Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = 127.0.0.1)(PORT = 1521))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = XE)));Password=123456;User ID = system";

        public List<Segurado> ToList()
        {
            List<Segurado> segurado = new List<Segurado>();
            using (OracleConnection connection = new OracleConnection(_ConnectionString))
            {
                try
                {
                    connection.Open();
                    string sql = "SELECT * FROM SEGURADO";
                    OracleCommand cmd = new OracleCommand(sql, connection);
                    cmd.Connection = connection;
                    OracleDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        segurado.Add(new Segurado()
                        {
                            Id = Convert.ToInt32(dr["ID"]),
                            Nome = dr["NOME"].ToString(),
                            Cpf = dr["CPF"].ToString(),
                            Idade = dr["IDADE"].ToString()
                        });
                    }
                    dr.Close();
                    return segurado;
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
        public void Add(Segurado segurado)
        {
            using (OracleConnection connection = new OracleConnection(_ConnectionString))
            {
                try
                {
                    connection.Open();
                    OracleParameter[] prm = new OracleParameter[4];
                    OracleCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT MAX(ID) FROM SEGURADO";
                    string resp = command.ExecuteScalar().ToString();
                    if (resp == "")
                    {
                        int maxno = 0;
                        prm[0] = command.Parameters.Add("ID", OracleDbType.Decimal, maxno + 1, ParameterDirection.Input);
                        prm[1] = command.Parameters.Add("NOME", OracleDbType.Varchar2, segurado.Nome, ParameterDirection.Input);
                        prm[2] = command.Parameters.Add("CPF", OracleDbType.Varchar2, segurado.Cpf, ParameterDirection.Input);
                        prm[3] = command.Parameters.Add("IDADE", OracleDbType.Varchar2, segurado.Idade, ParameterDirection.Input);
                        command.CommandText = "INSERT INTO SEGURADO (ID, NOME, CPF, IDADE) values(:1, :2, :3, :4)";
                        command.ExecuteNonQuery();
                    }
                    else
                    {
                        int maxno = Convert.ToInt32(resp);
                        prm[0] = command.Parameters.Add("ID", OracleDbType.Decimal, maxno + 1, ParameterDirection.Input);
                        prm[1] = command.Parameters.Add("NOME", OracleDbType.Varchar2, segurado.Nome, ParameterDirection.Input);
                        prm[2] = command.Parameters.Add("CPF", OracleDbType.Varchar2, segurado.Cpf, ParameterDirection.Input);
                        prm[3] = command.Parameters.Add("IDADE", OracleDbType.Varchar2, segurado.Idade, ParameterDirection.Input);
                        command.CommandText = "INSERT INTO SEGURADO (ID, NOME, CPF, IDADE) values(:1, :2, :3, :4)";
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
        public Segurado FindById(int id)
        {
            var segurado = new Segurado();
            using (OracleConnection connection = new OracleConnection(_ConnectionString))
            {
                try
                {
                    connection.Open();
                    OracleParameter[] prm = new OracleParameter[1];
                    OracleCommand command = connection.CreateCommand();
                    prm[0] = command.Parameters.Add("ID", OracleDbType.Decimal, id, ParameterDirection.Input);
                    command.CommandText = "SELECT * FROM SEGURADO WHERE ID = :1";
                    command.ExecuteNonQuery();
                    OracleDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        segurado.Id = Convert.ToInt32(dr["ID"]);
                        segurado.Nome = dr["NOME"].ToString();
                        segurado.Cpf = dr["CPF"].ToString();
                        segurado.Idade = dr["IDADE"].ToString();
                    }
                    dr.Close();
                    return segurado;
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
                    command.CommandText = "DELETE FROM SEGURADO WHERE ID = :1";
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
        public void Update(Segurado segurado)
        {
            using (OracleConnection connection = new OracleConnection(_ConnectionString))
            {
                try
                {
                    connection.Open();
                    OracleParameter[] prm = new OracleParameter[4];
                    OracleCommand command = connection.CreateCommand();
                    prm[0] = command.Parameters.Add("NOME", OracleDbType.Varchar2, segurado.Nome, ParameterDirection.Input);
                    prm[1] = command.Parameters.Add("CPF", OracleDbType.Varchar2, segurado.Cpf, ParameterDirection.Input);
                    prm[2] = command.Parameters.Add("IDADE", OracleDbType.Varchar2, segurado.Idade, ParameterDirection.Input);
                    prm[3] = command.Parameters.Add("ID", OracleDbType.Decimal, segurado.Id, ParameterDirection.Input);
                    command.CommandText = "UPDATE SEGURADO SET NOME = :1 , CPF = :2 , IDADE = :3 WHERE ID = :4";
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