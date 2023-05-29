using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;

namespace RogueLike
{
    /// <summary>
    /// Класс управления состоянием игры
    /// </summary>
    public class StateHolder
    {
        // Посредник
        protected Mediator mediator;
        // Список объектов состояние
        protected List<GameObject> stateObjects = new List<GameObject>();
        // Координаты
        protected int x;
        protected int y;
        // Размер спрайта
        protected int size = 32;
        // Предоставляет значение времени
        protected GameTime gameTime;
        public Song menuSong;

        /// <summary>
        /// Управление состоянием игры
        /// </summary>
        /// <param name="mediator">Посредник</param>
        /// <param name="x">Координата х</param>
        /// <param name="y">Координата у</param>
        /// <param name="gameTime">Предоставляет значение времени</param>
        public StateHolder(Mediator mediator, int x, int y, GameTime gameTime)
        {
            this.mediator = mediator;
            this.x = x;
            this.y = y;
            this.gameTime = gameTime;
        }

        /// <summary>
        /// Задний фон меню
        /// </summary>
        public void MenuBackground()
        {
            Random random = new Random();

            for (int i = 0; i < this.x; i += size)
            {
                for (int j = 0; j < this.x; j += size)
                {
                    stateObjects.Add(new HUDTile(i, j, random.Next(3), this.mediator));
                }
            }
        }

        /// <summary>
        /// Рисование сцены
        /// </summary>
        /// <param name="gameTime">Предоставляет значение времени</param>
        /// <param name="spriteBatch">Спрайт</param>
        public virtual void StateDraw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (GameObject gameObject in stateObjects)
            {
                gameObject.Load();
                gameObject.Draw(spriteBatch, gameTime);
            }
        }

        /// <summary>
        /// Обновление состояния игры
        /// </summary>
        /// <param name="gameTime">Предоставляет значение времени</param>
        /// <param name="spriteBatch">Спрайт</param>
        public void StateUpdate(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (GameObject gameObject in stateObjects)
            {
                gameObject.Update(gameTime);
            }
        }

        /// <summary>
        /// Загрузка объектов
        /// </summary>
        public virtual void Load()
        {

        }

        /// <summary>
        /// Объекты меню
        /// </summary>
        public List<GameObject> MenuObjects
        {
            get => stateObjects;
            set => stateObjects = value;
        }
    }
}