﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Change_for_a_Dollar_Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        VM vm = new VM();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = vm;
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox tb = sender as TextBox;
            e.Handled = !int.TryParse(tb.Text + e.Text, out _);
        }

        private void Coin_Click(object sender, RoutedEventArgs e)
        {
            var Button = sender as Button;
            var prop = Button.Tag;

            vm.IncrementCoinCount(prop);
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            vm.CalculateResult();
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            vm.ResetGame();
        }

        private void InfoButton_Click(object sender, RoutedEventArgs e)
        {
            How_to_Play info = new How_to_Play();
            info.Show();
        }
    }
}
