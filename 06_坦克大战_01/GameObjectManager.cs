using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using _06_坦克大战_01.Properties;

namespace _06_坦克大战_01
{
    class GameObjectManager
    {
        private static List<Immovable> wallList = new List<Immovable>();
        private static List<Immovable> steelList = new List<Immovable>();
        private static Immovable boss;

        private static MyTank myTank;
        private static List<EnemyTank> tankList = new List<EnemyTank>();
        private static List<Bullet> bulletList = new List<Bullet>();

        private static List<Explosion> expList = new List<Explosion>();

        //敌人生成时间间隔
        private static int enemyBornSpeed = 240;
        //敌人生成间隔计数
        private static int enemyBornCount = 0;

        //敌人生成点
        private static Point[] points = new Point[3];

        public static void Start()
        {
            //敌人生成点
            points[0].X = 0;
            points[0].Y = 0;
            points[1].X = 7 * 30;
            points[1].Y = 0 * 30;
            points[2].X = 14 * 30;
            points[2].Y = 0 * 30;

        }

        public static void Update()
        {
            foreach (Immovable nm in wallList)
            {
                nm.Update();
            }
            foreach (Immovable nm in steelList)
            {
                nm.Update();
            }

            foreach (EnemyTank tank in tankList)
            {
                tank.Update();
            }

            CheckAndDestroyBullet();
            foreach (Bullet bullet in bulletList)
            {
                bullet.Update();
            }

            CheckAndDestroyExplosion();
            foreach (Explosion exp in expList)
            {
                exp.Update();
            }

            boss.Update();
            myTank.Update();

            EnemyBorn();
        }

        public static void CreateBullet(int x, int y, Direction dir,Tag tag)
        {
            Bullet bullet = new Bullet(x, y, 6, dir, tag);
            bulletList.Add(bullet);
        }

        private static void EnemyBorn()
        {
            enemyBornCount++;
            if (enemyBornCount < enemyBornSpeed) return;

            //在points[]中随机一个位置生成一个随机敌人
            Random rd = new Random();
            int index = rd.Next(0, 3);
            Point position = points[index];

            int enemyType = rd.Next(1, 5);
            switch (enemyType)
            {
                case 1:
                    CreateEnemyTank01(position.X, position.Y);
                    break;
                case 2:
                    CreateEnemyTank02(position.X, position.Y);
                    break;
                case 3:
                    CreateEnemyTank03(position.X, position.Y);
                    break;
                case 4:
                    CreateEnemyTank04(position.X, position.Y);
                    break;
            }

            enemyBornCount = 0;
        }

        private static void CreateEnemyTank01(int x,int y)
        {
            EnemyTank tank = new EnemyTank(x, y, 2, Resources.GrayUp, Resources.GrayDown, Resources.GrayLeft, Resources.GrayRight) ;
            tankList.Add(tank);
        }
        private static void CreateEnemyTank02(int x, int y)
        {
            EnemyTank tank = new EnemyTank(x, y, 2, Resources.GreenUp, Resources.GreenDown, Resources.GreenLeft, Resources.GreenRight);
            tankList.Add(tank);
        }
        private static void CreateEnemyTank03(int x, int y)
        {
            EnemyTank tank = new EnemyTank(x, y, 3, Resources.QuickUp, Resources.QuickDown, Resources.QuickLeft, Resources.QuickRight);
            tankList.Add(tank);
        }
        private static void CreateEnemyTank04(int x, int y)
        {
            EnemyTank tank = new EnemyTank(x, y, 1, Resources.SlowUp, Resources.SlowDown, Resources.SlowLeft, Resources.SlowRight);
            tankList.Add(tank);
        }

        public static EnemyTank IsCollidedEnemyTank(Rectangle rect)
        {
            foreach (EnemyTank tank in tankList)
            {
                if (tank.GetRectangle().IntersectsWith(rect))
                {
                    return tank;
                }
            }
            return null;
        }

        public static Immovable IsCollidedWall(Rectangle rect)
        {
            foreach (Immovable immovable in wallList)
            {
                if (immovable.GetRectangle().IntersectsWith(rect))
                {
                    return immovable;
                }
            }
            return null;
        }

        public static Immovable IsCollidedSteel(Rectangle rect)
        {
            foreach (Immovable immovable in steelList)
            {
                if (immovable.GetRectangle().IntersectsWith(rect))
                {
                    return immovable;
                }
            }
            return null;
        }

        public static bool IsCollidedBoss(Rectangle rect)
        {
            return boss.GetRectangle().IntersectsWith(rect);
        }

        //public static void DrawMap()
        //{
        //    foreach (Immovable nm in wallList)
        //    {
        //        nm.Update();
        //    }
        //    foreach (Immovable nm in steelList)
        //    {
        //        nm.Update();
        //    }

