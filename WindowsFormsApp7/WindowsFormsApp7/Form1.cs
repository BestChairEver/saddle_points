using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp7
{
    public partial class Form1 : Form
    {
        public static int g;
        public static int p;
        public static int h;
        public static int op;
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            int x = Convert.ToInt32(textBox1.Text);
            int y = Convert.ToInt32(textBox2.Text);
            dataGridView1.RowCount = x;
            dataGridView1.ColumnCount = y;
            int[,] a = new int[x, y];
            int[,] op =new int[x, y];
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                { 
                    a[i, j] = r.Next(0, 100);
                }
            }
            for (int i = 0; i < x; i++)
                for (int j = 0; j < y; j++)
                    dataGridView1.Rows[i].Cells[j].Value = a[i, j].ToString();
            helpmepls(a);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (g == 0)
                textBox3.Text = "Седловых точек нет";
            else
                textBox3.Text = "Кол-во седловых точек = " + Convert.ToString(g) + "; строка: " + p + "; столбец: " + h + "; элемент: " + op;
        }
        public static void helpmepls(int[,] a)
        {
            g = 0;
            p = 0;
            h = 0;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    if (!minrow(a, i, j) || !maxcol(a, i, j)) continue;
                    p = i + 1;
                    h = j + 1;
                    g++;
                    op = a[i, j];
                }
            }
        }

        public static bool maxcol(int[,] a, int i, int j)
        {
            for (int k = 0; k < a.GetLength(0); k++)
            {
                if (a[k, j] > a[i, j])
                    return false;
            }
            return true;
        }
        public static bool minrow(int[,] a, int i, int j)
        {
            for (int k = 0; k < a.GetLength(1); k++)
            {
                if (a[i, k] < a[i, j])
                    return false;
            }
            return true;
        }
    }
}
