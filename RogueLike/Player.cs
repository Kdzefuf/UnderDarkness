using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RogueLike
{
    /// <summary>
    /// Класс игрока
    /// </summary>
    public class Player : GameObject
    {
        // Текстуры игрока
        private Texture2D playerRight;
        private Texture2D playerLeft;

        private SoundEffect defaultShoot;
        private SoundEffect death;
        public Rectangle hitbox;

        private Texture2D winGem;
        // Оружие
        public Weapon weapon;
        // Направление
        private Direction direction;

        // Скорость
        public int speed = 2;
        // Ширина спрайта
        private int spriteWidth = 27;
        // Высота спрайта
        private int spriteHeight = 27;
        // Здоровье
        public int health = 300;
        // Флаг жизни
        private bool alive = true;
        // Предыдущая позиция
        public int prevPosX;
        public int prevPosY;
        // Пауза между выстрелами
        private int cooldown = 500;
        // Последний выстрел
        private double lastShot = 0;
        // Флаг удара
        private bool hurting = false;
        // Количество убийств
        private int kills = 0;
        // Всего урона получено
        private int overallDamageTaken;
        // Всего урона нанесено
        private int overallDamageDone;
        // Всего вылечено
        private int overallHealingDone;
        // Пройденные уровни
        private int levelsCompleted;
        // Количество выстрелов
        private int projectilesFired;
        // Максимальное здоровья
        private int maxHp = 300;
        private bool win = false;

        /// <summary>
        /// Игрок
        /// </summary>
        /// <param name="x">Координата х</param>
        /// <param name="y">Координата у</param>
        public Player(int x, int y)
        {
            this.X = x;
            this.Y = y;
            this.prevPosX = x;
            this.prevPosY = y;
            this.hitbox = new Rectangle(X, Y, spriteWidth, spriteHeight);
            this.priority = 5;
        }

        /// <summary>
        /// Столкновение
        /// </summary>
        /// <param name="other">Другой объект</param>
        /// <returns>Проверяет на столкновение два объекта</returns>
        public override bool Collision(GameObject other)
        {
            if (other is Wall)
            {
                this.Y = prevPosY;
                this.X = prevPosX;
            }
            return true;
        }

        /// <summary>
        /// Рисование игрока по направлениям
        /// </summary>
        /// <param name="spriteBatch">Спрайты</param>
        /// <param name="gameTime">Предоставляет значение времени</param>
        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (direction == Direction.Down)
            {
                spriteBatch.Draw(playerRight, hitbox, Color.White);
            }
            if (direction == Direction.Up)
            {
                spriteBatch.Draw(playerRight, hitbox, Color.White);
            }
            if (direction == Direction.Left)
            {
                spriteBatch.Draw(playerLeft, hitbox, Color.White);
            }
            if (direction == Direction.Right)
            {
                spriteBatch.Draw(playerRight, hitbox, Color.White);
            }
            else
                spriteBatch.Draw(playerLeft, hitbox, Color.White);
        }

        /// <summary>
        /// Выстрелы
        /// </summary>
        /// <param name="x">Координата х</param>
        /// <param name="y">Координата у</param>
        /// <param name="direction">направление движения</param>
        private void Fire(int x, int y, Direction direction)
        {
            // Начальный снаряд
            Projectile defaultProjectile = new Projectile(x, y, direction, mediator);
            this.Load();
            defaultShoot.CreateInstance().Play();
            defaultProjectile.Load();
            mediator.itemToBeAdded.Add(defaultProjectile);
        }

        /// <summary>
        /// Флаг смерти
        /// </summary>
        /// <returns>Проверяет жив ли игрок</returns>
        private bool IsDead()
        {
            if (health <= 0)
            {
                death.CreateInstance().Play();
                this.alive = false;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Загрузка текстур
        /// </summary>
        public override void Load()
        {
            playerRight = Mediator.Game.Content.Load<Texture2D>(@"Graphic\Hero\Stay\stay1right");
            playerLeft = Mediator.Game.Content.Load<Texture2D>(@"Graphic\Hero\Stay\stay1left");

            death = Mediator.Game.Content.Load<SoundEffect>(@"Graphic\music\Death");
            defaultShoot = Mediator.Game.Content.Load<SoundEffect>(@"Graphic\music\Bow");
        }

        /// <summary>
        /// Движение игрока
        /// </summary>
        public void Move()
        {
            KeyboardState key = Keyboard.GetState();

            if (key.IsKeyDown(Keys.A) && key.IsKeyDown(Keys.D) && key.IsKeyDown(Keys.S) || key.IsKeyDown(Keys.A) && key.IsKeyDown(Keys.D) && key.IsKeyDown(Keys.W))
            {
                this.direction = Direction.Left;
                this.X = this.X - this.speed;
            }

            if (key.IsKeyDown(Keys.D))
            {
                this.direction = Direction.Right;
                this.prevPosX = this.X;
                this.X = this.X + this.speed;
            }

            if (key.IsKeyDown(Keys.A))
            {
                this.direction = Direction.Left;
                this.prevPosX = this.X;
                this.X = this.X - this.speed;
            }

            if (key.IsKeyDown(Keys.S))
            {
                this.direction = Direction.Down;
                this.prevPosY = this.Y;
                this.Y = this.Y + this.speed;
            }

            if (key.IsKeyDown(Keys.W))
            {
                this.direction = Direction.Up;
                this.prevPosY = this.Y;
                this.Y = this.Y - this.speed;
            }
        }

        /// <summary>
        /// Стрельба
        /// </summary>
        /// <param name="gameTime">Предоставляет значение времени</param>
        public void Shooting(GameTime gameTime)
        {
            KeyboardState key = Keyboard.GetState();
            if (key.IsKeyDown(Keys.Space))
            {
                if (lastShot > cooldown)
                {
                    projectilesFired++;
                    lastShot = 0;

                    if (weapon != null)
                    {
                        mediator.player.weapon.Fire(this.X, this.Y, this.direction);
                    }
                    else if (weapon == null)
                    {
                        Fire(this.X, this.Y, this.direction);
                    }
                }
            }
        }

        /// <summary>
        /// Обновление состояния игрока
        /// </summary>
        /// <param name="gameTime">Предоставляет значение времени</param>
        public override void Update(GameTime gameTime)
        {
            lastShot += gameTime.ElapsedGameTime.TotalMilliseconds;
            Move();
            Shooting(gameTime);


            if (health > maxHp)
            {
                this.speed = 1;
                this.health--;

            }
            else
            {
                this.speed = 2;
                this.cooldown = 500;
            }

            if (IsDead())
            {
                mediator.gameOverMenu.player = this;
                mediator.gameOverMenu.GiveStats();
                mediator.State.State = GameState.GameOver;
            }
            if (levelsCompleted == 3)
                win = true;
            if (win)
            {
                mediator.gameOverMenu.player = this;
                mediator.gameOverMenu.GiveStats();
                mediator.State.State = GameState.GameOver;
            }

            this.hitbox = new Rectangle(this.X, this.Y, spriteWidth, spriteHeight);
        }

        /// <summary>
        /// Определение координаты х
        /// </summary>
        /// <returns>Возвращает координату х</returns>
        public int getX()
        {
            return this.X;
        }

        /// <summary>
        /// Определение координаты у
        /// </summary>
        /// <returns>Возвращает координату у</returns>
        public int getY()
        {
            return this.Y;
        }

        /// <summary>
        /// Установка координаты х
        /// </summary>
        /// <param name="x">Координата х</param>
        public void setX(int x)
        {
            this.X = x;
        }

        /// <summary>
        /// Установка координаты у
        /// </summary>
        /// <param name="y">Координата у</param>
        public void setY(int y)
        {
            this.Y = y;
        }

        /// <summary>
        /// Пройденные уровни
        /// </summary>
        public int LevelsCompleted
        {
            get => levelsCompleted;
            set => levelsCompleted = value;
        }

        /// <summary>
        /// Количество выстрелов
        /// </summary>
        public int ProjectilesFired
        {
            get => projectilesFired;
            set => projectilesFired = value;
        }

        /// <summary>
        /// Флаг получения урона
        /// </summary>
        public bool Hurting
        {
            get => hurting;
            set => hurting = value;
        }

        /// <summary>
        /// Количество убийств
        /// </summary>
        public int Kills
        {
            get => kills;
            set => kills = value;
        }

        /// <summary>
        /// Всего нанесено урона
        /// </summary>
        public int OverallDamageDone
        {
            get => overallDamageDone;
            set => overallDamageDone = value;
        }

        /// <summary>
        /// Всего получено урона
        /// </summary>
        public int OverallDamageTaken
        {
            get => overallDamageTaken;
            set => overallDamageTaken = value;
        }

        /// <summary>
        /// Всего вылечено
        /// </summary>
        public int OverallHealingDone
        {
            get => overallHealingDone;
            set => overallHealingDone = value;
        }

        /// <summary>
        /// Пауза между выстрелами
        /// </summary>
        public int playerCooldown
        {
            get { return cooldown; }
            set { cooldown = value; }
        }

        /// <summary>
        /// Оружие
        /// </summary>
        public Weapon Weapon
        {
            get => weapon;
            set => weapon = value;
        }
    }
}
