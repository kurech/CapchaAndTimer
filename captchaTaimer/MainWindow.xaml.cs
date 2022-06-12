using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

namespace captchaTaimer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int resultCaptcha = 0;

        public int firstNum = 0;
        public int secondNum = 0;

        public string res = "";

        DateTime date;
        public MainWindow()
        {
            InitializeComponent();
            UpdateCapcha();
        }

        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {
            CheckCapcha();
        }

        public void CheckCapcha()
        {
            resultCaptcha = firstNum + secondNum;
            if (int.Parse(txtResult.Text) == resultCaptcha)
            {
                MessageBox.Show("Верно!");
                UpdateCapcha();
            }
            else
            {
                MessageBox.Show("Неверно!");
                UpdateCapcha();
            }
        }

        public void UpdateCapcha()
        {
            txtCapcha.Clear();
            txtResult.Clear();
            Random rnd = new Random();
            firstNum = rnd.Next(1, 9);
            secondNum = rnd.Next(1, 9);
            txtCapcha.Text += firstNum.ToString() + "+" + secondNum.ToString() + "=";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            date = DateTime.Now;
            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromMilliseconds(1);
            dt.Tick += Dt_Tick;
            dt.Start();
        }

        public DateTime stop = new DateTime();
        private void Dt_Tick(object sender, EventArgs e)
        {
            long tick = DateTime.Now.Ticks - date.Ticks;
            DateTime stopWatch = new DateTime();

            stopWatch = stopWatch.AddTicks(tick);
            lblTimer.Content = String.Format("{0:HH:mm:ss:ff}", stopWatch);
            stop = stopWatch;
        }
        
        private void Window_Closed(object sender, EventArgs e)
        {
            MessageBox.Show("Время работы программы: " + String.Format("{0:HH:mm:ss:ff}", stop));
        }
    }
}
