﻿using System.Text;
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
        bool fan1Back, fan2Back, fan3Back, fan4Back, fan5Back;
        double temp = 0;
        DispatcherTimer fan1 = new DispatcherTimer();
        DispatcherTimer fan2 = new DispatcherTimer();
        DispatcherTimer fan3 = new DispatcherTimer();
        DispatcherTimer fan4 = new DispatcherTimer();
        DispatcherTimer fan5 = new DispatcherTimer();
        DispatcherTimer tempChange = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            tempChange.Tick += new EventHandler(tempChange_Tick);
            fan1.Tick += new EventHandler(Fan1_Tick);
            fan2.Tick += new EventHandler(Fan2_Tick);
            fan3.Tick += new EventHandler(Fan3_Tick);
            fan4.Tick += new EventHandler(Fan4_Tick);
            fan5.Tick += new EventHandler(Fan5_Tick);
            fan1.Interval = TimeSpan.FromMilliseconds(100);
            fan2.Interval = TimeSpan.FromMilliseconds(100);
            fan3.Interval = TimeSpan.FromMilliseconds(100);
            fan4.Interval = TimeSpan.FromMilliseconds(100);
            fan5.Interval = TimeSpan.FromMilliseconds(100);
            tempChange.Interval = TimeSpan.FromSeconds(1);
            tempChange.Start();
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

        private void Fans_Click(object sender, RoutedEventArgs e)
        {

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
            temp++;
            temp -= Fan1Prog.Value / 600;
            temp -= Fan2Prog.Value / 600;
            temp -= Fan3Prog.Value / 600;
            temp -= Fan4Prog.Value / 600;
            temp -= Fan5Prog.Value / 600;
            Temp.Text = Math.Round(temp).ToString();
        }
    }
}