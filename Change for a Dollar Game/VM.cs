using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Change_for_a_Dollar_Game
{
    enum Coins
    {
        Penny,
        Nickel,
        Dime,
        Quarter
    }

    class VM : INotifyPropertyChanged
    {
        const int PENNY = 1;
        const int NICKEL = 5;
        const int DIME = 10;
        const int QUARTER = 25;

        const string START_UP_MESSAGE = "Pick a number of Coins & Hit GO to start playing!";
        const string WIN_MESSAGE = "WINNER, that makes a Dollar!";

        private int penny = 0;
        public int Penny {
            get { return penny; }
            set { penny = value; propertyChanged(); } 
        }

        private int nickel = 0;
        public int Nickel {
            get { return nickel; }
            set { nickel = value; propertyChanged(); } 
        }

        private int dime = 0;
        public int Dime { 
            get { return dime; }
            set { dime = value; propertyChanged(); } 
        }

        private int quarter = 0;
        public int Quarter { 
            get { return quarter; }
            set { quarter = value; propertyChanged(); } 
        }

        private string result = START_UP_MESSAGE;
        public string Result { 
            get { return result; } 
            set { result = value; propertyChanged(); }
        }

        private string resetButtonVisibility = "Collapsed";
        public string ResetButtonVisibility
        {
            get { return resetButtonVisibility; }
            set { resetButtonVisibility = value; propertyChanged(); }
        }

        public void CalculateResult()
        {
            int Result;
            int TotalCents = (Penny * PENNY) + (Nickel * NICKEL) + (Dime * DIME) + (QUARTER * Quarter);
            Result = 100 - TotalCents;
            UpdateResultLabel(Result);
        }

        public string GetResultMoreMessage(int R)
        {
            return $"OOPS! That's {Math.Abs(R):N} cents more than a Dollar";
        }

        public string GetResultLessMessage(int R)
        {
            return $"OOPS! That's {R} cents short of a Dollar";
        }

        public string GetWinMessage()
        {
            return WIN_MESSAGE;
        }

        public void UpdateResultLabel(int Res)
        {
            if (Res == 0)
            {
                Result = GetWinMessage();
            }
            else if (Res < 0)
            {
                Result = GetResultMoreMessage(Res);
            }
            else
            {
                Result = GetResultLessMessage(Res);
            }

            ResetButtonVisibility = "Visible";
        }

        public void ResetGame()
        {
            Penny = Nickel = Dime = Quarter = 0;
            ResetButtonVisibility = "Collapsed";
            Result = START_UP_MESSAGE;
        }

        public void IncrementCoinCount(object prop)
        {
            var CoinSelected = prop;

            switch (prop)
            {
                case "Penny":
                    Penny++;
                    break;
                case "Nickel":
                    Nickel++;
                    break;
                case "Dime":
                    Dime++;
                    break;
                case "Quarter":
                    Quarter++;
                    break;
                default:
                    break;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #region Property Changed
        private void propertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
