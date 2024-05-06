﻿using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.Modulo_fornecedor;
using ControleMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleMedicamentos.ConsoleApp.ModuloPaciente;
using ControleMedicamentos.ConsoleApp.ModuloRequisicao;
using ControleMedicamentos.ConsoleApp.ModuloRequisicaoEntrada;

namespace ControleMedicamentos.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RepositorioPaciente repositorioPaciente = new RepositorioPaciente();

            TelaPaciente telaPaciente = new TelaPaciente();
            telaPaciente.tipoEntidade = "Paciente";
            telaPaciente.repositorio = repositorioPaciente;

            telaPaciente.CadastrarEntidadeTeste();

            RepositorioMedicamento repositorioMedicamento = new RepositorioMedicamento();
            TelaMedicamento telaMedicamento = new TelaMedicamento();
            telaMedicamento.repositorio = repositorioMedicamento;
            telaMedicamento.tipoEntidade = "Medicamento";

            telaMedicamento.CadastrarMedicamentoTeste();

            RepositorioRequisicaoSaida repositorioRequisicaoSaida = new RepositorioRequisicaoSaida();

            TelaRequisicaoSaida telaRequisicaoSaida = new TelaRequisicaoSaida();
            telaRequisicaoSaida.repositorio = repositorioRequisicaoSaida;
            telaRequisicaoSaida.tipoEntidade = "Requisição Saida";

            telaRequisicaoSaida.telaPaciente = telaPaciente;
            telaRequisicaoSaida.telaMedicamento = telaMedicamento;

            telaRequisicaoSaida.repositorioPaciente = repositorioPaciente;
            telaRequisicaoSaida.repositorioMedicamento = repositorioMedicamento;

            RepositorioFuncionario repositorioFuncionario = new RepositorioFuncionario();
            TelaFuncionario telaFuncionario = new TelaFuncionario();
            telaFuncionario.repositorio = repositorioFuncionario;
            telaFuncionario.tipoEntidade = "Funcionario";

            telaFuncionario.CadastrarFuncionarioTeste();

            Repositoriofornecedor repositorioFornecedor = new Repositoriofornecedor();
            TeladoFornecedor teladoFornecedor = new TeladoFornecedor();
            teladoFornecedor.repositorio = repositorioFornecedor;
            teladoFornecedor.tipoEntidade = "Fornecedor";

            teladoFornecedor.CadastrarFornecedorTeste();

            RepositorioRequisicaoEntrada repositorioRequisicaoEntrada = new RepositorioRequisicaoEntrada();

            TelaRequisicaoEntrada telaRequisicaoEntrada = new TelaRequisicaoEntrada();
            telaRequisicaoEntrada.repositorio = repositorioRequisicaoEntrada;
            telaRequisicaoEntrada.tipoEntidade = "Requisiçao entrada";

            telaRequisicaoEntrada.telaMedicamento = telaMedicamento;
            telaRequisicaoEntrada.teladoFornecedor = teladoFornecedor;
            telaRequisicaoEntrada.telaFuncionario = telaFuncionario;

            telaRequisicaoEntrada.repositorioMedicamento = repositorioMedicamento;
            telaRequisicaoEntrada.repositorioFornecedor = repositorioFornecedor;
            telaRequisicaoEntrada.repositorioFuncionario = repositorioFuncionario;

            while (true)
            {
                char opcaoPrincipalEscolhida = TelaPrincipal.ApresentarMenuPrincipal();

                if (opcaoPrincipalEscolhida == 'S' || opcaoPrincipalEscolhida == 's')
                    break;

                TelaBase tela = null;

                if (opcaoPrincipalEscolhida == '1')
                    tela = telaPaciente;

                else if (opcaoPrincipalEscolhida == '2')
                    tela = telaMedicamento;

                else if (opcaoPrincipalEscolhida == '3')
                    tela = telaRequisicaoSaida;

                else if (opcaoPrincipalEscolhida == '4')
                    tela = telaFuncionario;

                else if (opcaoPrincipalEscolhida == '5')
                    tela = teladoFornecedor;

                else if (opcaoPrincipalEscolhida == '6')
                    tela = telaRequisicaoEntrada;


                char operacaoEscolhida = tela.ApresentarMenu();

                if (operacaoEscolhida == 'S' || operacaoEscolhida == 's')
                    continue;

                if (operacaoEscolhida == '1')
                    tela.Registrar();

                else if (operacaoEscolhida == '2')
                    tela.Editar();

                else if (operacaoEscolhida == '3')
                    tela.Excluir();

                else if (operacaoEscolhida == '4')
                    tela.VisualizarRegistros(true);

                //else if (operacaoEscolhida == '5')
                //    tela.VisualizarRegistros(true);

                //else if (operacaoEscolhida == '6')
                //    tela.VisualizarRegistros(true);
            }

            Console.ReadLine();
        }
    }
}
