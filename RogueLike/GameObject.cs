using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace RogueLike
{
    /// <summary>
    /// Класс игрового объекта
    /// </summary>
    public abstract class GameObject : IMediator, IUpdateable, IComparable, IDrawable, ICollideable
    {
        // Начальный спрайт
        private Texture2D defaultSprite;
        // Зона взаимодействия
        public Rectangle hitbox;
        // Координата х
        protected int X;
        // Координата у
        protected int Y;
        // Ширина спрайта
        protected int spriteWidth = 32;
        // Длина спрайта
        protected int spriteHeight = 32;
        protected SoundEffect effect;
        // Приоритет
        protected int priority = 2;
        protected SoundEffect soundEffect;

        /// <summary>
        /// Посредник
        /// </summary>
        public Mediator mediator { get; set; }

        /// <summary>
        /// Игровой объект
        /// </summary>
        public GameObject()
        {

        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="mediator">Посредник</param>
        /// <param name="x">Координата х</param>
        /// <param name="y">Координата у</param>
        public GameObject(Mediator mediator, int x, int y)
        {
            this.mediator = mediator;
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Сравнение приоритета
        /// </summary>
        /// <param name="obj">Объект</param>
        /// <returns>Возвращает результат сравнения</returns>
        public int CompareTo(object obj)
        {
            // Игровой объект
            GameObject gameObject = (GameObject)obj;
            int rtn = 0;

            if (this.priority < gameObject.priority) { rtn = -1; }
            if (this.priority > gameObject.priority) { rtn = +1; }
            return rtn;
        }

        /// <summary>
        /// Столкновение объектов
        /// </summary>
        /// <param name="other">Другой объект</param>
        /// <returns>Проверяет на столкновение два объекта</returns>
        public virtual bool Collision(GameObject other)
        {
            return true;
        }

        /// <summary>
        /// Рисование объектов
        /// </summary>
        /// <param name="spriteBatch">Спрайты</param>
        /// <param name="gameTime">Предоставляет значение времени</param>
        public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {

        }

        /// <summary>
        /// Рисования зона взаимодействия
        /// </summary>
        public void DrawHitbox()
        {

        }

        /// <summary>
        /// Загрузка объектов
        /// </summary>
        public virtual void Load()
        {

        }

        /// <summary>
        /// Проигрывание эффекта
        /// </summary>
        public virtual void PlayEffect()
        {
            if (effect != null)
            {
                effect.Play();
            }
        }

        /// <summary>
        /// Проигрывание звука
        /// </summary>
        public virtual void PlaySound()
        {

        }

        /// <summary>
        /// Обновление состояния игры
        /// </summary>
        /// <param name="gameTime">Предоставляет значение времени</param>
        public virtual void Update(GameTime gameTime)
        {

        }

        /// <summary>
        /// Прямоугольник взаимодействия объекта
        /// </summary>
        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle(this.X, this.Y, defaultSprite.Width, defaultSprite.Height);
            }
        }

        /// <summary>
        /// Координата х
        /// </summary>
        public int x
        {
            get => X;
            set => X = value;
        }

        /// <summary>
        /// Координата у
        /// </summary>
        public int y
        {
            get => Y;
            set => Y = value;
        }
    }
}
