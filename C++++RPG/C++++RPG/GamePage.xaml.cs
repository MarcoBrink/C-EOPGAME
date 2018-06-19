using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using System.Windows;
using System.Diagnostics;
using System.Threading;
using XamlAnimatedGif;
using System.ComponentModel;
using Windows.Media.Playback;
using Windows.Media.Core;





// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace C____RPG
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GamePage : Page
    {
		readonly Game1 _game;
        List<Animation> animations;
        string currentLocation;
        DispatcherTimer actTimer;
    

        public GamePage()
        {
            this.InitializeComponent();

            myGamePage.Width = Window.Current.Bounds.Width;
            myGamePage.Height = Window.Current.Bounds.Height;

            var iets = XamlAnimatedGif.AnimationBehavior.GetSourceUri(player_sprite);
            
            Debug.WriteLine(iets);
            // Create the game.
            var launchArguments = string.Empty;
            _game = MonoGame.Framework.XamlGame<Game1>.Create(launchArguments, Window.Current.CoreWindow, swapChainPanel);

            //databinding for the dynamic gif file
            // No idea if this is going to work...
            this.DataContext = this;

            //current location to check what animation should play. 
            currentLocation = "home";
            // add_movement to add new animations in a curtain animationset  Woodcutting => fishingToWoodcutting / miningToWoodcutting 
            animations = new List<Animation>();
            Animation xp_gain = new Animation("xp", "test", "-5,0");
            Animation woodcutting = new Animation("woodcutting", "test", "-5,0", "5,0", "10,0");
            woodcutting.Add_Movement("fishingToWoodcutting", "0,-8", "-4,0", "0,-4");
            woodcutting.Add_Movement("homeToWoodcutting", "0, 1","-5,0", "0,-6", "-4,0", "0,-3", "-5,0", "0,-1", "-1,0", "0,-1", "-8,0", "0,-4");
            woodcutting.Add_Movement("woodcuttingToWoodcutting", "0,0");
            woodcutting.Add_Movement("miningToWoodcutting", "0,3", "-1,0", "0,1", "-3,0", "0,2", "-4,0", "0,-3", "-5,0", "0,-1", "-1,0", "0,-1", "-8,0", "0,-4");

            Animation mining = new Animation("mining", "test", "-5,0", "0, -10", "0,0");
            mining.Add_Movement("fishingToMining", "0,-8","4,0", "0,1", "1,0", "0,1", "5,0", "0,3", "4,0", "0,-2", "3,0", "0,-1", "1,0", "0,-3");
            mining.Add_Movement("homeToMining", "0, 1", "-5,0", "0,-8", "3,0", "0,-1", "1,0", "0,-3");
            mining.Add_Movement("woodcuttingToMining", "0,4", "8,0", "0,1", "1,0", "0,1", "5,0", "0,3", "4,0", "0,-2", "3,0", "0,-1", "1,0", "0,-3");
            mining.Add_Movement("miningToMining", "0,0");

            Animation fishing = new Animation("fishing", "test", "-5,0", "0,5", "-10,0");
            fishing.Add_Movement("fishingToFishing", "0,0");
            fishing.Add_Movement("homeToFishing", "0, 1", "-5,0", "0,-6", "-4,0", "0,-3", "-5,0", "0,-1", "-1,0", "0,-1", "-4,0", "0,8");
            fishing.Add_Movement("woodcuttingToFishing", "0,4","4,0", "0,8");
            fishing.Add_Movement("miningToFishing", "0,3", "-1,0", "0,1", "-3,0", "0,2", "-4,0", "0,-3", "-5,0", "0,-1", "-1,0", "0,-1", "-4,0", "0,8");

            Animation home = new Animation("home", "test", "-5,0", "0,5", "-10,0");
            home.Add_Movement("fishingToHome", "0,-8", "4,0", "0,1", "1,0", "0,1", "5,0", "0,3", "4,0", "0,6", "5,0", "0,-1");
            home.Add_Movement("homeToHome", "0, 0");
            home.Add_Movement("woodcuttingToHome", "0,4", "8,0", "0,1", "1,0", "0,1", "5,0", "0,3", "4,0", "0,6", "5,0", "0,-1");
            home.Add_Movement("miningToHome", "0,3", "-1,0", "0,1", "-3,0","0,8", "5,0", "0,-1");

            animations.Add(woodcutting);
            animations.Add(mining);
            animations.Add(fishing);
            animations.Add(home);

            actTimer = new DispatcherTimer();
            actTimer.Interval = new TimeSpan(0,0,1);
            actTimer.Tick += XpEvent;
            actTimer.Stop();


        }

     
        private async void XpEvent(object sender, object e)
        {
            xp_gain_textblock.Visibility = Visibility.Visible;
            Xp_Gain_story_anim.From = _game.GetPlayer().getLocation().y;
            Xp_Gain_story_anim.To = _game.GetPlayer().getLocation().y - 50;
      
            Canvas.SetTop(xp_gain_textblock, _game.GetPlayer().getLocation().y);
            Canvas.SetLeft(xp_gain_textblock, _game.GetPlayer().getLocation().x);
            Xp_Gain_story.Begin();
            await System.Threading.Tasks.Task.Delay(TimeSpan.FromSeconds(1));
            xp_gain_textblock.Visibility = Visibility.Collapsed;

            Dictionary<string, Source> sources = _game.getSources();
            foreach(var source in sources)
            {
                if (source.Key == currentLocation)
                {
                    _game.GetPlayer().Act(source.Value.Experience, currentLocation);
                    break;
                }
            }
            
            

        }

        public int MoveTo(int vx, int vy)
        {
            _game.stopSound();
            actTimer.Stop();
            if (vx < 0)
            {

                //change to left gif
                XamlAnimatedGif.AnimationBehavior.SetSourceUri(player_sprite, new Uri("ms-resource:///Files/Content/Player/left.gif"));
            }
            if(vx > 0)
            {
                //change to right gif
                XamlAnimatedGif.AnimationBehavior.SetSourceUri(player_sprite, new Uri("ms-resource:///Files/Content/Player/right.gif"));
            }
            
            if (vy > 0)
            {
                //change to down gif
                XamlAnimatedGif.AnimationBehavior.SetSourceUri(player_sprite, new Uri("ms-resource:///Files/Content/Player/down.gif"));
            }
            if (vy < 0)
            {
                //change to upper gif
                XamlAnimatedGif.AnimationBehavior.SetSourceUri(player_sprite, new Uri("ms-resource:///Files/Content/Player/up.gif"));
            }


            Storyboard Moving_object = player_move;
            DoubleAnimationUsingKeyFrames df = player_move_x;
            DoubleAnimationUsingKeyFrames df2 = player_move_y;


            EasingDoubleKeyFrame x = new EasingDoubleKeyFrame();
            EasingDoubleKeyFrame y = new EasingDoubleKeyFrame();

            Moving_object.Stop();

            df.KeyFrames.Clear();
            df2.KeyFrames.Clear();

            //makes a grid for easy parameter input
            int value_x = vx * 30;
            int value_y = vy * 30;


            int speed = 1;
            int time_x = 0;
            int time_y = 0;
            
            //calculates the speed 
            if (vx != 0)
            {
                time_x = speed * vx;
                if (time_x < 0)
                {
                    time_x = time_x * -1;
                    Debug.WriteLine("speed x: " + time_x);
                }
            }
            if (vy != 0)
            {
                time_y = speed * vy;
                if (time_y < 0)
                {
                    time_y = time_y * -1;
                    Debug.WriteLine("speed y: " + time_y);
                }
            }
            
            //keytime add to give the movement a timespan
            //value to give the movement pixels to move at
            x.KeyTime = new TimeSpan(0, 0, time_x);
            x.Value = _game.GetPlayer().getLocation().x + value_x;
            y.KeyTime = new TimeSpan(0, 0, time_y);
            y.Value = _game.GetPlayer().getLocation().y + value_y;

            df.KeyFrames.Add(x);
            df2.KeyFrames.Add(y);

            
            Moving_object.Begin();

           
            
            _game.GetPlayer().getLocation().x = (int) x.Value;
            _game.GetPlayer().getLocation().y = (int) y.Value;

            player_sprite.SetValue(Canvas.LeftProperty, x.Value);
            player_sprite.SetValue(Canvas.TopProperty, y.Value);

            return time_x + time_y;
        }

        //--------------------------------------------------------------------------------------------------------------------------------------
        //Skill animations. buttons for each skill. checks what skill it needs and get the movement data to create moveTo functions.
        // await function to wait for the animation to be completed. otherwise the movement will be instantly.
        private async void Woodcutting(object sender, RoutedEventArgs e)
        {
            
            foreach (Animation anim in animations)
            {
                if (anim.Name == "woodcutting")
                {
                    List<int[]> actions = new List<int[]>();
                    switch(currentLocation){
                        case "home":
                            actions = anim.getAnimation("homeToWoodcutting");
                            break;
                        case "woodcutting":
                            actions = anim.getAnimation("woodcuttingToWoodcutting");
                            break;
                        case "fishing":
                            actions = anim.getAnimation("fishingToWoodcutting");
                            break;
                        case "mining":
                            actions = anim.getAnimation("miningToWoodcutting");
                            break;
                        default:
                            break;

                    }
                    currentLocation = "woodcutting";
                    
                    
                    foreach (int[] action in actions)
                    {
                        int timespan = MoveTo(action[0], action[1]);
                        await System.Threading.Tasks.Task.Delay(TimeSpan.FromSeconds(timespan));

                    }
                    _game.playSound("woodcutting");
                    XamlAnimatedGif.AnimationBehavior.SetSourceUri(player_sprite, new Uri("ms-resource:///Files/Content/Player/woodcutting.gif"));
                    actTimer.Start();
                }
            }
            
        }

        private async void Mining(object sender, RoutedEventArgs e)
        {
            foreach (Animation anim in animations)
            {
                if (anim.Name == "mining")
                {
                    List<int[]> actions = new List<int[]>();
                    switch (currentLocation)
                    {
                        case "home":
                            actions = anim.getAnimation("homeToMining");
                            break;
                        case "woodcutting":
                            actions = anim.getAnimation("woodcuttingToMining");
                            break;
                        case "fishing":
                            actions = anim.getAnimation("fishingToMining");
                            break;
                        case "mining":
                            actions = anim.getAnimation("miningToMining");
                            break;
                        default:
                            break;

                    }
                    currentLocation = "mining";


                    foreach (int[] action in actions)
                    {
                        int timespan = MoveTo(action[0], action[1]);
                        await System.Threading.Tasks.Task.Delay(TimeSpan.FromSeconds(timespan));

                    }
                    _game.playSound("mining");
                    XamlAnimatedGif.AnimationBehavior.SetSourceUri(player_sprite, new Uri("ms-resource:///Files/Content/Player/mine.gif"));
                    actTimer.Start();
                }
            }

        }

        private async void Fishing(object sender, RoutedEventArgs e)
        {
            foreach (Animation anim in animations)
            {
                if (anim.Name == "fishing")
                {
                    List<int[]> actions = new List<int[]>();
                    switch (currentLocation)
                    {
                        case "home":
                            actions = anim.getAnimation("homeToFishing");
                            break;
                        case "woodcutting":
                            actions = anim.getAnimation("woodcuttingToFishing");
                            break;
                        case "fishing":
                            actions = anim.getAnimation("fishingToFishing");
                            break;
                        case "mining":
                            actions = anim.getAnimation("miningToFishing");
                            break;
                        default:
                            break;

                    }
                    currentLocation = "fishing";


                    foreach (int[] action in actions)
                    {
                        int timespan = MoveTo(action[0], action[1]);
                        await System.Threading.Tasks.Task.Delay(TimeSpan.FromSeconds(timespan));

                    }
                    _game.playSound("fishing");
                    XamlAnimatedGif.AnimationBehavior.SetSourceUri(player_sprite, new Uri("ms-resource:///Files/Content/Player/fishing.gif"));
                    actTimer.Start();
                }
            }

        }

        private async void Home(object sender, RoutedEventArgs e)
        {
            foreach (Animation anim in animations)
            {
                if (anim.Name == "home")
                {
                    List<int[]> actions = new List<int[]>();
                    switch (currentLocation)
                    {
                        case "home":
                            actions = anim.getAnimation("homeToHome");
                            break;
                        case "woodcutting":
                            actions = anim.getAnimation("woodcuttingToHome");
                            break;
                        case "fishing":
                            actions = anim.getAnimation("fishingToHome");
                            break;
                        case "mining":
                            actions = anim.getAnimation("miningToHome");
                            break;
                        default:
                            break;

                    }
                    currentLocation = "home";


                    foreach (int[] action in actions)
                    {
                        int timespan = MoveTo(action[0], action[1]);
                        await System.Threading.Tasks.Task.Delay(TimeSpan.FromSeconds(timespan));

                    }
                    
                }
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            newGame.Visibility = Visibility.Collapsed;
            gameOverlay.Visibility = Visibility.Collapsed;
            var Name = CharNameTB.Text;
            Save save = new Save(Name);
        }
    }
}
