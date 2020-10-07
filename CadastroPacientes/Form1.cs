using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CadastroPacientes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void limpaCampos()
        {
            tbCpf.Clear();
            tbId.Clear();
            tbNome.Clear();
            rbFeminino.Checked = false;
            rbMasculino.Checked = false;
        }

        Paciente p;
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                p = new Paciente();
                p.Id = Convert.ToInt32(tbId.Text);
                p.Nome = tbNome.Text;
                p.Cpf = tbCpf.Text;
                p.DataNascimento = Convert.ToDateTime(dateTimePicker1.Text);
                if(rbMasculino.Checked)
                {
                    p.Sexo = "Masculino";
                    rbFeminino.Checked = false;
                }
                if (rbFeminino.Checked)
                {
                    p.Sexo = "Feminino";
                    rbMasculino.Checked = false;
                }
                p = new Paciente(p.Nome, p.Cpf, p.DataNascimento, p.Id, p.Sexo);
                string conteudo = p.ToString() + Environment.NewLine;
                File.AppendAllText("paciente.txt", conteudo, Encoding.UTF8);
                MessageBox.Show("Paciente cadastrado com sucesso! ");
                limpaCampos();
            }
            catch(PacienteException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            try
            {
                lbLista.Items.Clear();
                string[] linhas = File.ReadAllLines("paciente.txt", Encoding.UTF8);
                foreach (string linha in linhas)
                {
                    lbLista.Items.Add(linha);
                }
            }
            catch(IOException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
