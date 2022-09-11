using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabiCorp.UI
{
    public class GameObjectBase : IGameObject
    {
        public SpriteBatch spriteBatch { get; set; }

        public Vector2 Position { get; set; }
        public Point Size { get; set; }
        public bool IsVisible { get; set; }
        public virtual Texture2D Texture { get; set; }
        public Color TextureColor { get; set; }

        public GameObjectBase(SpriteBatch spriteBatch)
        {
            this.spriteBatch = spriteBatch;
        }

        public virtual void Render(GameTime tm) {
            if (Texture != null)
            {
                spriteBatch.Draw(Texture, Position, TextureColor);
            }
            else
            {
                spriteBatch.DrawString(MouseTestGame.MainFont.spriteFont, "TEXTURE NOT FOUND", Position, Color.White);
            }
        }

        public virtual void Update(GameTime tm) { }
    }
}
