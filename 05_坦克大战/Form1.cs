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

            //生成窗体的位置
            //this.StartPosition = FormStartPosition.CenterScreen;    //将窗体生成在屏幕中间
            this.StartPosition = FormStartPosition.Manual;  //手动指定生成位置
            this.Location = new Point(300, 300);

        }

        //Paint事件可以在窗体中绘制
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //GDI Graphics Device Interface
            //使用GDI在窗体中绘制图像
            Graphics g = this.CreateGraphics();

            #region 使用GDI绘图 绘制线和字符串
            //Color c = Color.FromArgb(50, 50, 50, 50);
            //Pen p1 = new Pen(Color.Black);
            //g.DrawLine(p1, new Point(0, 0), new Point(100, 100));

            //g.DrawString(
            //    "Dugege杜哥哥", 
            //    new Font("宋体", 20), 
            //    new SolidBrush(Color.Blue), 
            //    new Point(100, 100));
            #endregion

            //可以使用Image在窗体中绘制图片
            Image imageBoss = Properties.Resources.Boss;
            //生成图片
            g.DrawImage(imageBoss, new Point(200, 200));

            //也可以使用Bitmap位图在窗体中绘制图片
            Bitmap bmBoss = Properties.Resources.Star1;
            //使用位图绘制的图片可以编辑
            //比如让图片中的某个颜色变透明
            bmBoss.MakeTransparent(Color.Black);
            //生成图片
            g.DrawImage(bmBoss, 150, 150);

        }
    }
}
