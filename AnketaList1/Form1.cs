using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;

namespace AnketaList1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Client> list = new List<Client>();
        private void Form1_Load(object sender, EventArgs e)
        {

            foreach (var item in list)
            {
                listBox1.Items.Add(item);

            }
            delete.Enabled = false;
            redakt.Enabled = false;
            replace.Enabled = false;
        }

        private void btn_AddToList_Click(object sender, EventArgs e)
        {
            Client client = new Client
            {
                surname = textBox1.Text,
                name = textBox2.Text,
                email = textBox3.Text,
                tel = textBox4.Text
            };
            list.Add(client);
            listBox1.Items.Add(client);

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) //выбрать клиента для удаления или редактир
        {
            delete.Enabled = redakt.Enabled = listBox1.SelectedIndex != -1;
        }

        private void delete_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            list.RemoveAt(index);
            listBox1.Items.RemoveAt(index);
            delete.Enabled = false; //раз элемент удален, то кнопка delete неактивна

        }

        private void redakt_Click(object sender, EventArgs e)//возможность редактировать поля в форме
        {
            int index = listBox1.SelectedIndex;
            Client client = list[index];

            textBox1.Text = client.surname;
            textBox2.Text = client.name;
            textBox3.Text = client.email;
            textBox4.Text = client.tel;
            replace.Enabled = true;



        }

        private void replace_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            Client client = new Client
            {
                surname = textBox1.Text,
                name = textBox2.Text,
                email = textBox3.Text,
                tel = textBox4.Text
            };

            list[index] = client;
            listBox1.Items[index] = client;
        }

        private void save_Click(object sender, EventArgs e)
        {
            // Client client = new Client;
            // surname = textBox1.Text;
            // name = textBox2.Text;
            // email = textBox3.Text;
            //tel= textBox4.Text;
            // List<string> list = new List<string>() { surname, name, email, tel}


            using (StreamWriter writer = new StreamWriter("Save1.txt"))
            {
                // in file
                foreach (Client item in list)
                    writer.WriteLine(item);
            }
        }

        private void load_Click(object sender, EventArgs e)
        {
            using (StreamReader reader = new StreamReader("Load.txt"))
            {
                //  back.
                while (!reader.EndOfStream)
                {
                    Client client = new Client
                    {
                        surname = reader.ReadLine(),
                        name = reader.ReadLine(),
                        email = reader.ReadLine(),
                        tel = reader.ReadLine()
                    };

                    list.Add(client);
                    listBox1.Items.Add(client);
                }

            }
        }
        class Client
        {
            public string surname { get; set; }
            public string name { get; set; }
            public string email { get; set; }
            public string tel { get; set; }

            public override string ToString()
            {
                return $"Surname: {surname}, Name: {name}, email: {email}, tel:{tel}";
            }
        }
    }
}
