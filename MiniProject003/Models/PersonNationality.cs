using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniProject003.Models
{
    [Table("MiniProject003_PersonsNationalities")]
    public class PersonNationality
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Person")]
        public int? PersonId { get; set; }
        public Person? Person { get; set; }
        [DisplayName("Nationality")]
        public int? NationalityId { get; set; }
        public Nationality? Nationality { get; set; }
    }
}
