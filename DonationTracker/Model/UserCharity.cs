namespace DonationTracker.Model
{
    public class UserCharity : User
    {
        private string _charityId;

        public UserCharity(string charityId, string userId, string username, string emailAddress, string password, string phoneNumber, string address) 
            : base(userId, username, emailAddress, password, phoneNumber, address)
        {
            _charityId = charityId;
        }
    }
}