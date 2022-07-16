using FluentValidation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Rocky.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Name")]
        [Required]
        public string Name { get; set; }

        [DisplayName("Display Order")]
        [Required]
        [Range(1,int.MaxValue,ErrorMessage ="Display Order for category must be greater than 0")]
        public int DisplayOrder { get; set; }

        public class СategoryValidator : AbstractValidator<Category>
        {
            public СategoryValidator()
            {
                RuleFor(x => x.Id).NotNull();
                RuleFor(x => x.Name).Length(0, 20);
                RuleFor(x => x.DisplayOrder).NotNull();
            }
        }
    }
}
