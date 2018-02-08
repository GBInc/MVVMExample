using Containers.ArrayList;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using WpfApp1.Model;

namespace WpfApp1.ViewModel
{
   public class WpfViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<int> theCollection = new ObservableCollection<int>();

        private WpfModel Model = null;

        public ObservableCollection<int> Collection
        {
            get
            {
                return theCollection;
            }

            set
            {
                theCollection = value;
                PropertyChanged?.Invoke(this,new PropertyChangedEventArgs("Collection"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public WpfViewModel()
        {
            Collection = new ObservableCollection<int>();
            Model = new WpfModel();
            Model.PropertyChanged += Model_PropertyChanged;
        }

        private void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "ArrayListProperty")
            {
                // Clear it and reload ... Need to have better event that just gives you the object that was added....
                // this will flash clearing it every time something is added.
                Application.Current.Dispatcher.Invoke(() =>
                {
                    Collection.Clear();
                });
                for (int i = 0; i < Model.ArrayListProperty.Size; i++)
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        Collection.Add(Model.ArrayListProperty.GetElement(i));
                    });
                }
            }
        }
    }
}
