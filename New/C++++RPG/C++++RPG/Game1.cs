using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;
using Windows.Media.Core;


using System;
using Windows.UI.Xaml;

namespace C____RPG
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Map map;
        private Dictionary<string, Source> sources;
        private Player player1 = new Player("player1", 1);
        Song song;
        Dictionary<string, SoundEffect> audios;
        SoundEffectInstance instance = null;
        public Shop shop { get; }



        public Game1()
        {

            Save save = new Save();
            //save.SaveGame();
            

            sources = new Dictionary<string, Source>();
            Item wood = new Resource("wood", "Wood comes from a tree", 5);
            Item  ore = new Resource("ore", "looks valuable", 5);
            Item fish = new Resource("fish", "fish! you can eat this", 5);

            Source woodcutting = new Source("Woodcutting", wood, 25, 100, 100);
            Source minining = new Source("mining", ore, 25, 100, 100);
            Source fishing = new Source("fishing", fish, 25, 100, 100);

            shop = new Shop();

            Item woodAxe = new Tool("wood axe", "a wooden axe", 300, "woodcutting", 2, 0);
            Item woodPickAxe = new Tool("wood pickaxe", "a wooden pickaxe", 300, "mining", 2, 0);
            Item woodRod = new Tool("wood rod", "a wooden fishing rod", 300, "fishing", 2, 0);
            Item stoneAxe = new Tool("stone axe", "a stone axe", 1000, "woodcutting", 4, 0);
            Item stonePickAxe = new Tool("stone pickaxe", "a stone pickaxe", 1000, "mining", 4, 0);
            Item stoneRod = new Tool("stone rod", "a stone fishing rod", 1000, "fishing", 4, 0);
            Item ironAxe = new Tool("iron axe", "an iron axe", 3000, "woodcutting", 6, 0);
            Item ironPickAxe = new Tool("iron pickaxe", "an iron pickaxe", 3000, "mining", 6, 0);
            Item ironRod = new Tool("iron rod", "a iron fishing rod", 3000, "fishing", 6, 0);
            Item goldAxe = new Tool("gold axe", "an iron axe", 4500, "woodcutting", 8, 0);
            Item goldPickAxe = new Tool("gold pickaxe", "a gold pickaxe", 4500, "mining", 8, 0);
            Item goldRod = new Tool("gold rod", "a golden fishing rod", 4500, "fishing", 8, 0);
            Item diamondAxe = new Tool("diamond axe", "a diamond axe", 6000, "woodcutting", 10, 0);
            Item diamondPickAxe = new Tool("diamond pickaxe", "a diamond axe", 6000, "mining", 10, 0);
            Item diamondRod = new Tool("diamond rod", "a diamond fishing rod", 6000, "fishing", 10, 0);

            shop.AddItem(woodAxe);
            shop.AddItem(woodPickAxe);
            shop.AddItem(woodRod);
            shop.AddItem(stoneAxe);
            shop.AddItem(stonePickAxe);
            shop.AddItem(stoneRod);
            shop.AddItem(ironAxe);
            shop.AddItem(ironPickAxe);
            shop.AddItem(ironRod);
            shop.AddItem(goldAxe);
            shop.AddItem(goldPickAxe);
            shop.AddItem(goldRod);
            shop.AddItem(diamondAxe);
            shop.AddItem(diamondPickAxe);
            shop.AddItem(diamondRod);

            sources.Add("woodcutting", woodcutting);
            sources.Add("mining", minining);
            sources.Add("fishing", fishing);

            graphics = new GraphicsDeviceManager(this);
            
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            

            
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

            //audio--------------------------------------------

            audios = new Dictionary<string, SoundEffect>();
            //audios.Add("fishing", Content.Load<SoundEffect>("ak47"));
            
            audios.Add("fishing", Content.Load<SoundEffect>("Audio/water"));
            audios.Add("mining", Content.Load<SoundEffect>("Audio/mining"));
            audios.Add("woodcutting", Content.Load<SoundEffect>("Audio/woodcutting"));
            audios.Add("menu", Content.Load<SoundEffect>("Audio/menu"));
            audios.Add("quest", Content.Load<SoundEffect>("Audio/quest"));
            audios.Add("upgrade", Content.Load<SoundEffect>("Audio/upgrade"));
            audios.Add("gold", Content.Load<SoundEffect>("Audio/gold"));

            this.song = Content.Load<Song>("Audio/main");
            MediaPlayer.Play(song);
            MediaPlayer.IsRepeating = true;
            MediaPlayer.MediaStateChanged += MediaPlayer_MediaStateChanged;

            map = new Map();
            base.LoadContent();
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Tile.Content = Content;

            GenerateHouse();

        }

    /// <summary>
    /// UnloadContent will be called once per game and is the place to unload
    /// game-specific content.
    /// </summary>
    protected override void UnloadContent()
        {
            base.UnloadContent();
            spriteBatch.Dispose();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here
            
            base.Update(gameTime);
        }


        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            GraphicsDevice.Clear(Color.White);

            spriteBatch.Begin();
            map.Draw(spriteBatch);
            spriteBatch.End();
        }

        void MediaPlayer_MediaStateChanged(object sender, System.
                                           EventArgs e)
        {
           
        }

        public Player GetPlayer()
        {
            return player1;
        }

        public Source getSource(String name)
        {
            foreach (var source in sources)
            {
                if (source.Key == name)
                {
                    return source.Value;
                }
            }
            return null;
        }

        public void playSound(String soundname)
        {
            
            instance = null;
            foreach (var sound in audios)
            {
                if (sound.Key == soundname)
                {
                    instance = sound.Value.CreateInstance();
                }
            }
           
            instance.IsLooped = true;
            instance.Play();
        }

        public void playSoundOnce(String soundname)
        {
            
            instance = null;
            foreach (var sound in audios)
            {
                if (sound.Key == soundname)
                {
                    instance = sound.Value.CreateInstance();
                }
            }

            instance.IsLooped = false;
            instance.Play();
        }

        public void stopSound()
        {
            instance.IsLooped = false;
            if (instance != null)
            {
                instance.Stop();
            }
            
        }

        public void ToggleMediaplayer(bool audio)
        {
            if (audio)
            {
                MediaPlayer.Play(song);
            }
            else
            {
                MediaPlayer.Pause();
            }
            
        }

        public void QuitGame()
        {
            Application.Current.Exit();
        }

        public void GenerateHouse()
        {
            map.Ct.Clear();
         
            //Make the game map
            double[,] background = {
{13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,14,14,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,},
{13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,14,14,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,},
{13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,14,14,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,},
{13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,14,14,14,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,},
{13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,14,14,14,14,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,},
{13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,14,14,14,15,15,15,15,15,15,15,15,15,15,15,15,15,15,},
{13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,14,14,14,15,15,15,15,15,15,15,15,15,15,15,15,},
{13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,14,14,14,14,14,15,15,15,15,15,15,15,14,14,},
{13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,14,14,14,14,14,15,15,14,14,14,14,14,},
{13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,14,14,15,15,14,14,14,13,13,},
{13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,14,14,13,13,13,13,},
{13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,},
{13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,},
{13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,},
{13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,},
{19,19,19,19,19,19,19,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,},
{19,19,19,19,19,19,19,19,19,19,19,19,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,},
{19,19,19,20,19,19,19,19,19,19,19,19,19,19,19,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,},
{19,19,19,19,19,19,19,19,20,19,19,19,19,19,19,19,19,19,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,},
{19,19,19,19,19,19,19,19,19,19,19,19,19,19,19,19,19,19,19,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,},
{19,19,19,19,19,19,19,19,19,19,19,19,19,19,19,20,19,19,19,19,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,},
{19,19,19,19,19,19,19,19,19,19,19,19,19,19,19,19,19,19,19,19,19,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,},
{19,19,19,19,19,19,19,19,19,19,19,19,19,19,19,19,19,19,19,19,19,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13 },
             };
            map.Generate(background, 32);
         
            //Make the game map
            double[,] layer2 = {
{14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,6,9,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0, },
{14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,6,9,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,6,7,9,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,0,6,7,9,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,0,6,9,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,6,7,9,0,0,0,0,0,0,0,0,0,0,0,0,},
{14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,0,6,7,7,9,0,0,0,0,0,0,0,12,7,},
{14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,0,0,6,7,7,0,0,7,7,7,8,0,},
{14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,0,0,0,0,0,0,0,14,14,},
{0,0,0,0,0,0,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,0,0,14,14,14,14,},
{0,0,0,0,0,0,0,0,0,0,0,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,},
{23,23,23,23,23,23,0,0,0,0,0,0,0,0,0,0,0,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,},
{23,23,23,23,23,23,23,23,23,23,23,0,0,0,0,0,0,0,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,},
{30,30,30,30,30,30,32,23,23,23,23,23,23,23,0,0,0,0,0,0,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,},
{0,0,0,0,0,0,29,30,30,30,30,32,23,23,23,23,23,0,0,0,0,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,},
{0,0,0,0,0,0,0,0,0,0,0,29,30,30,32,23,23,23,0,0,0,0,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,29,30,30,32,23,23,0,0,0,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,29,32,23,23,0,0,0,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,29,32,23,23,0,0,0,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,29,32,23,23,0,0,0,14,14,14,14,14,14,14,14,14,14,14,14,14,14,},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,27,23,23,0,0,0,14,14,14,14,14,14,14,14,14,14,14,14,14,14},
             };
            map.Generate(layer2, 32);
          

            double[,] path = {
{ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0, },
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{0,0,0,0,0,0,40,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{0,0,0,0,0,0,0,40,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{0,0,0,0,0,0,0,40,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{0,0,0,0,0,0,0,40,40,40,40,40,40,40,40,40,40,40,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,15,15,0,0,0,0,0,},
{0,0,0,0,0,0,0,0,0,0,0,0,40,0,0,0,0,40,40,0,0,0,0,0,0,0,0,0,0,0,0,0,0,40,15,0,0,0,0,0,},
{0,0,0,0,0,0,0,0,0,0,0,0,40,0,0,0,0,0,40,40,40,40,40,40,0,0,0,0,0,0,0,0,40,40,40,40,40,0,0,0,},
{0,0,0,0,0,0,0,0,0,0,0,0,40,0,0,0,0,0,0,0,0,0,0,40,0,0,0,0,40,40,40,40,40,0,0,0,40,40,40,40,},
{0,0,0,0,0,0,0,0,0,0,0,0,40,0,0,0,0,0,0,0,0,0,0,40,0,0,0,0,40,0,0,0,0,0,0,0,0,0,0,0,},
{0,0,0,0,0,0,0,0,0,0,0,0,40,0,0,0,0,0,0,0,0,0,0,40,40,40,40,40,40,0,0,0,0,0,0,0,0,0,0,0,},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,player1.getPathing("up"),0,0,0,0,0,0,0,0,0,0,0,},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,player1.getPathing("up"),0,0,0,0,0,0,0,0,0,0,0,},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,player1.getPathing("up"),0,0,0,0,0,0,0,0,0,0,0,},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,player1.getPathing("up"),0,0,0,0,0,0,0,0,0,0,0,},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,player1.getPathing("up"),0,0,0,0,0,player1.getPathing("up"),0,0,0,0,0,},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,player1.getPathing("up"),0,0,0,0,0,player1.getPathing("up"),0,0,0,0,0,},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,player1.getPathing("LL"),player1.getPathing("sideways"),player1.getPathing("sideways"),player1.getPathing("sideways"),player1.getPathing("sideways"),player1.getPathing("sideways"),player1.getPathing("RL"),0,0,0,0,0,},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
             };
            map.Generate(path, 32);

            double[,] resources = {
{ 0,34,0,34,0,34,0,34,0,34,0,34,0,0,0,0,0,0,0,0,0,0,0,0,0,0,36,0,0,0,0,0,0,0,0,37,0,0,0,36, },
{34,0,34,0,34,0,34,0,34,0,34,0,0,0,0,0,0,0,0,0,0,0,0,36,0,0,0,0,0,0,37,0,0,0,0,0,0,0,0,0,},
{0,34,0,34,0,34,0,34,0,34,0,34,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,36,0,0,0,0,0,0,0,0,0,36,0,},
{34,0,34,0,0,0,0,0,34,0,34,0,34,0,0,0,0,16,0,0,0,0,0,0,0,37,0,0,0,0,0,0,0,0,36,0,0,0,0,0,},
{0,34,0,0,0,0,0,0,0,34,0,34,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,36,0,0,0,0,0,0,0,0,37,0,},
{34,0,34,0,0,0,0,0,34,0,34,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,36,0,},
{0,34,0,34,0,0,0,0,0,34,0,34,0,0,0,0,0,0,0,0,17,0,0,0,0,0,0,0,0,0,0,37,0,0,0,36,0,0,0,0,},
{34,0,0,0,34,0,0,0,0,16,0,0,0,0,0,17,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{0,0,0,0,16,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,17,0,0,0,0,0,0,},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,16,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,17,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,16,0,},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,16,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,16,player1.getHouse(),0,0,0,0,0,0,0,0,},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,17,0,0,0,0,0,0,0,0,0,0,0,0,},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,16,0},
             };
            map.Generate(resources, 32);
            
            
            
        }

        public void StopAllAudio()
        {
            foreach (var sound in audios)
            {
                //sound.Value.
            }
        }

    }
}
