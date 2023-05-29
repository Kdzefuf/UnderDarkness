using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace RogueLike
{
    /// <summary>
    /// Класс снаряда
    /// </summary>
    public class Projectile : GameObject, IProjectile
    {
        // Текстуры снарядов
        protected Texture2D projectileTextureLeft;
        protected Texture2D projectileTextureRight;
        protected Texture2D projectileTextureUp;
        protected Texture2D projectileTextureDown;
        protected Texture2D projectileTextureUpRight;
        protected Texture2D projectileTextureUpLeft;
        protected Texture2D projectileTextureDownRight;
        protected Texture2D projectileTextureDownLeft;

        // Звуковые эффекты
        protected SoundEffect hitMonster;
        protected SoundEffect hitWall;

        // Флаг необходимости рисования
        protected bool shouldDraw = true;
        // Урон
        protected int damage = 33;
        // Направление
        protected Direction direction;
        // Флаг видимости снаряда
        protected bool visible;
        // Скорость снаряда
        protected int shootSpeed = 8;

        // Высота
        protected int Height = 22;
        // Ширина
        protected int Width = 22;
        // Текущая высота
        protected const int actualHeight = 1;
        // текущая ширина
        protected const int actualWidth = 1;
        // Флаг удара
        protected bool hasHit = false;

        /// <summary>
        /// Снаряд
        /// </summary>
        /// <param name="x">Координата х</param>
        /// <param name="y">Координата у</param>
        /// <param name="direction">Направление</param>
        /// <param name="mediator">Посредник</param>
        public Projectile(int x, int y, Direction direction, Mediator mediator) : base(mediator, x, y)
        {
            this.hitbox = new Rectangle(this.X, this.Y, actualWidth, actualHeight);
            this.direction = direction;
            this.priority = 4;
        }

        /// <summary>
        /// Столкновение
        /// </summary>
        /// <param name="other">Другой объект</param>
        /// <returns>Проверяет объекты на столкновение</returns>
        public override bool Collision(GameObject other)
        {
            if (other is Monster)
            {
                hasHit = true;
                Monster p = (Monster)other;
                p.Health = p.Health - damage;
                hitMonster.CreateInstance().Play();
                mediator.player.OverallDamageDone += damage;
                mediator.itemToBeDeleted.Add(this);
            }

            if (other is Wall || other is Door)
            {
                hitWall.CreateInstance().Play();
                mediator.itemToBeDeleted.Add(this);
            }
            return true;
        }

        /// <summary>
        /// Рисование снаряда
        /// </summary>
        /// <param name="spriteBatch">Спрайт</param>
        /// <param name="gameTime">Предоставляет значение времени</param>
        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            DrawAccordingToDirection(spriteBatch);
        }

        /// <summary>
        /// Рисование относительно направления
        /// </summary>
        /// <param name="spriteBatch">Спрайт</param>
        public virtual void DrawAccordingToDirection(SpriteBatch spriteBatch)
        {
            if (shouldDraw)
            {
                if (this.direction == Direction.Up)
                {
                    spriteBatch.Draw(projectileTextureUp, hitbox, Color.White);
                }
                else if (this.direction == Direction.Down)
                {
                    spriteBatch.Draw(projectileTextureDown, hitbox, Color.White);
                }
                else if (this.direction == Direction.Right)
                {
                    spriteBatch.Draw(projectileTextureRight, hitbox, Color.White);
                }
                else if (this.direction == Direction.Left)
                {
                    spriteBatch.Draw(projectileTextureLeft, hitbox, Color.White);
                }
            }
        }

        /// <summary>
        /// Рисование поля взаимодействия 
        /// </summary>
        /// <param name="spriteBatch">Спрайт</param>
        /// <param name="gameTime">Предоставляет значение времени</param>
        public void drawHitbox(SpriteBatch spriteBatch, GameTime gameTime)
        {
            Texture2D texture = new Texture2D(projectileTextureLeft.GraphicsDevice, 1, 1);
            texture.SetData(new Color[] { Color.Aqua });
            spriteBatch.Draw(texture, hitbox, Color.White);

            spriteBatch.Draw(projectileTextureLeft, hitbox, Color.White);
        }

        /// <summary>
        /// Загрузка контента
        /// </summary>
        public override void Load()
        {
            projectileTextureLeft =
                Mediator.Game.Content.Load<Texture2D>(@"Graphic\Weapons\common_arrow_5");
            projectileTextureRight =
                Mediator.Game.Content.Load<Texture2D>(@"Graphic\Weapons\common_arrow");
            projectileTextureUp =
                Mediator.Game.Content.Load<Texture2D>(@"Graphic\Weapons\common_arrow_3");
            projectileTextureDown =
                Mediator.Game.Content.Load<Texture2D>(@"Graphic\Weapons\common_arrow_7");
            projectileTextureUpLeft =
                Mediator.Game.Content.Load<Texture2D>(@"Graphic\Weapons\common_arrow_4");
            projectileTextureUpRight =
                Mediator.Game.Content.Load<Texture2D>(@"Graphic\Weapons\common_arrow_2");
            projectileTextureDownLeft =
                Mediator.Game.Content.Load<Texture2D>(@"Graphic\Weapons\common_arrow_6");
            projectileTextureDownRight =
                Mediator.Game.Content.Load<Texture2D>(@"Graphic\Weapons\common_arrow_8");

            hitMonster = Mediator.Game.Content.Load<SoundEffect>(@"Graphic\music\Shot");
            hitWall = Mediator.Game.Content.Load<SoundEffect>(@"Graphic\music\Arrow");
        }

        /// <summary>
        /// Движение снаряда
        /// </summary>
        public void MoveProjectile()
        {
            if (this.direction == Direction.Up)
            {
                Y -= shootSpeed;
            }
            else if (this.direction == Direction.Down)
            {
                Y += shootSpeed;
            }
            else if (this.direction == Direction.Right)
            {
                X += shootSpeed;
            }
            else if (this.direction == Direction.Left)
            {
                X -= shootSpeed;
            }
        }

        /// <summary>
        /// Проигрывание выстрела
        /// </summary>
        private void PlayShot()
        {
            //hitMonster.CreateInstance().Play();
        }

        /// <summary>
        /// Обновление состояния снаряда
        /// </summary>
        /// <param name="gameTime">Предоставляет значение времени</param>
        public override void Update(GameTime gameTime)
        {
            MoveProjectile();
            this.hitbox = new Rectangle(this.X, this.Y, Width, Height);

            if (hasHit)
            {
                PlayShot();
                hasHit = false;
            }
        }

        /// <summary>
        /// Урон
        /// </summary>
        public int Damage
        {
            get => damage;
            set => damage = value;
        }

        /// <summary>
        /// Зона взаимодействия
        /// </summary>
        public Rectangle Rectangle
        {
            get { return new Rectangle(this.X, this.Y, projectileTextureLeft.Width, projectileTextureLeft.Height); }
        }
    }
}