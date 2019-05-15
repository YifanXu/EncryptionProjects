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
    public partial class MainForm : Form
    {
        public ComplexKeySet k;

        public MainForm()
        {
            InitializeComponent();
            k = new ComplexKeySet("default", 2);
            UpdateKeySet();
        }

        private void KeySetButton_Click(object sender, EventArgs e)
        {
            KeySetDialog dialog = new KeySetDialog(k);
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                k = dialog.k;
            }
            UpdateKeySet();
        }

        private void UpdateKeySet()
        {
            var kExist = k != null;
            KeySetNameBox.Enabled = kExist;
            EncodeButton.Enabled = kExist;
            DecodeButton.Enabled = kExist;
            if(k != null)
            {
                KeySetNameBox.Enabled = true;
                KeySetNameBox.Text = k.ToString();
            }
        }

        private void EncodeButton_Click(object sender, EventArgs e)
        {
            if (k == null)
            {
                OutputTextBox.ForeColor = Color.Red;
                OutputTextBox.Text = "No key";
            }
            string[] paragraphs = InputTextBox.Text.Split('\n');
            StringBuilder output = new StringBuilder();
            try
            {
                Random r = new Random();
                for (int i = 0; i < paragraphs.Length; i++)
                {
                    output.Append(k.Encrypt(paragraphs[i],r));
                    if (i != paragraphs.Length - 1) output.Append('\n');
                }
                OutputTextBox.ForeColor = Color.Black;
                OutputTextBox.Text = output.ToString();
            }
            catch(Exception ex)
            {
                OutputTextBox.ForeColor = Color.Red;
                OutputTextBox.Text = $"The message could not be encoded. Error: {ex.GetType()} - \"{ex.Message}\"";
            }
            
        }

        private void DecodeButton_Click(object sender, EventArgs e)
        {
            if (k == null)
            {
                OutputTextBox.ForeColor = Color.Red;
                OutputTextBox.Text = "No key";
            }
            string[] paragraphs = InputTextBox.Text.Split('\n');
            StringBuilder output = new StringBuilder();
            try
            {
                for (int i = 0; i < paragraphs.Length; i++)
                {
                    if (string.IsNullOrEmpty(paragraphs[i])) continue;
                    output.Append(k.Decrypt(paragraphs[i]));
                    if (i != paragraphs.Length - 1) output.Append('\n');
                }
                OutputTextBox.ForeColor = Color.Black;
                OutputTextBox.Text = output.ToString();
            }
            catch(Exception ex)
            {
                OutputTextBox.ForeColor = Color.Red;
                OutputTextBox.Text = $"The message could not be encoded. Error: {ex.GetType()} - \"{ex.Message}\"";
            }
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
