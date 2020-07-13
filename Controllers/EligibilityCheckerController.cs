using System;
using System.Linq;
using System.Threading.Tasks;
using CreditCardEligibilityCheckerAPI.Data;
using CreditCardEligibilityCheckerAPI.HelperClasses;
using CreditCardEligibilityCheckerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace CreditCardEligibilityCheckerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EligibilityCheckerController : ControllerBase
    {
        private readonly CardDataContext _cardDataContext;

        /// <summary>
        /// Initializes a new instance of the dabase context.
        /// </summary>
        /// <param name="cardDataContext"></param>
        public EligibilityCheckerController(CardDataContext cardDataContext)
        {
            _cardDataContext = cardDataContext;
        }

        /// <summary>
        /// GetCardType method takes input parameters entererd by customer and gives the appropriate car
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="dob"></param>
        /// <param name="annualIncome"></param>
        /// <returns></returns>
        [HttpGet("{firstName}/{lastName}/{dob}/{annualIncome}")]
        public async Task<ActionResult<CreditCardType>> GetCardType(string firstName, string lastName, string dob, int annualIncome)
        {
            try
            {
                //Convert DateOfBirth conversion to Date type 
                var dateofBirth = DateTime.Parse(dob).ToString("MM/dd/yyyy");

                //Calculate the age of the customer
                var customerAge = AgeConverter.CalculateAge(dateofBirth);

                //Get the eligible card type based on Customer Input
                var card = CardChecker.GetCardType(customerAge, annualIncome);

                //Get the card type based on Customer Input
                var creditCardType = await _cardDataContext.CreditCardType.Where(a => a.CardId == card).FirstOrDefaultAsync();
                if (creditCardType != null)
                {
                    //Store the customer details in Audit table with along with the resultant cardtype shown
                    var auditDetails = new Audit()
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        DOB = dateofBirth,
                        AnnualIncome = annualIncome,
                        CardId = creditCardType.CardId,
                        CreatedDateTime = DateTime.UtcNow
                    };
                    await _cardDataContext.CreditCardAudit.AddAsync(auditDetails);
                    _cardDataContext.SaveChanges();
                }
                return creditCardType;
            }
            catch(Exception ex)
            {
                return Ok(NotFound());
            }
            
        }

    }
}
