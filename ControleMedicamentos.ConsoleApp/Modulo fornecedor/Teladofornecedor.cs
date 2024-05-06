using ControleMedicamentos.ConsoleApp.Compartilhado;

namespace ControleMedicamentos.ConsoleApp.Modulo_fornecedor
{
    internal class TeladoFornecedor : TelaBase
    {
        public override void VisualizarRegistros(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();

                Console.WriteLine("Vizualizando Fornecedores...");
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -20} | {3, -20}",
                "Id", "Nome", "Telefone", "CNPJ"
                );

            EntidadeBase[] fornecedorescadastrados = repositorio.SelecionarTodos();

            foreach (Fornecedor fornecedor in fornecedorescadastrados)
            {
                if (fornecedor == null)
                    continue;

                Console.WriteLine("{0, -10} | {1, -20} | {2, -20} | {3, -20}",
                fornecedor.Id, fornecedor.Nome, fornecedor.Telefone, fornecedor.Cnpj
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

            Console.WriteLine("Digite o CNPJ: ");
            string Cnpj = Console.ReadLine();

            Fornecedor fornecedor = new Fornecedor(nome, telefone, Cnpj);

            return fornecedor ;
        }

        public void CadastrarFornecedorTeste()
        {
            Fornecedor fornecedor = new Fornecedor("Veloz", "999440807", "11222333/0004-55");
            repositorio.Cadastrar(fornecedor);
        }
    }
}

