namespace ParticleFieldSimulation
{
    partial class MainWindow
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
            this._spacePanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // _spacePanel
            // 
            this._spacePanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this._spacePanel.Location = new System.Drawing.Point(12, 12);
            this._spacePanel.Name = "_spacePanel";
            this._spacePanel.Size = new System.Drawing.Size(515, 493);
            this._spacePanel.TabIndex = 0;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 517);
            this.Controls.Add(this._spacePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(555, 555);
            this.MinimumSize = new System.Drawing.Size(555, 555);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel _spacePanel;
    }
}

