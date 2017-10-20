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
    public partial class frmStudentScores : Form
    {
        
        public frmStudentScores()
        {
            InitializeComponent();
        }

        List<string> listStudentScores = new List<string>();
        int currentStudentIndex = 0;

        private void frmStudentScores_Load(object sender, EventArgs e)
        {
            //set defaults here
            // original example: lstStudentData.Items.Add("Jane Doe|20|22|23");
            listStudentScores.Add("Jane Doe|20|22|23");
            listStudentScores.Add("John Doe|20|24|19");
            listStudentScores.Add("Tom Smythe|22|23|25");
            
            foreach (string student in listStudentScores)
            {
                lstStudentData.Items.Add(student);
            }

            lstStudentData.SelectedIndex = 0;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddNewStudent addNewForm = new frmAddNewStudent();                       
            DialogResult selectedButton = addNewForm.ShowDialog();

            //coming back from Add New Student Form
            if (selectedButton == DialogResult.OK && addNewForm.Tag != "")
            { 
                //add new data to stringList 
                listStudentScores.Add(addNewForm.Tag.ToString());
                lstStudentData.Items.Clear();
                foreach (string student in listStudentScores)
                {
                    lstStudentData.Items.Add(student);
                }

                //load stringList into Listbox with a for each loop
            }
        }


        private void lstStudentData_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstStudentData.SelectedIndex > -1)
            {
                string score = "";
                int total = 0;
                int count = 0;
                int average = 0;
                string selectedStudent = "";

                //variable to hold one student & scores based on index in listbox
                selectedStudent = lstStudentData.SelectedItem.ToString();
                currentStudentIndex = lstStudentData.SelectedIndex;

                //splits the main string into a student and their scores
                string[] studentScoreArray = selectedStudent.Split('|');

                if (studentScoreArray.Length > 1)
                {//loops through each student's scores after skipping their name
                    for (int i = 1; i < studentScoreArray.Length; i++)
                    {
                        score = studentScoreArray[i];
                        total += Convert.ToInt32(score);
                    }

                    //loads the results into their respective text boxes
                    txtScoreTotal.Text = total.ToString();
                    count = studentScoreArray.Length - 1;
                    txtScoreCount.Text = count.ToString();
                    average = total / count;
                    txtAverage.Text = average.ToString();
                }
                else
                {
                    txtScoreTotal.Text = "0";
                    txtScoreCount.Text = "0";
                    txtAverage.Text = "0";
                }
            }    
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string selectedStudent = "";
            string updatedStudent = "";            

            frmUpdateScores updateForm = new frmUpdateScores();
            selectedStudent = listStudentScores[currentStudentIndex];
            updateForm.Tag = selectedStudent;
            DialogResult selectedButton = updateForm.ShowDialog();

            if (selectedButton == DialogResult.OK)
            {
                updatedStudent = updateForm.Tag.ToString();
                lstStudentData.Items[currentStudentIndex] = updatedStudent;

            }
            if (selectedButton == DialogResult.Cancel)
                lstStudentData.SelectedIndex = currentStudentIndex;          
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            lstStudentData.Items.Remove(lstStudentData.SelectedItem);
            listStudentScores.Clear();

            foreach (object student in lstStudentData.Items)
            {
                
                listStudentScores.Add(student.ToString());
            }

            lstStudentData.Items.Clear();

            foreach (string student in listStudentScores)
            {
                lstStudentData.Items.Add(student);
            }
        }
    }
}
