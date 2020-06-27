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

        private bool need_to_redraw_panelFlow;  // Если необходимо перерисовать пирамиду, установи этот флаг в true.

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

            need_to_redraw_panelFlow = true;  // Первоначальная отрисовка
            timer1.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            // Добавление элемента из text_box в пирамиду

            if (Int32.TryParse(textBox2.Text, out int add_element))
            {
                // Если удалось распарсить число из text_box
                binomialHeap1.Insert(add_element);
                panelFlow.update();
                need_to_redraw_panelFlow = true;
            }
            else
            {
                // Если не удалось распарсить число из text_box
                // Вывести ошибку (?)
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            // Очистка binHeap-а
            binomialHeap1.Clear();
            panelFlow.update();
            need_to_redraw_panelFlow = true;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (need_to_redraw_panelFlow)
            {
                flowLayoutPanel1.CreateGraphics().Clear(Color.White);
                panelFlow.Paint();
                textBox1.Text = binomialHeap1.PrintHeapToString();
                need_to_redraw_panelFlow = false;
            }
        }

        private void FlowLayoutPanel1_Scroll(object sender, ScrollEventArgs e)
        {
            need_to_redraw_panelFlow = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Получение минимума
            int? a = binomialHeap1.PopMin();
            if (a != null)
            {
                textBox3.Text = a.ToString();
                panelFlow.update();
                need_to_redraw_panelFlow = true;
            }
            else
            {
                textBox3.Text = "Пирамида пуста.";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Случайный элемент
            Random rnd = new Random();

            binomialHeap1.Insert(rnd.Next(-10000, 10000));
            panelFlow.update();
            need_to_redraw_panelFlow = true;
        }
    }
}
