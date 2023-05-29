using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace RogueLike
{
    /// <summary>
    /// Класс двери
    /// </summary>
    public class Door : Structures
    {
        // Закрытая дверь
        private Texture2D closedDoor;
        // Открытая дверь
        private Texture2D openDoor;
        private Player player;
        // Уровень
        private int level;
        // Флаг открытой двери
        private bool isOpen;
        // Звуковой эффект
        private SoundEffect soundEffect;
        // Проигрывание звука
        private bool PlaySoundBool = false;

        /// <summary>
        /// Дверь
        /// </summary>
        /// <param name="x">Координата х</param>
        /// <param name="y">Координата у</param>
        /// <param name="mediator">Посредник</param>
        /// <param name="isOpen">Флаг открытой двери</param>
        public Door(int x, int y, Mediator mediator, bool isOpen) : base(mediator, x, y)
        {
            this.isOpen = isOpen;
            this.hitbox = new Rectangle(this.X, this.Y, spriteWidth, spriteHeight);
        }

        /// <summary>
        /// Столкновение
        /// </summary>
        /// <param name="other">Другой объект</param>
        /// <returns>Проверяет объекты на столкновение</returns>
        public override bool Collision(GameObject other)
        {
            if (other is Player)
            {
                Player p = (Player)other;
                if (this.isOpen == true)
                {
                    PlaySoundBool = true;
                    p.LevelsCompleted++;
                    p.setX(UnitCoord(1));
                    p.setY(UnitCoord(7));
                    mediator.room.InitializeRandomLevel();
                    mediator.itemToBeAdded.Add(mediator.player);
                    mediator.itemToBeDeleted.Add(mediator.player);
                }
                else
                {
                    p.setX(mediator.player.prevPosX);
                    p.setY(mediator.player.prevPosY);
                }
            }
            return true;
        }

        /// <summary>
        /// Рисование двери
        /// </summary>
        /// <param name="spriteBatch">Спрайт</param>
        /// <param name="gameTime">Предоставляет значение времени</param>
        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (!isOpen)
            {
                spriteBatch.Draw(closedDoor, hitbox, Color.White);
            }
            else
            {
                spriteBatch.Draw(openDoor, hitbox, Color.White);
            }
        }

        /// <summary>
        /// Повышение уровня
        /// </summary>
        /// <param name="itemToBeAdded">Предметы для добавления</param>
        /// <returns>Прибавляет к уровню единицу</returns>
        public int LevelUp(List<GameObject> itemToBeAdded)
        {
            return level++;
        }

        /// <summary>
        /// Загрузка контента
        /// </summary>
        public override void Load()
        {
            closedDoor = Mediator.Game.Content.Load<Texture2D>(@"Graphic\Environment\door");
            openDoor = Mediator.Game.Content.Load<Texture2D>(@"Graphic\Environment\open_door");
            soundEffect = Mediator.Game.Content.Load<SoundEffect>(@"Graphic\music\Door");
        }

        /// <summary>
        /// Установка координат
        /// </summary>
        /// <param name="coord">Координата</param>
        /// <returns>Возвращает установленные координаты</returns>
        public int UnitCoord(int coord)
        {
            int unitCoord = coord * size;
            return unitCoord;
        }

        /// <summary>
        /// Обновление состояния игры
        /// </summary>
        /// <param name="gameTime">Предоставляет значение времени</param>
        public override void Update(GameTime gameTime)
        {
            if (PlaySoundBool)
            {
                soundEffect.CreateInstance().Play();
                PlaySoundBool = false;
            }

            if (mediator.room.EnemyCount == 0)
            {
                isOpen = true;
                LevelUp(mediator.itemToBeAdded);

            }
            else
            {
                isOpen = false;
            }
        }
    }
}