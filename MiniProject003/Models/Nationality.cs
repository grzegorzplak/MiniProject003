using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniProject003.Models
{
    [Table("MiniProject003_Nationalities")]
    public class Nationality
    {
        public int Id { get; set; }
        [DisplayName("Nationality name")]
        public string NationalityName { get; set; }
        public ICollection<PersonNationality>? PersonsNationalities { get; set; }
    }
}
