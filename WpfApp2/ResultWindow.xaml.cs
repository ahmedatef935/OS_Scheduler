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
    /// helllo 
    /// <summary>
    /// Interaction logic for ResultWindow.xaml
    /// </summary>
    public partial class ResultWindow : Window
    {
        public ResultWindow()
        {
            InitializeComponent();
        }
        int y;
        private List<int> FCFS()
        {
            
            if ( y == 2){ }
            List<int> processIDinTime = new List<int>();

            List<double> ArriveTime = ((MainWindow)Application.
                Current.MainWindow).GetArriveTimeList();
            List<double> BurstTime = ((MainWindow)Application.
                Current.MainWindow).GetBurstTimeList();

            int numberProcess = ((MainWindow)Application.
                Current.MainWindow).GetProcessNumber();

            List<Process> processes = new List<Process>();

            for (var i = 0; i < numberProcess; i++)
            {
                Process p = new Process(i, ArriveTime[i], BurstTime[i]);
                processes.Add(p);
            }
           
            for (var i = 0; i < numberProcess; i++)
            {
                Process to_serve = FindNextProcess_ArriveTime(processes, numberProcess);
                for (int j = 0, n = (int)(to_serve.GetBurstTime() + 0.5); j < n; i++)
                    processIDinTime.Add(to_serve.GetID());
            }

            return processIDinTime;
        }

        private Process FindNextProcess_ArriveTime(List<Process> processes,
            int numberProcesses)
        {
            Process current = processes[0]; // first element
            for (var i = 1; i < numberProcesses; i++)
            {
                if ((!processes[i].IsAssigned() && !processes[i].IsFinished())
                    && (!current.IsAssigned() && !current.IsFinished()))
                {
                    if (current.CompareArriveTime(processes[i]) == -1) /*means that current 
                        arrived before next*/
                    {}

                    else if (current.CompareArriveTime(processes[i]) == -1) /* they both arrived
                        at the same time*/
                    {
                        // we need to compare burst time of each
                        if (current.CompareBurstTime(processes[i]) == -1) /* means that current 
                            has burst time less than next*/
                        {}

                        else /* in case they both have the same burst time or if current 
                            has burst time larger than next*/
                        {
                            current = processes[i];
                        }

                    }
                    else // current arrived after next
                    {
                        current = processes[i];
                    }
                }
            }
            return current;
        }
    }
}
