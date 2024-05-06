using ControleMedicamentos.ConsoleApp.Compartilhado;
using System.Collections;

namespace ControleMedicamentos.ConsoleApp.ModuloFuncionario
{
    internal class Funcionario : EntidadeBase
    {
        public string Nome {  get; set; }
        public string Telefone {  get; set; }
        public string Cpf {  get; set; }

        public Funcionario() { }

        public Funcionario(string nome, string telefone, string cpf)
        {
            Nome = nome;
            Telefone = telefone;
            Cpf = cpf;
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (string.IsNullOrEmpty(Nome))
                erros.Add("O campo \"nome\" é obrigatório");

            if (string.IsNullOrEmpty(Telefone))
                erros.Add("O campo \"telefone\" é obrigatório");

            if (string.IsNullOrEmpty(Cpf))
                erros.Add("O campo \"Cpf\" é obrigatório");            

            return erros;
        }

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Funcionario novasInformacoes = (Funcionario)novoRegistro;

            this.Nome = novasInformacoes.Nome;
            this.Telefone = novasInformacoes.Telefone;
            this.Cpf = novasInformacoes.Cpf;
        }
    }
}
