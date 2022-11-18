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
    
    public partial class Menu : Form
    {
        
        public Menu()
        {
            
            int n = 0;
            do
            {
                InitializeComponent();
                using (var context = new ModelContext())
                {

                    var query = context.Productos
                                       
                                       .FirstOrDefault<Producto>();

                    if (n == 0)
                    {
                        labelDescripcion.Text = query.Descripcionproducto.ToString();
                        n++;
                    }
                    else if (n == 1)
                    {
                        labelDescripcion2.Text = query.Descripcionproducto.ToString();
                        n++;
                    }

                    else if (n == 2)
                    {
                        labelDescripcion3.Text = query.Descripcionproducto.ToString();
                        n++;
                    }

                    else if (n == 3)
                    {
                        labelDescripcion4.Text = query.Descripcionproducto.ToString();
                        n++;
                    }

                    else if (n == 4)
                    {
                        labelDescripcion5.Text = query.Descripcionproducto.ToString();
                        n++;
                    }
                }
                
            } while (n < 5);

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ViewBebida1 bebida1 =new ViewBebida1();
            bebida1.Show();
        }
    }
}
