using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace BinomialHeap.Visualization
{

    class PanelNode : Panel
    {
        private TreePanel panel;


        public PanelNode(BinomialHeapPack.Heap heap)
        {
            // this();
            this.AutoScroll = true;
            panel = new TreePanel(heap);
            updateSize();
            this.Controls.Add(panel);
            this.Scroll += Panel1_Scroll;
        }


        private void Panel1_Scroll(object sender, ScrollEventArgs e)
        {
            Paint();
        }

        public void updateSize()
        {
            if (panel.Width > 400) this.Width = 400;
            else this.Width = panel.Width;

            if (panel.Height > 400) this.Height = 400;
            else this.Height = panel.Height;
        }

        public void Paint()
        {
            Pen p = new Pen(Color.Black, width: 2);
            SolidBrush myBrush = new SolidBrush(System.Drawing.Color.Red);
            SolidBrush fontBrush = new SolidBrush(Color.Black);
            Font font = new Font(FontFamily.GenericSansSerif, 10);

            Graphics gr = panel.CreateGraphics();

            gr.Clear(Color.White);

            panel.Paint_(gr, p, myBrush, fontBrush, font);
        }


    }


}