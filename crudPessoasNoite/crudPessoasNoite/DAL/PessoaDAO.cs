using crudPessoasNoite.Modelo;
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

        }

        public Pessoa PesquisarPessoaPorId(Pessoa pessoa)
        {
            return pessoa;
        }

        public List<Pessoa> PesquisarPessoaPorNome(Pessoa pessoa) 
        {
            List<Pessoa> listaPessoas = new List<Pessoa>();
            return listaPessoas; 
        }

        public void EditarPessoa(Pessoa pessoa)
        {

        }

        public void ExcluirPessoa(Pessoa pessoa)
        {

        }
    }
}
