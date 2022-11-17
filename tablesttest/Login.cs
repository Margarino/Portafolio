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
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


namespace tablesttest
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }




        private void pass_TextChanged(object sender, EventArgs e)
        {
            pass.PasswordChar = '*';
        }


        private void log_Click(object sender, EventArgs e)
        {
            //string sPass = Encrypt.GetSHA256(pass.Text.Trim());
           

            using (Models.ModelContext context = new Models.ModelContext()) {
                var lst = from d in context.Empleados
                          where d.Nombre == user.Text
                          && d.Rut == pass.Text
                          select d;
                if ( lst.Count() > 0)
                {
                    this.Hide();
                    MessageBox.Show("Ingreso Exitoso");
                    MUser frm = new MUser();
                    frm.FormClosed += (s,args) => this.Close();
                    frm.Show();
                    
                }
                else
                {
                    MessageBox.Show("Usuario no existe");
                }
            
            }
        }
    }


}
