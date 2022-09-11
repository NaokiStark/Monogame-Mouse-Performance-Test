using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabiCorp.UI.Components
{
    public class Picture : GameObjectBase
    {

        public override Texture2D Texture
        {
            get
            {
                return tx2d;
            }
            set
            {
                Size = overrideSize == Point.Zero ? value.Bounds.Size : overrideSize;
                tx2d = value;
            }
        }

        public Point overrideSize = Point.Zero;

        Texture2D tx2d;
        public Picture(SpriteBatch spriteBatch) : base(spriteBatch)
        {
            TextureColor = Color.White;
        }

        public override void Render(GameTime tm)
        {
            if (Texture != null)
            {
                spriteBatch.Draw(Texture, new Rectangle(Position.ToPoint(), overrideSize != Point.Zero ? overrideSize : Size), TextureColor);
            }
            else
            {
                spriteBatch.DrawString(MouseTestGame.MainFont.spriteFont, "TEXTURE NOT FOUND", Position, Color.White);
            }
        }
    }
}
