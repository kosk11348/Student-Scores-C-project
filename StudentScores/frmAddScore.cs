using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentScores
{
    public partial class frmAddScore : Form
    {
        public frmAddScore()
        {
            InitializeComponent();
        }

        private void Ok(object sender, EventArgs e)
        {
            this.Tag = txtScore.Text;
        }

        private void Cancel(object sender, EventArgs e)
        {

        }
    }
}
