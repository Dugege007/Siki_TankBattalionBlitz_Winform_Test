using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_坦克大战_01
{
    /// <summary>
    /// 不可移动的物体
    /// </summary>
    class Immovable : GameObject
    {

        private Image img { get; set; }
        public Image Img {
            get 
            { 
                return img; 
            } 
            set
            {
                img = value;
                Width = img.Width;
                Height = img.Height;
            }
        }

        public Immovable(int x, int y, Image img)
        {
            X = x;
            Y = y;
            Img = img;
        }

        protected override Image GetImage()
        {
            return Img;
        }
    }
}
