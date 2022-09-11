using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace FabiCorp.UI.Components
{
    public class FrameCounter : GameObjectBase
    {
        Label counterLabel;
        double time;
        int frames = 0;

        public double AverageFramesPerSecond { get; private set; }

        public FrameCounter(SpriteBatch spriteBatch) : base(spriteBatch)
        {
            counterLabel = new Label(spriteBatch)
            {
                Position = Vector2.Zero,
                Text = "Loading...",
                TextureColor = Color.Black,
            };
        }

        public override void Update(GameTime tm)
        {
            frames++;
            time += tm.ElapsedGameTime.Milliseconds;
            if (time >= 250)
            {
                AverageFramesPerSecond = Math.Floor((float)frames * 4f);
                counterLabel.Text = AverageFramesPerSecond.ToString("000", CultureInfo.InvariantCulture) + " FPS"; 
                frames = 0;
                time = 0;
            }
        }

        public override void Render(GameTime tm)
        {
            counterLabel.Render(tm);
        }
    }
}
