using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PetStore.Common;

namespace PetStore.Models
{
    public class Client
    {
        public Client()
        {
            this.Id = Guid.NewGuid().ToString();
            this.PetReservations = new HashSet<PetReservation>();
            this.ProductSales = new HashSet<ProductSale>();
        }
        [Key]
        public string Id { get; set; }
        [Required]
        [MaxLength(ClientValidationConstants.NAME_MAX_LENGTH)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(ClientValidationConstants.NAME_MAX_LENGTH)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(ClientValidationConstants.EMAIL_MAX_LENGTH)]
        public string Email { get; set; }
        [Required]
        [MaxLength(ClientValidationConstants.PASSWORD_MAX_LENGTH)]
        public string Password { get; set; }
        [Required]
        [MaxLength(ClientValidationConstants.PHONE_NUMBER_MAX_LENGTH)]
        public string PhoneNumber { get; set; }
        
        [ForeignKey(nameof(Address))]
        public string AddressId { get; set; }
        public virtual Address Address { get; set; }
        [ForeignKey(nameof(Card))]
        public string CardId { get; set; }
        public virtual CardInfo Card { get; set; }
        public virtual ICollection<PetReservation> PetReservations { get; set; }

        public virtual ICollection<ProductSale> ProductSales { get; set; }

        
    }
}