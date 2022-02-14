using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _06_坦克大战_01.Properties;

namespace _06_坦克大战_01
{
    class MyTank : Movable
    {
        //可否移动
        public bool IsMoving { get; set; }

        public MyTank(int x, int y, int speed)
        {
            IsMoving = false;

            this.X = x;
            this.Y = y;
            this.Speed = speed;
            BmpUp = Resources.MyTankUp;
            BmpDown = Resources.MyTankDown;
            BmpLeft = Resources.MyTankLeft;
            BmpRight = Resources.MyTankRight;
            this.Dir = Direction.Up;
        }

        public override void Update()
        {
            MoveCheck();//移动检查
            Move();

            base.Update();
        }

        private void MoveCheck()
        {
            #region 检查有没有超出窗体边界
            if (Dir == Direction.Up)
            {
                if (Y - Speed < 0)
                {
                    IsMoving = false;
                    return;
                }
            }
            else if (Dir == Direction.Down)
            {
                if (Y + Speed > 450 - Height)
                {
                    IsMoving = false;
                    return;
                }
            }
            else if (Dir == Direction.Left)
            {
                if (X - Speed < 0)
                {
                    IsMoving = false;
                    return;
                }
            }
            else if (Dir == Direction.Right)
            {
                if (X + Speed > 450 - Width)
                {
                    IsMoving = false;
                    return;
                }
            }
            //if (Dir == Direction.Up || Dir == Direction.Down)
            //{
            //    if (Y - Speed < 0 || Y + Speed > 450 - Height)
            //    {
            //        IsMoving = false;
            //        return;
            //    }
            //}
            //else if (Dir == Direction.Left || Dir == Direction.Right) 
            //{
            //    if (X - Speed < 0 || X + Speed > 450 - Width) 
            //    {
            //        IsMoving = false;
            //        return;
            //    }
            //}
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
                IsMoving = false;
                return;
            }

            if (GameObjectManager.IsCollidedSteel(rect) != null)
            {
                IsMoving = false;
                return;
            }

            if (GameObjectManager.IsCollidedBoss(rect))
            {
                IsMoving = false;
                return;
            }
            #endregion
        }

        private void Move()
        {
            if (IsMoving == false)
            {
                return;
            }
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

        public void KeyDown(KeyEventArgs args)
        {
            switch (args.KeyCode)
            {
                case Keys.W:
                    if (Dir!=Direction.Up)
                    {
                        Dir = Direction.Up;
                    }
                    IsMoving = true;
                    break;
                case Keys.S:
                    if (Dir != Direction.Down)
                    {
                        Dir = Direction.Down;
                    }
                    IsMoving = true;
                    break;
                case Keys.A:
                    if (Dir != Direction.Left)
                    {
                        Dir = Direction.Left;
                    }
                    IsMoving = true;
                    break;
                case Keys.D:
                    if (Dir != Direction.Right)
                    {
                        Dir = Direction.Right;
                    }
                    IsMoving = true;
                    break;
                case Keys.Space:
                    Attack();
                    break;
            }
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
            GameObjectManager.CreateBullet(x, y, Dir, Tag.MyTank);
        }

        public void KeyUp(KeyEventArgs args)
        {
            IsMoving = false;

            switch (args.KeyCode)
            {
                case Keys.W:
                    Dir = Direction.Up;
                    break;
                case Keys.S:
                    Dir = Direction.Down;
                    break;
                case Keys.A:
                    Dir = Direction.Left;
                    break;
                case Keys.D:
                    Dir = Direction.Right;
                    break;
            }
        }
    }
}
