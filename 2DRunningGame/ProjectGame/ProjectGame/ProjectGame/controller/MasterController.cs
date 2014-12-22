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
        private bool paused = false;
        private MenuControlls m_MenuController;
        private MenuView m_MenuView;
        private GameState CurrentGameState = GameState.MainMenu;

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
            IsMouseVisible = true;

            // TODO: use this.Content to load your game content here
            m_View = new View(GraphicsDevice, Content);
            model = new gameModel();
            m_soundEffect = Content.Load<SoundEffect>("plong1");
            m_Song = Content.Load<Song>("BackgroundSong");
            m_Camera = new Camera();
            m_MenuView = new MenuView(GraphicsDevice, Content, spriteBatch);
            m_MenuController = new MenuControlls(GraphicsDevice);
            MediaPlayer.Play(m_Song);
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
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            //    this.Exit();



            MouseState m_mouse = Mouse.GetState();

            //if exit button is clicked then exit the game.
            if (m_MenuController.isClickedToQuit)
            {
                this.Exit();
            }

            // TODO: Add your update logic here


            elapased += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            // Update the game when is not paused.
            if (paused == false)
            {

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

            }

            // swith stats to take care about which button is clicked for menu.
            switch (CurrentGameState)
            {
                case GameState.MainMenu:

                    if (m_MenuController.isCklickedToPlay)
                    {

                        CurrentGameState = GameState.Playing;
                        paused = false;
                        m_MenuController.isCklickedToReturn = false;
                        m_MenuController.isClickedToCMenu = false;

                    }

                    if (m_MenuController.isCklickedToSeInfo)
                    {
                        CurrentGameState = GameState.Options;
                        m_MenuController.isCklickedToSeInfo = true;
                        m_MenuController.isCklickedToPlay = false;
                        m_MenuController.isCklickedToReturn = false;
                    }

                    break;



                case GameState.Options:

                    if (m_MenuController.isCklickedToReturn)
                    {
                        CurrentGameState = GameState.MainMenu;
                        paused = true;
                        m_MenuController.isCklickedToPlay = false;
                        m_MenuController.isCklickedToSeInfo = false;
                    }

                    break;



                case GameState.Playing:


                    if (m_MenuController.isClickedToCMenu == true)
                    {
                        CurrentGameState = GameState.Pause;
                        paused = true;
                        m_MenuController.isCklickedToPlay = false;
                        m_MenuController.isCklickedToSeInfo = false;
                        m_MenuController.isClickedToResume = false;
                        m_MenuController.isClickedToCMenu = false;

                    }

                    if (m_MenuController.isCklickedToReturn == true)
                    {

                        CurrentGameState = GameState.MainMenu;
                        paused = true;
                        m_MenuController.isCklickedToPlay = false;
                        m_MenuController.isCklickedToSeInfo = false;
                    }

                    break;

                case GameState.Pause:

                    if (m_MenuController.isClickedToResume)
                    {
                        CurrentGameState = GameState.Playing;
                        paused = false;
                        m_MenuController.isCklickedToPlay = true;
                        m_MenuController.isClickedToResume = true;
                        m_MenuController.isCklickedToReturn = false;
                        m_MenuController.isClickedToCMenu = false;

                    }

                    break;

            }
            m_MenuController.mousePosition(m_mouse);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            //get the playerposition for the view
            Level level = model.GetLevel();

            //update camera
            m_Camera.CenterOn(model.getPosition(),
                              new Vector2(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height),
                              new Vector2(Level.g_levelWidth, Level.g_levelHeight));

            m_Camera.SetZoom(88);

            //draw background and player 
            m_View.DrawLevel(level, m_Camera, model.getPosition(), model);


            // TODO: Add your drawing code here 

            // Switch sats to draw the right texture in the right gamestate.
            switch (CurrentGameState)
            {
                case GameState.MainMenu:

                    m_MenuView.DrawMenu();
                    m_MenuView.DrawButtons();
                    paused = true;
                    break;

                case GameState.Pause:

                    m_MenuView.DrawPaused();
                    MediaPlayer.Pause();
                    m_MenuView.DrawResumeButton();
                    paused = true;

                    break;

                case GameState.Playing:

                    paused = false;
                    MediaPlayer.Resume();
                    m_MenuView.DrawPauseTexture();
                    m_MenuView.DrawReturnButton();

                    break;

                case GameState.Options:

                    m_MenuView.DrawMenu();
                    m_MenuView.DrawOpstion();
                    m_MenuView.DrawReturnButton();

                    break;

            }

            base.Draw(gameTime);
        }


    }
}
