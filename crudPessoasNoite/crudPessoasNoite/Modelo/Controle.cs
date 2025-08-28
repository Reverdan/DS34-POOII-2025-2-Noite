using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crudPessoasNoite.Modelo
{
    public class Controle
    {
        public String mensagem;
        public void CadastrarPessoa(List<Pessoa> listaDadosPessoa)
        {

        }

        public Pessoa PesquisarPessoaPorId(String identificacao)
        {
            Pessoa pessoa = new Pessoa();
            return pessoa;
        }

        public List<Pessoa> PesquisarPessoaPorNome(String nome)
        {
            List<Pessoa> listaPessoas = new List<Pessoa>();
            return listaPessoas;
        }

        public void EditarPessoa(List<Pessoa> listaDadosPessoa)
        {

        }

        public void ExcluirPessoa(String identificacao)
        {

        }
    }
}
