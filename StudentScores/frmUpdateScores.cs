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
    public partial class frmUpdateScores : Form
    {
        public frmUpdateScores()
        {
            InitializeComponent();
        }

        private void frmUpdateScores_Load(object sender, EventArgs e)
        {
            string selectedStudent = "";            

            //grabs selected Student and displays name
            selectedStudent = this.Tag.ToString();
            string[] studentScoreArray = selectedStudent.Split('|');
            txtName.Text = studentScoreArray[0];
            //splits scores and displays in listbox vertically
            for (int i = 1; i < studentScoreArray.Length ; i++)
            {
                lstScores.Items.Add(studentScoreArray[i]);
            }

        }

        private void Cancel(object sender, EventArgs e)
        {

        }

        private void Ok(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddScore addScoreForm = new frmAddScore();
            DialogResult selectedButton = addScoreForm.ShowDialog();
            lstScores.Items.Add(addScoreForm.Tag);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            frmUpdateScore updateScoreForm = new frmUpdateScore();
            DialogResult selectedButton = updateScoreForm.ShowDialog();
            string scoreToUpdate = lstScores.SelectedValue.ToString();
            updateScoreForm.Tag = scoreToUpdate;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {

        }

        private void btnClearScores_Click(object sender, EventArgs e)
        {
            lstScores.Items.Clear();
        }
    }
}
