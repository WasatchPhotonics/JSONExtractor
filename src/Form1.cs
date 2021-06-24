using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JSONExtractor
{
    public partial class Form1 : Form
    {
        string samplePathname;

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonLoadSample_Click(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(buttonLoadSample, null);
            samplePathname = null;

            var result = openFileDialogSample.ShowDialog();
            if (result != DialogResult.OK)
                return;

            samplePathname = openFileDialogSample.FileName;
            toolTip1.SetToolTip(buttonLoadSample, samplePathname);
            var json = loadJson(samplePathname);
        }
    }
}
