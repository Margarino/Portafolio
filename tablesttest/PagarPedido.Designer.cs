namespace tablesttest
{
    partial class PagarPedido
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.pagarBoton = new System.Windows.Forms.Button();
            this.montoTotalLabel = new System.Windows.Forms.TextBox();
            this.descripcionTotal = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel1.Controls.Add(this.pagarBoton);
            this.panel1.Controls.Add(this.montoTotalLabel);
            this.panel1.Controls.Add(this.descripcionTotal);
            this.panel1.Location = new System.Drawing.Point(248, 95);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(423, 479);
            this.panel1.TabIndex = 0;
            // 
            // pagarBoton
            // 
            this.pagarBoton.BackColor = System.Drawing.Color.White;
            this.pagarBoton.Location = new System.Drawing.Point(165, 405);
            this.pagarBoton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pagarBoton.Name = "pagarBoton";
            this.pagarBoton.Size = new System.Drawing.Size(86, 31);
            this.pagarBoton.TabIndex = 2;
            this.pagarBoton.Text = "Pagar";
            this.pagarBoton.UseVisualStyleBackColor = false;
            this.pagarBoton.Click += new System.EventHandler(this.button1_Click);
            // 
            // montoTotalLabel
            // 
            this.montoTotalLabel.BackColor = System.Drawing.Color.LightGray;
            this.montoTotalLabel.Location = new System.Drawing.Point(152, 353);
            this.montoTotalLabel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.montoTotalLabel.Name = "montoTotalLabel";
            this.montoTotalLabel.Size = new System.Drawing.Size(114, 27);
            this.montoTotalLabel.TabIndex = 1;
            // 
            // descripcionTotal
            // 
            this.descripcionTotal.BackColor = System.Drawing.Color.LightGray;
            this.descripcionTotal.Location = new System.Drawing.Point(50, 33);
            this.descripcionTotal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.descripcionTotal.Multiline = true;
            this.descripcionTotal.Name = "descripcionTotal";
            this.descripcionTotal.Size = new System.Drawing.Size(325, 299);
            this.descripcionTotal.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.DarkGreen;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBox1.Location = new System.Drawing.Point(298, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(325, 56);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "Pagar Cuenta";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // PagarPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.ClientSize = new System.Drawing.Size(914, 600);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PagarPedido";
            this.Text = "PagarPedido";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel panel1;
        private Button pagarBoton;
        private TextBox montoTotalLabel;
        private TextBox descripcionTotal;
        private TextBox textBox1;
    }
}