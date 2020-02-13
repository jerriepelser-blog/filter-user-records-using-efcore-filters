using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WeightRecorder.Data;

namespace WeightRecorder.Pages.Weight
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;

        public List<RecordedWeight> Weights { get; set; }

        public IndexModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task OnGetAsync()
        {
            Weights = await _dbContext.RecordedWeights
                .OrderByDescending(w => w.Date)
                .ToListAsync();
        }
    }
}
