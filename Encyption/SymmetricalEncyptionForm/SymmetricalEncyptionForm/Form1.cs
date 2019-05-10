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
        public KeySet k;

        public MainForm()
        {
            InitializeComponent();
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
                KeySetNameBox.Name = k.ToString();
            }
        }

        private void EncodeButton_Click(object sender, EventArgs e)
        {
            StringBuilder s = new StringBuilder();
            string input = InputTextBox.Text;
            for(int i = 0; i < input.Length; i++)
            {
                if(k.EncryptKey.TryGetValue(input[i], out string val))
                {
                    s.Append(val);
                }
            }
            //Append x number of extra distractory letters so k.charLength cannot be deduced from number of characters
            int tailLength = k.r.Next(k.charLength);
            for(int i = 0; i < tailLength; i++)
            {
                s.Append((char)k.r.Next(KeySet.ASCIIRangeStart, KeySet.ASCIIRangeEnd));
            }
            //Output
            OutputTextBox.ForeColor = Color.Black;
            OutputTextBox.Text = s.ToString();
        }

        private void DecodeButton_Click(object sender, EventArgs e)
        {
            StringBuilder s = new StringBuilder();
            string input = InputTextBox.Text;
            for(int i = 0; i < input.Length/k.charLength; i++)
            {
                var substring = input.Substring(i * k.charLength, k.charLength);
                if(k.DecryptKey.TryGetValue(substring, out char c))
                {
                    s.Append(c);
                }
                else
                {
                    OutputTextBox.ForeColor = Color.Red;
                    OutputTextBox.Text = "Decrypt key is Invalid. Decoded: " + s.ToString();
                    return;
                }
            }
            OutputTextBox.ForeColor = Color.Black;
            OutputTextBox.Text = s.ToString();
        }
    }
}
