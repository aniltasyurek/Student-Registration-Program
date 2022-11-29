using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace kendi_Projem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadOrRefleshPage();           
        }

        public void LoadOrRefleshPage()
        {
            SqlCommand commandList = new SqlCommand("Select * from StudentTable", SqlOperations.connection);

            SqlOperations.CheckConnection(SqlOperations.connection);

            SqlDataAdapter dataAdapter = new SqlDataAdapter(commandList);

            DataTable dataTable = new DataTable();

            dataAdapter.Fill(dataTable);

            dataGridView1.DataSource = dataTable;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand commandAdd = new SqlCommand("Insert into StudentTable (StudentName,StudentSurname,StudentNumber,StudentEmail) values(@pname,@psurname,@pnumber,@pemail)", SqlOperations.connection);
            
            SqlOperations.CheckConnection(SqlOperations.connection);

            commandAdd.Parameters.AddWithValue("@pname", textBox1.Text);

            commandAdd.Parameters.AddWithValue("@psurname", textBox2.Text);

            commandAdd.Parameters.AddWithValue("@pnumber", textBox3.Text);
            
            commandAdd.Parameters.AddWithValue("@pemail", textBox4.Text);

            commandAdd.ExecuteNonQuery();

            LoadOrRefleshPage();
        }

        string selectedNumber;

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand commandDelete = new SqlCommand("Delete from StudentTable where StudentNumber=@pnumber", SqlOperations.connection);

            SqlOperations.CheckConnection(SqlOperations.connection);

            commandDelete.Parameters.AddWithValue("@pnumber", selectedNumber);

            commandDelete.ExecuteNonQuery();

            LoadOrRefleshPage();


            //Veri silmek için textbox ile kullanım eskide kaldığı için bunu yerine daha kolay olan tıklayarak silmeyi projede kullanacağım!
            /*
            int selectedNumber = Convert.ToInt32(textBox5.Text);

            SqlCommand commandDelete = new SqlCommand("Delete from StudentTable where StudentNumber=@pnumber",SqlOperations.connection);

            SqlOperations.CheckConnection(SqlOperations.connection);

            commandDelete.Parameters.AddWithValue("@pnumber", selectedNumber);

            commandDelete.ExecuteNonQuery();

            LoadOrRefleshPage();
            */
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            selectedNumber = (dataGridView1.CurrentRow.Cells["StudentNumber"].Value).ToString();

            label5.Text = selectedNumber.ToString();

            textBox8.Text = (dataGridView1.CurrentRow.Cells["StudentName"].Value).ToString();

            textBox7.Text = (dataGridView1.CurrentRow.Cells["StudentSurname"].Value).ToString();

            textBox6.Text = (dataGridView1.CurrentRow.Cells["StudentNumber"].Value).ToString();
            
            textBox5.Text = (dataGridView1.CurrentRow.Cells["StudentEmail"].Value).ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand commandEdit = new SqlCommand("Update StudentTable set StudentName=@pname, StudentSurname=@psurname, StudentNumber=@pnumber, StudentEmail=@pemail where StudentNumber=@pnumber",SqlOperations.connection);

            SqlOperations.CheckConnection(SqlOperations.connection);

            commandEdit.Parameters.AddWithValue("@pname", textBox8.Text);

            commandEdit.Parameters.AddWithValue("@psurname", textBox7.Text);

            commandEdit.Parameters.AddWithValue("@pnumber", textBox6.Text);

            commandEdit.Parameters.AddWithValue("@pemail", textBox5.Text);

            commandEdit.ExecuteNonQuery();

            LoadOrRefleshPage();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox8.Text = " ";

            textBox7.Text = " ";

            textBox6.Text = " ";

            textBox5.Text = " ";
        }
    }
}
