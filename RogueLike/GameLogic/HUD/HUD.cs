﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;

namespace RogueLike
{
    /// <summary>
    /// Класс визуального интерфейса
    /// </summary>
    class HUD : GameObject
    {
        // Игрок
        private Player _player;
        // Уровень
        private Level _level;
        private int unitsAvailableX;
        private int unitsAvailableY;
        // Размер блока
        private int unit = 32;
        // Шрифт
        private SpriteFont _spriteFont;
        // Цвет шрифта
        private Color textColor = Color.LightYellow;
        private Song gameSong;

        /// <summary>
        /// Визуальный интерфейс
        /// </summary>
        /// <param name="x">Координата х</param>
        /// <param name="y">Координата у</param>
        /// <param name="mediator">Посредник</param>
        public HUD(int x, int y, Mediator mediator) : base(mediator, x, y)
        {
            unitsAvailableX = X / unit;
            unitsAvailableY = Y / unit;

            InitHUDBackground();
        }

        /// <summary>
        /// Метод изображения урона
        /// </summary>
        /// <param name="spriteBatch">Спрайт</param>
        public void DisplayDamage(SpriteBatch spriteBatch)
        {
            int x = unit * 9;
            int y = 480 + unit;

            if (mediator.player.Weapon == null)
            {
                Projectile p = new Projectile(0, 0, Direction.Up, mediator);
                spriteBatch.DrawString(_spriteFont, "DMG " + p.Damage, new Vector2(x, y), textColor);
            }
            else if (mediator.player.Weapon != null)
            {
                spriteBatch.DrawString(_spriteFont, "DMG " + mediator.player.weapon.Projectile.Damage, new Vector2(x, y), textColor);
            }
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            StaticHUDText(spriteBatch);
        }

        /// <summary>
        /// Метод инициализации фона интерфейса
        /// </summary>
        private void InitHUDBackground()
        {
            Random random = new Random();

            for (int i = 0; i < X; i += unit)
            {
                for (int j = 0; j < Y; j += unit)
                {
                    mediator.AllObjects.Add(new HUDTile(i, j + 480, random.Next(3), mediator));
                }
            }
        }

        public override void Load()
        {
            _spriteFont = Mediator.Game.Content.Load<SpriteFont>(@"Fonts\Font");
            gameSong = Mediator.Game.Content.Load<Song>(@"Graphic\music\Boss");
            MediaPlayer.Stop();
            MediaPlayer.Play(gameSong);
            MediaPlayer.IsRepeating = true;
        }

        /// <summary>
        /// Метод статического текста
        /// </summary>
        /// <param name="spriteBatch">Спрайт</param>
        private void StaticHUDText(SpriteBatch spriteBatch)
        {
            if (mediator.player.health > 0)
            {
                spriteBatch.DrawString(_spriteFont, "HP: " + mediator.player.health, new Vector2(0 + 10, 480), textColor);
            }
            else
            {
                spriteBatch.DrawString(_spriteFont, "DEAD", new Vector2(0 + 10, 480), textColor);
            }
            spriteBatch.DrawString(_spriteFont, "Weapon: " + mediator.player.weapon, new Vector2(0 + 10, 480 + unit), textColor);
            spriteBatch.DrawString(_spriteFont, "Cooldown: " + mediator.player.playerCooldown, new Vector2(0 + 10, 480 + unit * 2), textColor);
            spriteBatch.DrawString(_spriteFont, "Movement Speed: " + mediator.player.speed, new Vector2(unit * 8, 480), textColor);
            spriteBatch.DrawString(_spriteFont, "Enemies in Room: " + mediator.room.EnemyCount, new Vector2(unit * 16, 480), textColor);
            DisplayDamage(spriteBatch);
        }

        /// <summary>
        /// Метод вычисления координаты
        /// </summary>
        /// <param name="coordinates"></param>
        /// <returns></returns>
        public int UnitCoord(int coordinates)
        {
            int unitCoord = coordinates * unit;
            return unitCoord;
        }

        public override void Update(GameTime gameTime)
        {

        }
    }
}
