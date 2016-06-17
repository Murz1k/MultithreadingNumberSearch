using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Murz1k.MultithreadingNumberSearch.Model
{
    public class Value : INotifyPropertyChanged
    {
        private int generatedValue;
        public int GeneratedValue
        {
            get
            {
                return generatedValue;
            }
            set
            {
                generatedValue = value;
                OnPropertyChanged("GeneratedValue");
            }
        }
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        private string date;
        public string Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
                OnPropertyChanged("Date");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
