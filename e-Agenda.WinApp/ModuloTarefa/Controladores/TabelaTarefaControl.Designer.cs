namespace e_Agenda.WinApp.ModuloTarefa
{
    partial class TabelaTarefaControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            gridTarefas = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)gridTarefas).BeginInit();
            SuspendLayout();
            // 
            // gridTarefas
            // 
            gridTarefas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridTarefas.Dock = DockStyle.Fill;
            gridTarefas.Location = new Point(0, 0);
            gridTarefas.Name = "gridTarefas";
            gridTarefas.RowTemplate.Height = 25;
            gridTarefas.Size = new Size(621, 437);
            gridTarefas.TabIndex = 0;
            // 
            // TabelaTarefaControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(gridTarefas);
            Name = "TabelaTarefaControl";
            Size = new Size(621, 437);
            ((System.ComponentModel.ISupportInitialize)gridTarefas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView gridTarefas;
    }
}
