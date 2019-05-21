using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PowerSamples4WindowsFormApp.Samples;

namespace PowerSamples4WindowsFormApp
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;

            btn01.Click += (o, ex) => { new Form01().ShowDialog(); };

        }
    }
}
