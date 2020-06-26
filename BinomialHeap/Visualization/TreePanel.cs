﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace BinomialHeap.Visualization
{
    class CircleNode
    {
        // The string we will draw.
        public string Text;
        private BinomialHeapPack.Node node;
        private Panel panel;
        private int diametr = 40;
        private int insets_x = 0;
        private int insets_y = 30;
        private int max_x = 0;
        private int max_y = 0;

        // Constructor.
        public CircleNode(BinomialHeapPack.Node node, Panel panel)
        {
            Text = node.value.ToString();
            this.node = node;
            this.panel = panel;
        }

        // Return the size of the string plus a 10 pixel margin.
        public SizeF GetSize(Graphics gr, Font font)
        {
            return gr.MeasureString(Text, font) + new SizeF(10, 10);
        }

        public void MyDraw(int steps_x, int steps_y, Graphics gr,
            Pen pen, Brush bg_brush, Brush text_brush, Font font) {
            // Рисуем head
            int x = insets_x + (diametr - 10 + insets_x) * steps_x;
            int y = insets_y + (diametr + insets_y) * steps_y;
            if (x + diametr > max_x)
            {
                max_x = x + diametr;
                if (panel.Width < max_x) panel.Width = max_x;
            }
            if (y + diametr > max_y)
            {
                max_y = y + diametr;
                if (panel.Height < max_y) panel.Height = max_y;
            }



            Draw(x, y,
                gr, pen, bg_brush, text_brush, font);
            BinomialHeapPack.Node child = node.child;
            if (child != null)
            {

                // Рисуем child
                gr.DrawLine(pen, insets_x + (diametr - 10 + insets_x) * steps_x + diametr / 2,
                 insets_y + (diametr + insets_y) * steps_y + diametr,
                 insets_x + (diametr - 10 + insets_x) * (steps_x + pow(2, child.degree - 1)) + diametr / 2,
                 insets_y + (diametr + insets_y) * (steps_y + 1));
                CircleNode temp = new CircleNode(child, panel);
                temp.MyDraw(steps_x + pow(2, child.degree - 1), steps_y + 1,
                    gr, pen, bg_brush, text_brush, font);
                // Рисуем brother-ов child-а
                BinomialHeapPack.Node brother = node.child.brother;
                while (brother != null)
                {
                    gr.DrawLine(pen, insets_x + (diametr - 10 + insets_x) * steps_x + diametr / 2,
                                     insets_y + (diametr + insets_y) * steps_y + diametr,
                                     insets_x + (diametr - 10 + insets_x) * (steps_x + pow(2, brother.degree)) + diametr / 2,
                                     insets_y + (diametr + insets_y) * (steps_y + 1));
                    CircleNode brother_temp = new CircleNode(brother, panel);
                    brother_temp.MyDraw(steps_x + pow(2, brother.degree), steps_y + 1,
                        gr, pen, bg_brush, text_brush, font);
                    brother = brother.brother;
                }
            }
        }

        // Draw the object centered at (x, y).
        void Draw(float x, float y, Graphics gr,
            Pen pen, Brush bg_brush, Brush text_brush, Font font)
        {
            // Fill and draw an ellipse at our location.
            SizeF my_size = new SizeF(diametr, diametr);
            RectangleF rect = new RectangleF(
                x,
                y,
                my_size.Width, my_size.Height);
            gr.FillEllipse(bg_brush, rect);
            gr.DrawEllipse(pen, rect);

            // Draw the text.
            using (StringFormat string_format = new StringFormat())
            {
                string_format.Alignment = StringAlignment.Center;
                string_format.LineAlignment = StringAlignment.Center;
                gr.DrawString(Text, font, text_brush,
                    x + my_size.Width / 2, y + my_size.Height / 2, string_format);
            }
        }


        private int pow(int number, int pow)
        {
            if (pow <= 0) return 0;
            return (int)Math.Pow(number, pow);
        }
    }



    class TreePanel : Panel
    {
        private BinomialHeapPack.Heap heap;

        public TreePanel(BinomialHeapPack.Heap heap)
        {
            this.heap = heap;

            //Width = 1;
            //Height = 1;
        }

        public void addNode()
        {
            
        }

        public void Paint_(Graphics graph, Pen pen, Brush br_back, Brush br_text, Font font)
        {
            int inset = 10;
            int size = 40;


            // Graphics gr = CreateGraphics();

            CircleNode newCircleNode = new CircleNode(heap.head, this);
            int y = 0;
            int x = 0;
            newCircleNode.MyDraw(inset * x, inset * y, graph, pen, br_back, br_text, font);

            // Рисуем для каждого Node кружок
        }
    }
}