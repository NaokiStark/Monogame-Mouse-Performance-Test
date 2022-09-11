using Microsoft.Xna.Framework.Graphics;
using SpriteFontPlus;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabiCorp.UI
{
    public class Font
    {
        public SpriteFont spriteFont;
        public static string BASE_PATH = System.AppContext.BaseDirectory;
        public Font(string name, GraphicsDevice graphicsDevice)
        {
            string file = Path.Combine(BASE_PATH, "Assets", "Fonts", name);

            var fontBakeResult = TtfFontBaker.Bake(File.ReadAllBytes(file), 25, 1024, 1024,
                new[]{
                        CharacterRange.BasicLatin,
                        CharacterRange.Latin1Supplement,
                        CharacterRange.LatinExtendedA,
                        CharacterRange.Cyrillic
                });

            spriteFont = fontBakeResult.CreateSpriteFont(graphicsDevice);
        }
    }
}
