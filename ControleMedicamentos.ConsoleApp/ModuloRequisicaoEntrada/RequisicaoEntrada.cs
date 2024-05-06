using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.Modulo_fornecedor;
using ControleMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;

namespace ControleMedicamentos.ConsoleApp.ModuloRequisicaosaida
{
    internal class Requisicaoentrada : EntidadeBase
    {
        public DateTime Data { get; set; }
        public Medicamento medicamento { get; set; }
        public Fornecedor Fornecedor { get; set; }
        public Funcionario Funcionario { get; set; }
        public int Quantidadepedida { get; set; }

        public Requisicaoentrada(Medicamento medicamentoselecionado, Fornecedor fornecedorselecionado, Funcionario funcionarioselecionado, int quantidadeselecionada)
        {

            medicamento = medicamentoselecionado;
            Fornecedor = fornecedorselecionado;

            Funcionario = funcionarioselecionado;
            Quantidadepedida = quantidadeselecionada;


        }

        public override string[] Validar()
        {
            string[] erros = new string[3];
            int contadorErros = 0;

            if (medicamento == null)
                erros[contadorErros++] = "O medicamento precisa ser preenchido";

            if (Funcionario == null)
                erros[contadorErros++] = "O Funcionario responsavel precisa ser informado";

            if (Fornecedor == null)
                erros[contadorErros++] = "por favor informe o fornecedor";

            if (Quantidadepedida < 1)
                erros[contadorErros++] = "Por favor informe uma quantidade válida";

           

            string[] errosFiltrados = new string[contadorErros];

            Array.Copy(erros, errosFiltrados, contadorErros);

            return errosFiltrados;
        }

        public bool Pedirmedicamento()
        {
            if (medicamento.Quantidade < Quantidadepedida)
                return false;

            medicamento.Quantidade += Quantidadepedida;
            return true;
        }

    }
}
    
