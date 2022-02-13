
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _05_坦克大战
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            //this.StartPosition = FormStartPosition.Manual;
            //this.Location = new Point(3000,500);

            //GDI Graphics Device Interface

            
        }

        //
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = this.CreateGraphics();

            #region 怎么绘制线和字符串
            // RGB red green blue

            //Pen p = new Pen(Color.Black);

            //g.DrawLine(p, new Point(50, 50), new Point(100, 100));

            //g.DrawString("www.sikiedu.com - SiKi学院", 
            //    new Font("隶书", 20), 
            //    new SolidBrush(Color.Red), 
            //    new Point(100, 100));
            #endregion

            Image image = Properties.Resources.Boss;

            Bitmap bm = Properties.Resources.Star1;
            bm.MakeTransparent(Color.Black);

            g.DrawImage(bm, 150, 150);


            g.DrawImage(image, 200, 200);
        }
    }
}
