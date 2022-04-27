using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace library_tenk
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Btn_close_Click(object sender, EventArgs e)
        {
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
    }
}
