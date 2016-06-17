using Murz1k.MultithreadingNumberSearch.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Murz1k.MultithreadingNumberSearch.App
{
    public class ViewModelLocator
    {
        private static MainViewModel mainViewModel;
        public ViewModelLocator()
        {
            mainViewModel = new MainViewModel();
        }
        public MainViewModel MainViewModel
        {
            get
            {
                return mainViewModel;
            }
        }
    }
}
