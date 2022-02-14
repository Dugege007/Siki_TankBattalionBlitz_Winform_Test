using _06_坦克大战_01.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_坦克大战_01
{
    class EnemyTank : Movable
    {
        public int ChangeDirSpeed { get; set; }
        private int changeDirCount = 0;
        public int AttackSpeed { get; set; }
        private int attackCount = 0;
        private Random r = new Random();

        public EnemyTank(int x, int y, int speed, Bitmap bmpUp, Bitmap bmpDown, Bitmap bmpLeft, Bitmap bmpRight)
        {
            this.X = x;
            this.Y = y;
            this.Speed = speed;
            BmpUp = bmpUp;
            BmpDown = bmpDown;
            BmpLeft = bmpLeft;
            BmpRight = bmpRight;
            this.Dir = Direction.Down;

            AttackSpeed = 120;
            ChangeDirSpeed = 180;
        }

        public override void Update()
        {
            MoveCheck();//移动检查
            Move();
            AttackCheck();
            AutoChangeDir();

            base.Update();
        }

        private void MoveCheck()
        {
            #region 检查有没有超出窗体边界
            if (Dir == Direction.Up)
            {
                if (Y - Speed < 0)
                {
                    ChangeDirection();
                    return;
                }
            }
            else if (Dir == Direction.Down)
            {
                if (Y + Speed > 450 - Height)
                {
                    ChangeDirection();
                    return;
                }
            }
            else if (Dir == Direction.Left)
            {
                if (X - Speed < 0)
                {
                    ChangeDirection();
                    return;
                }
            }
            else if (Dir == Direction.Right)
            {
                if (X + Speed > 450 - Width)
                {
                    ChangeDirection();
                    return;
                }
            }
            #endregion

            #region 有没有和其他游戏元素发生碰撞
            Rectangle rect = GetRectangle();
            switch (Dir)
            {
                case Direction.Up:
                    rect.Y -= Speed;
                    break;
                case Direction.Down:
                    rect.Y += Speed;
                    break;
                case Direction.Left:
                    rect.X -= Speed;
                    break;
                case Direction.Right:
                    rect.X += Speed;
                    break;
            }

            if (GameObjectManager.IsCollidedWall(rect) != null)
            {
                ChangeDirection();
                return;
            }

            if (GameObjectManager.IsCollidedSteel(rect) != null)
            {
                ChangeDirection();
                return;
            }

            if (GameObjectManager.IsCollidedBoss(rect))
            {
                ChangeDirection();
                return;
            }
            #endregion
        }

        private void AutoChangeDir()
        {
            changeDirCount++;
            if (changeDirCount > ChangeDirSpeed)
            {
                ChangeDirection();
            }
        }

        private void ChangeDirection()
        {
            //随机方向
            while (true)
            {
                Direction dir = (Direction)r.Next(0, 4);
                if (dir == Dir)
                {
                    continue;
                }
                else
                {
                    Dir = dir;
                    break;
                }
            }
            changeDirCount -= 60;
        }

        private void Move()
        {
            switch (Dir)
            {
                case Direction.Up:
                    Y -= Speed;
                    break;
                case Direction.Down:
                    Y += Speed;
                    break;
                case Direction.Left:
                    X -= Speed;
                    break;
                case Direction.Right:
                    X += Speed;
                    break;
            }
        }

        private void AttackCheck()
        {
            attackCount++;
            if (attackCount < AttackSpeed)
            {
                return;
            }

            Attack();

            attackCount = 0;
        }

        private void Attack()
        {
            //发射子弹
            //偏移量
            int p = 1;

            //子弹生成位置
            int x = this.X;
            int y = this.Y;

            //int x = this.X + (Width / 2);
            //int y = this.Y + (Height / 2);

            switch (Dir)
            {
                case Direction.Up:
                    x += p;
                    y = y - Height / 2;
                    break;
                case Direction.Down:
                    x += p;
                    y = y + Height / 2 + p;
                    break;
                case Direction.Left:
                    x = x - Width / 2 + p;
                    y += p + p;
                    break;
                case Direction.Right:
                    x = x + Width / 2 + p;
                    y += p;
                    break;
            }
            GameObjectManager.CreateBullet(x, y, Dir, Tag.EnemyTank);
        }
    }
}
