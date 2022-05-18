using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace library_tenk
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Check if users.csv exists if yes load users to listBox_clients, if not create it
            if (File.Exists("users.csv"))
            {
                string[] lines = File.ReadAllLines("users.csv");
                foreach (string line in lines)
                {
                    listBox_clients.Items.Add(line);
                }
            }
            else
            {
                File.Create("users.csv").Close();
            }

            // Check if aviable_books.csv exists if yes load aviable books to listBox_aviable_books, if not create it
            if (File.Exists("aviable_books.csv"))
            {
                string[] lines = File.ReadAllLines("aviable_books.csv");
                foreach (string line in lines)
                {
                    listBox_aviable_books.Items.Add(line);
                }
            }
            else
            {
                File.Create("aviable_books.csv").Close();
            }

            // Check if borrowed_books.csv exists if yes load borrowed books to listBox_borrowed_books, if not create it
            if (File.Exists("borrowed_books.csv"))
            {
                string[] lines = File.ReadAllLines("borrowed_books.csv");
                foreach (string line in lines)
                {
                    listBox_borrowed_books.Items.Add(line);
                }
            }
            else
            {
                File.Create("borrowed_books.csv").Close();
            }

            // Check if transaction_history.txt exists if yes load transaction history to listBox_transactions_history
            if (File.Exists("transaction_history.txt"))
            {
                string[] lines = File.ReadAllLines("transaction_history.txt");
                foreach (string line in lines)
                {
                    listBox_transactions_history.Items.Add(line);
                }
            }
        }

        private void Btn_close_Click(object sender, EventArgs e)
        {
            // Save all data to csv files
            File.WriteAllLines("users.csv", listBox_clients.Items.OfType<string>().ToArray());
            File.WriteAllLines("aviable_books.csv", listBox_aviable_books.Items.OfType<string>().ToArray());
            File.WriteAllLines("borrowed_books.csv", listBox_borrowed_books.Items.OfType<string>().ToArray());

            this.Close();            
        }

        private void Btn_minimalize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Btn_add_client_Click(object sender, EventArgs e)
        {
            bool canAdd = true;

            for(int i = 0; i < listBox_clients.Items.Count; i++)
            {
                if (listBox_clients.Items[i].ToString() == tb_readed_client.Text)
                    canAdd = false;
            }

            if (canAdd)
                listBox_clients.Items.Add(tb_readed_client.Text);

            tb_readed_client.Text = "";
        }

        private void Btn_remove_client_Click(object sender, EventArgs e)
        {
            bool canDelete = false;

            for (int i = 0; i < listBox_clients.Items.Count; i++)
            {
                if (listBox_clients.Items[i].ToString() == tb_readed_client.Text)
                    canDelete = true;
            }

            if (canDelete)
                listBox_clients.Items.Remove(tb_readed_client.Text);

            tb_readed_client.Text = "";
        }

        private void Btn_add_book_Click(object sender, EventArgs e)
        {
            bool canAdd = true;

            for (int i = 0; i < listBox_aviable_books.Items.Count; i++)
            {
                if (listBox_aviable_books.Items[i].ToString() == tb_readed_book.Text)
                    canAdd = false;
            }

            for (int i = 0; i < listBox_borrowed_books.Items.Count; i++)
            {
                if (listBox_borrowed_books.Items[i].ToString() == tb_readed_book.Text)
                    canAdd = false;
            }

            if (canAdd)
                listBox_aviable_books.Items.Add(tb_readed_book.Text);

            tb_readed_book.Text = "";
        }

        private void Btn_remove_book_Click(object sender, EventArgs e)
        {
            bool canDelete = false;

            for (int i = 0; i < listBox_aviable_books.Items.Count; i++)
            {
                if (listBox_aviable_books.Items[i].ToString() == tb_readed_book.Text)
                    canDelete = true;
            }

            if (canDelete)
                listBox_aviable_books.Items.Remove(tb_readed_book.Text);

            tb_readed_book.Text = "";
        }

        private void Btn_borrow_Click(object sender, EventArgs e)
        {
            bool isClientExisting = false;
            bool canAdd = true;
            bool canDelete = false;

            for (int i = 0; i < listBox_clients.Items.Count; i++)
            {
                if (listBox_clients.Items[i].ToString() == tb_readed_client.Text)
                    isClientExisting = true;
            }

            for (int i = 0; i < listBox_borrowed_books.Items.Count; i++)
            {
                if (listBox_borrowed_books.Items[i].ToString() == tb_readed_book.Text)
                    canAdd = false;
            }            

            for (int i = 0; i < listBox_aviable_books.Items.Count; i++)
            {
                if (listBox_aviable_books.Items[i].ToString() == tb_readed_book.Text)
                    canDelete = true;
            }

            if (isClientExisting && canAdd && canDelete)
            {
                string log_text = "[" + DateTime.Now.ToString() + "] Uživatel " + tb_readed_client.Text +
                    " si vypůjčil knihu " + tb_readed_book.Text;

                listBox_aviable_books.Items.Remove(tb_readed_book.Text);
                listBox_borrowed_books.Items.Add(tb_readed_book.Text);
                listBox_transactions_history.Items.Add(log_text);

                tb_readed_client.Text = "";
                tb_readed_book.Text = "";
            }                
        }

        private void Btn_return_Click(object sender, EventArgs e)
        {
            bool isClientExisting = false;
            bool canAdd = true;
            bool canDelete = false;

            for (int i = 0; i < listBox_clients.Items.Count; i++)
            {
                if (listBox_clients.Items[i].ToString() == tb_readed_client.Text)
                    isClientExisting = true;
            }

            for (int i = 0; i < listBox_borrowed_books.Items.Count; i++)
            {
                if (listBox_borrowed_books.Items[i].ToString() == tb_readed_book.Text)
                    canDelete = true;
            }

            for (int i = 0; i < listBox_aviable_books.Items.Count; i++)
            {
                if (listBox_aviable_books.Items[i].ToString() == tb_readed_book.Text)
                    canAdd = false;
            }

            if (isClientExisting && canAdd && canDelete)
            {
                string log_text = "[" + DateTime.Now.ToString() + "] Uživatel " + tb_readed_client.Text +
                    " vrátil knihu " + tb_readed_book.Text;

                listBox_aviable_books.Items.Add(tb_readed_book.Text);
                listBox_borrowed_books.Items.Remove(tb_readed_book.Text);
                listBox_transactions_history.Items.Add(log_text);

                tb_readed_client.Text = "";
                tb_readed_book.Text = "";
            }
        }

        private void btn_print_history_Click(object sender, EventArgs e)
        {
            // Create history file and write all transactions to it
            if (!File.Exists("historie_transakci.txt"))
                File.Create("historie_transakci.txt").Close();
            
            File.WriteAllLines("historie_transakci.txt", listBox_transactions_history.Items.OfType<string>().ToArray());
        }
    }
}
