using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroPacientes
{
    class Paciente
    {
        private string _nome;
        private string _cpf;
        private DateTime _dataNascimento;
        public int Id { get; set; }
        public string Sexo { get; set; }

        public Paciente()
        {
        }

        public Paciente(string nome, string cpf, DateTime dataNascimento, int id, string sexo)
        {
            _nome = nome;
            _cpf = cpf;
            _dataNascimento = dataNascimento;
            Id = id;
            Sexo = sexo;
        }

        public string Nome
        {
            get { return _nome; }
            set
            {
                if (Validacoes.validaNome(value))
                    _nome = value;
                else
                    throw new PacienteException("Nome inválido!");
            }
        }
        public string Cpf
        {
            get { return _cpf; }
            set
            {
                if (Validacoes.isCpf(value))
                    _cpf = value;
                else
                    throw new PacienteException("Cpf inválido!");
            }
        }
        public DateTime DataNascimento
        {
            get { return _dataNascimento; }
            set
            {
                if (Validacoes.validaData(value))
                    _dataNascimento = value;
                else
                    throw new PacienteException("Data inválida!");
            }
        }
        public override string ToString()
        {
            return "Id: " + Id + " -" +
                " Nome: " + Nome + " -" +
                " CPF: " + Cpf + " -" +
                " Data de Nascimento: " + DataNascimento.ToString("dd/MM/yyyy") + " -" +
                " Sexo: " + Sexo; 
        }
    }
}
