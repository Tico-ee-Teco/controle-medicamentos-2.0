using ControleMedicamentos.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.ConsoleApp.Modulo_fornecedor
{
    internal class Fornecedor : EntidadeBase
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Cnpj { get; set; }

        public Fornecedor() { }

        public Fornecedor(string nome, string telefone, string cnpj)
        {
            Nome = nome;
            Telefone = telefone;
            Cnpj = cnpj;
        }

        public override string[] Validar()
        {
            string[] erros = new string[3];
            int contadorErros = 0;

            if (string.IsNullOrEmpty(Nome))
                erros[contadorErros++] = ("O campo \"nome\" é obrigatório");

            if (string.IsNullOrEmpty(Telefone))
                erros[contadorErros++] = ("O campo \"telefone\" é obrigatório");

            if (string.IsNullOrEmpty(Cnpj))
                erros[contadorErros++] = ("O campo \"CNPJ\" é obrigatório");

            string[] errosFiltrados = new string[contadorErros];

            Array.Copy(erros, errosFiltrados, contadorErros);

            return errosFiltrados;



        }
    }
}
