namespace JiPP5KaMil
{
    partial class ScoreboadForm
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
            this.dataGridViewWyniki = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWyniki)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewWyniki
            // 
            this.dataGridViewWyniki.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWyniki.Location = new System.Drawing.Point(54, 36);
            this.dataGridViewWyniki.Name = "dataGridViewWyniki";
            this.dataGridViewWyniki.Size = new System.Drawing.Size(696, 368);
            this.dataGridViewWyniki.TabIndex = 1;
            // 
            // ScoreboadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridViewWyniki);
            this.Name = "ScoreboadForm";
            this.Text = "Tablica wyników";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWyniki)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridViewWyniki;
    }
}