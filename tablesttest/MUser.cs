using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tablesttest;


namespace tablesttest
{
    public partial class MUser : Form
    {
        public MUser()
        {
            InitializeComponent();
        }
        
        
        private void movesidepanel(Button btn)
        {
            panelslide.Top = btn.Top;
            panelslide.Height = btn.Height;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            movesidepanel(button1);
            viewOrden orden = new viewOrden();
            orden.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            movesidepanel(button2);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            movesidepanel(button3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            movesidepanel(button4);
            var llamarM = MessageBox.Show("El mesero fué llamado");
            Console.Out.WriteLine(llamarM);
        }

        private void main_Load(object sender, EventArgs e)
        {

        }
    }
}