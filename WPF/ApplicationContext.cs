using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace WPF
{
    class ApplicationContext : INotifyPropertyChanged
    {
        private Transportvehicle selectedTransp;
        static public ObservableCollection<Transportvehicle> Devices { get; set; }

        public ApplicationContext() 
        {
            Devices = new();
        }
        public Transportvehicle SelectedTransp
        {
            get { return selectedTransp; }
            set
            {
                selectedTransp = value;
                OnPropertyChanged("SelectedTransp");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
