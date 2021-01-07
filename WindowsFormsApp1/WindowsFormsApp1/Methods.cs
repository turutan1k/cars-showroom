using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    [Serializable]
    class Methods
    {
        public static bool CheckNumber(string text, char[] chars)
        {
            text = text.Trim();
            if (text.Length != 9 || text[4] != ' ' || text[7] != '-' || !char.IsDigit(text[8]) || Convert.ToInt32(text[8].ToString()) == 0
               || Convert.ToInt32(text[8].ToString()) > 7 || Array.IndexOf(chars, text[5]) == -1 || Array.IndexOf(chars, text[6]) == -1)
                return false;
            for (int i = 0; i < 4; i++)
                if (!char.IsDigit(text[i]))
                    return false;
            return true;
        }
       
        public static bool Check (string text1)
        {
            text1 = text1.Trim();
            if (text1.Length != 18)
                return false;
            else return true;
        }
        public static void ChangeVisible(bool b1, bool b2, TextBox textBox)
        {
            textBox.Text = string.Empty;
            textBox.Visible = b1;
           
        }
        public static void PrintCar(DataGridView dataGridView2, auto c, int i, int num, int ind)
        {
            dataGridView2.RowCount += num;
            dataGridView2.Rows[i].Cells[0].Value = c.name;
            dataGridView2.Rows[i].Cells[1].Value = c.mark;
            dataGridView2.Rows[i].Cells[2].Value = c.year;
            dataGridView2.Rows[i].Cells[3].Value = c.model;
            dataGridView2.Rows[i].Cells[4].Value = c.vin;
            dataGridView2.Rows[i].Cells[5].Value = c.colour;
            dataGridView2.Rows[i].Cells[6].Value = c.nomer;
            
        }
        public static MemoryStream SerializeToStream(object o)
        {
            MemoryStream stream = new MemoryStream();
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, o);
            return stream;
        }

        public static auto DeserializeFromStream(MemoryStream stream)
        {
            IFormatter formatter = new BinaryFormatter();
            stream.Seek(0, SeekOrigin.Begin);
            object o = formatter.Deserialize(stream);
            return (auto)o;
        }

    }
}
