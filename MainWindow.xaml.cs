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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    

    public partial class MainWindow : Window
    {
        public static Button[,] board = new Button[10, 10];

        public MainWindow()
        {
            InitializeComponent();

            Schachbrett();
        }

        void einsClicked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hallo Test1234");
        }

        private void zwei_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Thunfisch");
        }

        private void drei_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void cell_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(sender.GetType().ToString());
            Wave(Grid.GetRow((Button)sender), Grid.GetColumn((Button)sender));
            MessageBox.Show(string.Format("Feld {0}{1} geklickt.", Convert.ToChar(64+Grid.GetColumn((Button)sender)), 9-Grid.GetRow((Button)sender)));
        }

        private async void Wave(int x, int y)
        {
            //while (true)
            //{
            for (int i = 1; i < 8; i++)
            {
                int rows = 9;
                int cols = 9;
                Brush[] def = new Brush[8];
                def[0] = board[Math.Min(x + i, rows), Math.Min(y + i, cols)].Background;
                def[1] = board[Math.Max(0,x - i), Math.Max(0, y - i)].Background;
                def[2] = board[Math.Min(x + i, rows), Math.Max(0, y - i)].Background;
                def[3] = board[Math.Max(0, x - i), Math.Min(y + i, cols)].Background;
                def[4] = board[x, Math.Min(y + i, cols)].Background;
                def[5] = board[x, Math.Max(0, y - i)].Background;
                def[6] = board[Math.Max(0, x - i), y].Background;
                def[7] = board[Math.Min(x + i, rows), y].Background;

                board[Math.Min(x + i, rows), Math.Min(y + i, cols)].Background = Brushes.Purple;
                board[Math.Max(0, x - i), Math.Max(0, y - i)].Background = Brushes.Purple;
                board[Math.Min(x + i, rows), Math.Max(0, y - i)].Background = Brushes.Purple;
                board[Math.Max(0, x - i), Math.Min(y + i, cols)].Background = Brushes.Purple;
                board[x, Math.Min(y + i, cols)].Background = Brushes.Purple;
                board[x, Math.Max(0, y - i)].Background = Brushes.Purple;
                board[Math.Max(0, x - i), y].Background = Brushes.Purple;
                board[Math.Min(x + i, rows), y].Background = Brushes.Purple;

                await Task.Delay(600);

                board[Math.Min(x + i, rows), Math.Min(y + i, cols)].Background = def[0];
                board[Math.Max(0, x - i), Math.Max(0, y - i)].Background = def[1];
                board[Math.Min(x + i, rows), Math.Max(0, y - i)].Background = def[2];
                board[Math.Max(0, x - i), Math.Min(y + i, cols)].Background = def[3];
                board[x, Math.Min(y + i, cols)].Background = def[4];
                board[x, Math.Max(0, y - i)].Background = def[5];
                board[Math.Max(0,x - i), y].Background = def[6];
                board[Math.Min(x + i, rows), y].Background = def[7];
            }
            //}
        }
        private int MyGetRow(Button B)
        {
            return Grid.GetRow(B);
        }
        private void Schachbrett()
        {

            //Button[,] board = new Button[10, 10];
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                {
                    board[i, j] = new Button();
                    board[i, j].MinHeight = 60;
                    board[i, j].MinWidth = 60;
                    board[i, j].Click += cell_Click;
                    Grid.SetColumn(board[i, j], j);
                    Grid.SetRow(board[i, j], i);
                    if(i > 0 && i < 9 && j > 0 && j < 9)
                    {
                        board[i, j].ToolTip = Convert.ToChar(64 + j) + (9 - i).ToString();
                        if ((i + j) % 2 == 0)
                        {
                            board[i, j].Background = Brushes.White; 
                        }
                        else
                        {
                            board[i, j].Background = Brushes.Black;
                        }
                    }
                    else
                    {
                        board[i, j].Background = Brushes.Orange;
                        board[i, j].Foreground = Brushes.WhiteSmoke;
                        if ((i == 0 || i == 9) && j != 0 && j != 9)
                        {
                            board[i, j].Content = Convert.ToChar(j + 64);//j.ToString();
                           
                        }
                        if ((j == 0 || j == 9) && i != 0 && i != 9)
                        {
                            board[i, j].Content = (9-i).ToString();
                        }
                    }
                    
                    Schach.Children.Add(board[i, j]);
                }
            DieBox.Items[0] = "ABCD";
            DieBox.Items[0] += DieBox.Items[0].ToString().ToLower();
            Schachbrett2 S = new Schachbrett2();
            //Schach.Children.Add(S);
        }
    }
}
