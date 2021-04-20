using System;
using System.Collections.Generic;
using System.Text;
using Vernam.Core;

namespace Vernam.ViewModels
{
    class MainViewModel : ObservableObject
    {
        public CorrespondensesViewModel CorrVM { get; set; }
        private object currentView;

        public object CurrentView
        {
            get { return currentView; }
            set
            {
                currentView = value;
                OnPropretyChanged();
            }
        }
        public MainViewModel()
        {
            CorrVM = new CorrespondensesViewModel();
            CurrentView = CorrVM;
        }
    }
}
