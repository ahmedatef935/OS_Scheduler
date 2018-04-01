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
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for ResultWindow.xaml
    /// </summary>
    public partial class ResultWindow : Window
    {
        public ResultWindow()
        {
            InitializeComponent();
        }
        private void FCFS()
        {
            List<double> ArriveTime = ((MainWindow)Application.
                Current.MainWindow).GetArriveTimeList();
            List<double> BurstTime = ((MainWindow)Application.
                Current.MainWindow).GetBurstTimeList();

            
            foreach (double singleItem in ArriveTime)
            {
                procrsses.a
            }
        }
    }
}
