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

        private Class1 panel;


        public Form1()
        {
            Random rnd = new Random();
            InitializeComponent();
            binomialHeap1 = new BinomialHeapPack.BinomialHeap(0);
            for (int i = 0; i < 1000; i++)
            {
                binomialHeap1.Insert(rnd.Next(-10000, 10000));
            }

            panel = new Class1(binomialHeap1.GetHeap(4));
            panel.Size = new Size(1000, 1000);
            flowLayoutPanel1.Controls.Add(panel);
            flowLayoutPanel1.AutoSize = true;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = flowLayoutPanel1.CreateGraphics();
            
            Pen p = new Pen(Color.Black, width:2);
            SolidBrush myBrush = new SolidBrush(System.Drawing.Color.Red);
            SolidBrush fontBrush = new SolidBrush(Color.Black);
            Font font = new Font(FontFamily.GenericSansSerif, 10);
            // gr.DrawEllipse(p, 50, 50, 60, 60);
            // gr.DrawLine(p, 0, 0, 100, 100);

            panel.CreateGraphics().Clear(Color.White);
            panel.Paint_(p, myBrush, fontBrush, font);
        }
    }
}
