using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ApplicationContext();
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            AddWindow addWindow = new AddWindow();
            addWindow.Show();
        }

        private void Button_Edit_Click(object sender, RoutedEventArgs e)
        {
            Transportvehicle selectedDevice = (Transportvehicle)myDatagrid.SelectedItem;
            if (selectedDevice != null)
            {
                int indexDevice = ApplicationContext.Devices.IndexOf(selectedDevice);

                Changed change = new Changed(indexDevice);

                if (typeof(Auto) == selectedDevice.GetType())
                {
                    Auto auto = (Auto)selectedDevice;
                    change.NameClass.Text = "Авто";
                    change.Spec.Text = Convert.ToString(auto.Fuel);
                }
                else if (typeof(Electricscooter) == selectedDevice.GetType())
                {
                    Electricscooter elec = (Electricscooter)selectedDevice;
                    change.Spec.Text = Convert.ToString(elec.Weight);
                    change.NameClass.Text = "Электроскутер";
                }
                else if (typeof(Transportvehicle) == selectedDevice.GetType())
                {
                    change.NameClass.Text = "Транспортное средство";
                }
                change.Firma.Text = selectedDevice.Firma;

                change.Model.Text = selectedDevice.Model;

                change.Pow.Text = Convert.ToString(selectedDevice.Pow);

                change.Speed.Text = Convert.ToString(selectedDevice.Speed);

                if (change.ShowDialog() == true) { }

                myDatagrid.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Запись не найдена!");
            }
        }

        private void Button_Deleted_Click(object sender, RoutedEventArgs e)
        {
            Transportvehicle selectedDevice = (Transportvehicle)myDatagrid.SelectedItem;
            if (selectedDevice != null)
            {
                var result = MessageBox.Show("Вы точно хотите удалить это устройство?", "Delete Device", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                    ApplicationContext.Devices.Remove(selectedDevice);
            }
            else
            {
                MessageBox.Show("Выберите устройство!", "Configuration", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}