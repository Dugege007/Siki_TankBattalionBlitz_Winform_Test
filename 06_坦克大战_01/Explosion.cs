using _06_坦克大战_01.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_坦克大战_01
{
    class Explosion : GameObject
    {
        public bool IsNeedDestroy { get; set; }

        private int playSpeed = 2;
        private int playCount = -1;
        private int index = 0;

        private Bitmap[] bmpArray = new Bitmap[]
        {
            Resources.EXP1,
            Resources.EXP2,
            Resources.EXP3,
            Resources.EXP4,
            Resources.EXP5
        };

        public Explosion(int x,int y)
        {
            IsNeedDestroy = false;

            foreach (Bitmap bmp in bmpArray)
            {
                //使黑色区域变透明
                bmp.MakeTransparent(Color.Black);
            }

            this.X = x - bmpArray[0].Width / 2;
            this.Y = y - bmpArray[0].Height / 2;
        }

        protected override Image GetImage()
        {
            if (index > 4) 
            {
                return Resources.EXP4;
            }
            return bmpArray[index];
        }

        public override void Update()
        {
            playCount++;
            index = (playCount - 1) / playSpeed;

            if (index > 4)
            {
                IsNeedDestroy = true;
            }

            base.Update();
        }
    }
}
