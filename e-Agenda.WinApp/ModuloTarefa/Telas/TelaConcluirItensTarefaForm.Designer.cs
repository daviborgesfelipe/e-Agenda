namespace e_Agenda.WinApp.ModuloTarefa
{
    partial class TelaConcluirItensTarefaForm
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
            txtTitulo = new TextBox();
            label2 = new Label();
            txtId = new TextBox();
            label3 = new Label();
            btnGravar = new Button();
            btnCancelar = new Button();
            listItensTarefa = new CheckedListBox();
            SuspendLayout();
            // 
            // txtTitulo
            // 
            txtTitulo.Location = new Point(69, 42);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.ReadOnly = true;
            txtTitulo.Size = new Size(412, 23);
            txtTitulo.TabIndex = 35;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 46);
            label2.Name = "label2";
            label2.Size = new Size(40, 15);
            label2.TabIndex = 34;
            label2.Text = "Título:";
            // 
            // txtId
            // 
            txtId.Location = new Point(69, 12);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(71, 23);
            txtId.TabIndex = 33;
            txtId.Text = "0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(38, 16);
            label3.Name = "label3";
            label3.Size = new Size(20, 15);
            label3.TabIndex = 32;
            label3.Text = "Id:";
            // 
            // btnGravar
            // 
            btnGravar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(325, 336);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(75, 45);
            btnGravar.TabIndex = 31;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(406, 336);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 45);
            btnCancelar.TabIndex = 30;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // listItensTarefa
            // 
            listItensTarefa.FormattingEnabled = true;
            listItensTarefa.Location = new Point(16, 98);
            listItensTarefa.Name = "listItensTarefa";
            listItensTarefa.Size = new Size(465, 220);
            listItensTarefa.TabIndex = 38;
            // 
            // TelaConcluirItensTarefaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(497, 396);
            Controls.Add(listItensTarefa);
            Controls.Add(txtTitulo);
            Controls.Add(label2);
            Controls.Add(txtId);
            Controls.Add(label3);
            Controls.Add(btnGravar);
            Controls.Add(btnCancelar);
            Name = "TelaConcluirItensTarefaForm";
            ShowIcon = false;
            Text = "Concluir Itens da Tarefa";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtTitulo;
        private Label label2;
        private TextBox txtId;
        private Label label3;
        private Button btnGravar;
        private Button btnCancelar;
        private CheckedListBox listItensTarefa;
    }
}