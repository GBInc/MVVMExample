using Containers.ArrayList;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    public class WpfModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        TaskFactory theTaskFactory = new TaskFactory();

        ArrayList<int> theArrayList = new ArrayList<int>();

        public ArrayList<int> ArrayListProperty
        {
            get
            {
                return theArrayList;
            }

            set
            {
                theArrayList = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ArrayListProperty"));
            }
        }

        public WpfModel()
        {
            theTaskFactory.StartNew(() =>
            {
                while (true)
                {
                    for (int i = 0; i < 200; i++)
                    {
                        theArrayList.Add(i);
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ArrayListProperty"));
                        Thread.Sleep(100);
                    }
                    for (int i = 199; i == 0; i--)
                    {

                        // WHY YOU NO HAVE REMOVE!
                        Thread.Sleep(100);
                    }
                }
            });
        }
    }
}
