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
    public partial class frmAddNewStudent : Form
    {    
        public frmAddNewStudent()
        {
            InitializeComponent();      
        }

        //define list of ints (scores)
        List<int> scoresList = new List<int>();


        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "")
            {
                string newStudent = txtName.Text;
                foreach (int score in scoresList)
                {
                    newStudent += "|" + score;
                }
                //add score list to name string

                this.Tag = newStudent;
            }
            
        }

        private void btnAddScore_Click(object sender, EventArgs e)
        {
            //add to list of scores here
            if (txtScore.Text != "")
            {
                scoresList.Add(Convert.ToInt32(txtScore.Text));
                txtScoreList.Text = txtScoreList.Text + " " + txtScore.Text;
                txtScore.Text = "";
                txtScore.Focus();
            }
        }

        private void btnClearScores_Click(object sender, EventArgs e)
        {
            txtScoreList.Text = "";
            scoresList.Clear();
        }
    }
}
