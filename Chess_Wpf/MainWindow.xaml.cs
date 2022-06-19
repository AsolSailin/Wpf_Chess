using LibraryChess;
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

namespace Chess_Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Piece piece;
        private string choice;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            int x = Grid.GetColumn(sender as Button);
            int y = Grid.GetRow(sender as Button);

            try
            {
                piece = PieceMaker.Make(choice, x, y);
                (sender as Button).Background = new SolidColorBrush(Color.FromRgb(216, 191, 216));
                (sender as Button).Content = choice;
            }
            catch
            {
            }
        }

        private void Piece_Click(object sender, RoutedEventArgs e)
        {
            var b = sender as Button;
            choice = b.Content.ToString();
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            int x = Grid.GetColumn(sender as Button);
            int y = Grid.GetRow(sender as Button);

            foreach (Button cell in Board.Children)
            {
                cell.Content = " ";
            }
        }

        private void GotFocus(object sender, RoutedEventArgs e)
        {
            Button tb = e.Source as Button;
            tb.Background = Brushes.Thistle;
        }

        private void WhiteLostFocus(object sender, RoutedEventArgs e)
        {
            Button tb = e.Source as Button;
            tb.Background = Brushes.White;
        }

        private void BlackLostFocus(object sender, RoutedEventArgs e)
        {
            Button tb = e.Source as Button;
            tb.Background = Brushes.Black;
        }
    }
}
