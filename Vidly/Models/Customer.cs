using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; //Namespace required to use Data Annotations
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please enter customer's name.")] //Adding a data annotation to make this field required.
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubsribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        public Byte MembershipTypeId { get; set; }


        [Display(Name = "Date of Birth")]
        [Min18YearsIfAMember]
        public DateTime? Birthday { get; set; }
    }
}