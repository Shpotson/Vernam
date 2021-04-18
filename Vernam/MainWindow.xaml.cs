using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Vernam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool isMinimized = false;
        public MainWindow()
        {
                InitializeComponent();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation animation = new DoubleAnimation();
            animation.From = 1;
            animation.To = 0;
            animation.Duration = TimeSpan.FromMilliseconds(100);

            Storyboard board = new Storyboard();
            board.Children.Add(animation);

            Storyboard.SetTarget(animation, MainWindowID);
            Storyboard.SetTargetProperty(animation, new PropertyPath("(Opacity)"));

            board.Completed += delegate
            {
                this.Close();
            };

            board.Begin();
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            
            DoubleAnimation animation = new DoubleAnimation();
            animation.From = 1;
            animation.To = 0;
            animation.Duration = TimeSpan.FromMilliseconds(100);

            Storyboard board = new Storyboard();
            board.Children.Add(animation);

            Storyboard.SetTarget(animation, MainWindowID);
            Storyboard.SetTargetProperty(animation, new PropertyPath("(Opacity)"));

            board.Completed += delegate
            {
                this.WindowState = WindowState.Minimized;
                isMinimized = true;
            };

            board.Begin();
        }

        private void MainWindowID_StateChanged(object sender, EventArgs e)
        {
            if (isMinimized)
            {
                DoubleAnimation animation = new DoubleAnimation();
                animation.From = 0;
                animation.To = 1;
                animation.Duration = TimeSpan.FromMilliseconds(100);

                MainWindowID.BeginAnimation(OpacityProperty, animation);
                isMinimized = false;
            }
        }
    }
}
