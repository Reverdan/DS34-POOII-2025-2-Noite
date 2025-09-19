using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crudPessoasNoite.Modelo
{
    public class Validacao
    {
        public String mensagem = String.Empty;
        public int id;

        public Validacao()
        {
        }

        public Validacao(List<String> listadadosPessoa)
        {
            ValidarId(listadadosPessoa[0]);
            ValidarNome(listadadosPessoa[1]);
            ValidarRg(listadadosPessoa[2]);
            ValidarCpf(listadadosPessoa[3]);
        }

        public void ValidarId(String identificacao)
        {
            try
            {
                this.id = Convert.ToInt32(identificacao);
            }
            catch
            {
                this.mensagem += "ID inválido \n";
            }
        }

        public void ValidarNome(String nome)
        {
            if (nome.Length < 2)
                this.mensagem += "Nome com menos que 3 caracteres \n";
            if (nome.Length > 45)
                this.mensagem += "Nome com mais que 45 caracteres \n";
        }

        public void ValidarRg(String rg)
        {
            if (rg.Length > 11)
                this.mensagem += "RG com mais que 11 caracteres \n";
        }

        public void ValidarCpf(String cpf)
        {
            if (cpf.Length > 13)
                this.mensagem += "CPF com mais que 13 caracteres \n";
        }


    }
}
