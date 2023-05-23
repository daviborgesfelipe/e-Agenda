namespace e_Agenda.WinApp.ModuloCompromisso
{
    partial class TelaFiltroCompromissosForm
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
            radioBtnTodosCompromissos = new RadioButton();
            radioBtnCompromissosPassados = new RadioButton();
            radioBtnCompromissosFuturos = new RadioButton();
            panelPeriodoFuturo = new Panel();
            txtDataFinal = new DateTimePicker();
            txtDataInicial = new DateTimePicker();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btnGravar = new Button();
            btnCancelar = new Button();
            panelPeriodoFuturo.SuspendLayout();
            SuspendLayout();
            // 
            // radioBtnTodosCompromissos
            // 
            radioBtnTodosCompromissos.AutoSize = true;
            radioBtnTodosCompromissos.Location = new Point(47, 43);
            radioBtnTodosCompromissos.Name = "radioBtnTodosCompromissos";
            radioBtnTodosCompromissos.Size = new Size(205, 19);
            radioBtnTodosCompromissos.TabIndex = 0;
            radioBtnTodosCompromissos.TabStop = true;
            radioBtnTodosCompromissos.Text = "Visualizar todos os Compromissos";
            radioBtnTodosCompromissos.UseVisualStyleBackColor = true;
            // 
            // radioBtnCompromissosPassados
            // 
            radioBtnCompromissosPassados.AutoSize = true;
            radioBtnCompromissosPassados.Location = new Point(47, 87);
            radioBtnCompromissosPassados.Name = "radioBtnCompromissosPassados";
            radioBtnCompromissosPassados.Size = new Size(257, 19);
            radioBtnCompromissosPassados.TabIndex = 1;
            radioBtnCompromissosPassados.TabStop = true;
            radioBtnCompromissosPassados.Text = "Visualizar somente Compromissos Passados";
            radioBtnCompromissosPassados.UseVisualStyleBackColor = true;
            // 
            // radioBtnCompromissosFuturos
            // 
            radioBtnCompromissosFuturos.AutoSize = true;
            radioBtnCompromissosFuturos.Location = new Point(47, 130);
            radioBtnCompromissosFuturos.Name = "radioBtnCompromissosFuturos";
            radioBtnCompromissosFuturos.Size = new Size(249, 19);
            radioBtnCompromissosFuturos.TabIndex = 2;
            radioBtnCompromissosFuturos.TabStop = true;
            radioBtnCompromissosFuturos.Text = "Visualizar somente Compromissos Futuros";
            radioBtnCompromissosFuturos.UseVisualStyleBackColor = true;
            // 
            // panelPeriodoFuturo
            // 
            panelPeriodoFuturo.Controls.Add(txtDataFinal);
            panelPeriodoFuturo.Controls.Add(txtDataInicial);
            panelPeriodoFuturo.Controls.Add(label3);
            panelPeriodoFuturo.Controls.Add(label2);
            panelPeriodoFuturo.Location = new Point(47, 204);
            panelPeriodoFuturo.Name = "panelPeriodoFuturo";
            panelPeriodoFuturo.Size = new Size(409, 94);
            panelPeriodoFuturo.TabIndex = 3;
            // 
            // txtDataFinal
            // 
            txtDataFinal.Format = DateTimePickerFormat.Custom;
            txtDataFinal.Location = new Point(297, 35);
            txtDataFinal.Name = "txtDataFinal";
            txtDataFinal.Size = new Size(100, 23);
            txtDataFinal.TabIndex = 3;
            // 
            // txtDataInicial
            // 
            txtDataInicial.Format = DateTimePickerFormat.Custom;
            txtDataInicial.Location = new Point(101, 35);
            txtDataInicial.Name = "txtDataInicial";
            txtDataInicial.Size = new Size(100, 23);
            txtDataInicial.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(219, 41);
            label3.Name = "label3";
            label3.Size = new Size(62, 15);
            label3.TabIndex = 1;
            label3.Text = "Data Final:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(24, 41);
            label2.Name = "label2";
            label2.Size = new Size(71, 15);
            label2.TabIndex = 0;
            label2.Text = "Data Inicial: ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(50, 186);
            label1.Name = "label1";
            label1.Size = new Size(207, 15);
            label1.TabIndex = 4;
            label1.Text = "Filtro para os Compromissos Futuros: ";
            // 
            // btnGravar
            // 
            btnGravar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(300, 341);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(75, 45);
            btnGravar.TabIndex = 20;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(381, 341);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 45);
            btnCancelar.TabIndex = 19;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // TelaFiltroCompromissosForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(501, 398);
            Controls.Add(btnGravar);
            Controls.Add(btnCancelar);
            Controls.Add(label1);
            Controls.Add(panelPeriodoFuturo);
            Controls.Add(radioBtnCompromissosFuturos);
            Controls.Add(radioBtnCompromissosPassados);
            Controls.Add(radioBtnTodosCompromissos);
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(467, 437);
            Name = "TelaFiltroCompromissosForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Filtro de Compromissos";
            panelPeriodoFuturo.ResumeLayout(false);
            panelPeriodoFuturo.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RadioButton radioBtnTodosCompromissos;
        private RadioButton radioBtnCompromissosPassados;
        private RadioButton radioBtnCompromissosFuturos;
        private Panel panelPeriodoFuturo;
        private Label label3;
        private Label label2;
        private Label label1;
        private DateTimePicker txtDataFinal;
        private DateTimePicker txtDataInicial;
        private Button btnGravar;
        private Button btnCancelar;
    }
}