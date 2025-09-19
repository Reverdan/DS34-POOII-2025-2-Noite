using crudPessoasNoite.DAL;
using crudPessoasNoite.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace crudPessoasNoite.Apresentacao
{
    /// <summary>
    /// Lógica interna para frmPEE.xaml
    /// </summary>
    public partial class frmPEE : Window
    {
        public frmPEE()
        {
            InitializeComponent();
        }

        private void btnPesquisarPorId_Click(object sender, RoutedEventArgs e)
        {
            Controle controle = new Controle();
            Pessoa pessoa = controle.PesquisarPessoaPorId(txbId.Text);
            txbNome.Text = pessoa.nome;
            txbRg.Text = pessoa.rg;
            txbCpf.Text = pessoa.cpf;

            if (pessoa.id.Equals(0))
                MessageBox.Show("ID não encontrado");
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            List<string> listaDadosPessoa = new List<string>();
            listaDadosPessoa.Add(txbId.Text);
            listaDadosPessoa.Add(txbNome.Text);
            listaDadosPessoa.Add(txbRg.Text);
            listaDadosPessoa.Add(txbCpf.Text);

            Controle controle = new Controle();
            controle.EditarPessoa(listaDadosPessoa);
            MessageBox.Show(controle.mensagem);
        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult resultado = MessageBox.Show(
                "Deseja realmente excluir esta pessoa?", "Alerta",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (resultado == MessageBoxResult.Yes)
            {
                Controle controle = new Controle();
                controle.ExcluirPessoa(txbId.Text);
                MessageBox.Show(controle.mensagem);
            }


            txbId.Text = "";
            txbNome.Text = string.Empty;
            txbRg.Text = string.Empty;
            txbCpf.Text = string.Empty;
        }

        private void btnPesquisarPorNome_Click(object sender, RoutedEventArgs e)
        {
            Controle controle = new Controle();
            List<Pessoa> listaPessoas = controle.PesquisarPessoaPorNome(txbNome.Text);

            if (!controle.mensagem.Equals(""))
            {
                MessageBox.Show(controle.mensagem);
                return;
            }

            if (listaPessoas.Count == 0)
            {
                MessageBox.Show("Não existe resposta para este critério de Pesquisa");
            }
            if (listaPessoas.Count == 1)
            {
                txbId.Text = listaPessoas[0].id.ToString();
                txbNome.Text = listaPessoas [0].nome;
                txbRg.Text = listaPessoas[0].rg;
                txbCpf.Text = listaPessoas[0].cpf;
            }
            if (listaPessoas.Count > 1)
            {
                MessageBox.Show("resposta com mais que 1 pessoa");
            }
        }
    }
}
