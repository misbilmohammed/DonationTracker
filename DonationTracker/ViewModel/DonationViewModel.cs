using DonationTracker.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationTracker.ViewModel
{
    public class DonationViewModel : BaseViewModel
    {
        private readonly Donation _donation;
        private readonly AllCharities _charities;

        public DonationViewModel(Donation donation, AllCharities charities)
        {
            _donation = donation;
            _charities = charities;
        }

        public string Charity
        {
            get
            {
                var name = _charities.Find(_donation.CharityId).LegalName;
                
                if(name != null)
                    return name;

                return "No Legal Name";
            }
        }

        public decimal Amount => _donation.Amount;

        public string Date => _donation.Date.ToShortDateString();

        public string IsPrivate => _donation.IsPrivate ? "Yes": "No";
    }
}
