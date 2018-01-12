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
        List<Label> row1labels = new List<Label>();
        List<Label> row2labels = new List<Label>();
        List<Label> row3labels = new List<Label>();
        List<Label> row4labels = new List<Label>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (p_one_name.Text != "")
            {
                playerName = p_one_name.Text;
            }
            else
            {
                playerName = "Player One";
            }
            if (p_two_name.Visibility != Visibility.Hidden)
            {
                if (p_two_name.Text != "")
                {
                    playerName = p_two_name.Text;
                }
                else
                {
                    playerName = "Player Two";

                }
            }
            difficulty = diffSelect.Text;
            if(difficulty == "Easy")
            {
                row_three_btn.Visibility = Visibility.Hidden;
                row_four_btn.Visibility = Visibility.Hidden;
            }
            else if(difficulty == "Medium")
            {
                row_four_btn.Visibility = Visibility.Hidden;
            }
            SetUp();
            SetUpGrid.Visibility = Visibility.Hidden;
            Game.Visibility = Visibility.Visible;
        }

        private void Row_one_btn_Click(object sender, RoutedEventArgs e)
        {
            row_two_btn.Visibility = Visibility.Hidden;
            row_three_btn.Visibility = Visibility.Hidden;
            row_four_btn.Visibility = Visibility.Hidden;
            if(row1labels.Count != 0)
            {
                row1labels.Remove(row1labels.Last());
                Row_one.Children.Remove(row1labels.Last());

            }
            row1MatchesLeft -= 1;
            matchesRemaining -= 1;
            if(row1MatchesLeft == 0)
            {
                row_one_btn.Visibility = Visibility.Hidden;
            }

        }
        private void Row_two_btn_Click(object sender, RoutedEventArgs e)
        {
            row_one_btn.Visibility = Visibility.Hidden;
            row_three_btn.Visibility = Visibility.Hidden;
            row_four_btn.Visibility = Visibility.Hidden;
            if (row2labels.Count != 0)
            {
                row2labels.Remove(row2labels.Last());
                Row_two.Children.Remove(row2labels.Last());
            }
            row2MatchesLeft -= 1;
            matchesRemaining -= 1;
            if (row2MatchesLeft == 0)
            {
                row_two_btn.Visibility = Visibility.Hidden;
            }

        }

        private void Row_three_btn_Click(object sender, RoutedEventArgs e)
        {
            row_one_btn.Visibility = Visibility.Hidden;
            row_two_btn.Visibility = Visibility.Hidden;
            row_four_btn.Visibility = Visibility.Hidden;
            if (row3labels.Count != 0)
            {
                row3labels.Remove(row3labels.Last());
                Row_three.Children.Remove(row3labels.Last());
            }
            row3MatchesLeft -= 1;
            matchesRemaining -= 1;
            if (row3MatchesLeft == 0)
            {
                row_three_btn.Visibility = Visibility.Hidden;
            }
        }

        private void Row_four_btn_Click(object sender, RoutedEventArgs e)
        {
            row_one_btn.Visibility = Visibility.Hidden;
            row_two_btn.Visibility = Visibility.Hidden;
            row_three_btn.Visibility = Visibility.Hidden;
            if (row4labels.Count != 0)
            {
                row4labels.Remove(row4labels.Last());
                Row_four.Children.Remove(row4labels.Last());
            }
            row4MatchesLeft -= 1;
            matchesRemaining -= 1;
            if (row4MatchesLeft == 0)
            {
                row_four_btn.Visibility = Visibility.Hidden;
            }
        }

        private void EndTurn_btn_Click(object sender, RoutedEventArgs e)
        {
            if (matchesRemaining == 1)
            {
                if (isPVP == true)
                {
                    if (isPlayer1Turn == true)
                    {
                        Win_Announce.Content = playerName;
                    }
                    else
                    {
                        Win_Announce.Content = player2Name;
                    }
                }
                else
                {
                    if (isPlayer1Turn == true)
                    {
                        Win_Announce.Content = playerName;
                    }
                    else
                    {
                        Win_Announce.Content = computerName;
                    }
                }

                EndGame();
            }
            if (matchesRemaining <= 0)
            {
                //Change win label to the opposite of current player
                if (isPVP == true)
                {
                    if (isPlayer1Turn == true)
                    {
                        Win_Announce.Content = player2Name + "Wins!";
                    }
                    else
                    {
                        Win_Announce.Content = playerName + "Wins!";
                    }
                }
                else
                {
                    if (isPlayer1Turn == true)
                    {
                        Win_Announce.Content = computerName + "Wins!";
                    }
                    else
                    {
                        Win_Announce.Content = playerName + "Wins!";
                    }
                }
                if (gameMode == "PVP")
                {
                    PlayerRotation();
                }
                else if (gameMode == "PVC")
                {
                    ComputerTurn();
                }
                else
                {
                    Console.WriteLine("Game Mode Was Not Changed Correctly");
                }
            }
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
            if(matchesRemaining == 1)
            {
                EndGame();
            }
            else if (matchesRemaining > 1)
            {
                if (row1MatchesLeft > 0)
                {
                    //row1labels[0].Visibility = Visibility.Hidden;
                    //Label l = row1labels[0];
                    Game.Children.Remove(row1labels[0]);
                    row1labels.Remove(row1labels[0]);
                    row1MatchesLeft--;
                    
                }
                else if (row2MatchesLeft > 0)
                {
                    Game.Children.Remove(row2labels[0]);
                    row2labels.Remove(row2labels[0]);
                    row2MatchesLeft--;
                    //Hide Match 2 Label
                }
                else if (row3MatchesLeft > 0)
                {
                    Game.Children.Remove(row3labels[0]);
                    row3labels.Remove(row3labels[0]);
                    row3MatchesLeft--;
                    //Hide Match 3 Label
                }
                else if (row4MatchesLeft > 0)
                {
                    Game.Children.Remove(row4labels[0]);
                    row4labels.Remove(row4labels[0]);
                    row4MatchesLeft--;
                    //Hide Match 4 Label
                }
                else
                {
                    Console.WriteLine("There are no matches left in any rows");
                }
                row_one_btn.Visibility = Visibility.Visible;
                row_two_btn.Visibility = Visibility.Visible;
                row_three_btn.Visibility = Visibility.Visible;
                row_four_btn.Visibility = Visibility.Visible;
                matchesRemaining--;
            }
            else
            {
                //Figure Out How EndGame Goes and set the person whos turn it just was to the loser
            }
        }

        public void PlaceMatches()
        {
            var counter1 = 1;
            var counter2 = 1;
            var counter3 = 1;
            var counter4 = 1;
            for (int i = 0; i < row1MatchesLeft; i++)
            {
                Label label = new Label();
                label.Content = "Match";
                label.Name = "row1match" + counter1;

                //label.Name = "row1match" + i;

                row1labels.Add(label);
                Row_one.Children.Add(label);
                 counter1++;

            }
            for (int i = 0; i < row2MatchesLeft; i++)
            {
                Label label = new Label();
                label.Content = "Match";

                label.Name = "row2match" + counter2;
                row2labels.Add(label);

                Row_two.Children.Add(label);
                counter2++;

            }
            for (int i = 0; i < row3MatchesLeft; i++)
            {
                Label label = new Label();
                label.Content = "Match";

                label.Name = "row3match" + counter3;
                row3labels.Add(label);

                Row_three.Children.Add(label);
                counter3++;

            }
            for (int i = 0; i < row4MatchesLeft; i++)
            {
                Label label = new Label();
                label.Content = "Match";

                label.Name = "row4match" + counter4;
                row4labels.Add(label);

                Row_four.Children.Add(label);
                counter4++;

            }



        }
        public void SetUp()
        {
      
            Turn_Label.Content = playerName;
            isPlayer1Turn = true;
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
                row3MatchesLeft = 7;
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

                Turn_Label.Visibility = Visibility.Hidden;
            }
            PlaceMatches();
        }
        public void PlayerRotation()
        {
            if (matchesRemaining == 1)
            {
                EndGame();
            }

            if (isPlayer1Turn == true)
            {

            isPlayer1Turn = false;
            }
            else
            {
                isPlayer1Turn = true;
            }


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

            if (isPlayer1Turn == false)
            {
                Turn_Label.Content = player2Name;

            }
            else
            {
                Turn_Label.Content = playerName;

            }
        }
        public void PVPSelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            //int selectedIndex = modeSelect.SelectedIndex;
            //Object selectedItem = modeSelect.SelectedItem;
            string modeText = modeSelect.Text;
            if (modeText == "PVC")
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

//<<<<<<< HEAD
        private void ModeSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
//=======


//>>>>>>> ce24027f449337d6525c6966216d6fe08e36e2ee
    }

}
