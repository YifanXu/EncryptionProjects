namespace SymmetricalEncyptionForm
{
    partial class KeySetDialog
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
            this.KeyDataGrid = new System.Windows.Forms.DataGridView();
            this.KeySetNameBox = new System.Windows.Forms.TextBox();
            this.KeySetLabel = new System.Windows.Forms.Label();
            this.NewKeyButton = new System.Windows.Forms.Button();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.KeyDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // KeyDataGrid
            // 
            this.KeyDataGrid.AllowUserToAddRows = false;
            this.KeyDataGrid.AllowUserToDeleteRows = false;
            this.KeyDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.KeyDataGrid.Location = new System.Drawing.Point(15, 138);
            this.KeyDataGrid.Name = "KeyDataGrid";
            this.KeyDataGrid.ReadOnly = true;
            this.KeyDataGrid.RowTemplate.Height = 24;
            this.KeyDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.KeyDataGrid.Size = new System.Drawing.Size(346, 330);
            this.KeyDataGrid.TabIndex = 0;
            // 
            // KeySetNameBox
            // 
            this.KeySetNameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.KeySetNameBox.Location = new System.Drawing.Point(80, 21);
            this.KeySetNameBox.Name = "KeySetNameBox";
            this.KeySetNameBox.ReadOnly = true;
            this.KeySetNameBox.Size = new System.Drawing.Size(281, 32);
            this.KeySetNameBox.TabIndex = 11;
            // 
            // KeySetLabel
            // 
            this.KeySetLabel.AutoSize = true;
            this.KeySetLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.KeySetLabel.Location = new System.Drawing.Point(10, 24);
            this.KeySetLabel.Name = "KeySetLabel";
            this.KeySetLabel.Size = new System.Drawing.Size(64, 29);
            this.KeySetLabel.TabIndex = 10;
            this.KeySetLabel.Text = "Key:";
            // 
            // NewKeyButton
            // 
            this.NewKeyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.NewKeyButton.Location = new System.Drawing.Point(19, 81);
            this.NewKeyButton.Name = "NewKeyButton";
            this.NewKeyButton.Size = new System.Drawing.Size(110, 34);
            this.NewKeyButton.TabIndex = 12;
            this.NewKeyButton.Text = "New Key";
            this.NewKeyButton.UseVisualStyleBackColor = true;
            this.NewKeyButton.Click += new System.EventHandler(this.NewKeyButton_Click);
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.ConfirmButton.Location = new System.Drawing.Point(135, 81);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(110, 34);
            this.ConfirmButton.TabIndex = 13;
            this.ConfirmButton.Text = "Confirm";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.CancelButton.Location = new System.Drawing.Point(251, 81);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(110, 34);
            this.CancelButton.TabIndex = 14;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // KeySetDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 493);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.ConfirmButton);
            this.Controls.Add(this.NewKeyButton);
            this.Controls.Add(this.KeySetNameBox);
            this.Controls.Add(this.KeySetLabel);
            this.Controls.Add(this.KeyDataGrid);
            this.Name = "KeySetDialog";
            this.Text = "KeySetDialog";
            this.Load += new System.EventHandler(this.KeySetDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.KeyDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView KeyDataGrid;
        private System.Windows.Forms.TextBox KeySetNameBox;
        private System.Windows.Forms.Label KeySetLabel;
        private System.Windows.Forms.Button NewKeyButton;
        private System.Windows.Forms.Button ConfirmButton;
        private System.Windows.Forms.Button CancelButton;
    }
}