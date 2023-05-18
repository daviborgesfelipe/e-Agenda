namespace e_Agenda.WinApp.ModuloCompromisso
{
    partial class TelaCompromissoForm
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
            lblNumero = new Label();
            textBox1 = new TextBox();
            lblAssunto = new Label();
            textBox2 = new TextBox();
            lblDataCompromisso = new Label();
            lblInicio = new Label();
            lblTermino = new Label();
            radioBtnContato = new RadioButton();
            comboBoxContatos = new ComboBox();
            dateTimePicker1 = new DateTimePicker();
            pnlLocalizacao = new Panel();
            txtBoxPresencial = new TextBox();
            txtBoxRemoto = new TextBox();
            radioBtnPresencial = new RadioButton();
            radioBtnRemoto = new RadioButton();
            maskedTextBox1 = new MaskedTextBox();
            maskedTextBox2 = new MaskedTextBox();
            label1 = new Label();
            btnCancelar = new Button();
            btnGravar = new Button();
            pnlLocalizacao.SuspendLayout();
            SuspendLayout();
            // 
            // lblNumero
            // 
            lblNumero.AutoSize = true;
            lblNumero.Location = new Point(12, 9);
            lblNumero.Name = "lblNumero";
            lblNumero.Size = new Size(57, 15);
            lblNumero.TabIndex = 0;
            lblNumero.Text = "Numero: ";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(75, 6);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(205, 23);
            textBox1.TabIndex = 1;
            // 
            // lblAssunto
            // 
            lblAssunto.AutoSize = true;
            lblAssunto.Location = new Point(12, 43);
            lblAssunto.Name = "lblAssunto";
            lblAssunto.Size = new Size(56, 15);
            lblAssunto.TabIndex = 2;
            lblAssunto.Text = "Assunto: ";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(75, 40);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(342, 23);
            textBox2.TabIndex = 3;
            // 
            // lblDataCompromisso
            // 
            lblDataCompromisso.AutoSize = true;
            lblDataCompromisso.Location = new Point(12, 80);
            lblDataCompromisso.Name = "lblDataCompromisso";
            lblDataCompromisso.Size = new Size(109, 15);
            lblDataCompromisso.TabIndex = 4;
            lblDataCompromisso.Text = "Data Compromisso";
            // 
            // lblInicio
            // 
            lblInicio.AutoSize = true;
            lblInicio.Location = new Point(75, 128);
            lblInicio.Name = "lblInicio";
            lblInicio.Size = new Size(36, 15);
            lblInicio.TabIndex = 5;
            lblInicio.Text = "Inicio";
            // 
            // lblTermino
            // 
            lblTermino.AutoSize = true;
            lblTermino.Location = new Point(241, 128);
            lblTermino.Name = "lblTermino";
            lblTermino.Size = new Size(50, 15);
            lblTermino.TabIndex = 6;
            lblTermino.Text = "Termino";
            // 
            // radioBtnContato
            // 
            radioBtnContato.AutoSize = true;
            radioBtnContato.Location = new Point(75, 159);
            radioBtnContato.Name = "radioBtnContato";
            radioBtnContato.Size = new Size(276, 19);
            radioBtnContato.TabIndex = 7;
            radioBtnContato.TabStop = true;
            radioBtnContato.Text = "Deseja marcar um contato neste compromisso?";
            radioBtnContato.UseVisualStyleBackColor = true;
            // 
            // comboBoxContatos
            // 
            comboBoxContatos.FormattingEnabled = true;
            comboBoxContatos.Location = new Point(75, 184);
            comboBoxContatos.Name = "comboBoxContatos";
            comboBoxContatos.Size = new Size(342, 23);
            comboBoxContatos.TabIndex = 8;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.AllowDrop = true;
            dateTimePicker1.CustomFormat = " dd/MM/yyyy";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.ImeMode = ImeMode.NoControl;
            dateTimePicker1.Location = new Point(127, 80);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(108, 23);
            dateTimePicker1.TabIndex = 11;
            // 
            // pnlLocalizacao
            // 
            pnlLocalizacao.BackgroundImageLayout = ImageLayout.Center;
            pnlLocalizacao.BorderStyle = BorderStyle.FixedSingle;
            pnlLocalizacao.Controls.Add(txtBoxPresencial);
            pnlLocalizacao.Controls.Add(txtBoxRemoto);
            pnlLocalizacao.Controls.Add(radioBtnPresencial);
            pnlLocalizacao.Controls.Add(radioBtnRemoto);
            pnlLocalizacao.ForeColor = SystemColors.ControlDarkDark;
            pnlLocalizacao.Location = new Point(75, 232);
            pnlLocalizacao.Name = "pnlLocalizacao";
            pnlLocalizacao.Size = new Size(342, 79);
            pnlLocalizacao.TabIndex = 14;
            // 
            // txtBoxPresencial
            // 
            txtBoxPresencial.Location = new Point(115, 40);
            txtBoxPresencial.Name = "txtBoxPresencial";
            txtBoxPresencial.Size = new Size(179, 23);
            txtBoxPresencial.TabIndex = 3;
            // 
            // txtBoxRemoto
            // 
            txtBoxRemoto.Location = new Point(115, 11);
            txtBoxRemoto.Name = "txtBoxRemoto";
            txtBoxRemoto.Size = new Size(179, 23);
            txtBoxRemoto.TabIndex = 2;
            // 
            // radioBtnPresencial
            // 
            radioBtnPresencial.AutoSize = true;
            radioBtnPresencial.Location = new Point(23, 44);
            radioBtnPresencial.Name = "radioBtnPresencial";
            radioBtnPresencial.Size = new Size(84, 19);
            radioBtnPresencial.TabIndex = 1;
            radioBtnPresencial.TabStop = true;
            radioBtnPresencial.Text = "Presencial: ";
            radioBtnPresencial.UseVisualStyleBackColor = true;
            // 
            // radioBtnRemoto
            // 
            radioBtnRemoto.AutoSize = true;
            radioBtnRemoto.Location = new Point(23, 12);
            radioBtnRemoto.Name = "radioBtnRemoto";
            radioBtnRemoto.Size = new Size(73, 19);
            radioBtnRemoto.TabIndex = 0;
            radioBtnRemoto.TabStop = true;
            radioBtnRemoto.Text = "Remoto: ";
            radioBtnRemoto.UseVisualStyleBackColor = true;
            // 
            // maskedTextBox1
            // 
            maskedTextBox1.Location = new Point(127, 125);
            maskedTextBox1.Mask = "90:00";
            maskedTextBox1.Name = "maskedTextBox1";
            maskedTextBox1.Size = new Size(108, 23);
            maskedTextBox1.TabIndex = 15;
            maskedTextBox1.TextAlign = HorizontalAlignment.Center;
            maskedTextBox1.ValidatingType = typeof(DateTime);
            // 
            // maskedTextBox2
            // 
            maskedTextBox2.Location = new Point(317, 125);
            maskedTextBox2.Mask = "90:00";
            maskedTextBox2.Name = "maskedTextBox2";
            maskedTextBox2.Size = new Size(100, 23);
            maskedTextBox2.TabIndex = 16;
            maskedTextBox2.TextAlign = HorizontalAlignment.Center;
            maskedTextBox2.ValidatingType = typeof(DateTime);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(79, 214);
            label1.Name = "label1";
            label1.Size = new Size(68, 15);
            label1.TabIndex = 0;
            label1.Text = "Localização";
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(342, 341);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 45);
            btnCancelar.TabIndex = 17;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            btnGravar.Location = new Point(261, 341);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(75, 45);
            btnGravar.TabIndex = 18;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            // 
            // TelaCompromissoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(451, 398);
            Controls.Add(btnGravar);
            Controls.Add(btnCancelar);
            Controls.Add(label1);
            Controls.Add(maskedTextBox2);
            Controls.Add(maskedTextBox1);
            Controls.Add(pnlLocalizacao);
            Controls.Add(dateTimePicker1);
            Controls.Add(comboBoxContatos);
            Controls.Add(radioBtnContato);
            Controls.Add(lblTermino);
            Controls.Add(lblInicio);
            Controls.Add(lblDataCompromisso);
            Controls.Add(textBox2);
            Controls.Add(lblAssunto);
            Controls.Add(textBox1);
            Controls.Add(lblNumero);
            Name = "TelaCompromissoForm";
            ShowIcon = false;
            Text = "Cadastro Compromisso";
            pnlLocalizacao.ResumeLayout(false);
            pnlLocalizacao.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNumero;
        private TextBox textBox1;
        private Label lblAssunto;
        private TextBox textBox2;
        private Label lblDataCompromisso;
        private Label lblInicio;
        private Label lblTermino;
        private RadioButton radioBtnContato;
        private ComboBox comboBoxContatos;
        private DateTimePicker dateTimePicker1;
        private Panel pnlLocalizacao;
        private MaskedTextBox maskedTextBox1;
        private MaskedTextBox maskedTextBox2;
        private Label label1;
        private TextBox txtBoxPresencial;
        private TextBox txtBoxRemoto;
        private RadioButton radioBtnPresencial;
        private RadioButton radioBtnRemoto;
        private Button btnCancelar;
        private Button btnGravar;
    }
}