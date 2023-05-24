using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace RogueLike
{
    public class Door : Structures
    {
        private Texture2D closedDoor;
        private Texture2D openDoor;
        private int level;
        private bool isOpen;
        private SoundEffect soundEffect;
        private bool PlaySoundBool = false;

        public Door(int x, int y, Mediator mediator, bool isOpen) : base(mediator, x, y)
        {
            this.isOpen = isOpen;
            this.hitbox = new Rectangle(this.X, this.Y, spriteWidth, spriteHeight);
        }

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

        public int LevelUp(List<GameObject> itemToBeAdded)
        {
            return level++;
        }

        public override void Load()
        {
            closedDoor = Mediator.Game.Content.Load<Texture2D>(@"Graphic\Environment\door");
            openDoor = Mediator.Game.Content.Load<Texture2D>(@"Graphic\Environment\open_door");
            //soundEffect = Mediator.Game.Content.Load<SoundEffect>("Sounds/LevelUp");
        }

        public int UnitCoord(int coord)
        {
            int unitCoord = coord * unit;
            return unitCoord;
        }

        public override void Update(GameTime gameTime)
        {
            if (PlaySoundBool)
            {
                //soundEffect.CreateInstance().Play();
                PlaySoundBool = false;
            }

            if (mediator.room.EnemyCount == 0)
            {
                isOpen = true;
            }

            else
            {
                isOpen = false;
            }
        }
    }
}