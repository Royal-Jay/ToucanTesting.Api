using ToucanTesting.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ToucanTesting.Data
{
    public class TestActionRepository : ITestActionRepository
    {
        private readonly ToucanDbContext _context;
        public TestActionRepository(ToucanDbContext context)
        {
            this._context = context;
        }

        public async Task<TestAction> Get(long id)
        {
            return await _context.TestActions.SingleOrDefaultAsync(a => a.Id == id);
        }

        public async Task<List<TestAction>> GetAll(long testCaseId)
        {
            return await _context.TestActions
                .Where(a => a.TestCaseId == testCaseId)
                .OrderBy(a => a.Sequence)
                .ToListAsync();
        }

        public void Add(TestAction testAction)
        {
            _context.TestActions.Add(testAction);
        }

        public void Update(TestAction testAction)
        {
            _context.TestActions.Update(testAction);
        }


        public void Remove(TestAction testAction)
        {
            _context.TestActions.Remove(testAction);
        }
    }
}