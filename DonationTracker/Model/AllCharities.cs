using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationTracker.Model
{
    public class AllCharities
    {
        private List<Charity> _charities;

        public AllCharities()
        {
            _charities = new List<Charity>();

            LoadACNCCharities();
        }

        public List<Charity> Charities
        {
            get { return _charities; }
        }

        public void Add(Charity charity)
        {
            _charities.Add(charity);
        }

        public Charity? Find(string id)
        {
            return _charities.Find(c => c.IsSame(id));
        }

        public List<Charity> Search(string id)
        {
            return _charities.FindAll(c => c.IsSimilar(id));
        }

        public void Remove(string id)
        {
            Charity? charity = _charities.Find(c => c.IsSame(id));

            if(charity != null) 
                _charities.Remove(charity);
        }

        public void LoadACNCCharities()
        {
           if(!_charities.Any())
            {
                _charities = CSVReader.Read(@"C:\Users\Misbil\projects\DonationTracker\DonationTracker\Files\charities.csv");
            }
        }
    }
}
