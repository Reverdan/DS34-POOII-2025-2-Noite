using crudPessoasNoite.DAL;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crudPessoasNoite.Modelo
{
    public class Controle
    {
        public String mensagem = "";
        public void CadastrarPessoa(List<String> listaDadosPessoa)
        {
            this.mensagem = "";
            Validacao validacao = new Validacao(listaDadosPessoa);
            if (validacao.mensagem.Equals(""))
            {
                Pessoa pessoa = new Pessoa();

                pessoa.id = 0;
                pessoa.nome = listaDadosPessoa[1];
                pessoa.rg = listaDadosPessoa[2];
                pessoa.cpf = listaDadosPessoa[3];

                PessoaDAO pessoaDAO = new PessoaDAO();
                pessoaDAO.CadastrarPessoa(pessoa);

                this.mensagem = pessoaDAO.mensagem;
            }
            else
            {
                this.mensagem = validacao.mensagem;
            }
        }

        public Pessoa PesquisarPessoaPorId(String identificacao)
        {
            this.mensagem = "";
            Pessoa pessoa = new Pessoa();
            Validacao validacao = new Validacao();
            validacao.ValidarId(identificacao);
            if (validacao.mensagem.Equals(""))
            {
                pessoa.id = validacao.id;
                PessoaDAO pessoaDAO = new PessoaDAO();
                pessoa = pessoaDAO.PesquisarPessoaPorId(pessoa);
            }
            else
            {
                this.mensagem = validacao.mensagem;
            }

            return pessoa;
        }

        public List<Pessoa> PesquisarPessoaPorNome(String nome)
        {
            this.mensagem = "";
            List<Pessoa> listaPessoas = new List<Pessoa>();

            Validacao Validacao = new Validacao();
            Validacao.ValidarNome(nome);
            if (Validacao.mensagem.Equals(""))
            {
                Pessoa pessoa = new Pessoa();
                pessoa.nome = nome;
                PessoaDAO pessoaDAO = new PessoaDAO();
                listaPessoas = pessoaDAO.PesquisarPessoaPorNome(pessoa);
            }
            else
            {
                this.mensagem = Validacao.mensagem;
            }

            return listaPessoas;
        }

        public void EditarPessoa(List<String> listaDadosPessoa)
        {
            this.mensagem = "";
            Validacao validacao = new Validacao(listaDadosPessoa);
            if (validacao.mensagem.Equals(""))
            {
                Pessoa pessoa = new Pessoa();
                pessoa.id = validacao.id;
                pessoa.nome = listaDadosPessoa[1];
                pessoa.rg = listaDadosPessoa[2];
                pessoa.cpf = listaDadosPessoa[3];
                PessoaDAO pessoaDAO = new PessoaDAO();
                pessoaDAO.EditarPessoa(pessoa);
                this.mensagem = pessoaDAO.mensagem;
            }
            else
            {
                this.mensagem = validacao.mensagem;
            }
        }

        public void ExcluirPessoa(String identificacao)
        {
            this.mensagem = "";
            Validacao validacao = new Validacao();
            validacao.ValidarId(identificacao);
            if (validacao.mensagem.Equals(""))
            {
                Pessoa pessoa = new Pessoa();
                pessoa.id = validacao.id;
                PessoaDAO pessoaDAO = new PessoaDAO();
                pessoaDAO.ExcluirPessoa(pessoa);
                this.mensagem = pessoaDAO.mensagem;
            }
            else
            {
                this.mensagem = validacao.mensagem;
            }
        }
    }
}
