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
        private Button motion;
        private bool tPiece; 


        public MainWindow()
        {
            InitializeComponent();
        }

        private void Cell_Click(object sender, RoutedEventArgs e)
        {
            int x = Grid.GetColumn(sender as Button);
            int y = Grid.GetRow(sender as Button);

            if (!tPiece)
            {
                piece = PieceMaker.Make(choice, x, y);
                (sender as Button).Content = choice;
                tPiece = true;
            }

            if (tPiece) 
            {
                if (piece.Move(x, y))
                {
                    foreach (Button cell in Board.Children)
                    {
                        cell.Content = null;
                    }
                    motion = sender as Button;
                    motion.Content = choice;
                }
            }
        }

        private void Piece_Click(object sender, RoutedEventArgs e)
        {
            Button name = sender as Button;
            choice = name.Content.ToString();
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            int x = Grid.GetColumn(sender as Button);
            int y = Grid.GetRow(sender as Button);

            foreach (Button cell in Board.Children)
            {
                cell.Content = null;
                tPiece = false;
            }
        }

        private void GotFocus(object sender, RoutedEventArgs e)
        {
            Button focus = e.Source as Button;
            focus.Background = Brushes.Thistle;
        }

        private void WhiteLostFocus(object sender, RoutedEventArgs e)
        {
            Button focus = e.Source as Button;
            focus.Background = Brushes.White;
        }

        private void BlackLostFocus(object sender, RoutedEventArgs e)
        {
            Button focus = e.Source as Button;
            focus.Background = Brushes.Black;
        }

        private void Cell_MouseEnter(object sender, MouseEventArgs e)
        {
            int x = Grid.GetColumn(sender as Button);
            int y = Grid.GetRow(sender as Button);

            foreach (Button cell in Board.Children)
            {
                if (!tPiece)
                {
                    return;
                }
                if ((sender as Button).Content != choice)
                {
                    (sender as Button).Content = (piece.TestMove(x, y)) ? "YES" : "NO";

                    if (cell.Content != choice)
                    {
                        cell.Content = null;
                    }
                }
            }
        }
    }
}
