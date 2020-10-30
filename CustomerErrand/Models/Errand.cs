using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CustomerErrand.Models
{
    public partial class Errand
    {
        public Errand(string description, DateTime creationTime, string customerFullName, string customerEmail, int? customerPhoneNr, string status, string category)
        {
            Description = description;
            CreationTime = creationTime;
            CustomerFullName = customerFullName;
            CustomerEmail = customerEmail;
            CustomerPhoneNr = customerPhoneNr;
            Status = status;
            Category = category;
        }

        public Errand()
        {

        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(500)]
        public string Description { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationTime { get; set; }
        [Required]
        [StringLength(100)]
        public string CustomerFullName { get; set; }
        [Required]
        [StringLength(100)]
        public string CustomerEmail { get; set; }
        public int? CustomerPhoneNr { get; set; }
        [Required]
        [StringLength(20)]
        public string Status { get; set; }
        [Required]
        [StringLength(20)]
        public string Category { get; set; }
    }
}
