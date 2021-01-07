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
    public partial class FindForm : Form
    {
        public FindForm()
        {
            InitializeComponent();
            /*   try
               {
                   dataGridView2.RowCount = MainForm.List.Count;
               }
               catch ()
               {

               }*/
            comboBox1.Items.Add("Чёрный");
            comboBox1.Items.Add("Белый");
            comboBox1.Items.Add("Красный");
            comboBox1.Items.Add("Коричневый");
            comboBox1.Items.Add("Серый");
            comboBox1.Items.Add("Жёлтый");
            comboBox1.Items.Add("Синий");
        }

        public bool x = true;

        private void button1_Click(object sender, EventArgs e)
        {
            if (MdiChildren.Length > 0)
                do
                {
                    MdiChildren[0].Close();
                } while (MdiChildren.Count() > 0);
            FindForm ff = new FindForm();
            if (ff.tableDataGridView.RowCount == 0)
            {
                MessageBox.Show("Не выбрано поле для изменения");
                return;
            }
            MainForm.trig = false;
            int current = tableDataGridView.CurrentRow.Index;
            OtherForm of = new OtherForm(current);

            of.MdiParent = ParentForm;
            of.StartPosition = FormStartPosition.CenterScreen;
            of.Show();
            Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tableDataGridView.RowCount == 0)
            {
                MessageBox.Show("Строка для удаления не выбрана или отсутсвует");
            }
            else
            {
                int current = tableDataGridView.CurrentRow.Index;
                MainForm.ms = Methods.SerializeToStream(MainForm.List[current]);
                MainForm.List.RemoveAt(current);
                tableDataGridView.RowCount = MainForm.List.Count;
                int i = 0;
                foreach (auto c in MainForm.List)
                {
                    Methods.PrintCar(tableDataGridView, c, i, 0, MainForm.List.IndexOf(c));
                    i++;
                }
            }

        }
        private void button5_Click(object sender, EventArgs e)
        {
            tableDataGridView.RowCount = MainForm.List.Count;
            int i = 0;
            foreach (auto c in MainForm.List)
            {
                Methods.PrintCar(tableDataGridView, c, i, 0, MainForm.List.IndexOf(c));
                i++;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int i = 0;

            tableDataGridView.Rows.Clear();


            foreach (auto c in MainForm.List)
            {
                if (c.mark.Equals(textBox1.Text.Trim()))
                {
                    if (c.colour.Equals(comboBox1.SelectedItem.ToString()))
                    {

                        Methods.PrintCar(tableDataGridView, c, i, 1, MainForm.List.IndexOf(c));
                        i++;
                    }
                }
            }
            if (tableDataGridView.RowCount == 1)
            {
                MessageBox.Show("Совпадений не найдено");
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            ;
            int i = 0;
            int n = 0;

            int sum=0;
            
            foreach (auto c in MainForm.List)
            {
                sum = sum + (2021 - c.year);
            }
            sum = sum / tableDataGridView.RowCount ;

            tableDataGridView.Rows.Clear();

                foreach (auto c in MainForm.List)
            {
                
                if ((2021-c.year) > sum){ 
                    
                    Methods.PrintCar(tableDataGridView, c, i, 1, MainForm.List.IndexOf(c));
                    i++;
                }
                

            }

        }

        private void FindForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet.Table". При необходимости она может быть перемещена или удалена.
            this.tableTableAdapter.Fill(this.database1DataSet.Table);

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
