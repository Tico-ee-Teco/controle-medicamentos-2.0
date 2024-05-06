using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.Modulo_fornecedor;
using System.Collections;

namespace ControleMedicamentos.ConsoleApp.ModuloFuncionario
{
    internal class TelaFuncionario : TelaBase
    {
        public override void VisualizarRegistros(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();

                Console.WriteLine("Vizualizando Funcionários...");
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -20} | {3, -20}",
                "Id", "Nome", "Telefone", "CPF"
                );

           ArrayList funcionariosCadastrados = repositorio.SelecionarTodos();

            foreach (Funcionario funcionario in funcionariosCadastrados)
            {
                if (funcionario == null)
                    continue;

                Console.WriteLine("{0, -10} | {1, -20} | {2, -20} | {3, -20}",
                funcionario.Id, funcionario.Nome, funcionario.Telefone, funcionario.Cpf
                );
            }

            Console.ReadLine();
            Console.WriteLine();
        }

        protected override EntidadeBase ObterRegistro()
        {
            Console.WriteLine("Digite o nome: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite o telefone: ");
            string telefone = Console.ReadLine();

            Console.WriteLine("Digite o Cpf: ");
            string cpf = Console.ReadLine();

            Funcionario funcionario = new Funcionario(nome, telefone, cpf);

            return funcionario;
        }

        public void CadastrarFuncionarioTeste()
        {
            Funcionario funcionario = new Funcionario("João ", "999440807", "111222333-44");

            repositorio.Cadastrar(funcionario);
        }
    }
}
