using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROI_Staff_Contact
{
    public class UserSet
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool lightOrDark { get; set; }
        public bool grayOrRed { get; set; }
        public int FontSize { get; set; }
    }
}
