using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           //ADD 
            tbl_students _student = new tbl_students();
            _student.StudentID = txtStudentID.Text;
            _student.FirstName = txtFName.Text;
            _student.LastName = txtLName.Text;
            _student.MiddleName = txtMName.Text;

            using (SampleEntities db = new SampleEntities())
            {
                db.tbl_students.Add(_student);
                db.SaveChanges();
            }
            MessageBox.Show("Add Successful");
            DisplayRecords();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DisplayRecords();
        }
         void DisplayRecords()
        {

            tbl_students _student = new tbl_students();
            using (SampleEntities db = new SampleEntities())
            {
                var stud = db.tbl_students.ToList();
                dataGridView1.DataSource = stud;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Update
            tbl_students _student = new tbl_students();
            _student.StudentID = txtStudentID.Text;
            _student.FirstName = txtFName.Text;
            _student.MiddleName = txtMName.Text;
            _student.LastName = txtLName.Text;

            using (SampleEntities db = new SampleEntities())
            {
                var stud = db.tbl_students.FirstOrDefault(a => a.StudentID == _student.StudentID);
                if (stud != null)
                {
                    stud.FirstName = _student.FirstName;
                    stud.LastName = _student.LastName;
                    stud.MiddleName = _student.MiddleName;
                    db.SaveChanges();
                }
                MessageBox.Show("Update  Successful");
                DisplayRecords();

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //DISPLAY RECORDS TO DATAGRIDVIEW
            try
            {
                txtStudentID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtFName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtMName.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtLName.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
            catch (Exception)
            {

            }
         
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tbl_students _student = new tbl_students();
            _student.StudentID = txtStudentID.Text;
            using (SampleEntities db = new SampleEntities())
            {
                var stud = db.tbl_students.FirstOrDefault(a => a.StudentID == _student.StudentID);
                db.tbl_students.Remove(stud);
                db.SaveChanges();
            }
            MessageBox.Show("Delete  Successful");
            DisplayRecords();
        }

    }
}
