using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _06_坦克大战_01
{
    class GameFramework
    {
        public static Graphics g;
        public static void Start()
        {
            GameObjectManager.CreateMap();
            GameObjectManager.CreateMyTank();
            GameObjectManager.Start();
        }

        public static void Update()
        {
            //GameObjectManager.DrawMap();
            //GameObjectManager.DrawMyTank();
            GameObjectManager.Update();
        }
    }
}
