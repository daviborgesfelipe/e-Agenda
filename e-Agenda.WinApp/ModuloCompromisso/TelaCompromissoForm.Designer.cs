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
            components = new System.ComponentModel.Container();
            lblNumero = new Label();
            txtNumero = new TextBox();
            lblAssunto = new Label();
            txtAssunto = new TextBox();
            lblDataCompromisso = new Label();
            lblInicio = new Label();
            lblTermino = new Label();
            comboBoxContatos = new ComboBox();
            repositorioContatoBindingSource = new BindingSource(components);
            txtDataCompromisso = new DateTimePicker();
            pnlLocalizacao = new Panel();
            txtBoxPresencial = new TextBox();
            txtBoxRemoto = new TextBox();
            radioBtnPresencial = new RadioButton();
            radioBtnRemoto = new RadioButton();
            txtInicio = new MaskedTextBox();
            txtTermino = new MaskedTextBox();
            label1 = new Label();
            btnCancelar = new Button();
            btnGravar = new Button();
            contatoBindingSource = new BindingSource(components);
            checkBoxDesejaContato = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)repositorioContatoBindingSource).BeginInit();
            pnlLocalizacao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)contatoBindingSource).BeginInit();
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
            // txtNumero
            // 
            txtNumero.Location = new Point(75, 6);
            txtNumero.Name = "txtNumero";
            txtNumero.Size = new Size(205, 23);
            txtNumero.TabIndex = 1;
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
            // txtAssunto
            // 
            txtAssunto.Location = new Point(75, 40);
            txtAssunto.Name = "txtAssunto";
            txtAssunto.Size = new Size(342, 23);
            txtAssunto.TabIndex = 3;
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
            // comboBoxContatos
            // 
            comboBoxContatos.DataSource = repositorioContatoBindingSource;
            comboBoxContatos.FormattingEnabled = true;
            comboBoxContatos.Location = new Point(75, 184);
            comboBoxContatos.Name = "comboBoxContatos";
            comboBoxContatos.Size = new Size(342, 23);
            comboBoxContatos.TabIndex = 8;
            // 
            // repositorioContatoBindingSource
            // 
            repositorioContatoBindingSource.DataSource = typeof(ModuloContato.RepositorioContato);
            // 
            // txtDataCompromisso
            // 
            txtDataCompromisso.AllowDrop = true;
            txtDataCompromisso.CustomFormat = " dd/MM/yyyy";
            txtDataCompromisso.Format = DateTimePickerFormat.Custom;
            txtDataCompromisso.ImeMode = ImeMode.NoControl;
            txtDataCompromisso.Location = new Point(127, 80);
            txtDataCompromisso.Name = "txtDataCompromisso";
            txtDataCompromisso.Size = new Size(100, 23);
            txtDataCompromisso.TabIndex = 11;
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
            radioBtnPresencial.ForeColor = SystemColors.ActiveCaptionText;
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
            radioBtnRemoto.ForeColor = SystemColors.ActiveCaptionText;
            radioBtnRemoto.Location = new Point(23, 12);
            radioBtnRemoto.Name = "radioBtnRemoto";
            radioBtnRemoto.Size = new Size(73, 19);
            radioBtnRemoto.TabIndex = 0;
            radioBtnRemoto.TabStop = true;
            radioBtnRemoto.Text = "Remoto: ";
            radioBtnRemoto.UseVisualStyleBackColor = true;
            // 
            // txtInicio
            // 
            txtInicio.Location = new Point(127, 125);
            txtInicio.Mask = "90:00";
            txtInicio.Name = "txtInicio";
            txtInicio.Size = new Size(100, 23);
            txtInicio.TabIndex = 15;
            txtInicio.TextAlign = HorizontalAlignment.Center;
            txtInicio.ValidatingType = typeof(DateTime);
            // 
            // txtTermino
            // 
            txtTermino.Location = new Point(317, 125);
            txtTermino.Mask = "90:00";
            txtTermino.Name = "txtTermino";
            txtTermino.Size = new Size(100, 23);
            txtTermino.TabIndex = 16;
            txtTermino.TextAlign = HorizontalAlignment.Center;
            txtTermino.ValidatingType = typeof(DateTime);
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
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(342, 341);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 45);
            btnCancelar.TabIndex = 17;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            btnGravar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(261, 341);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(75, 45);
            btnGravar.TabIndex = 18;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // contatoBindingSource
            // 
            contatoBindingSource.DataSource = typeof(ModuloContato.Contato);
            // 
            // checkBoxDesejaContato
            // 
            checkBoxDesejaContato.AutoSize = true;
            checkBoxDesejaContato.Location = new Point(75, 159);
            checkBoxDesejaContato.Name = "checkBoxDesejaContato";
            checkBoxDesejaContato.Size = new Size(277, 19);
            checkBoxDesejaContato.TabIndex = 19;
            checkBoxDesejaContato.Text = "Deseja marcar um contato neste compromisso?";
            checkBoxDesejaContato.UseVisualStyleBackColor = true;
            // 
            // TelaCompromissoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(451, 398);
            Controls.Add(checkBoxDesejaContato);
            Controls.Add(btnGravar);
            Controls.Add(btnCancelar);
            Controls.Add(label1);
            Controls.Add(txtTermino);
            Controls.Add(txtInicio);
            Controls.Add(pnlLocalizacao);
            Controls.Add(txtDataCompromisso);
            Controls.Add(comboBoxContatos);
            Controls.Add(lblTermino);
            Controls.Add(lblInicio);
            Controls.Add(lblDataCompromisso);
            Controls.Add(txtAssunto);
            Controls.Add(lblAssunto);
            Controls.Add(txtNumero);
            Controls.Add(lblNumero);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(467, 437);
            Name = "TelaCompromissoForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro Compromisso";
            ((System.ComponentModel.ISupportInitialize)repositorioContatoBindingSource).EndInit();
            pnlLocalizacao.ResumeLayout(false);
            pnlLocalizacao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)contatoBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNumero;
        private TextBox txtNumero;
        private Label lblAssunto;
        private TextBox txtAssunto;
        private Label lblDataCompromisso;
        private Label lblInicio;
        private Label lblTermino;
        private ComboBox comboBoxContatos;
        private DateTimePicker txtDataCompromisso;
        private Panel pnlLocalizacao;
        private MaskedTextBox txtInicio;
        private MaskedTextBox txtTermino;
        private Label label1;
        private TextBox txtBoxPresencial;
        private TextBox txtBoxRemoto;
        private RadioButton radioBtnPresencial;
        private RadioButton radioBtnRemoto;
        private Button btnCancelar;
        private Button btnGravar;
        private BindingSource repositorioContatoBindingSource;
        private BindingSource contatoBindingSource;
        private CheckBox checkBoxDesejaContato;
    }
}