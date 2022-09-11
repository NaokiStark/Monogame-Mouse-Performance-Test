using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabiCorp.UI.Components
{
    public class Label : GameObjectBase
    {
        Font font = MouseTestGame.MainFont;

        public string Text
        {
            get
            {
                return actualText;
            }
            set
            {
                lastText = actualText;
                actualText = value;
            }
        }
        string actualText = "";
        string lastText = "";

        public Vector2 textSize = Vector2.Zero;

        public Label(SpriteBatch spriteBatch) : base(spriteBatch)
        {

        }

        public override void Update(GameTime tm)
        {
            base.Update(tm);

            // this is because SpriteFont.MeasureString(string) is too expensive
            if (!lastText.Equals(actualText)) {
                textSize = font.spriteFont.MeasureString(actualText);
                lastText = actualText;
            }
        }

        public override void Render(GameTime tm)
        {
            spriteBatch.DrawString(font.spriteFont, Text, Position, TextureColor);
        }
    }
}
