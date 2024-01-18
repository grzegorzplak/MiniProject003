using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniProject003.Models
{
    [Table("MiniProject003_Persons")]
    public class Person
    {
        public int Id { get; set; }
        [DisplayName("Person name")]
        public string PersonName { get; set; }
        public ICollection<PersonNationality>? PersonsNationalities { get; set; }
    }
}
