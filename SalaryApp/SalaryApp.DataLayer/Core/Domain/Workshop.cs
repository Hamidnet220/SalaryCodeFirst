using System.ComponentModel.DataAnnotations;

namespace SalaryApp.DataLayer.Core.Domain
{
    public class Workshop
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        [VerboseName("عنوان کارگاه")]
        public string Title { get; set; }

        [VerboseName("آدرس کارگاه")]
        public string Address { get; set; }

        [VerboseName("تلفن کارگاه")]
        public string Tel { get; set; }
    }
}