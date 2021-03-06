using ToucanTesting.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ToucanTesting.Data
{
    public class TestConditionRepository : ITestConditionRepository
    {
        private readonly ToucanDbContext _context;
        public TestConditionRepository(ToucanDbContext context)
        {
            this._context = context;
        }

        public async Task<TestCondition> Get(long id)
        {
            return await _context.TestConditions.SingleOrDefaultAsync(a => a.Id == id);
        }

        public async Task<List<TestCondition>> GetAll(long testCaseId)
        {
            return await _context.TestConditions
                .Where(c => c.TestCaseId == testCaseId)
                .ToListAsync();
        }

        public void Add(TestCondition testCondition)
        {
            _context.TestConditions.Add(testCondition);
        }

        public void Update(TestCondition testCondition)
        {
            _context.TestConditions.Update(testCondition);
        }


        public void Remove(TestCondition testCondition)
        {
            _context.TestConditions.Remove(testCondition);
        }
    }
}