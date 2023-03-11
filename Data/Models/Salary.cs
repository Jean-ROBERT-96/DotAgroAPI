using System.Runtime.CompilerServices;

namespace DotAgroAPI.Data.Models
{
    public class Salary
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Gender { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string Image { get; set; }
        public int IdService { get; set; }
        public int IdHeadquarter { get; set; }
        public virtual Service IdServiceNavigation { get; set; }
        public virtual Headquarter IdHeadquarterNavigation { get; set; }
    }
}
