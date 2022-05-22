using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PetStore.Common;

namespace PetStore.Models
{
    public class Address
    {
        public Address()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Clients = new HashSet<Client>();
            this.Stores = new HashSet<Store>();
            this.Sales = new HashSet<ProductSale>();
        }
        [Key]
        public string Id { get; set; }
        [Required]
        [MaxLength(AddressValidationConstants.TOWN_NAME_MAX_LENGTH)]
        public string TownName { get; set; }
        [Required]
        [MaxLength(AddressValidationConstants.ADDRESS_TEXT_MAX_LENGTH)]
        public string AddressText { get; set; }

        [MaxLength(AddressValidationConstants.NOTES_MAX_LENGTH)]
        public string Notes { get; set; }

        public virtual ICollection<Store> Stores { get; set; }
        public virtual ICollection<Client> Clients { get; set; }

        public virtual ICollection<ProductSale> Sales { get; set; }
    }
}