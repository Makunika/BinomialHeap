using System;
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

        // Constructor.
        public CircleNode(string new_text)
        {
            Text = new_text;
        }

        // Return the size of the string plus a 10 pixel margin.
        public SizeF GetSize(Graphics gr, Font font)
        {
            return gr.MeasureString(Text, font) + new SizeF(10, 10);
        }

        // Draw the object centered at (x, y).
        void Draw(float x, float y, Graphics gr,
            Pen pen, Brush bg_brush, Brush text_brush, Font font)
        {
            // Fill and draw an ellipse at our location.
            SizeF my_size = GetSize(gr, font);
            RectangleF rect = new RectangleF(
                x - my_size.Width / 2,
                y - my_size.Height / 2,
                my_size.Width, my_size.Height);
            gr.FillEllipse(bg_brush, rect);
            gr.DrawEllipse(pen, rect);

            // Draw the text.
            using (StringFormat string_format = new StringFormat())
            {
                string_format.Alignment = StringAlignment.Center;
                string_format.LineAlignment = StringAlignment.Center;
                gr.DrawString(Text, font, text_brush,
                    x, y, string_format);
            }
        }
    }



    class Class1 : Panel
    {
        private BinomialHeapPack.Heap heap;

        public Class1(BinomialHeapPack.Heap heap)
        {
            this.heap = heap;
        }

        public void addNode()
        {
            
        }

        public void Paint_(Pen pen, Brush br_back, Brush br_text, Font font)
        {
            int inset = 10;
            int size = 40;


            Graphics gr = CreateGraphics();
            int most_right_x = 0; // Самый правый x
            // Обходим дерево
            Node n = heap.head.child;
            CircleNode newCircleNode = new CircleNode(heap.head.value.ToString());
            int y = 1;
            int x = 1;
            newCircleNode.Draw(inset * x, inset * y, gr, pen, br_back, br_text, );
            do
            {
                n = n.brother;
            } while (n);

            // Рисуем для каждого Node кружок
        }
    }
}
