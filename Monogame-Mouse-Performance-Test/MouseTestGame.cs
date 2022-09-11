using FabiCorp.UI;
using FabiCorp.UI.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace FabiCorp
{
    public class MouseTestGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public static MouseTestGame Instance;
        public static Font MainFont;
        public List<GameObjectBase> Controls = new();
        public GameRectangle MouseRect;
        public FrameCounter frameCounter;
        public Label displayLabel;

        public Picture targetObject;
        public MouseTestGame()
        {
            Instance = this;
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // Mouse visible setted to false
            IsMouseVisible = false;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Set to simulate 200Hz
            IsFixedTimeStep = true;
            _graphics.SynchronizeWithVerticalRetrace = false;
            TargetElapsedTime = TimeSpan.FromSeconds(1.0f / 200f);

            // Resolution
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;

            _graphics.ApplyChanges();

            // TODO: use this.Content to load your game content here

            MainFont = new Font("DJB_Emphatic.ttf", GraphicsDevice);

            MouseRect = new GameRectangle(_spriteBatch, new Point(10))
            { TextureColor = Color.Red };

            frameCounter = new FrameCounter(_spriteBatch);

            string ltext = $"Move your cursor as fast as possible {Environment.NewLine}Or try to catch Wada Don";
            Vector2 ltext_size = MainFont.spriteFont.MeasureString(ltext);
            displayLabel = new Label(_spriteBatch)
            {
                Text = ltext,
                Position = new Vector2(
                    GraphicsDevice.Viewport.Width / 2f - (ltext_size.X / 2f),
                    GraphicsDevice.Viewport.Height / 2 - (ltext_size.Y / 2f)),
                TextureColor = Color.Black,
            };

            targetObject = new Picture(_spriteBatch)
            {
                Texture = Content.Load<Texture2D>("Catcher"),
                overrideSize = new Point(200),
            };


            Controls.Add(MouseRect);
            Controls.Add(targetObject);
            Controls.Add(displayLabel);
            Controls.Add(frameCounter);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);

            // Mouse tracking with a rectangle
            MouseRect.Position = Mouse.GetState().Position.ToVector2();

            Point target_size = targetObject.overrideSize == Point.Zero ? targetObject.Size : targetObject.overrideSize;
            var mouseRct = new Rectangle(MouseRect.Position.ToPoint(), MouseRect.Size);
            var targetPosition = new Rectangle(targetObject.Position.ToPoint(), target_size);

            if (mouseRct.Intersects(targetPosition))
            {
                var rnd = new Random(gameTime.TotalGameTime.Milliseconds);
                targetObject.Position = new Vector2(rnd.Next(20, GraphicsDevice.Viewport.Width - target_size.X), rnd.Next(20, GraphicsDevice.Viewport.Height - target_size.Y));
            }

            foreach (GameObjectBase gameObject in Controls)
            {
                if (gameObject is FrameCounter)
                {
                    continue;
                }
                gameObject.Update(gameTime);
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
            _spriteBatch.Begin(SpriteSortMode.Immediate);
            frameCounter.Update(gameTime);
            foreach (GameObjectBase gameObject in Controls)
            {
                gameObject.Render(gameTime);
            }
            _spriteBatch.End();
        }
    }
}