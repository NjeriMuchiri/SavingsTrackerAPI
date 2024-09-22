using Microsoft.AspNetCore.Mvc;
using SavingsTrackerAPI.Models;

namespace SavingsTrackerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SavingsPlanController : ControllerBase
    {
        private static List<SavingsPlan> savingsPlans = new List<SavingsPlan>();

        public SavingsPlanController()
        {
            if (savingsPlans.Count == 0)
            {
                decimal CumulativeBalance = 0;

                for (int i = 1; i <= 52; i++)
                {
                    decimal deposit = i <= 18 ? 50 * i : 50 * i; // Simplified logic
                    CumulativeBalance += deposit;

                    savingsPlans.Add(new SavingsPlan
                    {
                        Week = i,
                        Deposit = deposit, // Simplified logic
                        Balance = CumulativeBalance,
                        IsChecked = false
                    });
                }
            }
        }
       // GET: api/savingsplan
        [HttpGet]
        public IActionResult GetSavingsPlans()
        {
            return Ok(savingsPlans);
        }

        // PUT: api/savingsplan/{week}
        [HttpPut("{week}")]
        public IActionResult UpdateSavingsPlan(int week, [FromBody] SavingsPlan plan)
        {
            var existingPlan = savingsPlans.Find(p => p.Week == week);
            if (existingPlan == null)
            {
                return NotFound();
            }

            existingPlan.IsChecked = plan.IsChecked;
            return Ok(existingPlan);
        }
    }
}
