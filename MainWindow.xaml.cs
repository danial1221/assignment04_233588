using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace CricketTeamManager
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<string> Players { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Players = new ObservableCollection<string>();
            PlayerListBox.ItemsSource = Players;
        }

        // Placeholder behavior for text input
        private void PlayerNameTextBox_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            if (PlayerNameTextBox.Text == "Enter player name")
            {
                PlayerNameTextBox.Text = "";
                PlayerNameTextBox.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Black);
            }
        }

        private void PlayerNameTextBox_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PlayerNameTextBox.Text))
            {
                PlayerNameTextBox.Text = "Enter player name";
                PlayerNameTextBox.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Gray);
            }
        }

        private void SearchPlayerTextBox_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            if (SearchPlayerTextBox.Text == "Search player name")
            {
                SearchPlayerTextBox.Text = "";
                SearchPlayerTextBox.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Black);
            }
        }

        private void SearchPlayerTextBox_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SearchPlayerTextBox.Text))
            {
                SearchPlayerTextBox.Text = "Search player name";
                SearchPlayerTextBox.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Gray);
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            PlayerNameTextBox.Clear();
        }

        private void AddPlayerButton_Click(object sender, RoutedEventArgs e)
        {
            string playerName = PlayerNameTextBox.Text.Trim();
            if (playerName.Length < 3)
            {
                MessageBox.Show("Player name must be at least 3 characters long.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!Players.Contains(playerName))
            {
                Players.Add(playerName);
                MessageBox.Show($"Player '{playerName}' added successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                PlayerNameTextBox.Clear();
            }
            else
            {
                MessageBox.Show("Player already exists.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SearchPlayerButton_Click(object sender, RoutedEventArgs e)
        {
            string searchName = SearchPlayerTextBox.Text.Trim();
            if (Players.Contains(searchName))
            {
                PlayerListBox.SelectedItem = searchName;
                MessageBox.Show($"Player '{searchName}' found.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show($"Player '{searchName}' not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RemovePlayerButton_Click(object sender, RoutedEventArgs e)
        {
            if (PlayerListBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a player to remove from the list.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string selectedPlayer = PlayerListBox.SelectedItem.ToString();
            Players.Remove(selectedPlayer);
            MessageBox.Show($"Player '{selectedPlayer}' has been removed from the roster.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
