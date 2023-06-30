using DonationTracker.Model;
using DonationTracker.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DonationTracker.ViewModel
{
    public class CancelDonationCommand : CommandBase
    {
        private readonly User _currentUser;
        private readonly NavigationStore _navigationStore;
        public readonly AllCharities _charities;

        public CancelDonationCommand(NavigationStore navigationStore, User currentUser, AllCharities charities)
        {
            _currentUser = currentUser;
            _navigationStore = navigationStore;
            _charities = charities;
        }

        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = new DonationsListingViewModel(_currentUser.Donations, _charities);
        }
    }
}
