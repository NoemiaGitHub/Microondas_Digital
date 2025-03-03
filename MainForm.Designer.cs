using System.Windows.Forms;

namespace MicroondasDigital
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtTempo;
        private System.Windows.Forms.TextBox txtPotencia;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnPauseCancel; 
        private System.Windows.Forms.Label lblResultado;

        private void InitializeComponent()
        {
            this.txtTempo = new System.Windows.Forms.TextBox();
            this.txtPotencia = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnPauseCancel = new System.Windows.Forms.Button();
            this.lblResultado = new System.Windows.Forms.Label();
            this.cmbProgramas = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtInstrucoes = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtAlimento = new System.Windows.Forms.TextBox();
            this.txtCadTempo = new System.Windows.Forms.TextBox();
            this.txtCadPotencia = new System.Windows.Forms.TextBox();
            this.txtInstrucoesII = new System.Windows.Forms.TextBox();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.txtCaractere = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn1 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.btn4 = new System.Windows.Forms.Button();
            this.btn5 = new System.Windows.Forms.Button();
            this.btn6 = new System.Windows.Forms.Button();
            this.btn7 = new System.Windows.Forms.Button();
            this.btn8 = new System.Windows.Forms.Button();
            this.btn9 = new System.Windows.Forms.Button();
            this.btn0 = new System.Windows.Forms.Button();
            this.labelNovoPrograma = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTempo
            // 
            this.txtTempo.BackColor = System.Drawing.Color.Black;
            this.txtTempo.Font = new System.Drawing.Font("Segoe UI Semibold", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTempo.ForeColor = System.Drawing.Color.Lime;
            this.txtTempo.Location = new System.Drawing.Point(580, 4);
            this.txtTempo.Name = "txtTempo";
            this.txtTempo.Size = new System.Drawing.Size(260, 57);
            this.txtTempo.TabIndex = 1;
            this.txtTempo.Text = "00:00";
            this.txtTempo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTempo.Click += new System.EventHandler(this.txtTempo_Click);
            // 
            // txtPotencia
            // 
            this.txtPotencia.BackColor = System.Drawing.Color.Black;
            this.txtPotencia.Location = new System.Drawing.Point(773, 33);
            this.txtPotencia.Name = "txtPotencia";
            this.txtPotencia.Size = new System.Drawing.Size(61, 20);
            this.txtPotencia.TabIndex = 2;
            this.txtPotencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPotencia.Click += new System.EventHandler(this.txtPotencia_Click);
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.ForeColor = System.Drawing.Color.Blue;
            this.btnStart.Location = new System.Drawing.Point(581, 394);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(55, 43);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Iniciar /+30 seg";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnPauseCancel
            // 
            this.btnPauseCancel.Font = new System.Drawing.Font("Segoe UI", 6.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPauseCancel.ForeColor = System.Drawing.Color.Red;
            this.btnPauseCancel.Location = new System.Drawing.Point(785, 392);
            this.btnPauseCancel.Name = "btnPauseCancel";
            this.btnPauseCancel.Size = new System.Drawing.Size(55, 43);
            this.btnPauseCancel.TabIndex = 4;
            this.btnPauseCancel.Text = "Pausar /Cancelar";
            this.btnPauseCancel.UseVisualStyleBackColor = true;
            this.btnPauseCancel.Click += new System.EventHandler(this.btnPauseCancel_Click);
            // 
            // lblResultado
            // 
            this.lblResultado.AutoSize = true;
            this.lblResultado.Location = new System.Drawing.Point(12, 436);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(55, 13);
            this.lblResultado.TabIndex = 0;
            this.lblResultado.Text = "Resultado";
            // 
            // cmbProgramas
            // 
            this.cmbProgramas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProgramas.FormattingEnabled = true;
            this.cmbProgramas.Location = new System.Drawing.Point(649, 80);
            this.cmbProgramas.Name = "cmbProgramas";
            this.cmbProgramas.Size = new System.Drawing.Size(121, 21);
            this.cmbProgramas.TabIndex = 6;
            this.cmbProgramas.SelectedIndexChanged += new System.EventHandler(this.cmbProgramas_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(690, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "MENU";
            // 
            // txtInstrucoes
            // 
            this.txtInstrucoes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInstrucoes.Location = new System.Drawing.Point(580, 99);
            this.txtInstrucoes.Multiline = true;
            this.txtInstrucoes.Name = "txtInstrucoes";
            this.txtInstrucoes.ReadOnly = true;
            this.txtInstrucoes.Size = new System.Drawing.Size(260, 65);
            this.txtInstrucoes.TabIndex = 7;
            this.txtInstrucoes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(581, 209);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(123, 20);
            this.txtNome.TabIndex = 11;
            this.txtNome.VisibleChanged += new System.EventHandler(this.MostrarPlaceholderTempo);
            // 
            // txtAlimento
            // 
            this.txtAlimento.Location = new System.Drawing.Point(709, 209);
            this.txtAlimento.Name = "txtAlimento";
            this.txtAlimento.Size = new System.Drawing.Size(131, 20);
            this.txtAlimento.TabIndex = 12;
            // 
            // txtCadTempo
            // 
            this.txtCadTempo.Location = new System.Drawing.Point(581, 183);
            this.txtCadTempo.Name = "txtCadTempo";
            this.txtCadTempo.Size = new System.Drawing.Size(123, 20);
            this.txtCadTempo.TabIndex = 9;
            // 
            // txtCadPotencia
            // 
            this.txtCadPotencia.Location = new System.Drawing.Point(709, 183);
            this.txtCadPotencia.Name = "txtCadPotencia";
            this.txtCadPotencia.Size = new System.Drawing.Size(131, 20);
            this.txtCadPotencia.TabIndex = 10;
            // 
            // txtInstrucoesII
            // 
            this.txtInstrucoesII.Location = new System.Drawing.Point(709, 235);
            this.txtInstrucoesII.Name = "txtInstrucoesII";
            this.txtInstrucoesII.Size = new System.Drawing.Size(131, 20);
            this.txtInstrucoesII.TabIndex = 14;
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadastrar.Location = new System.Drawing.Point(635, 261);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(146, 23);
            this.btnCadastrar.TabIndex = 8;
            this.btnCadastrar.Text = "CADASTRAR";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click_1);
            // 
            // txtCaractere
            // 
            this.txtCaractere.Location = new System.Drawing.Point(580, 235);
            this.txtCaractere.Name = "txtCaractere";
            this.txtCaractere.Size = new System.Drawing.Size(123, 20);
            this.txtCaractere.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(773, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "POTÊNCIA";
            // 
            // btn1
            // 
            this.btn1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.btn1.Location = new System.Drawing.Point(580, 296);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(55, 43);
            this.btn1.TabIndex = 17;
            this.btn1.Text = "1";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.BotaoNumero_Click);
            // 
            // btn2
            // 
            this.btn2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.btn2.Location = new System.Drawing.Point(648, 296);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(55, 43);
            this.btn2.TabIndex = 18;
            this.btn2.Text = "2";
            this.btn2.UseVisualStyleBackColor = true;
            this.btn2.Click += new System.EventHandler(this.BotaoNumero_Click);
            // 
            // btn3
            // 
            this.btn3.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.btn3.Location = new System.Drawing.Point(715, 296);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(55, 43);
            this.btn3.TabIndex = 19;
            this.btn3.Text = "3";
            this.btn3.UseVisualStyleBackColor = true;
            this.btn3.Click += new System.EventHandler(this.BotaoNumero_Click);
            // 
            // btn4
            // 
            this.btn4.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.btn4.Location = new System.Drawing.Point(785, 296);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(55, 43);
            this.btn4.TabIndex = 20;
            this.btn4.Text = "4";
            this.btn4.UseVisualStyleBackColor = true;
            this.btn4.Click += new System.EventHandler(this.BotaoNumero_Click);
            // 
            // btn5
            // 
            this.btn5.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.btn5.Location = new System.Drawing.Point(580, 345);
            this.btn5.Name = "btn5";
            this.btn5.Size = new System.Drawing.Size(55, 43);
            this.btn5.TabIndex = 21;
            this.btn5.Text = "5";
            this.btn5.UseVisualStyleBackColor = true;
            this.btn5.Click += new System.EventHandler(this.BotaoNumero_Click);
            // 
            // btn6
            // 
            this.btn6.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.btn6.Location = new System.Drawing.Point(649, 345);
            this.btn6.Name = "btn6";
            this.btn6.Size = new System.Drawing.Size(55, 43);
            this.btn6.TabIndex = 22;
            this.btn6.Text = "6";
            this.btn6.UseVisualStyleBackColor = true;
            this.btn6.Click += new System.EventHandler(this.BotaoNumero_Click);
            // 
            // btn7
            // 
            this.btn7.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.btn7.Location = new System.Drawing.Point(715, 343);
            this.btn7.Name = "btn7";
            this.btn7.Size = new System.Drawing.Size(55, 43);
            this.btn7.TabIndex = 23;
            this.btn7.Text = "7";
            this.btn7.UseVisualStyleBackColor = true;
            this.btn7.Click += new System.EventHandler(this.BotaoNumero_Click);
            // 
            // btn8
            // 
            this.btn8.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.btn8.Location = new System.Drawing.Point(785, 343);
            this.btn8.Name = "btn8";
            this.btn8.Size = new System.Drawing.Size(55, 43);
            this.btn8.TabIndex = 24;
            this.btn8.Text = "8";
            this.btn8.UseVisualStyleBackColor = true;
            this.btn8.Click += new System.EventHandler(this.BotaoNumero_Click);
            // 
            // btn9
            // 
            this.btn9.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.btn9.Location = new System.Drawing.Point(715, 394);
            this.btn9.Name = "btn9";
            this.btn9.Size = new System.Drawing.Size(55, 43);
            this.btn9.TabIndex = 25;
            this.btn9.Text = "9";
            this.btn9.UseVisualStyleBackColor = true;
            this.btn9.Click += new System.EventHandler(this.BotaoNumero_Click);
            // 
            // btn0
            // 
            this.btn0.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.btn0.Location = new System.Drawing.Point(649, 394);
            this.btn0.Name = "btn0";
            this.btn0.Size = new System.Drawing.Size(55, 43);
            this.btn0.TabIndex = 26;
            this.btn0.Text = "0";
            this.btn0.UseVisualStyleBackColor = true;
            this.btn0.Click += new System.EventHandler(this.BotaoNumero_Click);
            // 
            // labelNovoPrograma
            // 
            this.labelNovoPrograma.AutoSize = true;
            this.labelNovoPrograma.Location = new System.Drawing.Point(655, 167);
            this.labelNovoPrograma.Name = "labelNovoPrograma";
            this.labelNovoPrograma.Size = new System.Drawing.Size(103, 13);
            this.labelNovoPrograma.TabIndex = 28;
            this.labelNovoPrograma.Text = "NOVO PROGRAMA";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightGray;
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(15, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(539, 415);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.DimGray;
            this.groupBox2.Location = new System.Drawing.Point(457, 44);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(30, 302);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 476);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnPauseCancel);
            this.Controls.Add(this.labelNovoPrograma);
            this.Controls.Add(this.btn0);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btn9);
            this.Controls.Add(this.btn8);
            this.Controls.Add(this.btn7);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.btn6);
            this.Controls.Add(this.btn5);
            this.Controls.Add(this.btn4);
            this.Controls.Add(this.btn3);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCaractere);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.txtInstrucoesII);
            this.Controls.Add(this.txtCadTempo);
            this.Controls.Add(this.txtCadPotencia);
            this.Controls.Add(this.txtAlimento);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.txtInstrucoes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbProgramas);
            this.Controls.Add(this.lblResultado);
            this.Controls.Add(this.txtPotencia);
            this.Controls.Add(this.txtTempo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "Micro-ondas Digital";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private System.Windows.Forms.ComboBox cmbProgramas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInstrucoes;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtAlimento;
        private System.Windows.Forms.TextBox txtCadTempo;
        private System.Windows.Forms.TextBox txtCadPotencia;
        private System.Windows.Forms.TextBox txtInstrucoesII;
        private System.Windows.Forms.Button btnCadastrar;
        private TextBox txtCaractere;
        private Label label2;
        private Button btn1;
        private Button btn2;
        private Button btn3;
        private Button btn4;
        private Button btn5;
        private Button btn6;
        private Button btn7;
        private Button btn8;
        private Button btn9;
        private Button btn0;
        private Label labelNovoPrograma;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
    }
}
