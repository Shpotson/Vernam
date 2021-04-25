using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using Vernam.Core;

namespace Vernam.ViewModels
{
    class MainViewModel : ObservableObject
    {
        private RelayCommand corrCommand;
        private RelayCommand profileCommand;
        public ObservableObject currentView;

        public CorrespondensesViewModel CorrVM { get; set; }
        public ProfileViewModel ProfileVM { get; set; }

        public ObservableObject CurrentView
        {
            get { return currentView; }
            set
            {
                currentView = value;
                this.OnPropertyChanged("CurrentView");
            }
        }
        public RelayCommand CorrCommand
        {
            get
            {
                return corrCommand;
            }
        }

        public RelayCommand ProfileCommand
        {
            get
            {
                return profileCommand;
            }
        }
        public MainViewModel()
        {
            CorrVM = new CorrespondensesViewModel();
            ProfileVM = new ProfileViewModel();

            profileCommand = new RelayCommand(obj =>
            {
                CurrentView = ProfileVM;
            });
            corrCommand = new RelayCommand(obj =>
            {
                CurrentView = CorrVM;
            });

            CurrentView = CorrVM;
        }
    }
}
