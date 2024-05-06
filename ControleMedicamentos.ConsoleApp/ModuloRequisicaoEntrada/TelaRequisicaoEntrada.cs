using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.Modulo_fornecedor;
using ControleMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleMedicamentos.ConsoleApp.ModuloRequisicaosaida;

namespace ControleMedicamentos.ConsoleApp.ModuloRequisicaoEntrada
{
    internal class TelaRequisicaoEntrada : TelaBase
    {
        public TeladoFornecedor teladoFornecedor = null;
        public TelaMedicamento telaMedicamento = null;
        public TelaFuncionario telaFuncionario = null;

        public Repositoriofornecedor repositorioFornecedor = null;
        public RepositorioMedicamento repositorioMedicamento = null;
        public RepositorioFuncionario repositorioFuncionario = null;


        public override void Registrar()
        {
            ApresentarCabecalho();

            Console.WriteLine($"Cadastrando {tipoEntidade}...");

            Console.WriteLine();

            Requisicaoentrada entidade = (Requisicaoentrada)ObterRegistro();

            string[] erros = entidade.Validar();

            if (erros.Length > 0)
            {
                ApresentarErros(erros);
                return;
            }

            bool conseguiupedir = entidade.Pedirmedicamento();

           
            repositorio.Cadastrar(entidade);


            ExibirMensagem($"O {tipoEntidade} foi cadastrado com sucesso!", ConsoleColor.Green);
        }

        public override void VisualizarRegistros(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();

                Console.WriteLine("Visualizando Requisições de Saída...");
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -15} | {3, -20} | {4, -5} | {5, -20}",
                "Id", "Medicamento", "Fornecedor","Funcionario", "Data de Requisição", "Quantidade"
            );

            EntidadeBase[] requisicoesCadastradas = repositorio.SelecionarTodos();

            foreach (Requisicaoentrada requisicao in requisicoesCadastradas)
            {
                if (requisicao == null)
                    continue;

                Console.WriteLine(
                    "{0, -10} | {1, -15} | {2, -15} | {3, -20} | {4, -5}",
                    requisicao.Id,
                    requisicao.medicamento.Nome,
                    requisicao.Fornecedor.Nome,
                    requisicao.Funcionario.Nome,
                    requisicao.Data.ToShortDateString(),
                    requisicao.Quantidadepedida
                );
            }

            Console.ReadLine();
            Console.WriteLine();
        }

        protected override EntidadeBase ObterRegistro()
        {
            telaMedicamento.VisualizarRegistros(false);

            Console.Write("Digite o ID do medicamento Que quer pedir: ");
            int idMedicamento = Convert.ToInt32(Console.ReadLine());

            Medicamento medicamentoSelecionado = (Medicamento)repositorioMedicamento.SelecionarPorId(idMedicamento);

            teladoFornecedor.VisualizarRegistros(false);
            
            Console.Write("Digite o ID do Fornecedor: ");
            int idFornecedor = Convert.ToInt32(Console.ReadLine());

            Fornecedor fornecedorSelecionado = (Fornecedor)repositorioFornecedor.SelecionarPorId(idFornecedor);

            telaFuncionario.VisualizarRegistros(false);

            Console.Write("Digite o ID do Funcionario: ");
            int idfuncionario = Convert.ToInt32(Console.ReadLine());

            Funcionario funcionarioSelecionado = (Funcionario)repositorioFuncionario.SelecionarPorId(idfuncionario);

           
            Console.Write("Digite a quantidade do medicamente que deseja pedir: ");
            int quantidade = Convert.ToInt32(Console.ReadLine());

            Requisicaoentrada novaRequisicao = new Requisicaoentrada(medicamentoSelecionado,fornecedorSelecionado ,funcionarioSelecionado, quantidade);

            return novaRequisicao;
        }
    }
}
