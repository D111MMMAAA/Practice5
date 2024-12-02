using System;
using System.Collections.Generic;
using System.Data;
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

namespace WPF
{
    /// <summary>
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public AddWindow()
        {
            InitializeComponent();
        }

        public AddWindow(int indexDevice)
        {
            InitializeComponent();
        }

        private object _selectedItem;
        public object SelectedItem
        {
            get => _selectedItem;
            set { _selectedItem = value;}
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Доступ к выбранному элементу
            SelectedItem = ((ComboBox)sender).SelectedItem;

            if (SelectedItem.ToString().Split(new string[] { ": " }, StringSplitOptions.None).Last() == "Авто")
            {
                SpecText.Text = "Средний расход топлива (л)";
                SpecText.Visibility = Visibility.Visible;
                Spec.Visibility = Visibility.Visible;
            }
            else if (SelectedItem.ToString().Split(new string[] { ": " }, StringSplitOptions.None).Last() == "Электроскутер")
            {
                SpecText.Text = "Вес (кг)";
                SpecText.Visibility = Visibility.Visible;
                Spec.Visibility = Visibility.Visible;
            }
            else
            {
                SpecText.Visibility = Visibility.Hidden;
                Spec.Visibility = Visibility.Hidden;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (NameClass.SelectedValue is { } && correct_input())
            {
                if (NameClass.Text == "Авто")
                {
                    ApplicationContext.Devices.Add(new Auto(Firma.Text.Trim(), Model.Text.Trim(), Convert.ToInt32(Pow.Text.Trim()), Convert.ToInt32(Speed.Text.Trim()), Convert.ToInt32(Spec.Text.Trim())));
                }
                else if (NameClass.Text == "Электроскутер")
                {
                    ApplicationContext.Devices.Add(new Electricscooter(Firma.Text.Trim(), Model.Text.Trim(), Convert.ToInt32(Pow.Text.Trim()), Convert.ToInt32(Speed.Text.Trim()), Convert.ToInt32(Spec.Text.Trim())));
                }
                else
                {
                    ApplicationContext.Devices.Add(new Transportvehicle(Firma.Text.Trim(), Model.Text.Trim(), Convert.ToInt32(Pow.Text.Trim()), Convert.ToInt32(Speed.Text.Trim())));
                }
                MessageBox.Show("Запись успешно добавлена");
                this.Close();
            }
        }

        private bool correct_input()
        {
            if (NameClass.Text.Trim() == "")
            {
                NameClass.ToolTip = "Вы не выбрали тип устройства";
                MessageBox.Show("Вы не выбрали тип устройства");
                return false;
            }
            else if (Firma.Text.Trim() == "")
            {
                Firma.ToolTip = "Введите фирму";
                MessageBox.Show("Введите фирму");
                return false;
            }
            else if (Model.Text.Trim() == "")
            {
                Model.ToolTip = "Введите модель";
                MessageBox.Show("Введите модель");
                return false;
            }
            else if (Speed.Text.Trim().Length < 1 )
            {
                Speed.ToolTip = "Введите скорость";
                MessageBox.Show("Введите скорость");
                return false;
            }
            else if (!double.TryParse(Speed.Text.Trim(), out var parsedNumber))
            {
                Speed.ToolTip = "Введите скорость (необходимо число)";
                MessageBox.Show("Введите скорость (необходимо число)");
                return false;
            }
            else if (Pow.Text.Trim() == "")
            {
                Pow.ToolTip = "Введите мощность";
                MessageBox.Show("Введите мощность");
                return false;
            }
            else if (!double.TryParse(Pow.Text.Trim(), out parsedNumber))
            {
                Speed.ToolTip = "Введите мощность (необходимо число)";
                MessageBox.Show("Введите мощность (необходимо число)");
                return false;
            }
            else if (!double.TryParse(Spec.Text.Trim(), out parsedNumber) && SelectedItem.ToString().Split(new string[] { ": " }, StringSplitOptions.None).Last() != "Транспортное средство")
            {
                Spec.ToolTip = "Некоректное ввод в последнем поле (необходимо число)";
                MessageBox.Show("Некоректное ввод в последнем поле (необходимо число)");
                return false;
            }

            return true;
        }
    }
}
