using System.Collections.Generic;
using System.Windows.Documents;

namespace DonationTracker.Model
{
    public class DonationsCollection
    {
        private List<Donation> _donations;

        public DonationsCollection()
        {
            _donations = new List<Donation>();
        }

        public void Add(Donation donation)
        {
            _donations.Add(donation);
        }
        public List<Donation> FindAll(string id)
        {
            return _donations.FindAll(d => d.IsSame(id));
        }

        public void Remove(Donation donation)
        {
            _donations.Remove(donation);
        }

        public List<Donation> Donations
        {
            get { return _donations; }
        }
    }
}