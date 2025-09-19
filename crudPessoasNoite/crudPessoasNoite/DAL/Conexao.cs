using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crudPessoasNoite.DAL
{
    //create database aulaNoite
    //go
    //use aulaNoite
    //go
    //create table Pessoas
    //(
    //    id int primary key identity(1,1),
    //    nome varchar(45) not null,
    //    rg varchar(11),
    //    cpf varchar(13)
    //)
    //go



    public class Conexao
    {
        public static SqlConnection con = new SqlConnection();
        public static string mensagem = "";
        public static string stringConexao =
            @"Data Source = .\SQLEXPRESS; Initial Catalog = aulaNoite; 
            User ID = sa; Password = prof456; Encrypt = False";

        public static SqlConnection Conectar()
        {
            mensagem = "";
            con.ConnectionString = stringConexao;
            try
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
            }
            catch (Exception ex)
            {
                mensagem = "Erro ao conectar como banco de dados " + ex.Message;
            }
            return con;
        }

        public static void Desconectar()
        {
            try
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                mensagem = "Erro ao desconctar do banco de dados " + ex.Message;
            }
        }
    }
}
