using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF
{
    /// <summary>
    /// Логика взаимодействия для Changed.xaml
    /// </summary>
    public partial class Changed : Window
    {
        int index;
        public Changed(int indexDevice)
        {
            InitializeComponent();
            index = indexDevice;
        }

        private object _selectedItem;
        public object SelectedItem
        {
            get => _selectedItem;
            set { _selectedItem = value; }
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
            ApplicationContext.Devices.RemoveAt(index);
            if (NameClass.SelectedValue is { })
            {
                if (NameClass.Text == "Авто")
                {
                    ApplicationContext.Devices.Insert(index, new Auto(Firma.Text.Trim(), Model.Text.Trim(), Convert.ToInt32(Pow.Text.Trim()), Convert.ToInt32(Speed.Text.Trim()), Convert.ToInt32(Spec.Text.Trim())));
                }
                else if (NameClass.Text == "Электроскутер")
                {
                    ApplicationContext.Devices.Insert(index, new Electricscooter(Firma.Text.Trim(), Model.Text.Trim(), Convert.ToInt32(Pow.Text.Trim()), Convert.ToInt32(Speed.Text.Trim()), Convert.ToInt32(Spec.Text.Trim())));
                }
                else
                {
                    ApplicationContext.Devices.Insert(index, new Transportvehicle(Firma.Text.Trim(), Model.Text.Trim(), Convert.ToInt32(Pow.Text.Trim()), Convert.ToInt32(Speed.Text.Trim())));
                }
                MessageBox.Show("Запись успешно измененна");
                this.Close();
            }
        }
    }
}
