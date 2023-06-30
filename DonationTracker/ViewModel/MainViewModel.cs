using DonationTracker.Model;
using DonationTracker.Store;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DonationTracker.ViewModel
{
    class MainViewModel : BaseViewModel
    {
        private User _currentUser;

        private readonly NavigationStore _navigationStore;

        public MainViewModel(User currentUser, NavigationStore navigationStore, AllCharities charities)
        {
            _currentUser = currentUser;
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            _navigationStore.CurrentViewModel = new DonationsListingViewModel(currentUser.Donations,charities);
            AddDonationViewCommand = new NavigateCommand(navigationStore, () => new AddDonationViewModel(navigationStore, currentUser, charities));
            DonationsListingViewCommand = new NavigateCommand(navigationStore, () => new DonationsListingViewModel(currentUser.Donations, charities));
        }
        
        public BaseViewModel CurrentViewModel { get { return _navigationStore.CurrentViewModel; } }

        public User CurrentUser
        {
            get { return _currentUser; }
            set { _currentUser = value; }
        }

        public ICommand AddDonationViewCommand { get; set; }

        public ICommand DonationsListingViewCommand { get; set; }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
