using _06_坦克大战_01.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_坦克大战_01
{
    enum Tag
    {
        MyTank,
        EnemyTank
    }

    class Bullet : Movable
    {
        public Tag Tag { get; set; }

        //判断是否需要销毁的参数
        public bool IsDestroy { get; set; }

        public Bullet(int x, int y, int speed, Direction dir, Tag tag)
        {
            IsDestroy = false;
            this.X = x + Width / 2;
            this.Y = y + Height / 2;
            this.Speed = speed;
            BmpUp = Resources.BulletUp;
            BmpDown = Resources.BulletDown;
            BmpLeft = Resources.BulletLeft;
            BmpRight = Resources.BulletRight;
            this.Dir = dir;
            this.Tag = tag;
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
                if (Y + Height < 0)
                {
                    IsDestroy = true;
                    return;
                }
            }
            else if (Dir == Direction.Down)
            {
                if (Y > 450)
                {
                    IsDestroy = true;
                    return;
                }
            }
            else if (Dir == Direction.Left)
            {
                if (X + Width < 0)
                {
                    IsDestroy = true;
                    return;
                }
            }
            else if (Dir == Direction.Right)
            {
                if (X > 450)
                {
                    IsDestroy = true;
                    return;
                }
            }
            #endregion

            #region 有没有和其他游戏元素发生碰撞
            Rectangle rect = GetRectangle();

            //子弹碰撞边界偏移量
            rect.X = X + Width / 2 - 3;
            rect.Y = Y + Height / 2 - 3;
            rect.Width = 5;
            rect.Height = 5;

            //爆炸的中心位置
            int xExplosion = this.X + Width / 2;
            int yExplosion = this.Y + Height / 2;

            EnemyTank tank = null;
            if (Tag==Tag.MyTank)
            {
                if ((tank = GameObjectManager.IsCollidedEnemyTank(rect)) != null)
                {
                    IsDestroy = true;
                    GameObjectManager.DestroyEnemyTank(tank);
                    GameObjectManager.CreateExplosion(xExplosion, yExplosion);
                    return;
                }
            }

            Immovable wall = null;
            if ((wall = GameObjectManager.IsCollidedWall(rect)) != null)
            {
                IsDestroy = true;
                GameObjectManager.DestroyWall(wall);
                GameObjectManager.CreateExplosion(xExplosion, yExplosion);
                return;
            }

            if ((wall = GameObjectManager.IsCollidedSteel(rect)) != null)
            {
                IsDestroy = true;
                GameObjectManager.CreateExplosion(xExplosion, yExplosion);
                return;
            }

            if (GameObjectManager.IsCollidedBoss(rect))
            {
                IsDestroy = true;
                return;
            }
            #endregion
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
    }
}
