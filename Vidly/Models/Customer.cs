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
        [Required(ErrorMessage ="Please Enter Customer Name")]   /*We override default message error validation */
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        [Min18YearsIfAMember]

        [Display(Name ="Date of Birth")] /*the proble of this approch each time you like to change lable you have to compile*/
        public DateTime? Birthdate { get; set; }
    }
}

//Data Annotations[Required]  
//        [StringLength(255)]
//         [Required]
//         [Range(1,10)]
//         [Compare("password")]
//         [Phone]
//         [EmailAddress]
//         [Url]
//         [RegularExpression("..")]
