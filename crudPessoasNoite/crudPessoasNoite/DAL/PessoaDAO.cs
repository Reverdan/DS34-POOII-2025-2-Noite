using crudPessoasNoite.Modelo;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crudPessoasNoite.DAL
{
    public class PessoaDAO
    {
        public String mensagem;
        public void CadastrarPessoa(Pessoa pessoa)
        {
            SqlConnection con = Conexao.Conectar();
            if (!Conexao.mensagem.Equals(""))
            {
                this.mensagem = Conexao.mensagem;
                return;
            }
            string sql = "insert into pessoas (nome, rg, cpf) values (@nome, @rg, @cpf)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@nome", pessoa.nome);
            cmd.Parameters.AddWithValue("@rg", pessoa.rg);
            cmd.Parameters.AddWithValue("@cpf", pessoa.cpf);
            try
            {
                cmd.ExecuteNonQuery();
                mensagem = "Pessoa cadastrada com sucesso!";
            }
            catch (Exception ex)
            {
                mensagem = "Erro ao cadastrar pessoa " + ex.Message;
            }
            finally
            {
                Conexao.Desconectar();
            }

        }

        public Pessoa PesquisarPessoaPorId(Pessoa pessoa)
        {
            SqlConnection con = Conexao.Conectar();
            if (!Conexao.mensagem.Equals(""))
            {
                this.mensagem = Conexao.mensagem;
                return null;
            }
            string sql = "select * from pessoas where id = @id";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@id", pessoa.id);
            SqlDataReader dr;
            try
            {
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    pessoa.nome = dr["nome"].ToString();
                    pessoa.rg = dr["rg"].ToString();
                    pessoa.cpf = dr["cpf"].ToString();
                }
                else
                {
                    pessoa.id = 0;
                    this.mensagem = "ID não encontrado";
                }
            }
            catch (Exception ex)
            {
                mensagem = "Erro ao pesquisar pessoa " + ex.Message;
            }
            finally
            {
                Conexao.Desconectar();
            }
            return pessoa;
        }

        public List<Pessoa> PesquisarPessoaPorNome(Pessoa pessoa) 
        {
            this.mensagem = "";
            List<Pessoa> listaPessoas = new List<Pessoa>();

            SqlConnection con = Conexao.Conectar();
            if (!Conexao.mensagem.Equals(""))
            {
                this.mensagem = Conexao.mensagem;
                return null;
            }

            string sql = @"select * from pessoas 
                        where nome like @nome";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@nome", pessoa.nome + "%");

            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Pessoa p = new Pessoa();
                    p.id = Convert.ToInt32(dr["id"]);
                    p.nome = dr["nome"].ToString();
                    p.rg = dr["rg"].ToString();
                    p.cpf = dr["cpf"].ToString();
                    listaPessoas.Add(p);
                }
            }
            catch (SqlException e)
            {
                this.mensagem = "Erro na pesquisa! \n" + e.Message;
            }
            finally
            {
                con.Close();
            }


            return listaPessoas; 
        }

        public void EditarPessoa(Pessoa pessoa)
        {
            SqlConnection con = Conexao.Conectar();
            if (!Conexao.mensagem.Equals(""))
            {
                this.mensagem = Conexao.mensagem;
                return;
            }
            string sql = "update pessoas set nome = @nome, rg = @rg, " +
                "cpf = @cpf where id = @id";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@id", pessoa.id);
            cmd.Parameters.AddWithValue("@nome", pessoa.nome);
            cmd.Parameters.AddWithValue("@rg", pessoa.rg);
            cmd.Parameters.AddWithValue("@cpf", pessoa.cpf);
            try
            {
                cmd.ExecuteNonQuery();
                mensagem = "Pessoa editada com sucesso!";
            }
            catch (Exception ex)
            {
                mensagem = "Erro ao editar pessoa " + ex.Message;
            }
            finally
            {
                Conexao.Desconectar();
            }
        }

        public void ExcluirPessoa(Pessoa pessoa)
        {
            pessoa = PesquisarPessoaPorId(pessoa);
            if (pessoa.id.Equals(0))
                return;

            SqlConnection con = Conexao.Conectar();
            if (!Conexao.mensagem.Equals(""))
            {
                this.mensagem = Conexao.mensagem;
                return;
            }
            string sql = "delete from pessoas where id = @id";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@id", pessoa.id);
            try
            {
                cmd.ExecuteNonQuery();
                mensagem = "Pessoa excluida com sucesso!";
            }
            catch (Exception ex)
            {
                mensagem = "Erro ao excluir pessoa " + ex.Message;
            }
            finally
            {
                Conexao.Desconectar();
            }
        }
    }
}
