using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationTracker.Model
{
    public class CharityClassMap : ClassMap<Charity>
    {
        private List<string> _addressColumns;
        private List<string> _operatesInColumns;
        private List<string> _typesColumns;
        public CharityClassMap()
        {
            _addressColumns = new List<string> { "Address_Line_1", "Address_Line_2", "Address_Line_3", "Town_City", "State", "Postcode", "Country" };
            _operatesInColumns = new List<string> { "Operates_in_ACT", "Operates_in_NSW", "Operates_in_NT", "Operates_in_QLD", "Operates_in_SA",
                "Operates_in_TAS", "Operates_in_VIC", "Operates_in_WA" };
            _typesColumns = new List<string> { "PBI", "HPC", "Preventing_or_relieving_suffering_of_animals", "Advancing_Culture", "Advancing_Education",
                "Advancing_Health", "Promote_or_oppose_a_change_to_law__government_poll_or_prac", "Advancing_natual_environment",
                "Promoting_or_protecting_human_rights", "Purposes_beneficial_to_ther_general_public_and_other_analogous",
                "Promoting_reconciliation__mutual_respect_and_tolerance", "Advancing_Religion", "Advancing_social_or_public_welfare",
                "Advancing_security_or_safety_of_Australia_or_Australian_public", "Aboriginal_or_TSI", "Adults", "Aged_Persons", "Children",
                "Communities_Overseas", "Early_Childhood", "Ethnic_Groups", "Families", "Females", "Financially_Disadvantaged",
                "General_Community_in_Australia", "Males", "Migrants_Refugees_or_Asylum_Seekers", "Other_Beneficiaries", "Other_Charities",
                "People_at_risk_of_homelessness", "People_with_Chronic_Illness", "People_with_Disabilities", "Pre_Post_Release_Offenders",
                "Rural_Regional_Remote_Communities", "Unemployed_Person", "Veterans_or_their_families", "Victims_of_crime", "Victims_of_Disasters", "Youth" };

            // Map column names to Charity properties
            Map(m => m.Id).Name("ID");
            Map(m => m.LegalName).Name("Charity_Legal_Name");
            Map(m => m.OtherNames).Name("Other_Organisation_Names");
            Map(m => m.Website).Name("Charity_Website");
            Map(m => m.Size).Name("Charity_Size");
            Map(m => m.ResponsiblePersons).Name("Number_of_Responsible_Persons");
            Map(m => m.Registered).Name("Registration_Date");
            Map(m => m.Established).Name("Date_Organisation_Established");
            Map(m => m.FinacialYearEnd).Name("Financial_Year_End");
            Map(m => m.ABN).Name("ABN");

            Map(m => m.RegisteredAddress).Convert(args => (List<string>)_addressColumns
               .Select(column => args.Row.GetField<string>(column)).ToList());

            Map(m => m.OperatesIn).Convert(row => (List<string>)_operatesInColumns
               .Select(column => row.Row.GetField<string>(column)).ToList());

            Map(m => m.Types).Convert(row => (List<string>)_typesColumns
               .Select(column => row.Row.GetField<string>(column)).ToList());
        }
    }
}
