using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationTracker.Model
{
    public abstract class User : IFindable
    {
        private string _id;
        private string _username;
        private string _emailAddress;
        private string _password;
        private string _phoneNumber;
        private string _address;
        private DonationsCollection _donations;

        public User(string id, string username, string emailAddress, string password, string phoneNumber, string address)
        {
            _id = id;
            _username = username;
            _emailAddress = emailAddress;
            _password = password;
            _phoneNumber = phoneNumber;
            _address = address;
            _donations = new DonationsCollection();
        }

        public string Id
        {
            get { return _id; }
        }

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        public string EmailAddress
        {
            get { return _emailAddress; }
            set { _emailAddress = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public List<Donation> FindDonations(string id)
        {
            return _donations.FindAll(id);
        }

        public DonationsCollection Donations
        {
            get { return _donations; }
        }

        public bool IsSame(string id)
        {
            return id == _id || id == _username || id == _emailAddress;
        }
    }
}
