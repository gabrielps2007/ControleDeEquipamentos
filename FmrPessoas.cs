using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleDeEquipamentos
{
    public partial class FmrPessoas : Form
    {
        private Pessoas _pessoa = new Pessoas();
        private Operacao _operacao = new Operacao();

        public FmrPessoas(string id, Operacao operacao)
        {
            InitializeComponent();

            _pessoa.ID = id;
            _operacao = operacao;
            Despachante();

        }
        private void Despachante()
        {
            if (_operacao == Operacao.Adicionar)
            {
                btnSalvar.Visible = false;
               
            }
            else if (_operacao == Operacao.Consultar)
            {
                MostrarDados();
                BloquearControles(true);
                btnAdicionar.Visible = false;
            }
            else if (_operacao == Operacao.Alterar)
            {
                MostrarDados();
                btnSalvar.Visible = true;
                btnDevolve.Visible = true;
                BloquearControles2(true);
                btnAdicionar.Visible = false;
            }
            else if (_operacao == Operacao.Excluir) 
            {
                MostrarDados();
                BloquearControles(true);
                btnExcluir.Visible = true;
                btnAdicionar.Visible = false;

            }
            //else if (_operacao == Operacao.Alterar)
            //{
            //    MostrarDados();
            //    btnDevolve.Visible = true;
            //    //BloquearControles2(true);
            //}

        }
        private void MostrarDados() 
        {
            var filter = Builders<Pessoas>.Filter.Eq(x => x.ID, _pessoa.ID);
            var colletionPessoa = Conn.AbrirColecaoPessoas();
            _pessoa = colletionPessoa.Find(filter).FirstOrDefault();

            txtId.Text = _pessoa.ID;
            txtMatricula.Text = _pessoa.MATRICUALA;
            txtNome.Text = _pessoa.NOME;
            txtColetor.Text = _pessoa.COLETOR;
            txtMovimentacao.Text = _pessoa.MOVIMENTACAO;
            txtStatus.Text = _pessoa.STATUS;
            TxtDataHora.Text = _pessoa.DATAHORA.ToString();//DateTime.Now.ToString();
             
        }
        private void BloquearControles(bool travar) 
        {
            travar = !travar;
            txtId.Enabled = travar;
            txtMatricula.Enabled = travar;
            txtNome.Enabled = travar;
            txtColetor.Enabled = travar;
            txtMovimentacao.Enabled = travar;
            txtStatus.Enabled = travar;
            TxtDataHora.Enabled = travar;
        }
        private void BloquearControles2(bool travar)
        {
            travar = !travar;
            txtId.Enabled = travar;
            txtMatricula.Enabled = travar;
            txtNome.Enabled = travar;
           // txtColetor.Enabled = travar;
            txtMovimentacao.Enabled = travar;
            txtStatus.Enabled = travar;
            TxtDataHora.Enabled = travar;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {  
            var colaborador = new Pessoas();
            if (txtMovimentacao.Text != "SEM PENDENCIA")
                MessageBox.Show("FALTA A DEVOLUÇÃO DO COLETOR : " + txtColetor.Text);
            
            else 
            {
                _pessoa.MOVIMENTACAO = "PENDENTE";
                MessageBox.Show("SAIDA DO COLETOR : " + txtColetor.Text);
                //xtColetor.Text

            }
            _pessoa.ID = txtId.Text;
            _pessoa.MATRICUALA = txtMatricula.Text;
            _pessoa.NOME = txtNome.Text;
            _pessoa.COLETOR = txtColetor.Text;
           // _pessoa.MOVIMENTACAO = "PENDENTE"; //txtMovimentacao.Text;
            _pessoa.STATUS = txtStatus.Text;
            _pessoa.DATAHORA = DateTime.Now;




            var colletionClientes = Conn.AbrirColecaoPessoas();

            if(_pessoa.ID == "")
                     colletionClientes.InsertOne(_pessoa);
            else 
            {
                var filter = Builders<Pessoas>.Filter.Eq(x => x.ID, _pessoa.ID);
                colletionClientes.ReplaceOne(filter, _pessoa);
            }
            Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtMovimentacao_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void TxtDataHora_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            var colletionPessoa = Conn.AbrirColecaoPessoas();
            colletionPessoa.DeleteOne(p => p.ID == _pessoa.ID);

            MessageBox.Show("CADASTRO EXCLUIDO COM SUCESSO DO SISTEMA");

            Close();
        }

        private void FmrPessoas_Load(object sender, EventArgs e)
        {

        }

        private void btnDevolve_Click(object sender, EventArgs e)
        {
            var colaborador = new Pessoas();
            if (txtMovimentacao.Text != "PENDENTE")
                MessageBox.Show("NÃO TEM A SAIDA DO COLETOR : " + txtColetor.Text);

            else
            {
                _pessoa.MOVIMENTACAO = "SEM PENDENCIA";
                MessageBox.Show("FOI DEVOLVIDO O COLETOR : " + txtColetor.Text);
            }
            _pessoa.ID = txtId.Text;
            _pessoa.MATRICUALA = txtMatricula.Text;
            _pessoa.NOME = txtNome.Text;
            _pessoa.COLETOR = txtColetor.Text;
            //_pessoa.MOVIMENTACAO = "SEM PENDENCIA"; //txtMovimentacao.Text;
            _pessoa.STATUS = txtStatus.Text;
            _pessoa.DATAHORA = DateTime.Now;

            var colletionClientes = Conn.AbrirColecaoPessoas();

            if (_pessoa.ID == "")
                colletionClientes.InsertOne(_pessoa);
            else
            {
                var filter = Builders<Pessoas>.Filter.Eq(x => x.ID, _pessoa.ID);
                colletionClientes.ReplaceOne(filter, _pessoa);
            }
            Close();

           
        }
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAdicionar_Click_1(object sender, EventArgs e)
        {
            var colaborador = new Pessoas();

            _pessoa.ID = txtId.Text;
            _pessoa.MATRICUALA = txtMatricula.Text;
            _pessoa.NOME = txtNome.Text;
            _pessoa.COLETOR = txtColetor.Text;
            _pessoa.MOVIMENTACAO = "SEM PENDENCIA"; //txtMovimentacao.Text;
            _pessoa.STATUS = txtStatus.Text;
            _pessoa.DATAHORA = DateTime.Today;
            MessageBox.Show("DADOS CADASTRADO COM SUCESSO NO SISTEMA ");




            var colletionClientes = Conn.AbrirColecaoPessoas();

            if (_pessoa.ID == "")
                colletionClientes.InsertOne(_pessoa);
            else
            {
                var filter = Builders<Pessoas>.Filter.Eq(x => x.ID, _pessoa.ID);
                colletionClientes.ReplaceOne(filter, _pessoa);
            }
            Close();
        }
    }   


}
