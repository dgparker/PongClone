using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PongClone
{
    public enum PlayerTypes
    {
        Human,
        Computer
    }
    public class Paddle : Sprite
    {
        private readonly PlayerTypes playerType;

        public Paddle(Texture2D texture, Vector2 location, Rectangle screenBounds, PlayerTypes playerType) : base(texture, location, screenBounds)
        {
            this.playerType = playerType;
        }

        public override void Update(GameTime gameTime, GameObjects gameObjects)
        {

            if(playerType == PlayerTypes.Computer)
            {
                var random = new Random();
                var reactionThreshold = random.Next(30, 130);

                if(gameObjects.Ball.Location.Y + gameObjects.Ball.Height < Location.Y + reactionThreshold)
                {
                    Velocity = new Vector2(0, -3.5f);
                }
                if (gameObjects.Ball.Location.Y > Location.Y + Height + reactionThreshold)
                {
                    Velocity = new Vector2(0, 3.5f);
                }

            }

            if(playerType == PlayerTypes.Human)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.W))
                {
                    Velocity = new Vector2(0, -3.5f);
                }

                if (Keyboard.GetState().IsKeyDown(Keys.S))
                {
                    Velocity = new Vector2(0, 3.5f);
                }
            }

            base.Update(gameTime, gameObjects);
        }

        protected override void CheckBounds()
        {
           Location.Y = MathHelper.Clamp(Location.Y, 0, gameBoundaries.Height - texture.Height);
        }
    }

}