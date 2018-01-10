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
        public void ComputerTurn()
        {
            if(isPlayer1Turn == true)
            {
                isPlayer1Turn = false;
            }
            else
            {
                isPlayer1Turn = true;
            }


            if(row1MatchesLeft > 0)
            {
                row1MatchesLeft--;
                //Hide Match 1 Label
            }
            else if(row2MatchesLeft > 0)
            {
                row2MatchesLeft--;
                //Hide Match 2 Label
            }
            else if(row3MatchesLeft > 0)
            {
                row3MatchesLeft--;

            }
            else if(row4MatchesLeft > 0)
            {
                row4MatchesLeft--;
            }
            else
            {
                Console.WriteLine("There are no matches left in any rows");
            }
        }
    }
}
