namespace e_Agenda.WinApp.ModuloTarefa
{
    partial class TelaFiltroTarefaForm
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
            rdbConcluidas = new RadioButton();
            rdbPendentes = new RadioButton();
            rdbTodos = new RadioButton();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(190, 190);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 45);
            btnCancelar.TabIndex = 19;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            btnGravar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(109, 190);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(75, 45);
            btnGravar.TabIndex = 20;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            // 
            // rdbConcluidas
            // 
            rdbConcluidas.AutoSize = true;
            rdbConcluidas.Location = new Point(24, 96);
            rdbConcluidas.Name = "rdbConcluidas";
            rdbConcluidas.Size = new Size(175, 19);
            rdbConcluidas.TabIndex = 23;
            rdbConcluidas.TabStop = true;
            rdbConcluidas.Text = "Visualizar Tarefas Concluídas";
            rdbConcluidas.UseVisualStyleBackColor = true;
            // 
            // rdbPendentes
            // 
            rdbPendentes.AutoSize = true;
            rdbPendentes.Location = new Point(24, 58);
            rdbPendentes.Name = "rdbPendentes";
            rdbPendentes.Size = new Size(171, 19);
            rdbPendentes.TabIndex = 22;
            rdbPendentes.TabStop = true;
            rdbPendentes.Text = "Visualizar Tarefas Pendentes";
            rdbPendentes.UseVisualStyleBackColor = true;
            // 
            // rdbTodos
            // 
            rdbTodos.AutoSize = true;
            rdbTodos.Location = new Point(24, 21);
            rdbTodos.Name = "rdbTodos";
            rdbTodos.Size = new Size(160, 19);
            rdbTodos.TabIndex = 21;
            rdbTodos.TabStop = true;
            rdbTodos.Text = "Visualizar Todas as Tarefas";
            rdbTodos.UseVisualStyleBackColor = true;
            // 
            // TelaFiltroTarefaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(277, 247);
            Controls.Add(rdbConcluidas);
            Controls.Add(rdbPendentes);
            Controls.Add(rdbTodos);
            Controls.Add(btnGravar);
            Controls.Add(btnCancelar);
            Name = "TelaFiltroTarefaForm";
            Text = "TelaFiltroTarefaForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnCancelar;
        private Button btnGravar;
        private RadioButton rdbConcluidas;
        private RadioButton rdbPendentes;
        private RadioButton rdbTodos;
    }
}