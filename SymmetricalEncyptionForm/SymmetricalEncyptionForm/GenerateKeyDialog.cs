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
    public partial class GenerateKeyDialog : Form
    {
        public string keyName;
        public int keyLength;
        public GenerateKeyDialog()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBox1.Text))
            {
                //show error

            }
            else
            {
                DialogResult = DialogResult.OK;
                keyName = textBox1.Text;
                keyLength = (int)numericUpDown1.Value;
                this.Close();
            }
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
            this.Close();
        }
    }
}
