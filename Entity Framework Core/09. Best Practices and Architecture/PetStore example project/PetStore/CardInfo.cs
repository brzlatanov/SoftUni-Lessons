using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PetStore.Common;

namespace PetStore.Models
{
    public class CardInfo
    {
        public CardInfo()
        {
            this.Id = Guid.NewGuid().ToString();
            this.ProductSales = new HashSet<ProductSale>();
        }
        [Key]
        public string Id { get; set; }
        [Required]
        [MaxLength(CardInfoValidationConstants.CARD_NUMBER_MAX_LENGTH)]
        public string CardNumber { get; set; }

        [Required]
        [MaxLength(CardInfoValidationConstants.CARD_HOLDER_MAX_LENGTH)]
        public string CardHolderName { get; set; }
        [Required]
        [MaxLength(CardInfoValidationConstants.EXPIRATION_DATE_MAX_LENGTH)]
        public string ExpirationDate { get; set; }
        [Required]
        [MaxLength(CardInfoValidationConstants.CVC_MAX_LENGTH)]
        public string CVC { get; set; }
        [Required]
        [ForeignKey(nameof(Owner))]
        public string ClientId { get; set; }
        public virtual Client Owner { get; set; }

        public ICollection<ProductSale> ProductSales { get; set; }

    }
}