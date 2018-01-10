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

namespace GameOfNim
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string computerName;
        public string playerName;
        public string player2Name;
        public string difficulty;
        public string gameMode;
        public int mathchesRemaining;
        public int matchesRemaining;
        public int row1MatchesLeft;
        public int row2MatchesLeft;
        public int row3MatchesLeft;
        public int row4MatchesLeft;
        public bool isPVP;
        public bool isPlayer1Turn;
        public bool matchTaken;



        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Row_one_btn_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Row_two_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Row_three_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Row_four_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EndTurn_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Yes_Click(object sender, RoutedEventArgs e)
        {

        }

        private void No_Click(object sender, RoutedEventArgs e)
        {

        }
        public void ComputerTurn()
        {

        }
    }
}
