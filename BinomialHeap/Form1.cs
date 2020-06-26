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
using BinomialHeap.BinomialHeapPack;
using BinomialHeap.Visualization;

namespace BinomialHeap
{
    public partial class Form1 : Form
    {
        BinomialHeapPack.BinomialHeap binomialHeap1;

        //private TreePanel panel;
        private BinHeapFlow panelFlow;

        public Form1()
        {
            Random rnd = new Random();
            InitializeComponent();
            binomialHeap1 = new BinomialHeapPack.BinomialHeap(0);
            for (int i = 0; i < 1000; i++)
            {
                binomialHeap1.Insert(rnd.Next(-10000, 10000));
            }

            panelFlow = new BinHeapFlow(binomialHeap1, flowLayoutPanel1);





            // Panel panel_for_tree_panel = new Panel();
            // panel_for_tree_panel.AutoScroll = true;
            // panel_for_tree_panel.Width = 300;
            // panel_for_tree_panel.Height = 300;
            // panel = new TreePanel(binomialHeap1.GetHeap(4));
            // 
            // panel_for_tree_panel.Scroll += Panel1_Scroll;

            // panel_for_tree_panel.Controls.Add(panel);
            // flowLayoutPanel1.Controls.Add(panel_for_tree_panel);

            textBox1.Text = binomialHeap1.PrintHeapToString();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            panelFlow.Paint();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Добавление элемента из text_box в пирамиду
            int add_element;

            if (Int32.TryParse(textBox2.Text, out add_element))
            {
                // Если удалось распарсить число из text_box
                binomialHeap1.Insert(add_element);
                panelFlow.update();
                textBox1.Text = binomialHeap1.PrintHeapToString();
            }
            else
            {
                // Если не удалось распарсить число из text_box
                // Вывести ошибку (?)
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            binomialHeap1.Clear();
            textBox1.Text = binomialHeap1.PrintHeapToString();
        }
    }
}
