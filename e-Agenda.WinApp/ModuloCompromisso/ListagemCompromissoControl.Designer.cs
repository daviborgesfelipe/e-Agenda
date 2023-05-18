namespace e_Agenda.WinApp.ModuloCompromisso
{
    partial class ListagemCompromissoControl
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
            listCompromisso = new ListBox();
            SuspendLayout();
            // 
            // listCompromisso
            // 
            listCompromisso.Dock = DockStyle.Fill;
            listCompromisso.FormattingEnabled = true;
            listCompromisso.ItemHeight = 15;
            listCompromisso.Location = new Point(0, 0);
            listCompromisso.Name = "listCompromisso";
            listCompromisso.Size = new Size(150, 150);
            listCompromisso.TabIndex = 0;
            // 
            // ListagemCompromissoControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(listCompromisso);
            Name = "ListagemCompromissoControl";
            ResumeLayout(false);
        }

        #endregion

        private ListBox listCompromisso;
    }
}
