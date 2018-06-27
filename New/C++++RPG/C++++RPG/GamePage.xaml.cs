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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI;
using Windows.UI.ViewManagement;





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
        DispatcherTimer timePlayedTimer;
        Source currentSource;
        bool audiotoggle;
        int mission_progress;
        int mission_toGo;


        public GamePage()
        {
            this.InitializeComponent();
            myGamePage.Width = Window.Current.Bounds.Width;
            myGamePage.Height = Window.Current.Bounds.Height;

            var iets = XamlAnimatedGif.AnimationBehavior.GetSourceUri(player_sprite);

            audiotoggle = false;

            Debug.WriteLine(iets);
            // Create the game.
            var launchArguments = string.Empty;
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(100, 100));
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
            woodcutting.Add_Movement("homeToWoodcutting", "0, 1", "-5,0", "0,-6", "-4,0", "0,-3", "-5,0", "0,-1", "-1,0", "0,-1", "-8,0", "0,-4");
            woodcutting.Add_Movement("woodcuttingToWoodcutting", "0,0");
            woodcutting.Add_Movement("miningToWoodcutting", "0,3", "-1,0", "0,1", "-3,0", "0,2", "-4,0", "0,-3", "-5,0", "0,-1", "-1,0", "0,-1", "-8,0", "0,-4");

            Animation mining = new Animation("mining", "test", "-5,0", "0, -10", "0,0");
            mining.Add_Movement("fishingToMining", "0,-8", "4,0", "0,1", "1,0", "0,1", "5,0", "0,3", "4,0", "0,-2", "3,0", "0,-1", "1,0", "0,-3");
            mining.Add_Movement("homeToMining", "0, 1", "-5,0", "0,-8", "3,0", "0,-1", "1,0", "0,-3");
            mining.Add_Movement("woodcuttingToMining", "0,4", "8,0", "0,1", "1,0", "0,1", "5,0", "0,3", "4,0", "0,-2", "3,0", "0,-1", "1,0", "0,-3");
            mining.Add_Movement("miningToMining", "0,0");

            Animation fishing = new Animation("fishing", "test", "-5,0", "0,5", "-10,0");
            fishing.Add_Movement("fishingToFishing", "0,0");
            fishing.Add_Movement("homeToFishing", "0, 1", "-5,0", "0,-6", "-4,0", "0,-3", "-5,0", "0,-1", "-1,0", "0,-1", "-4,0", "0,8");
            fishing.Add_Movement("woodcuttingToFishing", "0,4", "4,0", "0,8");
            fishing.Add_Movement("miningToFishing", "0,3", "-1,0", "0,1", "-3,0", "0,2", "-4,0", "0,-3", "-5,0", "0,-1", "-1,0", "0,-1", "-4,0", "0,8");

            Animation home = new Animation("home", "test", "-5,0", "0,5", "-10,0");
            home.Add_Movement("fishingToHome", "0,-8", "4,0", "0,1", "1,0", "0,1", "5,0", "0,3", "4,0", "0,6", "5,0", "0,-1");
            home.Add_Movement("homeToHome", "0, 0");
            home.Add_Movement("woodcuttingToHome", "0,4", "8,0", "0,1", "1,0", "0,1", "5,0", "0,3", "4,0", "0,6", "5,0", "0,-1");
            home.Add_Movement("miningToHome", "0,3", "-1,0", "0,1", "-3,0", "0,8", "5,0", "0,-1");

            animations.Add(woodcutting);
            animations.Add(mining);
            animations.Add(fishing);
            animations.Add(home);

            actTimer = new DispatcherTimer();
            actTimer.Interval = new TimeSpan(0, 0, 1);
            actTimer.Tick += XpEvent;
            actTimer.Stop();

            timePlayedTimer = new DispatcherTimer();
            timePlayedTimer.Interval = new TimeSpan(0, 0, 1);
            timePlayedTimer.Tick += secondeTick;

            var story = _game.GetPlayer().getStory();
            mission_progress = 0;
            mission_toGo = mission_progress + story.GetCurrentMission().toGo;



            SellWood.Click += new RoutedEventHandler((send, even) => SellResource(send, even,SellWood,_game.getSource("woodcutting").resource));
            SellFish.Click += new RoutedEventHandler((send, even) => SellResource(send, even, SellFish, _game.getSource("fishing").resource));
            SellOre.Click += new RoutedEventHandler((send, even) => SellResource(send, even, SellOre, _game.getSource("mining").resource));


            //testing
            _game.GetPlayer().GetInventory().AddItems(_game.getSource("woodcutting").resource, 100000);
            _game.GetPlayer().GetInventory().AddItems(_game.getSource("mining").resource, 100000);
            _game.GetPlayer().GetInventory().AddItems(_game.getSource("fishing").resource, 100000);


        }


        private void SellResource(object sender, RoutedEventArgs e, Button SellButton, Item item)
        {
            Dictionary<String, dynamic> PlayerResources = _game.GetPlayer().GetInventory().GetResourceAmount();
            int selectedAmount = 0;
            int totalFunds = 0;
            _game.playSoundOnce("gold");
            if (item.name == "wood")
            {

                if (SellWood100.IsChecked == true)
                {
                    selectedAmount = 100;
                }
                else if (SellWood1000.IsChecked == true)
                {
                    selectedAmount = 1000;
                }
                else if (SellWood10000.IsChecked == true)
                {
                    selectedAmount = 10000;
                }
                totalFunds = selectedAmount * item.value;


                if (PlayerResources.ContainsKey("wood"))
                {
                    if (PlayerResources["wood"] > selectedAmount)
                    {
                        _game.GetPlayer().GetInventory().DiscardItem(item, selectedAmount);
                        _game.GetPlayer().ChangeCoins(totalFunds,true);
                        UpdateMenu();
                    }
                }
            }
            else if (item.name == "fish")
            {
                if (SellFish100.IsChecked == true)
                {
                    selectedAmount = 100;
                }
                else if (SellFish1000.IsChecked == true)
                {
                    selectedAmount = 1000;
                }
                else if (SellFish10000.IsChecked == true)
                {
                    selectedAmount = 10000;
                }
                totalFunds = selectedAmount * item.value;


                if (PlayerResources.ContainsKey("fish"))
                {
                    if (PlayerResources["fish"] > selectedAmount)
                    {
                        _game.GetPlayer().GetInventory().DiscardItem(item, selectedAmount);
                        _game.GetPlayer().ChangeCoins(totalFunds, true);
                        UpdateMenu();
                    }
                }
            }
            else if (item.name == "ore")
            {
                if (SellOre100.IsChecked == true)
                {
                    selectedAmount = 100;
                }
                else if (SellOre1000.IsChecked == true)
                {
                    selectedAmount = 1000;
                }
                else if (SellOre10000.IsChecked == true)
                {
                    selectedAmount = 10000;
                }
                totalFunds = selectedAmount * item.value;


                if (PlayerResources.ContainsKey("ore"))
                {
                    if (PlayerResources["ore"] > selectedAmount)
                    {
                        _game.GetPlayer().GetInventory().DiscardItem(item, selectedAmount);
                        _game.GetPlayer().ChangeCoins(totalFunds, true);
                        UpdateMenu();
                    }
                }
            }




        }

        private void secondeTick(object sender, object e)
        {
            var stats = _game.GetPlayer().GetStats();
            timeplayed.Text = "Time played: " + stats["totalplaytime"] + " sec";
            if(currentLocation == "home")
            {
                home_option.Visibility = Visibility.Visible;
            }
            else
            {
                home_option.Visibility = Visibility.Collapsed;
            }
            inventory_money.Text = "" +  _game.GetPlayer().coins;
            if (_game.GetPlayer().coins < (_game.GetPlayer().home.tier * 1000))
            {
                upgrade_button.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
                upgrade_button.Text = _game.GetPlayer().home.tier * 1000 + " Gold";
            }
            else if (_game.GetPlayer().home.tier >= 5)
            {
                upgrade_button.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 255));
                upgrade_button.Text = "No upgrades";
            }
            else
            {
                upgrade_button.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 255, 0));
                upgrade_button.Text = _game.GetPlayer().home.tier * 1000 + " Gold";
            }
       

            var story = _game.GetPlayer().getStory();

            if (story.GetCurrentMission() != null)
            {
                missionName.Text = story.GetCurrentMission().name;
                missionDes.Text = story.GetCurrentMission().description;
                missionReward.Text = "" + story.GetCurrentMission().reward + " Gold";

                Debug.WriteLine(mission_toGo);
                Debug.WriteLine(mission_progress);
                mission_progress = _game.GetPlayer().GetInventory().GetResourceAmount()[story.GetCurrentMission().skill];

                if (mission_progress > mission_toGo)
                {
                    _game.playSoundOnce("gold");
                    _game.playSoundOnce("quest");
                    _game.GetPlayer().ChangeCoins(100, true);
                    mission_progress = _game.GetPlayer().GetInventory().GetResourceAmount()[story.GetCurrentMission().skill];
                    mission_toGo = mission_progress + story.GetCurrentMission().toGo;
                    story.NextMainMission(story.GetCurrentMission());
                    Debug.WriteLine("WORKEEDEDDE");

                    if (story.GetCurrentMission() == null)
                    {
                        missionName.Text = "Out of missions.";
                        missionDes.Text = "program more missions to do missions";
                        missionReward.Text = "None";

                    }
                }
            }

            var inventory = _game.GetPlayer().GetInventory().GetResourceAmount();

            if (inventory.ContainsKey("ore"))
            {
                inventory_ore.Text = "" + inventory["ore"];
            }

            if (inventory.ContainsKey("wood"))
            {
                inventory_wood.Text = "" + inventory["wood"];
            }

            if (inventory.ContainsKey("fish"))
            {
                inventory_fish.Text = "" + inventory["fish"];
            }



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

            var source = currentSource;
            if (source != null)
            {
                _game.GetPlayer().ChangeSkill(currentLocation);
                xp_gain_textblock.Text = _game.GetPlayer().Act(source.Experience, source.resource).ToString() + "xp";
                

            }

            Dictionary<string, dynamic> stats = _game.GetPlayer().GetStats();
            woodcuttinglevel.Text = "lvl: " + stats["woodcuttinglvl"].ToString();
            woodcuttingxp.Text = "xp: " + stats["woodcuttingxp"].ToString();

            mininglevel.Text = "lvl: " + stats["mininglvl"].ToString();
            miningxp.Text = "xp: " + stats["miningxp"].ToString();

            fishinglevel.Text = "lvl: " + stats["fishinglvl"].ToString();
            fishingxp.Text = "xp: " + stats["fishingxp"].ToString();

            goldearned.Text = "Total earned: " + stats["totalearned"] + " gold";
           
            totalxp.Text = "Total xp: " + (stats["woodcuttingxp"] + stats["fishingxp"] + stats["miningxp"]);
            mostplayed.Text = "Most played: " + stats["mostplayedskill"];

            
            

            


        }

        public int MoveTo(int vx, int vy)
        {
            _game.StopAllAudio();
            actTimer.Stop();
            

            if (vx < 0)
            {

                //change to left gif
                XamlAnimatedGif.AnimationBehavior.SetSourceUri(player_sprite, new Uri("ms-resource:///Files/Content/Player/left.gif"));
            }
            if (vx > 0)
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



            _game.GetPlayer().getLocation().x = (int)x.Value;
            _game.GetPlayer().getLocation().y = (int)y.Value;

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
                    switch (currentLocation)
                    {
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
                    currentSource = _game.getSource(currentLocation);

                    woodcutting.Visibility = Visibility.Collapsed;
                    mining.Visibility = Visibility.Collapsed;
                    fishing.Visibility = Visibility.Collapsed;
       
                    foreach (int[] action in actions)
                    {
                        int timespan = MoveTo(action[0], action[1]);
                        await System.Threading.Tasks.Task.Delay(TimeSpan.FromSeconds(timespan));

                    }
                    fishing.Visibility = Visibility.Visible;
                    mining.Visibility = Visibility.Visible;
                    woodcutting.Visibility = Visibility.Visible;
                 

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
                    currentSource = _game.getSource(currentLocation);

                    woodcutting.Visibility = Visibility.Collapsed;
                    mining.Visibility = Visibility.Collapsed;
                    fishing.Visibility = Visibility.Collapsed;
                  

                    foreach (int[] action in actions)
                    {
                        int timespan = MoveTo(action[0], action[1]);
                        await System.Threading.Tasks.Task.Delay(TimeSpan.FromSeconds(timespan));

                    }
                    fishing.Visibility = Visibility.Visible;
                    mining.Visibility = Visibility.Visible;
                    woodcutting.Visibility = Visibility.Visible;
                    

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
                    currentSource = _game.getSource(currentLocation);

                    woodcutting.Visibility = Visibility.Collapsed;
                    mining.Visibility = Visibility.Collapsed;
                    fishing.Visibility = Visibility.Collapsed;
               

                    foreach (int[] action in actions)
                    {
                        int timespan = MoveTo(action[0], action[1]);
                        await System.Threading.Tasks.Task.Delay(TimeSpan.FromSeconds(timespan));

                    }
                    fishing.Visibility = Visibility.Visible;
                    mining.Visibility = Visibility.Visible;
                    woodcutting.Visibility = Visibility.Visible;
                    
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
                    currentSource = null;


                    foreach (int[] action in actions)
                    {
                        int timespan = MoveTo(action[0], action[1]);
                        await System.Threading.Tasks.Task.Delay(TimeSpan.FromSeconds(timespan));

                    }

                }
            }

        }


        private void MuteChange(object sender, TappedRoutedEventArgs e)
        {
            if (audiotoggle)
            {
                _game.ToggleMediaplayer(audiotoggle);
                sound.Source = new BitmapImage(new Uri("ms-appx:///Content/misc/high-volume.png"));
                audiotoggle = false;
            }
            else
            {
                _game.ToggleMediaplayer(audiotoggle);
                sound.Source = new BitmapImage(new Uri("ms-appx:///Content/misc/no-audio.png"));
                audiotoggle = true;
            }

        }

        private void GeneralKeyDown(object sender, KeyRoutedEventArgs e)
        {
            
            if (e.Key.ToString() == "Escape")
            {
                if (setting.Visibility == Visibility.Visible)
                {
                    overlay.Visibility = Visibility.Collapsed;
                    setting.Visibility = Visibility.Collapsed;
                    _game.playSoundOnce("menu");
                  
                }
                else
                {
                    overlay.Visibility = Visibility.Visible;
                    setting.Visibility = Visibility.Visible;
                    _game.playSoundOnce("menu");
                }
                
            }

            if (e.Key.ToString() == "I")
            {
                if (inventory.Visibility == Visibility.Visible)
                {
                    overlay.Visibility = Visibility.Collapsed;
                    inventory.Visibility = Visibility.Collapsed;
                    _game.playSoundOnce("menu");
                }
                else
                {
                    overlay.Visibility = Visibility.Visible;
                    inventory.Visibility = Visibility.Visible;
                    _game.playSoundOnce("menu");
                }

            }

        }

        private void QuitGame(object sender, RoutedEventArgs e)
        {
            _game.QuitGame();
        }

        private void SaveGame(object sender, RoutedEventArgs e)
        {
            //save game
        }

        private void Menu_Close(object sender, RoutedEventArgs e)
        {

            try
            {
                gameMenu.Visibility = Visibility.Collapsed;
                overlay.Visibility = Visibility.Collapsed;
                _game.playSoundOnce("menu");
                items.Children.Clear();

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
            }

        }

        private void Start_Animation(Object sender, RoutedEventArgs e)
        {
            try
            {
              //Menu actions
                gameMenu.Visibility = Visibility.Visible;
                overlay.Visibility = Visibility.Visible;
                _game.playSoundOnce("menu");

                Dictionary<String, dynamic> PlayerResources = _game.GetPlayer().GetInventory().GetResourceAmount();
                List<Item> ShopTools = _game.shop.GetItems();
                UpdateMenu();
                 


                foreach (Tool item in ShopTools)
                {
                    Debug.WriteLine(item.name);
                    bool obtained = PlayerResources.ContainsKey(item.name);

                    //Generate the tools 

                    Border relPanBor = new Border
                    {
                        BorderBrush = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0)),
                        Background = new SolidColorBrush(Color.FromArgb(255, 242, 241, 239)),
                        Height = 42
                    };

                    RelativePanel relPan = new RelativePanel
                    {
                        BorderBrush = new SolidColorBrush(Color.FromArgb(255, 52, 73, 94)),
                        BorderThickness = new Thickness(1),
                        VerticalAlignment = VerticalAlignment.Bottom,
                        Height = 42,
                        Width = 191
                    };

                    Border butBor = new Border
                    {
                        Background = new SolidColorBrush(Color.FromArgb(255, 195,195,195)),
                        Margin = new Thickness(135, 11, -133, -7),
                        Height = 20,
                        VerticalAlignment = VerticalAlignment.Top
                    };

                    Button but = new Button
                    {
                        HorizontalAlignment = HorizontalAlignment.Left,
                        Height = 20,
                        VerticalAlignment = VerticalAlignment.Top,
                        Width = 40,
                        Foreground = new SolidColorBrush(Color.FromArgb(255, 0,0,0)),
                        FontSize = 12,
                        Padding = new Thickness(0, 0, 0, 0)
                    };

                    if (obtained)
                    {
                        but.Content = "Got it";
                        
                        but.IsEnabled = false;
                        but.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));

                    }
                    else if (_game.GetPlayer().coins < item.value)
                    {

                        but.Content = item.value.ToString();
                        but.IsEnabled = false;
                    }
                    else
                    {
                        but.Content = item.value.ToString();
                        but.Click += new RoutedEventHandler((sendMen, ev) => Click_buyResc(sendMen, ev, item, but));
                    }


                    TextBlock text = new TextBlock
                    {
                        HorizontalAlignment = HorizontalAlignment.Left,
                        Height = 21,
                        TextWrapping = TextWrapping.Wrap,
                        Text = item.name,
                        VerticalAlignment = VerticalAlignment.Top,
                        Width = 86,
                        Margin = new Thickness(44, 11, -68, -12),
                        Foreground = new SolidColorBrush(Color.FromArgb(255, 0,0,0)),
                        FontSize = 13,
                        Padding = new Thickness(0, 0, 0, 0)
                    };

                    Image img = new Image
                    {
                        Height = 26,
                        Width = 37,

                        Source = new BitmapImage(new Uri(@"ms-appx:content\resources\" + item.name + ".png", UriKind.RelativeOrAbsolute)),
                        Margin = new Thickness(2, 9, -2, -9)
                    };


                    //Add all the elements together 
                    relPanBor.Child = relPan;
                    relPan.Children.Add(butBor);
                    text.FontSize = 12;
                    relPan.Children.Add(text);
                    relPan.Children.Add(img);
                    butBor.Child = but;


                    items.Children.Add(relPanBor);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
            }



        }

        void Click_buyResc(object sender, RoutedEventArgs e, Tool tool, Button buttonWithContent)
        {
            try
            {
          
                    _game.GetPlayer().ChangeCoins(tool.value, false);
                
                
                buttonWithContent.Content = "Got it";
                buttonWithContent.IsEnabled = false;

                //Add to inventory
                //Source = new BitmapImage(new Uri(@"ms-appx:content\resources\" + item.name + ".png", UriKind.RelativeOrAbsolute)),
                switch (tool.skill)
                {
                    case "woodcutting":
                        tool_axe.Source = new BitmapImage(new Uri(@"ms-appx:content\resources\" + tool.name + ".png", UriKind.RelativeOrAbsolute));
                        break;
                    case "mining":
                        tool_pick.Source = new BitmapImage(new Uri(@"ms-appx:content\resources\" + tool.name + ".png", UriKind.RelativeOrAbsolute));
                        break;
                    case "fishing":
                        tool_rod.Source = new BitmapImage(new Uri(@"ms-appx:content\resources\" + tool.name + ".png", UriKind.RelativeOrAbsolute));
                        break;
                }
                _game.GetPlayer().GetInventory().AddItem(tool);

                UpdateMenu();

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
            }


        }

        private void UpdateMenu()
        {
            goldView.Text = "Gold      " + _game.GetPlayer().coins;

            Dictionary<String, dynamic> PlayerResources = _game.GetPlayer().GetInventory().GetResourceAmount();

            int oreAmount = 0;
            int woodAmount = 0;
            int fishAmount = 0;

            if (PlayerResources.ContainsKey("ore"))
            {
                oreAmount = PlayerResources["ore"];
            }

            if (PlayerResources.ContainsKey("wood"))
            {
                woodAmount = PlayerResources["wood"];
            }

            if (PlayerResources.ContainsKey("fish"))
            {
                fishAmount = PlayerResources["fish"];
            }

           

            goldView.Text = "Gold      " + _game.GetPlayer().coins;
            woodView.Text = woodAmount.ToString();
            fishView.Text = fishAmount.ToString();
            oreView.Text = oreAmount.ToString();
        }

        private void Start_game(object sender, RoutedEventArgs e)
        {
            home_option.Visibility = Visibility.Visible;
            Misson_panel.Visibility = Visibility.Visible;
            stats.Visibility = Visibility.Visible;
            newGame.Visibility = Visibility.Collapsed;
            gameOverlay.Visibility = Visibility.Collapsed;
            var Name = CharNameTB.Text;
            woodcutting.Visibility = Visibility.Visible;
            home_button.Visibility = Visibility.Visible;
            mining.Visibility = Visibility.Visible;
            fishing.Visibility = Visibility.Visible;
            player_sprite.Visibility = Visibility.Visible;
            timePlayedTimer.Start();

        }

        private void Upgrade_home(object sender, RoutedEventArgs e)
        {
            WaitButton(upgradeB, new TimeSpan(0, 0, 3));
            var gold = 0;    
            gold = _game.GetPlayer().home.tier * 1000;

            if (_game.GetPlayer().coins > gold && _game.GetPlayer().home.tier < 5)
            {
                _game.GetPlayer().home.Upgrade();
                _game.playSoundOnce("upgrade");


                _game.GenerateHouse();


                
                _game.GetPlayer().ChangeCoins(gold, false);
            }
            else
            {

            }
           

            
        }

        public async void WaitButton(Button button, TimeSpan time)
        {
            button.IsEnabled = false;
            await System.Threading.Tasks.Task.Delay(time);
            button.IsEnabled = true;
        }

        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
     
                if ((this.Width != 1080) & (this.Height != 720))
                {
                    this.Width = 1080;
                    this.Height = 720;
                Debug.WriteLine(Window.Current.Bounds);
                }
            
        }
    }
}
