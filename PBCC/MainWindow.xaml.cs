using System.Diagnostics.CodeAnalysis;
using System.Media;
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
        BitmapImage RpON = new BitmapImage(new Uri(@"pack://application:,,,/PBCC;component/Images/rpON.png"));
        BitmapImage RpOFF = new BitmapImage(new Uri(@"pack://application:,,,/PBCC;component/Images/rpOFF.png"));
        Energy energy = new Energy();
        bool[] fanBack =new bool[5];
        bool[] laser = new bool[5];
        double temp = 0;
        int state = 0;
        int reactorPower = 1;
        string info;
        bool triggered = false;
        private bool highTempWarn = false;
        readonly SoundPlayer _player = new SoundPlayer();
        DispatcherTimer fan1 = new DispatcherTimer();
        DispatcherTimer fan2 = new DispatcherTimer();
        DispatcherTimer fan3 = new DispatcherTimer();
        DispatcherTimer fan4 = new DispatcherTimer();
        DispatcherTimer fan5 = new DispatcherTimer();
        DispatcherTimer tempChange = new DispatcherTimer();
        DispatcherTimer vis = new DispatcherTimer();
        DispatcherTimer productionUpdate = new DispatcherTimer();
        
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
            productionUpdate.Tick += new EventHandler(productionUpdate_Tick);
            fan1.Interval = TimeSpan.FromMilliseconds(100);
            fan2.Interval = TimeSpan.FromMilliseconds(100);
            fan3.Interval = TimeSpan.FromMilliseconds(100);
            fan4.Interval = TimeSpan.FromMilliseconds(100);
            fan5.Interval = TimeSpan.FromMilliseconds(100);
            vis.Interval = TimeSpan.FromMilliseconds(1000);
            tempChange.Interval = TimeSpan.FromSeconds(1);
            productionUpdate.Interval = TimeSpan.FromSeconds(5);
            tempChange.Start();
            vis.Start();

            
        }
        void playSound(string path)
        {
            _player.SoundLocation = path;
            _player.Load();
            _player.Play();
        }

        private void productionUpdate_Tick(object? sender, EventArgs e)
        {
            
        }

        async Task HideAll()
        {
            fans.Visibility = Visibility.Collapsed;
            lasers.Visibility = Visibility.Collapsed;
            rp.Visibility = Visibility.Collapsed;
            production.Visibility=Visibility.Collapsed;
            Coolant.Visibility = Visibility.Collapsed;
            RP.IsEnabled= false;
            Laser.IsEnabled= false;
            Fans.IsEnabled= false;
            coolant.IsEnabled = false;
            Production.IsEnabled = false;
            Walk.Visibility = Visibility.Visible;
            for (walk.Value = 0; walk.Value != walk.Maximum; walk.Value++) await Task.Delay(100);
            Walk.Visibility = Visibility.Hidden;
            RP.IsEnabled = true;
            Laser.IsEnabled = true;
            Fans.IsEnabled = true;
            coolant.IsEnabled = true;
            Production.IsEnabled = true;
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
                fanBack[0]=false;
                fan1.Start();
            }
            else if (Fan1Prog.Value == 600)
            {
                fanBack[0]=true;
                fan1.Start();
            }
        }
        private void Fan2_Click(object sender, RoutedEventArgs e)
        {
            if (Fan2Prog.Value == 0)
            {
                fanBack[1] = false;
                fan2.Start();
            }
            else if (Fan2Prog.Value == 600)
            {
                fanBack[1] = true;
                fan2.Start();
            }
        }
        private void Fan3_Click(object sender, RoutedEventArgs e)
        {
            if (Fan3Prog.Value == 0)
            {
                fanBack[2] = false;
                fan3.Start();
            }
            else if (Fan3Prog.Value == 600)
            {
                fanBack[2] = true;
                fan3.Start();
            }
        }
        private void Fan4_Click(object sender, RoutedEventArgs e)
        {
            if (Fan4Prog.Value == 0)
            {
                fanBack[3] = false;
                fan4.Start();
            }
            else if (Fan4Prog.Value == 600)
            {
                fanBack[3] = true;
                fan4.Start();
            }
        }
        private void Fan5_Click(object sender, RoutedEventArgs e)
        {
            if (Fan5Prog.Value == 0)
            {
                fanBack[4] = false;
                fan5.Start();
            }
            else if (Fan5Prog.Value == 600)
            {
                fanBack[4] = true;
                fan5.Start();
            }
        }
        private void Fan1_Tick(object sender, EventArgs e)
        {
            if (!fanBack[0])
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
            if (!laser[1])
            {
                laser2.IsEnabled = false;
                while (laser2.Opacity <= 1)
                {
                    laser2.Opacity += 0.01;
                    await Task.Delay(30);
                }
                laser2.IsEnabled = true;
                laser[1] = true;
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
                laser[1] = false;
            }
        }

        async private void laser3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!laser[2])
            {
                laser3.IsEnabled = false;
                while (laser3.Opacity <= 1)
                {
                    laser3.Opacity += 0.01;
                    await Task.Delay(30);
                }
                laser3.IsEnabled = true;
                laser[2] = true;
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
                laser[2] = false;
            }
        }

        async private void laser4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!laser[3])
            {
                laser4.IsEnabled = false;
                while (laser4.Opacity <= 1)
                {
                    laser4.Opacity += 0.01;
                    await Task.Delay(30);
                }
                laser4.IsEnabled = true;
                laser[3] = true;
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
                laser[3] = false;
            }
        }

        async private void RP_Click(object sender, RoutedEventArgs e)
        {
            await HideAll();
            rp.Visibility = Visibility.Visible;
        }

        async private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!laser[4])
            {
                core.IsEnabled = false;
                while (core.Opacity <= 1)
                {
                    core.Opacity += 0.01;
                    await Task.Delay(60);
                }
                core.IsEnabled = true;
                laser[4] = true;
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
                laser[4] = false;
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
            if (!fanBack[1])
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
            await HideAll();
            fans.Visibility = Visibility.Visible;
        }

        async private void Laser_Click(object sender, RoutedEventArgs e)
        {
            await HideAll();
            lasers.Visibility = Visibility.Visible;
        }

        async private void laser1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!laser[0])
            {
                laser1.IsEnabled= false;
                while (laser1.Opacity <= 1)
                {
                    laser1.Opacity += 0.01;
                    await Task.Delay(30);
                }
                laser1.IsEnabled = true;
                laser[0] =true;
            }
            else{
                laser1.IsEnabled = false;
                while (laser1.Opacity >= 0.2)
                {
                    
                    laser1.Opacity -= 0.01;
                    await Task.Delay(30);
                }
                laser1.IsEnabled = true;
                laser[0] = false;
            }
        }

        private void Fan3_Tick(object sender, EventArgs e)
        {
            if (!fanBack[2])
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

        async private void Coolant_Click(object sender, RoutedEventArgs e)
        {
            await HideAll();
            Coolant.Visibility = Visibility.Visible;
        }

        async private void CoolantSwitch_Click(object sender, RoutedEventArgs e)
        {
            if (CoolantSwitch.Background == Brushes.Red)
            {
                CoolantSwitch.Background = Brushes.Yellow;
                await Task.Delay(5000);
                CoolantSwitch.Background = Brushes.Lime;
            }
            else if (CoolantSwitch.Background == Brushes.Lime) {
                CoolantSwitch.Background = Brushes.Yellow;
                await Task.Delay(5000);
                CoolantSwitch.Background = Brushes.Red;
            }
        }

        private void Fan4_Tick(object sender, EventArgs e)
        {
            if (!fanBack[3])
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
            if (!fanBack[4])
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
        async private void tempChange_Tick(object sender, EventArgs e)
        {
            temp+=1.5;
            temp -= (Fan1Prog.Value / 600)*1.5;
            temp -= (Fan2Prog.Value / 600)*1.5;
            temp -= (Fan3Prog.Value / 600)* 1.5;
            temp -= (Fan4Prog.Value / 600) * 1.5;
            temp -= (Fan5Prog.Value / 600) * 1.5;
            if (laser[0]) temp += 1.25;
            if (laser[1]) temp += 1.25;
            if (laser[2]) temp += 1.25;
            if (laser[3]) temp += 1.25;
            if (laser[4]) temp += 1.25;
            if (reactorPower == 2) temp += 1;
            if (reactorPower == 3) temp += 3;
            if (reactorPower == 4) temp += 6;
            Temp.Text = Math.Round(temp).ToString();
            energy.update(laser, new int[] { (int)Fan1Prog.Value, (int)Fan2Prog.Value, (int)Fan3Prog.Value, (int)Fan4Prog.Value, (int)Fan5Prog.Value }, CoolantSwitch.Background == Brushes.Lime, reactorPower,Convert.ToInt32(temp));
            info=energy.powerInfo();
            output.Text = info;
            if (temp > 3000 && !highTempWarn)
            {
                playSound("Sounds/HighTemp.wav");
                highTempWarn = true;
            }
            else if(temp < 3000 && highTempWarn)
            {
                highTempWarn = false;
            }

            if (temp > 4000 && !triggered)
            {
                triggered = true;
                playSound("Sounds/MeltdownStart.wav");
                await Task.Delay(10000);
                playSound("Sounds/ECaval.wav");
                
            }
            else if (temp < -4000 && !triggered)
            {
                MessageBox.Show("Freezedown triggered");
                triggered = true;
            }
        }
        private void RPvis_Tick(object sender, EventArgs e)
        {
            if (state == 0)
            {
                state0.Source = RpON;
                state1.Source = RpOFF;
                state2.Source = RpOFF;
                state3.Source = RpOFF;
                state = 1;
            }
            else if (state == 1)
            {
                state0.Source = RpOFF;
                state1.Source = RpON;
                state2.Source = RpOFF;
                state3.Source = RpOFF;
                state=2;
            }
            else if(state == 2)
            {
                state0.Source = RpOFF;
                state1.Source = RpOFF;
                state2.Source = RpON;
                state3.Source = RpOFF;
                state = 3;
            }
            else if (state == 3)
            {
                state0.Source = RpOFF;
                state1.Source = RpOFF;
                state2.Source = RpOFF;
                state3.Source = RpON;
                state = 0;
            }

        }

        async private void Production_OnClick(object sender, RoutedEventArgs e)
        {
            await HideAll();
            production.Visibility = Visibility.Visible;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            playSound("Sounds/MeltdownStart.wav");
        }
    }
}