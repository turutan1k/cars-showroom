using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class OtherForm : Form
    {
        public OtherForm(int current)
        {
            InitializeComponent();

            comboBox1.Items.Add("Чёрный");
            comboBox1.Items.Add("Белый");
            comboBox1.Items.Add("Красный");
            comboBox1.Items.Add("Коричневый");
            comboBox1.Items.Add("Серый");
            comboBox1.Items.Add("Жёлтый");
            comboBox1.Items.Add("Синий");

        }

        

        char[] chars = { 'A', 'B', 'E', 'I', 'K', 'M', 'H', 'O', 'P', 'C', 'T', 'X' };

        private int currentindex;

        private void OtherForm_Load(object sender, EventArgs e)
        {
            if (MainForm.trig)
            {
                button1.Text = "Добавить";
                Text = "Добавить";
            }
            else
            {
                button1.Text = "Изменить";
                Text = "Изменить";
                FindForm ff = new FindForm();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MainForm.trig)
            {
                auto car = new auto();
                if (textBox1.Text.Trim() == "")
                {
                    MessageBox.Show("Поле 'ФИО' не заполнено");
                    return;
                }
                if (textBox2.Text.Trim() == "")
                {
                    MessageBox.Show("Поле 'Марка' не заполнено");
                    return;
                }
                if (textBox3.Text.Trim() == "")
                {
                    MessageBox.Show("Поле 'Модель' не заполнено");
                    return;
                }
                if (numericUpDown1.Text.Trim() == "")
                {
                    MessageBox.Show("Поле 'Год' не заполнено");
                    return;
                }
                if (comboBox1.Text.Trim() == "")
                {
                    MessageBox.Show("Поле 'Цвет' не заполнено");
                    return;
                }
                if (textBox5.Text.Trim() == "")
                {
                    MessageBox.Show("Поле 'Номерной знак' не заполнено");
                    return;
                }
                if (!Methods.CheckNumber(textBox5.Text, chars))
                    MessageBox.Show("Поле 'Номерной знак' заполнено неверно! Заполните по образцу: NNNN XX-N (N - Цифры, X - Буквы)");
                if (textBox4.Text.Trim() == "")
                {
                    MessageBox.Show("Поле 'ВИН-Номер' не заполнено");
                    return;
                }
                if (!Methods.Check(textBox4.Text)) 
                {
                    MessageBox.Show("Поле 'ВИН-Номер' заполнено неверно!(Поле должно содержать 18 символов)");
                }
                else
                {
                    car.Creation = DateTime.Now;
                    car.name = textBox1.Text.Trim();
                    car.mark = textBox2.Text.Trim();
                    car.year = Convert.ToInt32(numericUpDown1.Value);
                    car.colour = comboBox1.SelectedItem.ToString();
                    car.model = textBox3.Text.Trim();
                    car.vin = textBox4.Text.Trim();
                    car.nomer = textBox5.Text.Trim();

                    MainForm.List.Add(car);
                    MessageBox.Show("Запись добавлена");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                }
            }

            else
            {
                MainForm.List[currentindex].name = textBox1.Text.Trim();
                MainForm.List[currentindex].mark = textBox2.Text.Trim();
                MainForm.List[currentindex].year = Convert.ToInt32(numericUpDown1.Value);
                MainForm.List[currentindex].model = textBox3.Text.Trim();
                MainForm.List[currentindex].vin = textBox4.Text.Trim();
                MainForm.List[currentindex].colour = comboBox1.SelectedItem.ToString();
                MainForm.List[currentindex].nomer = textBox5.Text.Trim();
                MessageBox.Show("Запись изменена");
                FindForm ff = new FindForm();
                ff.MdiParent = ParentForm;
                ff.StartPosition = FormStartPosition.CenterScreen;
                ff.Show();
                Close();


            }
        }
    }
}
