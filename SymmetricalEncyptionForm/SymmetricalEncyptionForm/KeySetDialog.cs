using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SymmetricalEncyptionForm
{
    public partial class KeySetDialog : Form
    {
        public ComplexKeySet k;

        public KeySetDialog(ComplexKeySet currentKey)
        {
            InitializeComponent();
            k = currentKey;
            
            DisplayKey();
        }

        private void NewKeyButton_Click(object sender, EventArgs e)
        {
            GenerateKeyDialog f = new GenerateKeyDialog();
            f.ShowDialog();
            if(f.DialogResult == DialogResult.OK)
            {
                k = new ComplexKeySet(f.keyName, f.keyLength);
                KeySetNameBox.Text = k.name;
                DisplayKey();
            }
        }

        private void DisplayKey()
        {
            if(k == null)
            {
                KeySetNameBox.Enabled = false;
                return;
            }
            KeySetNameBox.Enabled = true;
            KeySetNameBox.Text = k.ToString();

            var grid = KeyDataGrid;
            grid.Rows.Clear();
            grid.Columns.Clear();
            grid.ColumnCount = 1;
            grid.Columns[0].Name = "Value";

            foreach (var pair in k.key)
            {
                var row = new DataGridViewRow();
                row.HeaderCell.Value = pair.key.ToString();
                row.Cells.Add(new DataGridViewTextBoxCell()
                {
                    Value = pair.value
                });
                grid.Rows.Add(row);
            }
        }

        private void KeySetDialog_Load(object sender, EventArgs e)
        {

        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
            this.Close();
        }
    }
}
