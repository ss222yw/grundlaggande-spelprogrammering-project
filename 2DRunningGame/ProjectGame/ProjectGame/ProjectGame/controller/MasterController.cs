using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using ProjectGame.view;
using ProjectGame.model;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace ProjectGame.controller
{
    class MasterController : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private View m_View;
        private gameModel model;
        private float elapased;
        private SoundEffect m_soundEffect;
        private Song m_Song;
        private Camera m_Camera;
  

        public MasterController()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }



        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            m_View = new View(GraphicsDevice, Content);
            model = new gameModel();
            m_soundEffect = Content.Load<SoundEffect>("plong1");
            m_Song = Content.Load<Song>("BackgroundSong");
            m_Camera = new Camera();
           // MediaPlayer.Play(m_Song);
                        
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exits
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

            elapased += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
          
                //Cheack keyboard input.
               if (m_View.IsCharacterMovingToRight())
               {
                   model.characterMovingFasterToRight();
               }

               else if (m_View.IsCharacterMovingToLeft())
               {
                   model.charcterMovingSlowlyToRight();
               }

               else
               {
                   model.characterAutoMovingToRight();
               }

            if (m_View.IsCharacterJumping() && model.getHasJumped() == false)
            {
                model.charcterIsJumping();
                m_soundEffect.Play();
            }

            model.isJumping();

            model.isPositionXLargerThanWindowsH();

            model.isNotJumping();

            
         
            base.Update(gameTime);
        }
         
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            // TODO: Add your drawing code here 
            //get the playerposition for the view
            Level level = model.GetLevel();

            //update camera
            m_Camera.CenterOn(model.getPosition(),
                              new Vector2(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height),
                              new Vector2(Level.g_levelWidth, Level.g_levelHeight));

            m_Camera.SetZoom(88);

            //draw background and player 
            m_View.DrawLevel(GraphicsDevice,level, m_Camera, model.getPosition(),model);


           // m_View.Draw(model);
            base.Draw(gameTime);
        }


    }
}
