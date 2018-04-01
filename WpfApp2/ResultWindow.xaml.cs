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














        List<double> ArriveTime = ((MainWindow)Application.
                Current.MainWindow).GetArriveTimeList();
        List<double> BurstTime = ((MainWindow)Application.
            Current.MainWindow).GetBurstTimeList();
        int NumberProcess = ((MainWindow)Application.
            Current.MainWindow).GetProcessNumber();
        List<double> Priority = ((MainWindow)Application.
        Current.MainWindow).GetPriorityList();

        int ScheduleTypeIndex = ((MainWindow)Application.
        Current.MainWindow).GetSchedulingTypeIndex();


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            double total = BurstTime.Sum();

            // Create the Grid
            Grid DynamicGrid = new Grid();

            DynamicGrid.Width = 1700;
            DynamicGrid.Height = 1000;

            //DynamicGrid.HorizontalAlignment = HorizontalAlignment.Left;
            DynamicGrid.VerticalAlignment = VerticalAlignment.Top;

            DynamicGrid.ShowGridLines = true;
            Border border = new Border();
            border.BorderThickness = new Thickness(1);
            border.BorderBrush = new SolidColorBrush(Colors.Black);

            DynamicGrid.Background = new SolidColorBrush(Colors.Black);
            DynamicGrid.Children.Add(border);


            // Create Columns
            for (int i = 0; i <= ArriveTime[0] + total; i++)
            {
                string x = i.ToString();
                ColumnDefinition gridColi = new ColumnDefinition();
                gridColi.Width = new GridLength(30);

                DynamicGrid.ColumnDefinitions.Add(gridColi);
                //MessageBox.Show(x);
            }
            // Create Rows :
            RowDefinition gridRow1 = new RowDefinition();

            gridRow1.Height = new GridLength(15);

            RowDefinition gridRow2 = new RowDefinition();

            gridRow2.Height = new GridLength(45);

            DynamicGrid.RowDefinitions.Add(gridRow1);
            DynamicGrid.RowDefinitions.Add(gridRow2);

            for (int n = 1; n <= ArriveTime[0] + total; n++)
            {
                TextBlock txtBlockx = new TextBlock();
                txtBlockx.Text = n.ToString();




                txtBlockx.FontSize = 12;

                // txtBlockx.FontWeight = FontWeights.Bold;

                txtBlockx.Foreground = new SolidColorBrush(Colors.Red);

                txtBlockx.VerticalAlignment = VerticalAlignment.Top;
                // txtBlockc.HorizontalAlignment = HorizontalAlignment.Left;

                Grid.SetColumn(txtBlockx, n);
                Grid.SetRow(txtBlockx, 0);
                DynamicGrid.Children.Add(txtBlockx);


            }


            // Add first column header
            List<string> processi = new List<string>();

            for (int t = 1; t <= NumberProcess; t++)
            {
                string z = t.ToString();
                processi.Add("P" + z);

            }


            if (ScheduleTypeIndex == 0)
            {
                double u = ArriveTime[0];

                double y = 0;
                for (int q = 0; q < NumberProcess; q++)
                {

                    for (double i = u; i < (u + BurstTime[q]); i++)
                    {

                        TextBlock txtBlockc = new TextBlock();
                        txtBlockc.Text = processi[q];

                        txtBlockc.FontSize = 14;

                        txtBlockc.FontWeight = FontWeights.Bold;


                        txtBlockc.Foreground = new SolidColorBrush(Colors.White);
                        txtBlockc.VerticalAlignment = VerticalAlignment.Top;

                        int m = (int)Math.Floor(i);
                        Grid.SetColumn(txtBlockc, m);
                        Grid.SetRow(txtBlockc, 1);
                        DynamicGrid.Children.Add(txtBlockc);

                        y = u + BurstTime[q];

                    }
                    u = y;
                }
            }

            if (ScheduleTypeIndex == 5)
            {

            }
            rootWindow.Content = DynamicGrid;
        } 















        private List<int> FCFS()
        {
            List<int> processIDinTime = new List<int>();

            List<Process> processes = new List<Process>();

            for (var i = 0; i < NumberProcess; i++)
            {
                Process p = new Process(i, ArriveTime[i], BurstTime[i]);
                processes.Add(p);
            }
           
            for (var i = 0; i < NumberProcess; i++)
            {
                Process to_serve = FindNextProcess_ArriveTime(processes, NumberProcess);
                to_serve.MarkAssigned();

                for (int j = 0, n = (int)(to_serve.GetBurstTime() + 0.5); j < n; i++)
                    processIDinTime.Add(to_serve.GetID());

                to_serve.MarkFinished();
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
                    { }

                    else if (current.CompareArriveTime(processes[i]) == -1) /* they both arrived
                        at the same time*/
                    {
                        // we need to compare burst time of each
                        if (current.CompareBurstTime(processes[i]) == -1) /* means that current 
                            has burst time less than next*/
                        { }

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
                else
                    current = processes[i - 1];
            }
            return current;
        }
    }
}
