namespace e_Agenda.WinApp.ModuloTarefa
{
    partial class TelaItensTarefaForm
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
            btnGravar = new Button();
            btnCancelar = new Button();
            txtTitulo = new TextBox();
            label2 = new Label();
            txtId = new TextBox();
            label3 = new Label();
            txtDescricao = new TextBox();
            lblDescricao = new Label();
            listaItensTarefa = new ListBox();
            btnAdicionar = new Button();
            SuspendLayout();
            // 
            // btnGravar
            // 
            btnGravar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(328, 339);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(75, 45);
            btnGravar.TabIndex = 22;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(409, 339);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 45);
            btnCancelar.TabIndex = 21;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // txtTitulo
            // 
            txtTitulo.Location = new Point(89, 48);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.ReadOnly = true;
            txtTitulo.Size = new Size(395, 23);
            txtTitulo.TabIndex = 26;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(40, 52);
            label2.Name = "label2";
            label2.Size = new Size(40, 15);
            label2.TabIndex = 25;
            label2.Text = "Título:";
            // 
            // txtId
            // 
            txtId.Location = new Point(89, 18);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(100, 23);
            txtId.TabIndex = 24;
            txtId.Text = "0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(58, 22);
            label3.Name = "label3";
            label3.Size = new Size(20, 15);
            label3.TabIndex = 23;
            label3.Text = "Id:";
            // 
            // txtDescricao
            // 
            txtDescricao.Location = new Point(90, 77);
            txtDescricao.Name = "txtDescricao";
            txtDescricao.Size = new Size(313, 23);
            txtDescricao.TabIndex = 28;
            // 
            // lblDescricao
            // 
            lblDescricao.AutoSize = true;
            lblDescricao.Location = new Point(19, 80);
            lblDescricao.Name = "lblDescricao";
            lblDescricao.Size = new Size(61, 15);
            lblDescricao.TabIndex = 27;
            lblDescricao.Text = "Descrição:";
            // 
            // listaItensTarefa
            // 
            listaItensTarefa.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listaItensTarefa.FormattingEnabled = true;
            listaItensTarefa.ItemHeight = 15;
            listaItensTarefa.Location = new Point(19, 117);
            listaItensTarefa.Name = "listaItensTarefa";
            listaItensTarefa.Size = new Size(465, 199);
            listaItensTarefa.TabIndex = 29;
            // 
            // btnAdicionar
            // 
            btnAdicionar.Location = new Point(409, 77);
            btnAdicionar.Name = "btnAdicionar";
            btnAdicionar.Size = new Size(75, 23);
            btnAdicionar.TabIndex = 30;
            btnAdicionar.Text = "Adicionar";
            btnAdicionar.UseVisualStyleBackColor = true;
            btnAdicionar.Click += btnAdicionar_Click;
            // 
            // TelaItensTarefaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(497, 396);
            Controls.Add(btnAdicionar);
            Controls.Add(listaItensTarefa);
            Controls.Add(txtDescricao);
            Controls.Add(lblDescricao);
            Controls.Add(txtTitulo);
            Controls.Add(label2);
            Controls.Add(txtId);
            Controls.Add(label3);
            Controls.Add(btnGravar);
            Controls.Add(btnCancelar);
            Name = "TelaItensTarefaForm";
            Text = "TelaItensTarefa";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnGravar;
        private Button btnCancelar;
        private TextBox txtTitulo;
        private Label label2;
        private TextBox txtId;
        private Label label3;
        private TextBox txtDescricao;
        private Label lblDescricao;
        private ListBox listaItensTarefa;
        private Button btnAdicionar;
    }
}