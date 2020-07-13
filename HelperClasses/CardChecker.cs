using System;
using static CreditCardEligibilityCheckerAPI.Enum.EnumTypes;

namespace CreditCardEligibilityCheckerAPI.HelperClasses
{
    public class CardChecker
    {
        /// <summary>
        /// Logic to retrieve card type based on Age and annaul income of the customer
        /// </summary>
        /// <param name="age"></param>
        /// <param name="annualIncome"></param>
        /// <returns></returns>
        public static string GetCardType(int age, int annualIncome)
        {
            try
            {
                if (age > 18 && annualIncome > 30000)
                    return Convert.ToString(CardType.BAR);
                return Convert.ToString(CardType.VAN);
            }
            catch
            {
                throw;
            }
            
        }
    }
}
