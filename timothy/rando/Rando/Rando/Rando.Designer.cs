namespace Rando
{
    partial class Rando
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            richBox = new RichTextBox();
            labelo = new Label();
            SuspendLayout();
            // 
            // richBox
            // 
            richBox.Location = new Point(32, 504);
            richBox.Name = "richBox";
            richBox.Size = new Size(100, 38);
            richBox.TabIndex = 0;
            richBox.Text = "";
            // 
            // labelo
            // 
            labelo.AutoSize = true;
            labelo.Location = new Point(232, 527);
            labelo.Name = "labelo";
            labelo.Size = new Size(38, 15);
            labelo.TabIndex = 1;
            labelo.Text = "label1";
            // 
            // Rando
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(612, 750);
            Controls.Add(labelo);
            Controls.Add(richBox);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Rando";
            Text = "Rando";
            Paint += Rando_Form_Paint;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox richBox;
        private Label labelo;
    }
}
