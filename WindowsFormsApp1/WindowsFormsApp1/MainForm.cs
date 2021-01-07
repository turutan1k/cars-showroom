using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        public static bool trig;

        private static List<auto> list = new List<auto>();
        public static MemoryStream ms;

        internal static List<auto> List { get => list; set => list = value; }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
                if (MdiChildren.Length > 0)
                do
                {
                    MdiChildren[0].Close();
                } while (MdiChildren.Count() > 0);
            trig = true;
            this.IsMdiContainer = true;
            OtherForm of = new OtherForm(0);
            of.MdiParent = this;
            
            of.Show();


        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MdiChildren.Length > 0)
                do
                {
                    MdiChildren[0].Close();
                } while (MdiChildren.Count() > 0);
            this.IsMdiContainer = true;
            FindForm ff = new FindForm();
            ff.MdiParent = this;
            ff.StartPosition = FormStartPosition.CenterScreen;
            ff.Show();

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                BinaryFormatter bin = new BinaryFormatter();
                FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.OpenOrCreate);
                if (fs.Length > 0)
                    List = (List<auto>)bin.Deserialize(fs);
                foreach (auto c in List)
                    c.Creation = DateTime.Now;
                fs.Close();
                findToolStripMenuItem_Click(null, null);
            }

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                BinaryFormatter bin = new BinaryFormatter();
                FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate);
                bin.Serialize(fs, List);
                fs.Close();
            }

        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ms == null)
                MessageBox.Show("В этой сессии не было удалено ни одного элемента!");
            else
            {
                if (ms.Length == 0)
                    MessageBox.Show("Элементы для восстановления отсутствуют!");
                else
                {
                    auto c = Methods.DeserializeFromStream(ms);
                    ms = new MemoryStream();
                    list.Add(c);
                    findToolStripMenuItem_Click(null, null);

                }
            }
        }
    }
}
