using System;

namespace DonationTracker.Model
{
    public class Donation : IFindable
    {
        private string _donorId;
        private string _charityId;
        private decimal _amount;
        private DateTime _date;
        private bool _isPrivate;

        public Donation(string donorId, string charityId, decimal amount, DateTime date, bool isPrivate)
        {
            _donorId = donorId;
            _charityId = charityId;
            _amount = amount;
            _date = date;
            _isPrivate = isPrivate;
        }

        public string DonorId
        {
            get { return _donorId; }
            set { _donorId = value; }
        }

        public string CharityId
        {
            get { return _charityId; }
            set { _charityId = value; }
        }

        public decimal Amount {
            get { return _amount; }
            set { _amount = value; }
        }

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public bool IsPrivate
        {
            get { return _isPrivate; }
            set { _isPrivate = value; }
        }

        public bool IsSame(string id)
        {
            return id == _donorId  || id == _charityId;
        }
    }
}