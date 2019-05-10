namespace SymmetricalEncyptionForm
{
    partial class MainForm
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
            this.KeySetLabel = new System.Windows.Forms.Label();
            this.InputTextBox = new System.Windows.Forms.RichTextBox();
            this.OutputTextBox = new System.Windows.Forms.RichTextBox();
            this.InputTextLabel = new System.Windows.Forms.Label();
            this.OutputTextLabel = new System.Windows.Forms.Label();
            this.EncodeButton = new System.Windows.Forms.Button();
            this.DecodeButton = new System.Windows.Forms.Button();
            this.ImportButton = new System.Windows.Forms.Button();
            this.KeySetButton = new System.Windows.Forms.Button();
            this.KeySetNameBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // KeySetLabel
            // 
            this.KeySetLabel.AutoSize = true;
            this.KeySetLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.KeySetLabel.Location = new System.Drawing.Point(32, 31);
            this.KeySetLabel.Name = "KeySetLabel";
            this.KeySetLabel.Size = new System.Drawing.Size(199, 29);
            this.KeySetLabel.TabIndex = 0;
            this.KeySetLabel.Text = "Current KeySet: ";
            // 
            // InputTextBox
            // 
            this.InputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.InputTextBox.Location = new System.Drawing.Point(37, 110);
            this.InputTextBox.Name = "InputTextBox";
            this.InputTextBox.Size = new System.Drawing.Size(600, 250);
            this.InputTextBox.TabIndex = 1;
            this.InputTextBox.Text = "";
            // 
            // OutputTextBox
            // 
            this.OutputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.OutputTextBox.Location = new System.Drawing.Point(37, 424);
            this.OutputTextBox.Name = "OutputTextBox";
            this.OutputTextBox.ReadOnly = true;
            this.OutputTextBox.Size = new System.Drawing.Size(600, 250);
            this.OutputTextBox.TabIndex = 2;
            this.OutputTextBox.Text = "";
            // 
            // InputTextLabel
            // 
            this.InputTextLabel.AutoSize = true;
            this.InputTextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.InputTextLabel.Location = new System.Drawing.Point(32, 78);
            this.InputTextLabel.Name = "InputTextLabel";
            this.InputTextLabel.Size = new System.Drawing.Size(123, 29);
            this.InputTextLabel.TabIndex = 3;
            this.InputTextLabel.Text = "Input Text";
            // 
            // OutputTextLabel
            // 
            this.OutputTextLabel.AutoSize = true;
            this.OutputTextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.OutputTextLabel.Location = new System.Drawing.Point(32, 392);
            this.OutputTextLabel.Name = "OutputTextLabel";
            this.OutputTextLabel.Size = new System.Drawing.Size(143, 29);
            this.OutputTextLabel.TabIndex = 4;
            this.OutputTextLabel.Text = "Output Text";
            // 
            // EncodeButton
            // 
            this.EncodeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.EncodeButton.Location = new System.Drawing.Point(295, 680);
            this.EncodeButton.Name = "EncodeButton";
            this.EncodeButton.Size = new System.Drawing.Size(110, 34);
            this.EncodeButton.TabIndex = 5;
            this.EncodeButton.Text = "Encode";
            this.EncodeButton.UseVisualStyleBackColor = true;
            this.EncodeButton.Click += new System.EventHandler(this.EncodeButton_Click);
            // 
            // DecodeButton
            // 
            this.DecodeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.DecodeButton.Location = new System.Drawing.Point(411, 680);
            this.DecodeButton.Name = "DecodeButton";
            this.DecodeButton.Size = new System.Drawing.Size(110, 34);
            this.DecodeButton.TabIndex = 6;
            this.DecodeButton.Text = "Decode";
            this.DecodeButton.UseVisualStyleBackColor = true;
            this.DecodeButton.Click += new System.EventHandler(this.DecodeButton_Click);
            // 
            // ImportButton
            // 
            this.ImportButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.ImportButton.Location = new System.Drawing.Point(527, 680);
            this.ImportButton.Name = "ImportButton";
            this.ImportButton.Size = new System.Drawing.Size(110, 34);
            this.ImportButton.TabIndex = 7;
            this.ImportButton.Text = "Close";
            this.ImportButton.UseVisualStyleBackColor = true;
            this.ImportButton.Click += new System.EventHandler(this.ImportButton_Click);
            // 
            // KeySetButton
            // 
            this.KeySetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.KeySetButton.Location = new System.Drawing.Point(508, 31);
            this.KeySetButton.Name = "KeySetButton";
            this.KeySetButton.Size = new System.Drawing.Size(129, 34);
            this.KeySetButton.TabIndex = 8;
            this.KeySetButton.Text = "Options";
            this.KeySetButton.UseVisualStyleBackColor = true;
            this.KeySetButton.Click += new System.EventHandler(this.KeySetButton_Click);
            // 
            // KeySetNameBox
            // 
            this.KeySetNameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.KeySetNameBox.Location = new System.Drawing.Point(221, 31);
            this.KeySetNameBox.Name = "KeySetNameBox";
            this.KeySetNameBox.ReadOnly = true;
            this.KeySetNameBox.Size = new System.Drawing.Size(281, 32);
            this.KeySetNameBox.TabIndex = 9;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 729);
            this.Controls.Add(this.KeySetNameBox);
            this.Controls.Add(this.KeySetButton);
            this.Controls.Add(this.ImportButton);
            this.Controls.Add(this.DecodeButton);
            this.Controls.Add(this.EncodeButton);
            this.Controls.Add(this.OutputTextLabel);
            this.Controls.Add(this.InputTextLabel);
            this.Controls.Add(this.OutputTextBox);
            this.Controls.Add(this.InputTextBox);
            this.Controls.Add(this.KeySetLabel);
            this.Name = "MainForm";
            this.Text = "SymmerticalEncryptor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label KeySetLabel;
        private System.Windows.Forms.RichTextBox InputTextBox;
        private System.Windows.Forms.RichTextBox OutputTextBox;
        private System.Windows.Forms.Label InputTextLabel;
        private System.Windows.Forms.Label OutputTextLabel;
        private System.Windows.Forms.Button EncodeButton;
        private System.Windows.Forms.Button DecodeButton;
        private System.Windows.Forms.Button ImportButton;
        private System.Windows.Forms.Button KeySetButton;
        private System.Windows.Forms.TextBox KeySetNameBox;
    }
}

