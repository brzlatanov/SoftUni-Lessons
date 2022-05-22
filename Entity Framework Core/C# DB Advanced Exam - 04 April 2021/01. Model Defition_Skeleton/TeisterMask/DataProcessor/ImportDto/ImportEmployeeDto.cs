using System.ComponentModel.DataAnnotations;
using TeisterMask.Common;

namespace TeisterMask.DataProcessor.ImportDto
{
    public class ImportEmployeeDto
    {
        [Required]
        [MinLength(CommonConstants.USERNAME_MIN_LENGTH)]
        [MaxLength(CommonConstants.USERNAME_MAX_LENGTH)]
        [RegularExpression(CommonConstants.USERNAME_VALIDATION_REGEX)]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression(CommonConstants.PHONE_VALIDATION_REGEX)]
        public string Phone { get; set; }

        public int[] Tasks { get; set; }
    }
}