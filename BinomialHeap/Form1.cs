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

namespace BinomialHeap
{
    public partial class Form1 : Form
    {
        BinomialHeapPack.BinomialHeap binomialHeap1;


        public Form1()
        {
            InitializeComponent();
            binomialHeap1 = new BinomialHeapPack.BinomialHeap(rnd.Next(-1000000, 1000000));
            for (int i = 0; i < 1000; i++)
            {
                binomialHeap1.Insert(rnd.Next(-1000000, 1000000));
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = panel1.CreateGraphics();
            Pen p = new Pen(Color.Black, width:5);
            gr.DrawEllipse(p, 50, 50, 60, 60);
            // gr.DrawLine(p, 0, 0, 100, 100);
            Class1 panel = new Class1(binomialHeap1.GetHeap(0))
        }
    }
}
