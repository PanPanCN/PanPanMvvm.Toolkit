using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyApp.Wpf.Demo.ViewModels;

namespace MyApp.Wpf.Demo.Locators
{
    public class ViewModelLocator
    {
        public MainWindowViewModel MainWindowViewModel => new MainWindowViewModel("ctor paramenter");
    }
}
