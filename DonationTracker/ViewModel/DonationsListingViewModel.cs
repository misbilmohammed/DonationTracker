using DonationTracker.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationTracker.ViewModel
{
    class DonationsListingViewModel : BaseViewModel
    {
        private readonly ObservableCollection<DonationViewModel> _donations;

        public DonationsListingViewModel(DonationsCollection donationsCollection, AllCharities charities)
        {
            _donations = new ObservableCollection<DonationViewModel>(donationsCollection.Donations.Select(d => new DonationViewModel(d, charities)));
        }

        public ObservableCollection<DonationViewModel> Donations
        {
            get
            {
               return _donations;
            }
        }
    }
}
