using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tablesttest.Models;


namespace tablesttest
{
    public partial class viewOrden : Form
    {
        public viewOrden()
        {
            InitializeComponent();
        }

        private void Refrescar()
        {
            using (ModelContext context = new ModelContext())
            {
                var lst = from d in context.Bebida
                          select d;
                dataGridView1.DataSource = lst.ToList();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void viewOrden_Load_1(object sender, EventArgs e)
        {

            Refrescar();
            cb_pedidos();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_compra_Click(object sender, EventArgs e)
        {

           // string[] listaPedido = new string[3];
        }
        private void cb_pedidos()
        {
            try
            {
                using (ModelContext context = new ModelContext())
                {

                    //realizamos la consulta aplicando filtros y ordenamientos
                    //y convertimos a lista, esto ultimo es Importante
                    cb_pedido.DataSource = context.Bebida.Where(d => d.Idbebida != null).Select(d => d.Nombrebebida + " $" + d.Valorbebida).ToList();

                    //campo que vera el usuario
                    cb_pedido.DisplayMember = "Nombrebebida";

                    //campo que es el valor real
                    cb_pedido.ValueMember = "Nombrebebida";


                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void cb_pedido_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Close();
            MUser viewOrden = new MUser();
            this.Hide();
            viewOrden.Show();
        }

        private void CalcularTotal()
        {
            decimal total = 0;



        }
    }
}
