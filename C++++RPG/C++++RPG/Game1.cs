﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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

        public Game1()
        {
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
            map = new Map();
            base.LoadContent();
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Tile.Content = Content;

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
{0,0,0,0,0,0,0,0,0,0,0,0,40,0,0,0,0,0,40,40,40,40,40,40,0,0,0,0,0,0,0,0,40,40,0,0,0,0,0,0,},
{0,0,0,0,0,0,0,0,0,0,0,0,40,0,0,0,0,0,0,0,0,0,0,40,0,0,0,0,40,40,40,40,40,0,0,0,0,0,0,0,},
{0,0,0,0,0,0,0,0,0,0,0,0,40,0,0,0,0,0,0,0,0,0,0,40,0,0,0,0,40,0,0,0,0,0,0,0,0,0,0,0,},
{0,0,0,0,0,0,0,0,0,0,0,0,40,0,0,0,0,0,0,0,0,0,0,40,40,40,40,40,40,0,0,0,0,0,0,0,0,0,0,0,},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,40,0,0,0,0,0,0,0,0,0,0,0,},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,40,0,0,0,0,0,0,0,0,0,0,0,},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,40,0,0,0,0,0,0,0,0,0,0,0,},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,40,0,0,0,0,0,0,0,0,0,0,0,},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,40,0,0,0,0,0,40,0,0,0,0,0,},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,40,0,0,0,0,0,40,0,0,0,0,0,},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,40,40,40,40,40,40,40,0,0,0,0,0,},
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
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,16,39,0,0,0,0,0,0,0,0,},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,17,0,0,0,0,0,0,0,0,0,0,0,0,},
{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,16,0},
             };
        map.Generate(resources, 32);
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
    }
}
