using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace PBCC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool fan1Back, fan2Back, fan3Back, fan4Back, fan5Back,laser1s,laser2s,laser3s,laser4s,cores;
        double temp = 0;
        int state = 0;
        int reactorPower = 1;
        DispatcherTimer fan1 = new DispatcherTimer();
        DispatcherTimer fan2 = new DispatcherTimer();
        DispatcherTimer fan3 = new DispatcherTimer();
        DispatcherTimer fan4 = new DispatcherTimer();
        DispatcherTimer fan5 = new DispatcherTimer();
        DispatcherTimer tempChange = new DispatcherTimer();
        DispatcherTimer vis = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            tempChange.Tick += new EventHandler(tempChange_Tick);
            fan1.Tick += new EventHandler(Fan1_Tick);
            fan2.Tick += new EventHandler(Fan2_Tick);
            fan3.Tick += new EventHandler(Fan3_Tick);
            fan4.Tick += new EventHandler(Fan4_Tick);
            fan5.Tick += new EventHandler(Fan5_Tick);
            vis.Tick += new EventHandler(RPvis_Tick);
            fan1.Interval = TimeSpan.FromMilliseconds(100);
            fan2.Interval = TimeSpan.FromMilliseconds(100);
            fan3.Interval = TimeSpan.FromMilliseconds(100);
            fan4.Interval = TimeSpan.FromMilliseconds(100);
            fan5.Interval = TimeSpan.FromMilliseconds(100);
            vis.Interval = TimeSpan.FromMilliseconds(1000);
            tempChange.Interval = TimeSpan.FromSeconds(1);
            tempChange.Start();
            vis.Start();
        }
        async void HideAll()
        {
            fans.Visibility = Visibility.Collapsed;
            lasers.Visibility = Visibility.Collapsed;
            rp.Visibility = Visibility.Collapsed;
            RP.IsEnabled= false;
            Laser.IsEnabled= false;
            Fans.IsEnabled= false;
            Walk.Visibility = Visibility.Visible;
            for (walk.Value = 0; walk.Value != walk.Maximum; walk.Value++) await Task.Delay(100);
            Walk.Visibility = Visibility.Hidden;
            RP.IsEnabled = true;
            Laser.IsEnabled = true;
            Fans.IsEnabled = true;
        }
        void allDarkRed()
        {
            rp1.Background=Brushes.DarkRed;
            rp2.Background=Brushes.DarkRed;
            rp3.Background=Brushes.DarkRed;
            rp4.Background=Brushes.DarkRed;
        }
            
        private void Fan1_Click(object sender, RoutedEventArgs e)
        {
            if (Fan1Prog.Value == 0)
            {
                fan1Back=false;
                fan1.Start();
            }
            else if (Fan1Prog.Value == 600)
            {
                fan1Back=true;
                fan1.Start();
            }
        }
        private void Fan2_Click(object sender, RoutedEventArgs e)
        {
            if (Fan2Prog.Value == 0)
            {
                fan2Back = false;
                fan2.Start();
            }
            else if (Fan2Prog.Value == 600)
            {
                fan2Back = true;
                fan2.Start();
            }
        }
        private void Fan3_Click(object sender, RoutedEventArgs e)
        {
            if (Fan3Prog.Value == 0)
            {
                fan3Back = false;
                fan3.Start();
            }
            else if (Fan3Prog.Value == 600)
            {
                fan3Back = true;
                fan3.Start();
            }
        }
        private void Fan4_Click(object sender, RoutedEventArgs e)
        {
            if (Fan4Prog.Value == 0)
            {
                fan4Back = false;
                fan4.Start();
            }
            else if (Fan4Prog.Value == 600)
            {
                fan4Back = true;
                fan4.Start();
            }
        }
        private void Fan5_Click(object sender, RoutedEventArgs e)
        {
            if (Fan5Prog.Value == 0)
            {
                fan5Back = false;
                fan5.Start();
            }
            else if (Fan5Prog.Value == 600)
            {
                fan5Back = true;
                fan5.Start();
            }
        }
        private void Fan1_Tick(object sender, EventArgs e)
        {
            if(!fan1Back)
                Fan1Prog.Value++;
            else Fan1Prog.Value--;
            if (Fan1Prog.Value == 0)
            {
                Fan1.Background=Brushes.Red;
                fan1.Stop();
            }
            else if (Fan1Prog.Value == 600)
            {
                Fan1.Background = Brushes.Lime;
                fan1.Stop();
            }
            else { 
                Fan1.Background=Brushes.Yellow;
            }
        }

        async private void laser2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!laser2s)
            {
                laser2.IsEnabled = false;
                while (laser2.Opacity <= 1)
                {
                    laser2.Opacity += 0.01;
                    await Task.Delay(30);
                }
                laser2.IsEnabled = true;
                laser2s = true;
            }
            else
            {
                laser2.IsEnabled = false;
                while (laser2.Opacity >= 0.2)
                {

                    laser2.Opacity -= 0.01;
                    await Task.Delay(30);
                }
                laser2.IsEnabled = true;
                laser2s = false;
            }
        }

        async private void laser3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!laser3s)
            {
                laser3.IsEnabled = false;
                while (laser3.Opacity <= 1)
                {
                    laser3.Opacity += 0.01;
                    await Task.Delay(30);
                }
                laser3.IsEnabled = true;
                laser3s = true;
            }
            else
            {
                laser3.IsEnabled = false;
                while (laser3.Opacity >= 0.2)
                {

                    laser3.Opacity -= 0.01;
                    await Task.Delay(30);
                }
                laser3.IsEnabled = true;
                laser3s = false;
            }
        }

        async private void laser4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!laser4s)
            {
                laser4.IsEnabled = false;
                while (laser4.Opacity <= 1)
                {
                    laser4.Opacity += 0.01;
                    await Task.Delay(30);
                }
                laser4.IsEnabled = true;
                laser4s = true;
            }
            else
            {
                laser4.IsEnabled = false;
                while (laser4.Opacity >= 0.2)
                {

                    laser4.Opacity -= 0.01;
                    await Task.Delay(30);
                }
                laser4.IsEnabled = true;
                laser4s = false;
            }
        }

        async private void RP_Click(object sender, RoutedEventArgs e)
        {
            HideAll();
            await Task.Delay(10000);
            rp.Visibility = Visibility.Visible;
        }

        async private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!cores)
            {
                core.IsEnabled = false;
                while (core.Opacity <= 1)
                {
                    core.Opacity += 0.01;
                    await Task.Delay(60);
                }
                core.IsEnabled = true;
                cores = true;
            }
            else
            {
                core.IsEnabled = false;
                while (core.Opacity >= 0.5)
                {

                    core.Opacity -= 0.01;
                    await Task.Delay(60);
                }
                core.IsEnabled = true;
                cores = false;
            }
        }

        private void rp1_Click(object sender, RoutedEventArgs e)
        {
            vis.Interval =  TimeSpan.FromMilliseconds(1000);
            allDarkRed();
            rp1.Background=Brushes.Red;
            reactorPower = 1;
        }

        private void rp2_Click(object sender, RoutedEventArgs e)
        {
            vis.Interval = TimeSpan.FromMilliseconds(500);
            allDarkRed();
            rp2.Background = Brushes.Red;
            reactorPower = 2;
        }

        private void rp3_Click(object sender, RoutedEventArgs e)
        {
            vis.Interval = TimeSpan.FromMilliseconds(200);
            allDarkRed();
            rp3.Background = Brushes.Red;
            reactorPower = 3;
        }

        private void rp4_Click(object sender, RoutedEventArgs e)
        {
            vis.Interval = TimeSpan.FromMilliseconds(75);
            allDarkRed();
            rp4.Background = Brushes.Red;
            reactorPower = 4;
        }

        private void Fan2_Tick(object sender, EventArgs e)
        {
            if (!fan2Back)
                Fan2Prog.Value++;
            else Fan2Prog.Value--;
            if (Fan2Prog.Value == 0)
            {
                Fan2.Background = Brushes.Red;
                fan2.Stop();
            }
            else if (Fan2Prog.Value == 600)
            {
                Fan2.Background = Brushes.Lime;
                fan2.Stop();
            }
            else
            {
                Fan2.Background = Brushes.Yellow;
            }
        }

        async private void Fans_Click(object sender, RoutedEventArgs e)
        {
            HideAll();
            await Task.Delay(10000);
            fans.Visibility = Visibility.Visible;
        }

        async private void Laser_Click(object sender, RoutedEventArgs e)
        {
            HideAll();
            await Task.Delay(10000);
            lasers.Visibility = Visibility.Visible;
        }

        async private void laser1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!laser1s)
            {
                laser1.IsEnabled= false;
                while (laser1.Opacity <= 1)
                {
                    laser1.Opacity += 0.01;
                    await Task.Delay(30);
                }
                laser1.IsEnabled = true;
                laser1s =true;
            }
            else{
                laser1.IsEnabled = false;
                while (laser1.Opacity >= 0.2)
                {
                    
                    laser1.Opacity -= 0.01;
                    await Task.Delay(30);
                }
                laser1.IsEnabled = true;
                laser1s = false;
            }
        }

        private void Fan3_Tick(object sender, EventArgs e)
        {
            if (!fan3Back)
                Fan3Prog.Value++;
            else Fan3Prog.Value--;
            if (Fan3Prog.Value == 0)
            {
                Fan3.Background = Brushes.Red;
                fan3.Stop();
            }
            else if (Fan3Prog.Value == 600)
            {
                Fan3.Background = Brushes.Lime;
                fan3.Stop();
            }
            else
            {
                Fan3.Background = Brushes.Yellow;
            }
        }
        private void Fan4_Tick(object sender, EventArgs e)
        {
            if (!fan4Back)
                Fan4Prog.Value++;
            else Fan4Prog.Value--;
            if (Fan4Prog.Value == 0)
            {
                Fan4.Background = Brushes.Red;
                fan4.Stop();
            }
            else if (Fan4Prog.Value == 600)
            {
                Fan4.Background = Brushes.Lime;
                fan4.Stop();
            }
            else
            {
                Fan4.Background = Brushes.Yellow;
            }
        }
        private void Fan5_Tick(object sender, EventArgs e)
        {
            if (!fan5Back)
                Fan5Prog.Value++;
            else Fan5Prog.Value--;
            if (Fan5Prog.Value == 0)
            {
                Fan5.Background = Brushes.Red;
                fan5.Stop();
            }
            else if (Fan5Prog.Value == 600)
            {
                Fan5.Background = Brushes.Lime;
                fan5.Stop();
            }
            else
            {
                Fan5.Background = Brushes.Yellow;
            }
        }
        private void tempChange_Tick(object sender, EventArgs e)
        {
            temp+=1.5;
            temp -= (Fan1Prog.Value / 600)*1.5;
            temp -= (Fan2Prog.Value / 600)*1.5;
            temp -= (Fan3Prog.Value / 600)* 1.5;
            temp -= (Fan4Prog.Value / 600) * 1.5;
            temp -= (Fan5Prog.Value / 600) * 1.5;
            if (laser1s) temp += 1.25;
            if (laser2s) temp += 1.25;
            if (laser3s) temp += 1.25;
            if (laser4s) temp += 1.25;
            if (cores) temp += 1.25;
            if (reactorPower == 2) temp += 1;
            if (reactorPower == 3) temp += 3;
            if (reactorPower == 4) temp += 6;
            Temp.Text = Math.Round(temp).ToString();
        }
        private void RPvis_Tick(object sender, EventArgs e)
        {
            if (state == 0)
            {
                state0.Source = new BitmapImage(new Uri(@"pack://application:,,,/PBCC;component/Images/rpON.png"));
                state1.Source = new BitmapImage(new Uri(@"pack://application:,,,/PBCC;component/Images/rpOFF.png"));
                state2.Source = new BitmapImage(new Uri(@"pack://application:,,,/PBCC;component/Images/rpOFF.png"));
                state3.Source = new BitmapImage(new Uri(@"pack://application:,,,/PBCC;component/Images/rpOFF.png"));
                state = 1;
            }
            else if (state == 1)
            {
                state0.Source = new BitmapImage(new Uri(@"pack://application:,,,/PBCC;component/Images/rpOFF.png"));
                state1.Source = new BitmapImage(new Uri(@"pack://application:,,,/PBCC;component/Images/rpON.png"));
                state2.Source = new BitmapImage(new Uri(@"pack://application:,,,/PBCC;component/Images/rpOFF.png"));
                state3.Source = new BitmapImage(new Uri(@"pack://application:,,,/PBCC;component/Images/rpOFF.png"));
                state=2;
            }
            else if(state == 2)
            {
                state0.Source = new BitmapImage(new Uri(@"pack://application:,,,/PBCC;component/Images/rpOFF.png"));
                state1.Source = new BitmapImage(new Uri(@"pack://application:,,,/PBCC;component/Images/rpOFF.png"));
                state2.Source = new BitmapImage(new Uri(@"pack://application:,,,/PBCC;component/Images/rpON.png"));
                state3.Source = new BitmapImage(new Uri(@"pack://application:,,,/PBCC;component/Images/rpOFF.png"));
                state = 3;
            }
            else if (state == 3)
            {
                state0.Source = new BitmapImage(new Uri(@"pack://application:,,,/PBCC;component/Images/rpOFF.png"));
                state1.Source = new BitmapImage(new Uri(@"pack://application:,,,/PBCC;component/Images/rpOFF.png"));
                state2.Source = new BitmapImage(new Uri(@"pack://application:,,,/PBCC;component/Images/rpOFF.png"));
                state3.Source = new BitmapImage(new Uri(@"pack://application:,,,/PBCC;component/Images/rpON.png"));
                state = 0;
            }

        }
    }
}