using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System;

namespace RogueLike
{
    /// <summary>
    /// Класс монстра
    /// </summary>
    public class Monster : GameObject
    {
        // Скорость передвижения
        protected int speed = 1;
        // Здоровье
        protected int health = 100;
        // Флаг жизни
        protected bool alive = true;
        // Предыдущие координаты
        protected int prevX;
        protected int prevY;
        // Направление
        protected Direction direction;
        // Флаг рисования
        protected bool shouldDraw = true;
        // Предыдущая позиция
        protected Vector2 previousPosition;
        // Прыжок назад
        protected int bounceBack = 3;
        // Звук смерти
        protected SoundEffect dead;
        // Митингующая точка
        protected Rectangle rallyPoint;
        // Случайная митингующая точка
        protected Rectangle randomRallyPoint;
        // Координата случайно митингующей точки
        protected int randomRallyPointCoord = 999;
        // Ширина спрайта
        protected int spriteWidth = 25;
        // Высота спрайта
        protected int spriteHeight = 25;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="x">Координата х</param>
        /// <param name="y">Координата у</param>
        /// <param name="mediator">Посредник</param>
        public Monster(int x, int y, Mediator mediator) : base(mediator, x, y)
        {
            Random random = new Random();
            this.hitbox = new Rectangle(X, Y, spriteWidth, spriteHeight);
            this.rallyPoint = new Rectangle(X, Y, spriteWidth, spriteHeight);
            this.randomRallyPoint = new Rectangle(X + random.Next(-randomRallyPointCoord, randomRallyPointCoord), Y + random.Next(-randomRallyPointCoord, randomRallyPointCoord), spriteHeight, spriteWidth);
        }

        /// <summary>
        /// Столкновение
        /// </summary>
        /// <param name="other">Другой объект</param>
        /// <returns></returns>
        public override bool Collision(GameObject other)
        {
            if (other is Player)
            {
                mediator.player.health = mediator.player.health - 1;
                mediator.player.OverallDamageTaken = mediator.player.OverallDamageTaken + 1;
                return true;
            }
            if (other is FrozenBowProjectile)
            {
                speed = speed / 2;
            }

            if (other is Wall || other is CommonMonster && other != this)
            {
                Random random = new Random();
                MoveTo(rallyPoint);

                if (other is CommonMonster && other != this)
                {
                    MoveTo(randomRallyPoint);
                    this.randomRallyPoint.X = this.X + random.Next(-randomRallyPointCoord, randomRallyPointCoord);
                    this.randomRallyPoint.Y = this.Y + random.Next(-randomRallyPointCoord, randomRallyPointCoord);
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Смерть монстра
        /// </summary>
        private void Die()
        {
            mediator.player.Kills++;
            mediator.room.EnemyCount--;
            mediator.gameOverMenu.PlayerKills = mediator.player.Kills;
            mediator.itemToBeDeleted.Add(this);
        }

        /// <summary>
        /// Загрузка объекта
        /// </summary>
        public override void Load()
        {
            dead = Mediator.Game.Content.Load<SoundEffect>(@"Graphic\music\Boardeath");
        }

        /// <summary>
        /// Движение к игроку
        /// </summary>
        /// <param name="player">Прямоугольник игрока</param>
        private void MoveTo(Rectangle player)
        {
            if (this.X < player.X)
            {
                this.direction = Direction.Right;
                this.X = this.X + this.speed;
            }

            if (this.Y < player.Y)
            {
                this.direction = Direction.Down;
                this.Y = this.Y + this.speed;
            }

            if (this.X > player.X)
            {
                this.direction = Direction.Left;
                this.X = this.X - this.speed;
            }

            if (this.Y > player.Y)
            {
                this.direction = Direction.Up;
                this.Y = this.Y - this.speed;
            }
        }

        /// <summary>
        /// Движение к игроку
        /// </summary>
        /// <param name="player">Игрок</param>
        public virtual void MoveTo(Player player)
        {
            this.hitbox.X = X;
            this.hitbox.Y = Y;

            if (this.X < player.getX())
            {
                this.direction = Direction.Right;
                this.X = this.X + this.speed;
            }

            if (this.Y < player.getY())
            {
                this.direction = Direction.Down;
                this.Y = this.Y + this.speed;
            }

            if (this.X > player.getX())
            {
                this.direction = Direction.Left;
                this.X = this.X - this.speed;
            }

            if (this.Y > player.getY())
            {
                this.direction = Direction.Up;
                this.Y = this.Y - this.speed;
            }
        }

        public void setX(int x)
        {
            this.X = x;
        }

        public void setY(int y)
        {
            this.Y = y;
        }

        /// <summary>
        /// Обновление состояния монстра
        /// </summary>
        /// <param name="gameTime">Предоставляет значение времени</param>
        public override void Update(GameTime gameTime)
        {
            this.prevX = this.X;
            this.prevY = this.Y;

            if (health <= 0)
            {
                alive = false;
                dead.Play();
            }

            if (!alive)
            {
                Die();
            }
            MoveTo(mediator.player);
        }

        /// <summary>
        /// Здоровье
        /// </summary>
        public int Health
        {
            get => health;
            set => health = value;
        }
    }
}