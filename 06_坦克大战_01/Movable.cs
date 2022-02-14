using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace _06_坦克大战_01
{
    enum Direction
    {
        Up = 0,
        Down = 1,
        Left = 2,
        Right = 3
    }

    /// <summary>
    /// 可移动的物体
    /// </summary>
    class Movable : GameObject
    {
        private Object _lock = new object();

        //上下左右对应的图片
        public Bitmap BmpUp { get; set; }
        public Bitmap BmpDown { get; set; }
        public Bitmap BmpLeft { get; set; }
        public Bitmap BmpRight { get; set; }

        //速度
        public int Speed { get; set; }

        //朝向
        //图片高宽
        private Direction dir;
        public Direction Dir
        {
            get { return dir; }
            set
            {
                dir = value;
                Bitmap bmp = null;

                switch (dir)
                {
                    case Direction.Up:
                        bmp = BmpUp;
                        break;
                    case Direction.Down:
                        bmp = BmpDown;
                        break;
                    case Direction.Left:
                        bmp = BmpLeft;
                        break;
                    case Direction.Right:
                        bmp = BmpRight;
                        break;
                }

                lock (_lock)
                {
                    Width = bmp.Width;
                    Height = bmp.Height;
                }
            }
        }

        protected override Image GetImage()
        {
            //得到其对应方向的图片
            Bitmap bitmap = null;
            switch (Dir)
            {
                case Direction.Up:
                    bitmap = BmpUp;
                    break;
                case Direction.Down:
                    bitmap = BmpDown;
                    break;
                case Direction.Left:
                    bitmap = BmpLeft;
                    break;
                case Direction.Right:
                    bitmap = BmpRight;
                    break;
            }
            //并将图片黑色像素设为透明
            bitmap.MakeTransparent(Color.Black);

            return bitmap;
        }

        public override void DrawSelf()
        {
            lock (_lock)
            {
                base.DrawSelf();
            }
        }
    }
}