        //    boss.Update();
        //}

        //public static void DrawMyTank()
        //{
        //    myTank.Update();
        //}

        public static void CreateMyTank()
        {
            int x = 5 * 30;
            int y = 14 * 30;

            myTank = new MyTank(x, y, 2);
        }

        public static void CreateMap()
        {
            CreateWall(1, 1, 5, Resources.wall, wallList);
            CreateWall(3, 1, 5, Resources.wall, wallList);
            CreateWall(5, 1, 4, Resources.wall, wallList);
            CreateWall(7, 1, 3, Resources.wall, wallList);

            CreateWall(7, 4, 1, Resources.steel, steelList);

            CreateWall(9, 1, 4, Resources.wall, wallList);
            CreateWall(11, 1, 5, Resources.wall, wallList);
            CreateWall(13, 1, 5, Resources.wall, wallList);

            CreateWall(0, 7, 1, Resources.steel, steelList);

            CreateWall(2, 7, 1, Resources.wall, wallList);
            CreateWall(3, 7, 1, Resources.wall, wallList);
            CreateWall(4, 7, 1, Resources.wall, wallList);
            CreateWall(6, 6, 1, Resources.wall, wallList);
            CreateWall(7, 6, 1, Resources.wall, wallList);
            CreateWall(8, 6, 1, Resources.wall, wallList);
            CreateWall(10, 7, 1, Resources.wall, wallList);
            CreateWall(11, 7, 1, Resources.wall, wallList);
            CreateWall(12, 7, 1, Resources.wall, wallList);

            CreateWall(14, 7, 1, Resources.steel, steelList);

            CreateWall(1, 9, 5, Resources.wall, wallList);
            CreateWall(3, 9, 5, Resources.wall, wallList);
            CreateWall(5, 9, 3, Resources.wall, wallList);
            CreateWall(6, 9, 2, Resources.wall, wallList);
            CreateWall(7, 8, 4, Resources.wall, wallList);
            CreateWall(8, 9, 2, Resources.wall, wallList);
            CreateWall(9, 9, 3, Resources.wall, wallList);
            CreateWall(11, 9, 5, Resources.wall, wallList);
            CreateWall(13, 9, 5, Resources.wall, wallList);

            CreateWall(6, 13, 2, Resources.wall, wallList);
            CreateWall(7, 13, 1, Resources.wall, wallList);
            CreateWall(8, 13, 2, Resources.wall, wallList);

            CreateBoss(7, 14);
        }

        private static void CreateWall(int x, int y, int count,Image img, List<Immovable> wallList)
        {
            int xPosition = x * 30;
            int yPosition = y * 30;
            for (int i = yPosition; i < yPosition + count * 30; i += 15)
            {
                // i xPosition      i xPosition+15
                Immovable wall01 = new Immovable(xPosition, i, img);
                Immovable wall02 = new Immovable(xPosition + 15, i, img);
                wallList.Add(wall01);
                wallList.Add(wall02);
            }
        }

        private static void CreateBoss(int x, int y)
        {
            int xPosition = x * 30;
            int yPosition = y * 30;

            boss = new Immovable(xPosition, yPosition, Resources.Boss);
        }

        public static void CreateExplosion(int x, int y)
        {
            Explosion exp = new Explosion(x, y);
            expList.Add(exp);
        }

        public static void KeyDown(KeyEventArgs args)
        {
            myTank.KeyDown(args);
        }

        public static void KeyUp(KeyEventArgs args)
        {
            myTank.KeyUp(args);
        }

        private static void CheckAndDestroyBullet()
        {
            List<Bullet> needToDestroy = new List<Bullet>();

            foreach (Bullet bullet in bulletList)
            {
                if (bullet.IsDestroy == true)
                {
                    needToDestroy.Add(bullet);
                }
            }

            foreach (Bullet bullet in needToDestroy)
            {
                if (bullet.IsDestroy == true)
                {
                    bulletList.Remove(bullet);
                }
            }
        }

        public static void DestroyBullet(Bullet bullet)
        {
            bulletList.Remove(bullet);
        }

        public static void DestroyEnemyTank(EnemyTank tank)
        {
            tankList.Remove(tank);
        }

        public static void DestroyWall(Immovable wall)
        {
            wallList.Remove(wall);
        }

        private static void CheckAndDestroyExplosion()
        {
            List<Explosion> needToDestroy = new List<Explosion>();

            foreach (Explosion exp in expList)
            {
                if (exp.IsNeedDestroy == true)
                {
                    needToDestroy.Add(exp);
                }
            }

            foreach (Explosion exp in needToDestroy)
            {
                expList.Remove(exp);
            }
        }
    }
}
