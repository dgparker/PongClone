using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PongClone
{
    public abstract class Sprite
    {      
        public int Width { get { return texture.Width; } }
        public int Height { get { return texture.Height; } }
        public Vector2 Velocity { get; protected set; }
        protected readonly Texture2D texture;
        public Vector2 Location;
        protected readonly Rectangle gameBoundaries;
        public Rectangle BoundingBox { get { return new Rectangle((int)Location.X, (int)Location.Y, (int)Width, (int)Height); } }



        public Sprite(Texture2D texture, Vector2 location, Rectangle gameBoundaries)
        {
            this.texture = texture;
            this.gameBoundaries = gameBoundaries;
            Location = location;
            Velocity = Vector2.Zero;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Location, Color.White);
        }

        public virtual void Update(GameTime gameTime, GameObjects gameObjects)
        {
            Location += Velocity;

            CheckBounds();
        }

        protected abstract void CheckBounds();

    }
}
