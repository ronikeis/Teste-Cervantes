using System;

namespace Aplicação_DEMO
{
    partial class FrmCadFunc
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.textnomefunc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textdepartamento = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textcodigo = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.npgsqlDataAdapter1 = new Npgsql.NpgsqlDataAdapter();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.bt_Sair = new System.Windows.Forms.Button();
            this.bt_Excluir = new System.Windows.Forms.Button();
            this.bt_Alterar = new System.Windows.Forms.Button();
            this.bt_Incluir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(39, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codigo do Funcionario :";
            // 
            // textnomefunc
            // 
            this.textnomefunc.Location = new System.Drawing.Point(229, 78);
            this.textnomefunc.MaxLength = 30;
            this.textnomefunc.Name = "textnomefunc";
            this.textnomefunc.Size = new System.Drawing.Size(284, 20);
            this.textnomefunc.TabIndex = 1;
            this.textnomefunc.TextChanged += new System.EventHandler(this.textnomefunc_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(39, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nome do Funcionario :";
            // 
            // textdepartamento
            // 
            this.textdepartamento.Location = new System.Drawing.Point(229, 112);
            this.textdepartamento.MaxLength = 20;
            this.textdepartamento.Name = "textdepartamento";
            this.textdepartamento.Size = new System.Drawing.Size(284, 20);
            this.textdepartamento.TabIndex = 2;
            this.textdepartamento.TextChanged += new System.EventHandler(this.textdepartamento_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(39, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Departamento :";
            // 
            // textcodigo
            // 
            this.textcodigo.Location = new System.Drawing.Point(229, 42);
            this.textcodigo.MaxLength = 5;
            this.textcodigo.Name = "textcodigo";
            this.textcodigo.Size = new System.Drawing.Size(48, 20);
            this.textcodigo.TabIndex = 0;
            this.textcodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textcodigo_KeyDown);
            this.textcodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textcodigo_KeyPress);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // npgsqlDataAdapter1
            // 
            this.npgsqlDataAdapter1.DeleteCommand = null;
            this.npgsqlDataAdapter1.InsertCommand = null;
            this.npgsqlDataAdapter1.SelectCommand = null;
            this.npgsqlDataAdapter1.UpdateCommand = null;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(42, 172);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(786, 150);
            this.dataGridView1.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(319, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(261, 18);
            this.label4.TabIndex = 8;
            this.label4.Text = "CADASTRO DE  FUNCIONARIOS";
            // 
            // bt_Sair
            // 
            this.bt_Sair.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.bt_Sair.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_Sair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_Sair.Location = new System.Drawing.Point(737, 12);
            this.bt_Sair.Name = "bt_Sair";
            this.bt_Sair.Size = new System.Drawing.Size(87, 23);
            this.bt_Sair.TabIndex = 6;
            this.bt_Sair.Text = "Sair";
            this.bt_Sair.UseVisualStyleBackColor = false;
            this.bt_Sair.Click += new System.EventHandler(this.bt_Sair_Click);
            // 
            // bt_Excluir
            // 
            this.bt_Excluir.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.bt_Excluir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_Excluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_Excluir.Location = new System.Drawing.Point(643, 12);
            this.bt_Excluir.Name = "bt_Excluir";
            this.bt_Excluir.Size = new System.Drawing.Size(87, 23);
            this.bt_Excluir.TabIndex = 5;
            this.bt_Excluir.Text = "Excluir";
            this.bt_Excluir.UseVisualStyleBackColor = false;
            this.bt_Excluir.Click += new System.EventHandler(this.bt_Excluir_Click);
            // 
            // bt_Alterar
            // 
            this.bt_Alterar.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.bt_Alterar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_Alterar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_Alterar.Location = new System.Drawing.Point(550, 12);
            this.bt_Alterar.Name = "bt_Alterar";
            this.bt_Alterar.Size = new System.Drawing.Size(87, 23);
            this.bt_Alterar.TabIndex = 4;
            this.bt_Alterar.Text = "Alterar";
            this.bt_Alterar.UseVisualStyleBackColor = false;
            this.bt_Alterar.Click += new System.EventHandler(this.bt_Alterar_Click);
            // 
            // bt_Incluir
            // 
            this.bt_Incluir.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.bt_Incluir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_Incluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_Incluir.Location = new System.Drawing.Point(457, 12);
            this.bt_Incluir.Name = "bt_Incluir";
            this.bt_Incluir.Size = new System.Drawing.Size(87, 23);
            this.bt_Incluir.TabIndex = 3;
            this.bt_Incluir.Text = "Novo";
            this.bt_Incluir.UseVisualStyleBackColor = false;
            this.bt_Incluir.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmCadFunc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(842, 345);
            this.Controls.Add(this.bt_Incluir);
            this.Controls.Add(this.bt_Alterar);
            this.Controls.Add(this.bt_Excluir);
            this.Controls.Add(this.bt_Sair);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textcodigo);
            this.Controls.Add(this.textdepartamento);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textnomefunc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCadFunc";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aplicação DEMO";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Click += new System.EventHandler(this.FrmCadFunc_Click);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmCadFunc_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void bt_Incluir_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textnomefunc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textdepartamento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textcodigo;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private Npgsql.NpgsqlDataAdapter npgsqlDataAdapter1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bt_Sair;
        private System.Windows.Forms.Button bt_Excluir;
        private System.Windows.Forms.Button bt_Alterar;
        private System.Windows.Forms.Button bt_Incluir;
    }
}

