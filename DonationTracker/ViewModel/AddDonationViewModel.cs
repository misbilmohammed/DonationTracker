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
    public class AddDonationViewModel : BaseViewModel
    {
        private string _charityId;
        private decimal _amount;
        private DateTime _date;
        private bool _isPrivate;
        private readonly AllCharities _charities;

        public AddDonationViewModel(NavigationStore navigationStore, User user, AllCharities charities) 
        {
            SubmitCommand = new AddDonationCommand(navigationStore, this, user, charities);
            CancelCommand = new CancelDonationCommand(navigationStore, user, charities);
            _charities = charities;
            _date = DateTime.Now;
        }

        public string CharityId
        {
            get
            {
                return _charityId;
            }

            set
            {
                _charityId = _charities.Find(value).Id;
                OnPropertyChanged(nameof(Charity));
            }
        }

        public Charity Charity
        {
            set
            {
                _charityId = value.Id;
                OnPropertyChanged(nameof(Charity));
            }
        }

        public List<Charity> Charities => _charities.Charities;

        public decimal Amount
        {
            get
            {
                return _amount;
            }

            set
            {
                _amount = value;
                OnPropertyChanged(nameof(Amount));
            }
        }

        public DateTime Date
        {
            get
            {
                return _date;
            }

            set
            {
                _date = value;
                OnPropertyChanged(nameof(Date));
            }
        }

        public bool IsPrivate
        {
            get
            {
                return _isPrivate;
            }

            set
            {
                _isPrivate = value;
                OnPropertyChanged(nameof(IsPrivate));
            }
        }

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }
    }
}
