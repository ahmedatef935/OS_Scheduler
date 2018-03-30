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

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        List<TextBox> ArriveTimeTextBoxList= new List<TextBox>();
        List<TextBox> BurstTimeTextBoxList = new List<TextBox>();
        List<TextBox> PriorityTextBoxList = new List<TextBox>();
        private int number_process = 0;
        private void StartClick(object sender, RoutedEventArgs e)
        {
            Refresh();
            if (nProcess == null)
                return;

            if (int.TryParse(nProcess.Text, out number_process))
            {
                for (int i = 1; i <= number_process; i++)
                {
                    Label processNumber = new Label();
                    processNumber.Foreground = Brushes.White;
                    processNumber.FontSize = 14;
                    processNumber.Content = "Data of Process "
                        + i.ToString();
                    DataFields.Children.Add(processNumber);

                    if (SchedulingType.SelectedIndex !=0 && /*FCFS*/
                        SchedulingType.SelectedIndex != 5) /*Round Robin*/
                    {
                        Grid ArriveTime = AddGridData("Arrive at", ArriveTimeTextBoxList);
                        DataFields.Children.Add(ArriveTime);
                    }

                    Grid BurstTime = AddGridData("Burst Time", BurstTimeTextBoxList);
                    DataFields.Children.Add(BurstTime);

                    if (SchedulingType.SelectedIndex == 3 ||
                        SchedulingType.SelectedIndex == 4)//priority
                    {
                        Grid Priority = AddGridData("Priority", PriorityTextBoxList);
                        DataFields.Children.Add(Priority);
                    }

                }
            }
            else
            {
                MessageBox.Show("Hey, we need an int over here.");
            }

            Button StartSchedulingButton = new Button();
            StartSchedulingButton.FontSize = 14;
            StartSchedulingButton.Margin = new Thickness(130, 20, 130, 20);
            StartSchedulingButton.Height = 100;
            StartSchedulingButton.Content = "Start Scheduling";
            StartSchedulingButton.Click += Start_scheduling_Click;
            DataFields.Children.Add(StartSchedulingButton);

        }
        List<double> ArriveTime = new List<double>();
        List<double> BurstTime = new List<double>();
        List<double> Priority = new List<double>();


        private void Start_scheduling_Click(object sender, RoutedEventArgs e)
        {
            bool validData = true;
            double test;
            foreach (TextBox singleItem in ArriveTimeTextBoxList)
            {
                if (double.TryParse(singleItem.Text, out test))
                {
                    ArriveTime.Add(Convert.ToDouble(singleItem.Text));
                }
                else
                {
                    validData = false;
                }
            }
            foreach (TextBox singleItem in BurstTimeTextBoxList)
            {
                if (double.TryParse(singleItem.Text, out test))
                {
                    BurstTime.Add(Convert.ToDouble(singleItem.Text));
                }
                else
                {
                    validData = false;
                }
            }
            foreach (TextBox singleItem in PriorityTextBoxList)
            {
                if (double.TryParse(singleItem.Text, out test))
                {
                    Priority.Add(Convert.ToDouble(singleItem.Text));
                }
                else
                {
                    validData = false;
                }
            }
            if (!validData)
                MessageBox.Show("Hey, Check the arrival time, Numbers Only");
            else
            {
                ResultWindow result = new ResultWindow();
                result.Show();
                this.Close();
            }
        }

        private Grid AddGridData(string labelContent, List<TextBox> myTextboxList)
        {
            Label label = new Label();
            label.Foreground = Brushes.White;
            label.FontSize = 14;
            label.Content = labelContent;
            label.Width = 80;

            TextBox text_box = new TextBox();
            myTextboxList.Add(text_box);

            Grid grid = new Grid();
            grid.Margin = new Thickness(20, 2, 70, 2);

            ColumnDefinition c1 = new ColumnDefinition();
            c1.Width = new GridLength(1, GridUnitType.Star);
            ColumnDefinition c2 = new ColumnDefinition();
            c2.Width = new GridLength(1, GridUnitType.Star);
            grid.ColumnDefinitions.Add(c1);
            grid.ColumnDefinitions.Add(c2);

            Grid.SetColumn(label, 0);
            Grid.SetColumn(text_box, 1);
            grid.Children.Add(label);
            grid.Children.Add(text_box);
            return grid;
        }
      

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void Refresh()
        {
            DataFields.Children.RemoveRange(3, 200);
        }

        private void nProcess_SelectionChanged(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
    }
}