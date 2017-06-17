using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }

        public static readonly byte Unknown = 0;  //if user not choose default value=0 refactoring magic Number as UnKnown we use it in Min18YearsIfAMember model
        public static readonly byte PayAsYouGo = 1; //if user chhose paytogo  value=1 refactoring magic Number as PayAsYouGo we use it in Min18YearsIfAMember model

    }
}