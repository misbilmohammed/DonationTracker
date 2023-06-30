using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationTracker.Model
{
    public class AllUsers
    {
        private List<User> _users;

        public AllUsers()
        {
            _users = new List<User>();
        }

        public void Add(User user)
        {
            _users.Add(user);
        }

        public User? Find(string id)
        {
            return _users.Find(u => u.IsSame(id));
        }

        public void Remove(string id)
        {
            User? user = _users.Find(u => u.IsSame(id));

            if(user != null) 
                _users.Remove(user);
        }
    }
}
