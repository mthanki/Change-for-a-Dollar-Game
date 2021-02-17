using System.ComponentModel;
using System.Windows;

namespace Change_for_a_Dollar_Game
{
    /// <summary>
    /// Interaction logic for How_to_Play.xaml
    /// </summary>
    public partial class How_to_Play : Window 
    {
        public string Info { get; set; } = "Click on the images or use the text box to enter number of each coins, when done Hit the GO button to check results, the total of all coins should make a Dollar Value!";
        public string PennyInfo { get; set; } = "PENNY = 1 Cent";
        public string NickelInfo { get; set; } = "NICKEL = 5 Cents";
        public string DimeInfo { get; set; } = "DIME = 10 Cents";
        public string QuarterInfo { get; set; } = "QUARTER= 25 Cents";

        public How_to_Play()
        {
            this.DataContext = this;
            InitializeComponent();
        }
    }
}
