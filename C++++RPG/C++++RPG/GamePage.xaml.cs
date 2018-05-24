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
using Windows.UI.Xaml.Navigation;




// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace C____RPG
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GamePage : Page
    {
		readonly Game1 _game;
       
        public GamePage()
        {
            this.InitializeComponent();

			// Create the game.
			var launchArguments = string.Empty;
            _game = MonoGame.Framework.XamlGame<Game1>.Create(launchArguments, Window.Current.CoreWindow, swapChainPanel);

          

        }

        private void Start_Button_Click(object sender, RoutedEventArgs e)
        {
          
    
        }

        private void movementEvent(Object state)
        {

            
          
        }

        private void Start_Animation(object sender, RoutedEventArgs e)
        {
            Blue_Circle_Animation.Duration = new Duration(new TimeSpan(5));
            Blue_Circle_Animation.From = new Point(200, 200);
            Blue_Circle_Animation.To = new Point(400, 400);
            myStoryboard.Begin();
            
            
        }
    }
}
