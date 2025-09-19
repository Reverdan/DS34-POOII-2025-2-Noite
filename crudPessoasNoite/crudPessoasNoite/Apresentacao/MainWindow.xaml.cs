using crudPessoasNoite.Apresentacao;
using crudPessoasNoite.DAL;
using crudPessoasNoite.Modelo;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace crudPessoasNoite
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Pessoa pessoa = new Pessoa();
            //pessoa.id = 6;
            //pessoa.nome = "Joana";
            //pessoa.rg = "999999";
            //pessoa.cpf = "000000";

            //PessoaDAO pessoaDAO = new PessoaDAO();
            //pessoaDAO.EditarPessoa(pessoa);

            //MessageBox.Show(pessoaDAO.mensagem);
        }

        private void mniCadastropessoas_Click(object sender, RoutedEventArgs e)
        {
            frmCadastro frmC = new frmCadastro();
            frmC.ShowDialog();
        }

        private void mniPEE_Click(object sender, RoutedEventArgs e)
        {
            frmPEE frmP = new frmPEE();
            frmP.ShowDialog();
        }
    }
}