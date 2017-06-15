using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;  

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]   /*need to add using System.ComponentModel.DataAnnotations; */
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }
        [Display(Name ="Date of Birth")] /*the proble of this approch each time you like to change lable you have to compile*/
        public DateTime? Birthdate { get; set; }
    }
}