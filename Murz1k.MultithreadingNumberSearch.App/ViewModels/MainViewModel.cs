using Murz1k.MultithreadingNumberSearch.App.Utility;
using Murz1k.MultithreadingNumberSearch.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace Murz1k.MultithreadingNumberSearch.App.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<Value> values;
        public MainViewModel()
        {
            values = new ObservableCollection<Value>();
            ClickCommand = new CustomCommand(Click, CanClick);
        }
        public ObservableCollection<Value> Values
        {
            get
            {
                return values;
            }
            set
            {
                values = value;
                OnPropertyChanged("Threads");
            }
        }
        private int threadsCount;
        public int ThreadsCount
        {
            get
            {
                return threadsCount;
            }
            set
            {
                threadsCount = value;
                OnPropertyChanged("ThreadsCount");
            }
        }
        private int interval;
        public int Interval
        {
            get
            {
                return interval;
            }
            set
            {
                interval = value;
                OnPropertyChanged("Interval");
            }
        }
        private int currentValue;
        public int CurrentValue
        {
            get
            {
                return currentValue;
            }
            set
            {
                currentValue = value;
                OnPropertyChanged("CurrentValue");
            }
        }
        private string buttonContent = "Пуск";
        public string ButtonContent
        {
            get
            {
                return buttonContent;
            }
            set
            {
                buttonContent = value;
                OnPropertyChanged("ButtonContent");
            }
        }
        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();
        public static int RandomNumber(int min, int max)
        {
            lock (syncLock)
            { 
                return random.Next(min, max);
            }
        }
        public ICommand ClickCommand { get; set; }
        private void Click(object obj)
        {
            if (ButtonContent == "Пуск")
            {
                ButtonContent = "Стоп";
                Start();
            }
            else
            {
                ButtonContent = "Пуск";
                Stop();
            }
        }
        private bool CanClick(object obj)
        {
            if (CurrentValue != 0 && ThreadsCount != 0 && Interval != 0)
                return true;
            return false;
        }
        private void Stop()
        {
            ButtonContent = "Пуск";
            stop = true;
        }
        private void Start()
        {
            values.Clear();
            stop = false;
            for (int i = 0; i < ThreadsCount; i++)
            {
                ThreadPool.QueueUserWorkItem(Add);
            }
        }
        bool stop = false;
        public void Add(object arg)
        {
            while (true)
            {
                Thread.Sleep(Interval);
                Value item = new Value();
                item.GeneratedValue = RandomNumber(0, 100);
                item.Date = DateTime.Now.ToString("dd.MM hh:mm:ss");
                item.Name = String.Format("Поток {0}", Thread.CurrentThread.ManagedThreadId);
                if (!stop)
                {
                    Application.Current.Dispatcher.BeginInvoke((Action)(() => Values.Add(item)));
                }
                if (item.GeneratedValue == CurrentValue)
                {
                    ButtonContent = "Пуск";
                    stop = true;
                    MessageBox.Show("Число найдено!");
                    return;
                }
            }
        }
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
