using DnsClient.Protocol;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleDeEquipamentos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdcionar_Click(object sender, EventArgs e)
        {
            using(var frm = new FmrPessoas("", Operacao.Adicionar))
                    frm.ShowDialog();

            //var colaborador = new Pessoas();
            //colaborador.MATRICUALA = "5098";
            //colaborador.NOME = "PAULO CESAR OLIVEIRA";
            //colaborador.COLETOR = "96";
            //colaborador.MOVIMENTACAO = "Sem pendencia";
            //colaborador.STATUS = "OK";
            //colaborador.DATAHORA = DateTime.Now;

            //MessageBox.Show("CADASTRO INCLUIDO COM SUCESSO NO SISTEMA");

            


            //var colletionClientes = Conn.AbrirColecaoPessoas();
            //colletionClientes.InsertOne(colaborador);


            //var cli = new MongoClient(Conn.Server);
            //var db = cli.GetDatabase(Conn.Db);
            //var colletionClientes = db.GetCollection<Pessoas>
            //    (Conn.ColletionClientes);
            //colletionClientes.InsertOne(colaborador);


        }

        //private void Form1_Load(object sender, EventArgs e)
        //{
        //    //var colletionClientes = Conn.AbrirColecaoPessoas();


        //    ////var cli = new MongoClient(Conn.Server);
        //    ////var db = cli.GetDatabase(Conn.Db);
        //    ////var colletionClientes = db.GetCollection<Pessoas>
        //    ////    (Conn.ColletionClientes);
        //    //var listacolaborador = colletionClientes.Find(p => true).ToList();
        //    //dataGridView1.DataSource = listacolaborador;

        //}

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0) 
            { 
                var id = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();

                /*using*/ var frm = new FmrPessoas(id, Operacao.Consultar);
                frm.ShowDialog();

            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {

            if (dataGridView1.Rows.Count > 0)
            {
                var id = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();

                /*using*/
                var frm = new FmrPessoas(id, Operacao.Excluir);
                frm.ShowDialog();
                

            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                var id = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();

                /*using*/
                var frm = new FmrPessoas(id, Operacao.Alterar   );
                frm.ShowDialog();

            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var colletionPessoa = Conn.AbrirColecaoPessoas();

            var filter = Builders<Pessoas>.Filter.Regex("MATRICUALA", new BsonRegularExpression(".*" + textBox1.Text + ".*", "i"));// ".*" + textBox1.Text.ToString() + ".*", "i"

            var ListaPessoas = colletionPessoa.Find(filter).ToList();
            dataGridView1.DataSource = ListaPessoas;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToString();
           

        }

        
        
    }
    
}
