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
            SetUpGrid.Visibility = Visibility.Hidden;
            Game.Visibility = Visibility.Visible;
            SetUp();
        }

        private void Row_one_btn_Click(object sender, RoutedEventArgs e)
        {
            row1MatchesLeft -= 1;
            matchesRemaining -= 1;
            row_two_btn.Visibility = Visibility.Hidden;
            row_three_btn.Visibility = Visibility.Hidden;
            row_four_btn.Visibility = Visibility.Hidden;
            if(row1MatchesLeft == 0)
            {
                row_one_btn.Visibility = Visibility.Hidden;
            }

        }
        private void Row_two_btn_Click(object sender, RoutedEventArgs e)
        {
            row2MatchesLeft -= 1;
            matchesRemaining -= 1;
            row_one_btn.Visibility = Visibility.Hidden;
            row_three_btn.Visibility = Visibility.Hidden;
            row_four_btn.Visibility = Visibility.Hidden;
            if (row2MatchesLeft == 0)
            {
                row_two_btn.Visibility = Visibility.Hidden;
            }

        }

        private void Row_three_btn_Click(object sender, RoutedEventArgs e)
        {
            row3MatchesLeft -= 1;
            matchesRemaining -= 1;
            row_one_btn.Visibility = Visibility.Hidden;
            row_two_btn.Visibility = Visibility.Hidden;
            row_four_btn.Visibility = Visibility.Hidden;
            if (row3MatchesLeft == 0)
            {
                row_three_btn.Visibility = Visibility.Hidden;
            }
        }

        private void Row_four_btn_Click(object sender, RoutedEventArgs e)
        {
            row4MatchesLeft -= 1;
            matchesRemaining -= 1;
            row_one_btn.Visibility = Visibility.Hidden;
            row_two_btn.Visibility = Visibility.Hidden;
            row_three_btn.Visibility = Visibility.Hidden;
            if (row4MatchesLeft == 0)
            {
                row_four_btn.Visibility = Visibility.Hidden;
            }
        }

        private void EndTurn_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Yes_Click(object sender, RoutedEventArgs e)
        {
            SetUpGrid.Visibility = Visibility.Visible;
            Game.Visibility = Visibility.Hidden;
            EndScreen.Visibility = Visibility.Hidden;
            //playerName = p_one_name.Text;
            p_one_name.Text = "Player 1 Name";
            p_two_name.Text = "Player 2 Name";
            computerName = "";
            playerName = "";
            playerName = "";
            player2Name = "";
            difficulty = "";
            gameMode = "";
            matchesRemaining = 0;
            row1MatchesLeft = 0;
            row2MatchesLeft = 0;
            row3MatchesLeft = 0;
            row4MatchesLeft = 0;
            isPVP = false;
            isPlayer1Turn = true;
            matchTaken = false;

        }

        private void No_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

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

        public void PlaceMatches()
        {

            for (int i = 1; i < row1MatchesLeft; i++)
            {
                Label label = new Label();
                label.Name = "row1match" + i;
                Canvas_Row_one.Children.Add(label);
            }
            for (int i = 1; i < row2MatchesLeft; i++)
            {
                Label label = new Label();
                label.Name = "row2match" + i;

                Canvas_Row_two.Children.Add(label);
            }
            for (int i = 1; i < row3MatchesLeft; i++)
            {
                Label label = new Label();
                label.Name = "row3match" + i;

                Canvas_Row_three.Children.Add(label);
            }
            for (int i = 1; i < row4MatchesLeft; i++)
            {
                Label label = new Label();
                label.Name = "row4match" + i;

                Canvas_Row_four.Children.Add(label);
            }



        }
        public void SetUp()
        {
      
            playerTurnLabel.Content = playerName;
            int selectedIndex = diffSelect.SelectedIndex;
           
            Object selectedItem = diffSelect.SelectedItem;
            if (difficulty == "Easy")
            {
                row1MatchesLeft = 3;
                row2MatchesLeft = 3;
            }
            else if (difficulty == "Medium")
            {
                row1MatchesLeft = 2;
                row2MatchesLeft = 5;
                row2MatchesLeft = 7;
            }
            else
            {
                row1MatchesLeft = 2;
                row2MatchesLeft = 3;
                row3MatchesLeft = 8;
                row4MatchesLeft = 9;

            }

            if (isPVP != true)
            {

                playerTurnLabel.Visibility = Visibility.Hidden;
            }
            PlaceMatches();
        }
        public void PlayerRotation()
        {
            if (matchesRemaining == 1)
            {
                EndGame();
            }


            isPlayer1Turn = false;


            if (row1MatchesLeft > 0)
            {
                row_one_btn.Visibility = Visibility.Visible;
            }
            if (row2MatchesLeft > 0)
            {
                row_two_btn.Visibility = Visibility.Visible;

            }
            if (row3MatchesLeft > 0)
            {
                row_three_btn.Visibility = Visibility.Visible;

            }
            if (row4MatchesLeft > 0)
            {
                row_four_btn.Visibility = Visibility.Visible;

            }

        }
        public void PVPSelectedIndexChanged()
        {
            int selectedIndex = modeSelect.SelectedIndex;
            Object selectedItem = modeSelect.SelectedItem;
            if (selectedItem.ToString() == "PVC")
            {
                p_two_name.Visibility = Visibility.Hidden;
                gameMode = "PVC";
                computerName = "CPU";
            }
            else
            {
                gameMode = "PVP";
                isPVP = true;

            }
        }
        public void EndGame()
        {
            Game.Visibility = Visibility.Hidden;
            EndScreen.Visibility = Visibility.Visible;
        }



    }

}
