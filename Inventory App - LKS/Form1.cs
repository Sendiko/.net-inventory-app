using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Inventory_App___LKS
{
    public partial class Inventory : Form
    {

        public Inventory()
        {
            InitializeComponent();
        }
        private void Inventory_Load(object sender, EventArgs e)
        {
            var connection = new MySqlConnection("Server=127.0.0.1;Database=inventory;Uid=root;Pwd=;");
            connection.Open();
            String readQuery = "SELECT * FROM product";
            MySqlCommand command = new MySqlCommand(readQuery, connection); 
            MySqlDataAdapter adapter = new MySqlDataAdapter(); 
            adapter.SelectCommand= command;
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            productTable.DataSource = dataTable;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if(this.textBoxID.Text.Length == 0 && this.textBoxBarang.Text.Length == 0 && this.textBoxCategory.Text.Length == 0 && this.textBoxPrice.Text.Length == 0)
            {
                String title = "Data invaild";
                String message = "The data is invalid, please check the data again";
                MessageBox.Show(message, title);
            } else
            {
                var connection = new MySqlConnection("Server=127.0.0.1;Database=inventory;Uid=root;Pwd=;");
                String insertQuery = "INSERT INTO product (Id, name, category, price) VALUES ('" + this.textBoxID.Text + "', '" + this.textBoxBarang.Text + "', '" + this.textBoxCategory.Text + "', '" + this.textBoxPrice.Text + "')";
                connection.Open();
                MySqlCommand command = new MySqlCommand(insertQuery, connection);
                MySqlDataReader reader;
                reader = command.ExecuteReader();
                this.textBoxID.Text = "";
                this.textBoxBarang.Text = "";
                this.textBoxCategory.Text = "";
                this.textBoxPrice.Text = "";
                connection.Close();
                String title = "Query update";
                String message = "Data successfully created";
                DialogResult result = MessageBox.Show(message, title);
                if (result == DialogResult.OK)
                {
                    connection.Open();
                    String readQuery = "SELECT * FROM product";
                    MySqlCommand commandRead = new MySqlCommand(readQuery, connection);
                    MySqlDataAdapter adapter = new MySqlDataAdapter();
                    adapter.SelectCommand = commandRead;
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    productTable.DataSource = dataTable;
                    connection.Close();
                }
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (this.textBoxID.Text.Length == 0 && this.textBoxBarang.Text.Length == 0 && this.textBoxCategory.Text.Length == 0 && this.textBoxPrice.Text.Length == 0)
            {
                String title = "Data invaild";
                String message = "The data is invalid, please check the data again";
                MessageBox.Show(message, title);
            } else
            { 
                var connection = new MySqlConnection("Server=127.0.0.1;Database=inventory;Uid=root;Pwd=;");
                connection.Open();
                String updateQuery = "UPDATE product SET name= '" + this.textBoxBarang.Text + "', category='" + this.textBoxCategory.Text + "', price='" + this.textBoxPrice.Text + "' WHERE Id='" + this.textBoxID.Text + "'";
                MySqlCommand command = new MySqlCommand(updateQuery, connection);
                MySqlDataReader reader;
                reader = command.ExecuteReader();
                this.textBoxID.Text = "";
                this.textBoxBarang.Text = "";
                this.textBoxCategory.Text = "";
                this.textBoxPrice.Text = "";
                connection.Close();
                String title = "Query update";
                String message = "Data successfully updated";
                DialogResult result = MessageBox.Show(message, title);
                if (result == DialogResult.OK)
                {
                    connection.Open();
                    String readQuery = "SELECT * FROM product";
                    MySqlCommand commandRead = new MySqlCommand(readQuery, connection);
                    MySqlDataAdapter adapter = new MySqlDataAdapter();
                    adapter.SelectCommand = commandRead;
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    productTable.DataSource = dataTable;
                    connection.Close();
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (this.textBoxID.Text.Length == 0)
            {
                String title = "Data invalid";
                String message = "The data input is invalid";
                DialogResult result = MessageBox.Show(message, title);
                if (result == DialogResult.OK)
                {
                    var connection = new MySqlConnection("Server=127.0.0.1;Database=inventory;Uid=root;Pwd=;");
                    connection.Open();
                    String readQuery = "SELECT * FROM product";
                    MySqlCommand commandRead = new MySqlCommand(readQuery, connection);
                    MySqlDataAdapter adapter = new MySqlDataAdapter();
                    adapter.SelectCommand = commandRead;
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    productTable.DataSource = dataTable;
                    connection.Close();
                }
            }
            else
            {
                var connection = new MySqlConnection("Server=127.0.0.1;Database=inventory;Uid=root;Pwd=;");
                connection.Open();
                String deleteQuery = "DELETE FROM product WHERE Id= '" + this.textBoxID.Text + "';";
                MySqlCommand command = new MySqlCommand(deleteQuery, connection);
                MySqlDataReader reader;
                reader = command.ExecuteReader();
                connection.Close();
                this.textBoxID.Text = "";
                String title = "Query update";
                String message = "Data successfully updated";
                DialogResult result = MessageBox.Show(message, title);
                if (result == DialogResult.OK)
                {
                    connection.Open();
                    String readQuery = "SELECT * FROM product";
                    MySqlCommand commandRead = new MySqlCommand(readQuery, connection);
                    MySqlDataAdapter adapter = new MySqlDataAdapter();
                    adapter.SelectCommand = commandRead;
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    productTable.DataSource = dataTable;
                    connection.Close();
                }
            }
        }

        private void productTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var connection = new MySqlConnection("Server=127.0.0.1;Database=inventory;Uid=root;Pwd=;");
            connection.Open();
            String readQuery = "SELECT * FROM product";
            MySqlCommand command = new MySqlCommand(readQuery, connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            productTable.DataSource = dataTable;
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var connection = new MySqlConnection("Server=127.0.0.1;Database=inventory;Uid=root;Pwd=;");
            connection.Open();
            String readQuery = "SELECT * FROM product";
            MySqlCommand command = new MySqlCommand(readQuery, connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            productTable.DataSource = dataTable;
            connection.Close();
        }

        private void textBoxBarang_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxCategory_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxPrice_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
