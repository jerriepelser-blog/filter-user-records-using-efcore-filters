using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WeightRecorder.Data;

namespace WeightRecorder.Pages.Weight
{
    public class RecordModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;

        [Required]
        [BindProperty]
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }

        [Required]
        [BindProperty]
        public decimal? Weight { get; set; }

        public RecordModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            _dbContext.RecordedWeights.Add(new RecordedWeight
            {
                Date = Date.Value, Weight = Weight.Value, UserId = User.GetUserId()
            });
            await _dbContext.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
    
    
}
