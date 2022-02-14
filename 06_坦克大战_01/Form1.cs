using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _06_坦克大战_01
{
    public partial class Form1 : Form
    {
        private Thread t;
        private static Graphics formG;
        //临时画布
        private static Bitmap tempBmp;

        public Form1()
        {
            InitializeComponent();

            //打开后在屏幕居中
            this.StartPosition = FormStartPosition.CenterScreen;

            formG = this.CreateGraphics();

            //将背景和图像先绘制到临时画布上，然后再将临时画布绘制到窗体中，可以避免闪烁
            tempBmp = new Bitmap(450, 450);
            Graphics bmpG = Graphics.FromImage(tempBmp);
            GameFramework.g = bmpG;

            t = new Thread(new ThreadStart(GameMainThread));
            t.Start();
        }

        private static void GameMainThread()
        {
            //GameFramework 游戏框架

            GameFramework.Start();

            int sleepTime = 1000 / 120;

            while (true)
            {
                GameFramework.g.Clear(Color.Black);
                GameFramework.Update();

                //绘制临时画布
                formG.DrawImage(tempBmp, 0, 0);
                Thread.Sleep(sleepTime);
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            t.Abort();
        }

        //事件  消息  事件消息
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            GameObjectManager.KeyDown(e);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            GameObjectManager.KeyUp(e);

        }
    }
}
