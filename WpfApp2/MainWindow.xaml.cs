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


        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }


        private int number_process = 0;
        private void StartClick(object sender, RoutedEventArgs e)
        {
            Refresh();
            if (nProcess == null)
                return;

            if (int.TryParse(nProcess.Text, out number_process))
            {
                for (int i = 0; i < number_process; i++)
                {
                    Label processNumber = new Label();
                    processNumber.Foreground = Brushes.White;
                    processNumber.FontSize = 14;
                    processNumber.Content = "Data of Process "
                        + (i + 1).ToString();
                    DataFields.Children.Add(processNumber);

                    if (SchedulingType.SelectedIndex !=0 && /*FCFS*/
                        SchedulingType.SelectedIndex != 5) /*Round Robin*/
                    {
                        Grid ArriveTime = AddGridData("Arrive at",
                            "ArriveTimeTextBox" + i.ToString(), i);
                        DataFields.Children.Add(ArriveTime);
                    }

                    Grid BurstTime = AddGridData("Burst Time",
                        "BurstTimeTextBox" + i.ToString(), i);
                    DataFields.Children.Add(BurstTime);

                    if (SchedulingType.SelectedIndex == 3 ||
                        SchedulingType.SelectedIndex == 4)//priority
                    {
                        Grid Priority = AddGridData("Priority",
                           "PriorityTextBox" + i.ToString(), i);
                        DataFields.Children.Add(Priority);
                    }

                }
            }
            else
            {
                MessageBox.Show("Hey, we need an int over here.");
            }
        }

        private Grid AddGridData(string labelContent, string textBoxName, int i)
        {
            Label label = new Label();
            label.Foreground = Brushes.White;
            label.FontSize = 14;
            label.Content = labelContent;
            label.Width = 80;

            TextBox text_box = new TextBox();
            label.Foreground = Brushes.White;
            text_box.Name = textBoxName;

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

            Grid.SetColumn(label, 0);
            Grid.SetRow(text_box, 1);
            return grid;
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {


        }

        private void Refresh()
        {
            DataFields.Children.RemoveRange(3, 200);
        }

        private void nProcess_SelectionChanged(object sender, RoutedEventArgs e)
        {
            DataFields.Children.RemoveRange(3, 200);
        }
    }
}