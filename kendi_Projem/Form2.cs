using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using kendi_Projem;
using System.Data.SqlClient;

namespace kendi_Projem
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           

        }

        private void button1_Click_1(object sender, EventArgs e)
        {         
            SqlCommand loginCommand = new SqlCommand("Select * From UserTable where UserEmail=@pemail and UserPassword=@ppassword", SqlOperations.connection);

            SqlOperations.CheckConnection(SqlOperations.connection);

            loginCommand.Parameters.AddWithValue("@pemail", textBox2.Text);

            loginCommand.Parameters.AddWithValue("@ppassword", textBox1.Text);

            SqlDataAdapter dataAdapter = new SqlDataAdapter(loginCommand);

            DataTable dataTable = new DataTable();

            dataAdapter.Fill(dataTable);

            if(dataTable.Rows.Count > 0)
            {
                MessageBox.Show("Successful Login!");
                Form1 form1 = new Form1();
                form1.Show();
                this.Hide();                
            }
            else
            {
                MessageBox.Show("Incorrect Entry!");
            }
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            SqlCommand commandRegister = new SqlCommand("Insert into UserTable (UserName, UserSurname, UserEmail, UserPassword) values (@pname,@psurname,@pemail,@ppassword)", SqlOperations.connection);

            SqlOperations.CheckConnection(SqlOperations.connection);

            commandRegister.Parameters.AddWithValue("@pname", textBoxName.Text);

            commandRegister.Parameters.AddWithValue("@psurname", textBoxSurname.Text);

            commandRegister.Parameters.AddWithValue("@pemail", textBoxMail.Text);

            commandRegister.Parameters.AddWithValue("@ppassword", textBoxPassword.Text);

            commandRegister.ExecuteNonQuery();

            MessageBox.Show("Registration Added");
        }
    }
}
