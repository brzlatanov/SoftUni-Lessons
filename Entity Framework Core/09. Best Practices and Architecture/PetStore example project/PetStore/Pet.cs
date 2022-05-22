using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PetStore.Common;
using PetStore.Models.Enumerations;

namespace PetStore.Models
{
    public class Pet
    {
        public Pet()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        [Key]
        public string Id { get; set; }
        [Required]
        [MaxLength(PetValidationConstants.NAME_MAXLENGTH)]
        public string Name { get; set; }
        public int Age { get; set; }

        [MaxLength(PetValidationConstants.DESCRIPTION_MAXLENGTH)]
        public string Description { get; set; }

        public Gender Gender { get; set; }
        [Required]
        [MaxLength(PetValidationConstants.URL_MAX_LENGTH)]
        public string ImageURL { get; set; }

        public decimal Price { get; set; }

        public bool IsSold { get; set; }
        [ForeignKey(nameof(PetType))]
        public int PetTypeId { get; set; }
        public virtual PetType PetType { get; set; }
        [ForeignKey(nameof(Breed))]
        public int BreedId { get; set; }
        public virtual Breed Breed { get; set; }
        [Required]
        [ForeignKey(nameof(Store))]
        public string StoreId { get; set; }
        public Store Store { get; set; }
        [ForeignKey(nameof(Reservation))]
        public string ReservationId { get; set; }
        public virtual PetReservation Reservation { get; set; }
    }
}
