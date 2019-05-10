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
        public KeySet k;

        public KeySetDialog(KeySet currentKey)
        {
            k = currentKey;
            InitializeComponent();
        }

        private void NewKeyButton_Click(object sender, EventArgs e)
        {
            
        }

        private void KeySetDialog_Load(object sender, EventArgs e)
        {

        }
    }
}
