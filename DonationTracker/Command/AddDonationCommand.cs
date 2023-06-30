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
    public class AddDonationCommand : CommandBase
    {
        private readonly User _currentUser;
        private readonly NavigationStore _navigationStore;
        public readonly AllCharities _charities;
        private AddDonationViewModel _addDonationViewModel;

        public AddDonationCommand(NavigationStore navigationStore, AddDonationViewModel addDonationViewModel, User currentUser, AllCharities charities)
        {
            _currentUser = currentUser;
            _navigationStore = navigationStore;
            _charities = charities;
            _addDonationViewModel = addDonationViewModel;
        }

        public override void Execute(object parameter)
        {
            // Add Donation to users donations
            Donation donation = new Donation(
                _currentUser.Id,
                _addDonationViewModel.CharityId,
                _addDonationViewModel.Amount,
                _addDonationViewModel.Date,
                _addDonationViewModel.IsPrivate
                );

            _currentUser.Donations.Add(donation);

            _navigationStore.CurrentViewModel = new DonationsListingViewModel(_currentUser.Donations, _charities);
        }
    }
}
