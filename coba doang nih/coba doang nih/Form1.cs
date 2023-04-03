using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace coba_doang_nih
{
    public partial class Form1 : Form
    {
        List<Class2> barang = new List<Class2>();
        List<Class1> isicatagory = new List<Class1>();
        List<string> nmcat = new List<string>();
        List<int> idcat = new List<int>();
        DataTable dataproduct = new DataTable();
        DataTable isinya = new DataTable();
        DataTable kirimkedatanya = new DataTable();
        int count = 6;
        int counter = 0;
        string catagory = "";
        Dictionary<string, string> dic = new Dictionary<string, string>()
        {
            {
                "C1","Jas"
            },
            {
                "C2","T-Shirt"
            },
            {
                "C3","Rok"
            },
            {
                "C4","Celana"
            },
            {
                "C5","Cawat"
            },
        };
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dataproduct.Columns.Add("ID Product");
            dataproduct.Columns.Add("Nama Product");
            dataproduct.Columns.Add("Harga");
            dataproduct.Columns.Add("Stock");
            dataproduct.Columns.Add("ID Catagory");
            dataGridView2.DataSource = dataproduct;
            kirimkedatanya.Columns.Add("ID Product");
            kirimkedatanya.Columns.Add("Nama Product");
            kirimkedatanya.Columns.Add("Harga");
            kirimkedatanya.Columns.Add("Stock");
            kirimkedatanya.Columns.Add("ID Catagory");

            isinya.Columns.Add("ID Catagory");
            isinya.Columns.Add("Nama Catagory");
            dataGridView1.DataSource = isinya;

            barang.Add(new Class2("Jas Hitam", "100000", "10", "C1"));
            barang.Add(new Class2("T-Shirt Black Pink", "70000", "20", "C2"));
            barang.Add(new Class2("T-Shirt Obsessive", "75000", "16", "C2"));
            barang.Add(new Class2("Rok Mini", "82000", "26", "C3"));
            barang.Add(new Class2("Jeans Biru", "90000", "5", "C4"));
            barang.Add(new Class2("Celana Pendek Coklat", "60000", "14", "C4"));
            barang.Add(new Class2("Cawat Blink-Blink", "100000", "1", "C5"));
            barang.Add(new Class2("Rocca Shirt", "50000", "8", "C2"));

            isicatagory.Add(new Class1 { katagoryid = "C1", katagoryname = "Jas" });
            isicatagory.Add(new Class1 { katagoryid = "C2", katagoryname = "T-Shirt" });
            isicatagory.Add(new Class1 { katagoryid = "C3", katagoryname = "Rok" });
            isicatagory.Add(new Class1 { katagoryid = "C4", katagoryname = "celana" });
            isicatagory.Add(new Class1 { katagoryid = "C5", katagoryname = "cawat" });


            foreach (Class1 katagori in isicatagory)
            {
                isinya.Rows.Add(katagori.katagoryid, katagori.katagoryname);
                comboBox1.Items.Add(katagori.katagoryname);
                comboBox2.Items.Add(katagori.katagoryname);
            }
            for (int k = 65; k <= 90; k++)
            {
                foreach (Class2 product in barang)
                {
                    if (product.namaproduct[0] == Convert.ToChar(k))
                    {
                        counter++;
                        product.Idproduct = Convert.ToChar(k) + counter.ToString("000");
                    }
                }
                counter = 0;
            }
            foreach (Class2 produk in barang)
            {
                dataproduct.Rows.Add(produk.Idproduct, produk.namaproduct, produk.hargaproduct, produk.stockproduct, produk.namacatagory);
            }
            comboBox2.DataSource = isinya;
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }       
        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                MessageBox.Show("error");
            }
            else
            {
                dic.Add("C" + count, textBox4.Text);
                catagorylist(textBox4.Text);
                textBox4.Text = "";
            }
        }
        public void catagorylist(string input)
        {
            bool ada = false;
            isinya.Rows.Clear();
            foreach (Class1 sakarepmu in isicatagory)
            {
                if (sakarepmu.katagoryname.Contains(input))
                {
                    ada = true;
                    break;
                }
            }
            if (ada == false)
            {
                isicatagory.Add(new Class1 { katagoryid = "C" + count, katagoryname = input });
                count++;
            }
            else
            {
                MessageBox.Show("Catagory existed, try another one", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            comboBox1.Items.Clear();
            foreach (Class1 katagori in isicatagory)
            {
                isinya.Rows.Add(katagori.katagoryid, katagori.katagoryname);
                comboBox1.Items.Add(katagori.katagoryname);
            }
        }
        private void removeproduct()
        {
            DataGridViewRow datagridview = dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex];
            string store = datagridview.Cells["Nama Product"].Value.ToString();
            for (int i = 0; i < barang.Count; i++)
            {
                if (barang[i].namaproduct == store)
                {
                    barang.RemoveAt(i);
                    break;
                }
            }
            dataproduct.Clear();
            foreach (Class2 product in barang)
            {
                dataproduct.Rows.Add(product.Idproduct, product.namaproduct, product.hargaproduct, product.stockproduct, product.namacatagory);
            }


        }
        private void addproduct()
        {
            Class2 newproduct = new Class2(textBox1.Text, textBox2.Text, textBox3.Text, catagory);
            barang.Add(newproduct);
            for (int k = 65; k <= 90; k++)
            {
                foreach (Class2 product in barang)
                {
                    if (product.namaproduct[0] == Convert.ToChar(k))
                    {
                        counter++;
                        product.Idproduct = Convert.ToChar(k) + counter.ToString("000");
                    }
                }
                counter = 0;
            }
            dataproduct.Clear();
            foreach (Class2 produk in barang)
            {
                dataproduct.Rows.Add(produk.Idproduct, produk.namaproduct, produk.hargaproduct, produk.stockproduct, produk.namacatagory);
            }
            
        }
       
       

        
        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Error");
            }
            else
            {
                addproduct();
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            removeproduct();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataGridViewRow edit = dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex];
            string penampung = edit.Cells["Nama Product"].Value.ToString();
            string store = "";
            
            for (int k = 65; k <= 90; k++)
            {
                foreach (Class2 product in barang)
                {
                    if (product.namaproduct[0] == Convert.ToChar(k))
                    {
                        counter++;
                        product.Idproduct = Convert.ToChar(k) + counter.ToString("000");
                    }
                }
                counter = 0;
            }
            for (int i = 0; i < barang.Count; i++)
            {
                if (barang[i].namaproduct == penampung)
                {
                    foreach (Class1 setnama in isicatagory)
                    {
                        if (setnama.katagoryname == comboBox1.Text)
                        {
                            store = setnama.katagoryid;
                        }
                    }
                    if (Convert.ToInt32(textBox3.Text) <= 0)
                    {
                        barang.RemoveAt(i);
                    }
                    else
                    {
                        barang[i].namaproduct = textBox1.Text;
                        barang[i].hargaproduct = textBox2.Text;
                        barang[i].stockproduct = textBox3.Text;
                        barang[i].namacatagory = store;
                    }
                }
            }
            dataproduct.Clear();
            foreach (Class2 produk in barang)
            {
                dataproduct.Rows.Add(produk.Idproduct, produk.namaproduct, produk.hargaproduct, produk.stockproduct, produk.namacatagory);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.RemoveAt(dataGridView2.CurrentCell.RowIndex);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            comboBox2.DisplayMember = "Nama Catagory";
            comboBox2.ValueMember = "ID Catagory";
            comboBox2.Enabled = true;           
            comboBox2.Text = "";
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow edit = dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex];               
                string penampung = edit.Cells["ID Catagory"].Value.ToString();
                string nama = dic[penampung];
                comboBox1.Text = nama;
                textBox1.Text = edit.Cells["Nama Product"].Value.ToString();
                textBox2.Text = edit.Cells["Harga"].Value.ToString();
                textBox3.Text = edit.Cells["Stock"].Value.ToString();
            }
        }
        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            kirimkedatanya.Clear();
            foreach (Class2 produks in barang)
            {
                if (comboBox2.SelectedValue.ToString() == produks.namacatagory)
                {
                    foreach (Class2 produk in barang)
                    {
                        if (produk.namacatagory == comboBox2.SelectedValue.ToString())
                        {
                            kirimkedatanya.Rows.Add(produk.Idproduct, produk.namaproduct, produk.hargaproduct, produk.stockproduct, produk.namacatagory);
                        }

                    }
                    for (int k = 65; k <= 90; k++)
                    {
                        foreach (Class2 product in barang)
                        {
                            if (product.namaproduct[0] == Convert.ToChar(k))
                            {
                                counter++;
                                product.Idproduct = Convert.ToChar(k) + counter.ToString("000");
                            }
                        }
                        counter = 0;
                    }
                    kirimkedatanya.Clear();
                    
                }
            }
            dataGridView1.DataSource = kirimkedatanya;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox2.Enabled = false;
            comboBox2.Text = "";
            dataGridView2.DataSource = dataproduct;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox2_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            catagory = "C" + (comboBox1.SelectedIndex + 1);
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow edit = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex];               
                string penampung = edit.Cells["ID Catagory"].Value.ToString();
                string nama = dic[penampung];
                comboBox1.Text = nama;
                textBox1.Text = edit.Cells["Nama Product"].Value.ToString();
                textBox2.Text = edit.Cells["Harga"].Value.ToString();
                textBox3.Text = edit.Cells["Stock"].Value.ToString();
            }
        }
    }
}








