﻿namespace e_Agenda.WinApp.ModuloTarefa
{
    partial class TelaTarefaForm
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
            btnCancelar = new Button();
            btnGravar = new Button();
            txtTitulo = new TextBox();
            label2 = new Label();
            txtId = new TextBox();
            label3 = new Label();
            txtDataCriacao = new DateTimePicker();
            label4 = new Label();
            label1 = new Label();
            cmbPrioridade = new ComboBox();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(403, 173);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 41);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            btnGravar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(322, 173);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(75, 41);
            btnGravar.TabIndex = 2;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            // 
            // txtTitulo
            // 
            txtTitulo.Location = new Point(84, 42);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.PlaceholderText = "Ex: Projeto EAgenda";
            txtTitulo.Size = new Size(395, 23);
            txtTitulo.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(35, 46);
            label2.Name = "label2";
            label2.Size = new Size(40, 15);
            label2.TabIndex = 8;
            label2.Text = "Título:";
            // 
            // txtId
            // 
            txtId.Location = new Point(84, 12);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(100, 23);
            txtId.TabIndex = 7;
            txtId.Text = "0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(53, 16);
            label3.Name = "label3";
            label3.Size = new Size(20, 15);
            label3.TabIndex = 6;
            label3.Text = "Id:";
            // 
            // txtDataCriacao
            // 
            txtDataCriacao.Format = DateTimePickerFormat.Short;
            txtDataCriacao.Location = new Point(328, 80);
            txtDataCriacao.Name = "txtDataCriacao";
            txtDataCriacao.Size = new Size(150, 23);
            txtDataCriacao.TabIndex = 17;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(229, 83);
            label4.Name = "label4";
            label4.Size = new Size(93, 15);
            label4.TabIndex = 16;
            label4.Text = "Data de Criação:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 80);
            label1.Name = "label1";
            label1.Size = new Size(64, 15);
            label1.TabIndex = 15;
            label1.Text = "Prioridade:";
            // 
            // cmbPrioridade
            // 
            cmbPrioridade.FormattingEnabled = true;
            cmbPrioridade.Location = new Point(84, 77);
            cmbPrioridade.Name = "cmbPrioridade";
            cmbPrioridade.Size = new Size(121, 23);
            cmbPrioridade.TabIndex = 14;
            // 
            // TelaTarefaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(497, 226);
            Controls.Add(txtDataCriacao);
            Controls.Add(label4);
            Controls.Add(label1);
            Controls.Add(cmbPrioridade);
            Controls.Add(txtTitulo);
            Controls.Add(label2);
            Controls.Add(txtId);
            Controls.Add(label3);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Name = "TelaTarefaForm";
            ShowIcon = false;
            Text = "Cadastro de Tarefas";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancelar;
        private Button btnGravar;
        private TextBox txtTitulo;
        private Label label2;
        private TextBox txtId;
        private Label label3;
        private DateTimePicker txtDataCriacao;
        private Label label4;
        private Label label1;
        private ComboBox cmbPrioridade;
    }
}