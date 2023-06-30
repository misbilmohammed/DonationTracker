using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationTracker.Model
{
    public class Charity : IFindable
    {
        private string _id;
        private string _legalName;
        private string _otherNames;
        private string _website;
        private List<string> _registeredAddress;
        private string _size;
        private string _responsiblePersons;
        private List<string> _types;
        private List<string> _operatesIn;
        private DateTime _registered;
        private DateTime _established;
        private DateTime _financialYearEnd;
        private string _abn;
        private bool _registeredOnACNC;
        private UserCharity? _userRegistration;


        public Charity(string id, string legalName, string otherNames, string website, List<string> registeredAddress, string size,
            List<string> types, List<string> operatesIn, string responsiblePersons, DateTime registered,
            DateTime established, DateTime financialYearEnd, string abn, bool registeredOnACNC)
        {
            _id = id;
            _legalName = legalName;
            _otherNames = otherNames;
            _website = website;
            _registeredAddress = registeredAddress;
            _size = size;
            _responsiblePersons = responsiblePersons;
            _types = types;
            _operatesIn = operatesIn;
            _registered = registered;
            _established = established;
            _financialYearEnd = financialYearEnd;
            _abn = abn;
            _registeredOnACNC = registeredOnACNC;
        }

        public Charity(string id, string legalName, string otherNames, string website, List<string> registeredAddress, string size,
          List<string> types, List<string> operatesIn, string responsiblePersons, DateTime registered,
          DateTime established, DateTime financialYearEnd, string abn, bool registeredOnACNC, UserCharity userRegistration)
            : this(id, legalName, otherNames, website, registeredAddress, size, types, operatesIn, responsiblePersons,
                  registered, established, financialYearEnd, abn, registeredOnACNC)
        {
            _userRegistration = userRegistration;
        }

        public Charity() : this("", "", "", "", new List<string>(), "", new List<string>(), new List<string>(), "", default(DateTime), default(DateTime), default(DateTime), "", true) { }

        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string LegalName
        {
            get { return _legalName; }
            set { _legalName = value; }
        }

        public string OtherNames
        {
            get { return _otherNames; }
            set { _otherNames = value; }
        }

        public string Website
        {
            get { return _website; }
            set { _website = value; }
        }

        public List<string> RegisteredAddress
        {
            get { return _registeredAddress; }
            set { _registeredAddress = value; }
        }

        public string Size
        {
            get { return _size; }
            set { _size = value; }
        }

        public string ResponsiblePersons
        {
            get { return _responsiblePersons; }
            set { _responsiblePersons = value; }
        }

        public List<string> Types
        {
            get { return _types; }
            set { _types = value; }
        }

        public List<string> OperatesIn
        {
            get { return _operatesIn; }
            set { _operatesIn = value; }
        }

        public string Registered
        {
            get { return _registered.ToString(); }
            set
            {
                if (value != "")
                    _registered = DateTime.ParseExact(value, "d/MM/yyyy", null);
                Console.WriteLine(_registered.ToString());
            }
        }

        public string Established
        {
            get { return _established.ToString(); }
            set
            {
                if (value != "")
                    _established = DateTime.ParseExact(value, "d/MM/yyyy", null);
            }
        }

        public string FinacialYearEnd
        {
            get { return _financialYearEnd.ToString(); }
            set
            {
                DateTime result;

                if (DateTime.TryParseExact(value, "d-MMM", null, DateTimeStyles.None, out result))
                {
                    _financialYearEnd = result;
                }
            }
        }
        public string ABN
        {
            get { return _abn; }
            set { _abn = value; }
        }

        public bool RegisteredOnACNC
        {
            get { return _registeredOnACNC; }
            set { _registeredOnACNC = value; }
        }

        public void RegisterAsUser(UserCharity userRegistration)
        {
            _userRegistration = userRegistration;
        }

        public void DeregisterAsUser()
        {
            _userRegistration = null;
        }

        public bool IsSame(string id)
        {
            return id == _id || id == _legalName;
        }

        public bool IsSimilar(string id)
        {
            return _legalName.Contains(id) || _otherNames.Contains(id);
        }
    }
}
