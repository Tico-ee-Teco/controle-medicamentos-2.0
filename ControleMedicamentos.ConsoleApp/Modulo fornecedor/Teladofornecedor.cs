using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloFuncionario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.ConsoleApp.Modulo_fornecedor
{
    internal class Teladofornecedor : TelaBase
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
    }
}

