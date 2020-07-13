using System;

namespace CreditCardEligibilityCheckerAPI.HelperClasses
{
    public static class AgeConverter
    {
        /// <summary>  
        /// For calculating age based on the date of birth provided  
        /// </summary>  
        /// <param name="dateOfBirth">Date of birth</param>  
        /// <returns> age e.g. 26</returns>  
        public static int CalculateAge(string dob)
        {
            try {
                DateTime dateOfBirth = Convert.ToDateTime(dob); //"1988/12/20"
                int age = 0;
                age = DateTime.Now.Year - dateOfBirth.Year;
                if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
                    age = age - 1;

                return age;
            }
            catch
            {
                throw;
            }
            
        }
    }
}
