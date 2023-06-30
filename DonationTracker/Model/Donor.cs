using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationTracker.Model
{
    public class Donor : User
    {
        private string _firstName;
        private string _lastName;

        public Donor(string firstName, string lastName, string id, string username, string emailAddress, string password, string phoneNumber, string address) 
            : base(id, username, emailAddress, password, phoneNumber, address)
        {
            _firstName = firstName;
            _lastName = lastName;
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string FullName
        {
            get { return _firstName + " " + _lastName; }
        }

        public void AddDonation(Donation donation)
        {
            Donations.Add(donation);
        }
    }
}
