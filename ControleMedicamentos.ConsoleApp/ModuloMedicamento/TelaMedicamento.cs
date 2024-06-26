﻿using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.Modulo_fornecedor;

namespace ControleMedicamentos.ConsoleApp.ModuloMedicamento
{
    internal class TelaMedicamento : TelaBase
    {

        public override void VisualizarRegistros(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();

                Console.WriteLine("Visualizando Medicamentos...");
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -20}",
                "Id", "Nome", "Quantidade"
            );

            EntidadeBase[] medicamentosCadastrados = repositorio.SelecionarTodos();

            foreach (Medicamento medicamento in medicamentosCadastrados)
            {
                if (medicamento == null)
                    continue;

                Console.WriteLine(
                    "{0, -10} | {1, -20} | {2, -20}",
                    medicamento.Id, medicamento.Nome, medicamento.Quantidade
                );
            }

            Console.ReadLine();
            Console.WriteLine();
        }

        protected override EntidadeBase ObterRegistro()
        {
            Console.Write("Digite o nome: ");
            string nome = Console.ReadLine();

            Console.Write("Digite a descrição: ");
            string descricao = Console.ReadLine();

            Console.Write("Digite o lote: ");
            string lote = Console.ReadLine();

            Console.Write("Digite a data de validade: ");
            DateTime dataValidade = Convert.ToDateTime(Console.ReadLine());

            Medicamento medicamento = new Medicamento(nome, descricao, lote, dataValidade);           

            return medicamento;
        }

        public void CadastrarMedicamentoTeste()
        {
            Medicamento medicamento = new Medicamento("Dipirona", "Cura tudo", "AXR567", DateTime.Now);
            repositorio.Cadastrar(medicamento);
        }
    }
}
