using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateSystem.Common
{
    public  class EntityValidationConsatnts
    {

        public static class Agent
        {
            public const int PhoneNumberMinLength = 7;
            public const int PhoneNumberMaxLength = 15;
        }

        public static class Hause
        {

            public const int TitleMinLength = 10;
            public const int TitleMaxLength = 50;

            public const int AddressMinLength = 30;
            public const int AddressMaxLength = 150;

            public const int DescriptionMinLength = 50;
            public const int DescriptionMaxLength = 500;

            

            public const string PricePerMonthMinLength = "0";
            public const string PricePerMonthMaxLength = "2000";

        
        
        
        }

        public static class Category
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 50;
        }

        public static class ApplicationUser
        {
            public const int FirstNameMinLength = 3;
            public const int FirstNameMaxLength = 20;

            public const int LastNameMinLength = 3;
            public const int LastNameMaxLength = 20;
        }




    }
}
