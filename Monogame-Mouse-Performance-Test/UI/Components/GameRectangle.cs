using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabiCorp.UI.Components
{
    public class GameRectangle : GameObjectBase
    {
        public GameRectangle(SpriteBatch spriteBatch, Point size) : base(spriteBatch)
        {
            Size = size;

            generateTexture();
        }

        private void generateTexture()
        {
            Color[] colors = new Color[Size.X * Size.Y];
            
            for (int i = 0; i < colors.Length; i++)
            {
                colors[i] = Color.White;  
            }

            Texture = new Texture2D(MouseTestGame.Instance.GraphicsDevice, Size.X, Size.Y);
            
            Texture.SetData(colors);

        } 
    }
}
