using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace BinomialHeap.Visualization
{
    class BinHeapFlow
    {
        private FlowLayoutPanel flp;
        private BinomialHeapPack.BinomialHeap binHeap;
        private List<PanelNode> panels;

        public BinHeapFlow(BinomialHeapPack.BinomialHeap binHeap, FlowLayoutPanel flp)
        {
            this.flp = flp;
            this.binHeap = binHeap;
            flp.AutoScroll = true;
            flp.Scroll += flp_scroll;
            update();
        }

        private void flp_scroll(object sender, ScrollEventArgs e)
        {
            Paint();
        }

        public void Paint()
        {
            // Рисуем главную цепочку binheapnode-ов
            foreach (PanelNode panelNode in panels)
            {
                panelNode.Paint();
            }
            // Рисуем деревья для каждого heap в binheapnode
        }


        public void update()
        {
            if (panels == null)
                panels = new List<PanelNode>();
            else
                panels.Clear();
            for (int i = 0; i < binHeap.binHeaps.Count; i++)
            {
                if (binHeap.binHeaps[i].size == 1)
                {
                    panels.Add(new PanelNode(binHeap.binHeaps[i].GetMinHeap()));
                }
                else if (binHeap.binHeaps[i].size == 2)
                {
                    panels.Add(new PanelNode(binHeap.binHeaps[i].heaps[0]));
                    panels.Add(new PanelNode(binHeap.binHeaps[i].heaps[1]));
                }
            }

            flp.Controls.Clear();
            foreach(PanelNode panelNode in panels)
            {
                panelNode.updateSize();
                flp.Controls.Add(panelNode);
            }
            Paint();
        }
    }
}
