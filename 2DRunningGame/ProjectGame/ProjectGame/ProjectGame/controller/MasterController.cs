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

        private SoundEffect m_soundEffect, m_destroyedEffect, m_waterEffect, m_BombEffect, m_hahaEfect, m_warningSong;
        private Song m_SongLevel1;
        private Camera m_Camera;
        private View m_View;
        private gameModel model;
        private MenuControlls m_MenuController;
        private MenuView m_MenuView;
        private GameState CurrentGameState = GameState.MainMenu;
        private SpriteFont m_NrOfLifes, m_LevelsFont;
        private SplitterView m_splitterView;
        private int CurrentLevel = 3;
        private float elapased;
        private bool paused = false;
        private Vector2 m_levelsTextPosition;
        private float space = 0;
        private List<BombView> bombs = new List<BombView>();
        private BombModel m_BombModel;

        RainParticle m_rainParticle;


        public MasterController()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            //graphics.PreferredBackBufferWidth = 600;
            //graphics.PreferredBackBufferHeight = 400;
            //graphics.ApplyChanges();
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


            m_levelsTextPosition = new Vector2(GraphicsDevice.Viewport.Width / 1.35f, GraphicsDevice.Viewport.Height / 100);
            m_View = new View(GraphicsDevice, Content);
            m_soundEffect = Content.Load<SoundEffect>("plong1");
            m_destroyedEffect = Content.Load<SoundEffect>("test");
            m_waterEffect = Content.Load<SoundEffect>("watereffect");
            m_BombEffect = Content.Load<SoundEffect>("BombEffect");
            m_hahaEfect = Content.Load<SoundEffect>("haha");

            m_SongLevel1 = Content.Load<Song>("BackgroundSong");
            m_warningSong = Content.Load<SoundEffect>("LeaveNow");
            m_Camera = new Camera(GraphicsDevice.Viewport);
            m_MenuController = new MenuControlls(GraphicsDevice);
            m_MenuView = new MenuView(GraphicsDevice, Content, spriteBatch, m_MenuController);

            m_NrOfLifes = Content.Load<SpriteFont>("SpriteFont1");
            m_LevelsFont = Content.Load<SpriteFont>("LevelsFont");

            m_splitterView = new SplitterView(GraphicsDevice, Content);


            // TODO: use this.Content to load your game content here
            model = new gameModel(Level.Maps(CurrentLevel));



            MediaPlayer.Play(m_SongLevel1);
            MediaPlayer.Volume = 0.1f;

            m_rainParticle = new RainParticle(Content,GraphicsDevice ,15);
                    
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


            MouseState m_mouse = Mouse.GetState();

            //if exit button is clicked then exit the game.
            if (m_MenuController.isClickedToQuit)
            {
                this.Exit();
            }

            // TODO: Add your update logic here
            elapased += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            float elapasedSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;

            // Update the game when is not paused.
            if (paused == false)
            {
                if (CurrentLevel == 1)
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
                }

                else if (CurrentLevel == 2)
                {
                    //Cheack keyboard input.
                    if (m_View.IsCharacterMovingToRight())
                    {
                        model.characterMovingFasterToRight2();
                    }

                    else if (m_View.IsCharacterMovingToLeft())
                    {
                        model.charcterMovingSlowlyToRight2();
                    }

                    else
                    {
                        model.characterAutoMovingToRight2();
                    }
                }

                    
                else if (CurrentLevel == 3)
                {

                    model.ghostMovingToRight();
                    //Cheack keyboard input.
                    if (m_View.IsCharacterMovingToRight())
                    {
                        model.characterMovingFasterToRight3();
                        model.ghostMovingFasterToRight();
                    }

                    else if (m_View.IsCharacterMovingToLeft())
                    {
                        model.charcterMovingSlowlyToRight3();
                    }

                    else
                    {
                        model.characterAutoMovingToRight3();
                    }
                }

                if (m_View.IsCharacterJumping() && model.getHasJumped())
                {
                    model.charcterIsJumping();
                    m_soundEffect.Play();
                }

                model.UpdatePlayer(elapasedSeconds);

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

                    if (m_MenuController.isClickedToRePlay)
                    {
                        model.newLifes();
                        CurrentGameState = GameState.Playing;
                        model.getPlayerDefaultPosition();
                        model.GhostDefaultPosition();
                        paused = false;
                        m_MenuController.isCklickedToReturn = false;
                        m_MenuController.isClickedToCMenu = false;
                    }

                    break;



                case GameState.Options:

                    Menu();

                    break;



                case GameState.Playing:

                    model.gameOver();
                    model.endOfTheGame();
                    m_rainParticle.Update(elapasedSeconds);

                    if (CurrentLevel != 1)
                    {

                        space += elapasedSeconds;

                        foreach (BombView bomb in bombs)
                        {
                            m_BombModel.Update();

                            if (m_View.playerRectangle().Intersects(bomb.BombRectangle()))
                            {
                                m_BombEffect.Play();
                                model.getPlayerDefaultPosition();
                                model.GhostDefaultPosition();
                                model.loseALife();
                            }

                        }
                        // the space between the boms is larger or equals 6 , make it zero.
                        if (space >= 6)
                        {
                            space = 0;

                            // add 5 bombs when it is less than 5
                             if (bombs.Count() < 5)
                            {
                                // add bombs position
                                m_BombModel = new BombModel(new Vector2(GraphicsDevice.Viewport.Width / 1.5f, GraphicsDevice.Viewport.Height/4),CurrentLevel);
                                bombs.Add(new BombView(Content, m_BombModel));
                            }

                            // Remove the bomb if it is not visible any more.
                             for (int i = 0; i < bombs.Count; i++)
                             {
                                 if (m_BombModel.isHidden)
                                 {
                                     bombs.RemoveAt(i);
                                     i -= 1;
                                 }
                             }
                        }
                    }

                    if (CurrentLevel == 3)
                    {

                        if (m_View.ghostRectangle().Intersects(m_View.playerRectangle()))
                        {
                            m_warningSong.Play();
                            model.getPlayerDefaultPosition();
                            model.GhostDefaultPosition();
                            model.m_positionLagerThanTheLevel = true;
                        }
                        else if (model.isGameOver)
                        {
                            m_hahaEfect.Play();
                        }
                    }

                    if (m_MenuController.isClickedToCMenu == true)
                    {
                        CurrentGameState = GameState.Pause;
                        paused = true;
                        m_MenuController.isCklickedToPlay = false;
                        m_MenuController.isCklickedToSeInfo = false;
                        m_MenuController.isClickedToResume = false;
                        m_MenuController.isClickedToCMenu = false;
                        m_MenuController.isClickedToRePlay = false;
                        m_MenuController.IsClickedToPlayAgain = false;
                    }

                    Menu();

                    if (model.isGameOver)
                    {
                        CurrentGameState = GameState.GameOver;
                        m_MenuController.isCklickedToPlay = false;
                        m_MenuController.IsClickedToPlayAgain = false;
                        model.isGameOver = false;
                        paused = true;

                    }

                    if (model.isLevelCompleted)
                    {
                        CurrentGameState = GameState.Finish;
                        paused = true;
                        m_MenuController.isClickedToContinue = false;
                    }

                    if (model.m_positionLagerThanTheLevel && model.hasCollidedWidthTheLeft() == false)
                    {
                        m_waterEffect.Play();
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
                        m_MenuController.isClickedToRePlay = false;
                    }

                    break;


                case GameState.GameOver:


                    if (m_MenuController.IsClickedToPlayAgain || m_View.IsClickedToPlayAgain())
                    {
                        model.getPlayerDefaultPosition();
                        model.GhostDefaultPosition();
                        model.isGameOver = false;
                        paused = false;
                        model.newLifes();
                        CurrentLevel = 1;
                        model = new gameModel(Level.Maps(CurrentLevel));
                        CurrentGameState = GameState.Playing;
                    }

                    Menu();
                    break;
                case GameState.Finish:

                    if (m_MenuController.isClickedToContinue)
                    {
                        model.getPlayerDefaultPosition();
                        model.GhostDefaultPosition();
                        model.isLevelCompleted = false;
                        m_MenuController.isClickedToRePlay = false;
                        m_MenuController.IsClickedToPlayAgain = false;
                        m_MenuController.isClickedToContinue = false;
                        paused = true;

                        if (CurrentLevel == 1 || CurrentLevel == 2)
                        {
                            model = new gameModel(Level.Maps(CurrentLevel += 1));
                            CurrentGameState = GameState.Playing;
                        }

                    }
                    break;
            }
            m_MenuController.mousePosition(m_mouse);

            base.Update(gameTime);
        }

        private void Menu()
        {
            if (m_MenuController.isCklickedToReturn == true)
            {

                CurrentGameState = GameState.MainMenu;
                paused = true;
                m_MenuController.isCklickedToPlay = false;
                m_MenuController.isCklickedToSeInfo = false;
                m_MenuController.isClickedToRePlay = false;
                m_MenuController.IsClickedToPlayAgain = false;
            }
        }



        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin();
            Level level = model.GetLevel();
            //get the playerposition for the view


            //update camera
            m_Camera.CenterOn(model.GetPlayerPosition(),
                              new Vector2(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height),
                              new Vector2(Level.g_levelWidth, Level.g_levelHeight));


            m_Camera.SetZoom(GraphicsDevice.Viewport.Width/12);



            //draw background and player 
            m_View.DrawLevel(level, m_Camera, model);


            // TODO: Add your drawing code here 

            // Switch sats to draw the right texture in the right gamestate.
            switch (CurrentGameState)
            {

                case GameState.MainMenu:

                    m_MenuView.DrawMenu();
                    m_MenuView.DrawButtons();
                    m_MenuView.DrawRePlayTexture();
                    paused = true;
                    break;

                case GameState.Pause:

                    m_MenuView.DrawPaused();
                    MediaPlayer.Pause();
                    m_MenuView.DrawResumeButton();
                    paused = true;

                    break;

                case GameState.Playing:
                    
                    if (CurrentLevel != 1)
                    {
                        m_rainParticle.Draw(spriteBatch);
                        foreach (BombView bomb in bombs)
                        {
                            bomb.Draw(spriteBatch,m_Camera);
                        }
                    }

                    if (model.hasCollidedWidthTheLeft() == true)
                    {
                        m_destroyedEffect.Play();
                        m_splitterView.draw((float)gameTime.ElapsedGameTime.TotalSeconds);
                    }


                    if (CurrentLevel == 1)
                    {
                        spriteBatch.DrawString(m_LevelsFont, "Level one", m_levelsTextPosition, Color.Black);
                    }
                    else if (CurrentLevel == 2)
                    {
                        spriteBatch.DrawString(m_LevelsFont, "Level two", m_levelsTextPosition, Color.Black);
                    }
                    else if (CurrentLevel == 3)
                    {
                        m_View.drawGhost();
                        spriteBatch.DrawString(m_LevelsFont, "Level three", m_levelsTextPosition, Color.Black);
                    }

                    paused = false;
                    MediaPlayer.Resume();
                    m_MenuView.DrawPauseTexture();
                    m_MenuView.DrawReturnButton();
                    model.endOfTheGame();

                    var Count = model.nrOfLifes();
                    spriteBatch.DrawString(m_NrOfLifes, "Lifes" + " = " + Count, new Vector2(GraphicsDevice.Viewport.Width / 1.35f, GraphicsDevice.Viewport.Height / 18), Color.Black);

                    break;

                case GameState.Options:
                    m_MenuView.DrawMenu();
                    m_MenuView.DrawOpstion();
                    m_MenuView.DrawReturnButton();

                    break;

                case GameState.GameOver:
                    MediaPlayer.Stop();
                    m_MenuView.DrawGameOver();
                    m_MenuView.DrawPlayAgainBtn();
                    m_MenuView.DrawReturnButton();

                    break;


                case GameState.Finish:
                    if (CurrentLevel == 1 || CurrentLevel == 2)
                    {
                        m_MenuView.DrawCompletedLevel();
                        m_MenuView.DrawContinueBtn();
                    }
                    else
                    {
                        m_MenuView.DrawTheEnd();
                        m_MenuView.drawExit();
                    }
                    MediaPlayer.Stop();

                    break;
            }
            spriteBatch.End();


            base.Draw(gameTime);
        }


    }
}
