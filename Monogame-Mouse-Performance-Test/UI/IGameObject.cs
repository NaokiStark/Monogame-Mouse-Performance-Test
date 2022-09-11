using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabiCorp.UI
{
    internal interface IGameObject
    {
        Vector2 Position { get; set; }
        Point Size { get; set; }
        bool IsVisible { get; set; }
        Texture2D Texture { get; set; }
        Color TextureColor { get; set; }


        void Update(GameTime tm);

        void Render(GameTime tm);
    }
}
