using SQLite;

namespace ROI_Staff_Contact
{
    public class Staff
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public int Department { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZIP { get; set; }
        public string Country { get; set; }

    }
}
