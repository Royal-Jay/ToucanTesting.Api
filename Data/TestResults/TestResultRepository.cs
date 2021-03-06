using ToucanTesting.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using ToucanTesting.Controllers.TestCases;
using System;

namespace ToucanTesting.Data
{
    public class TestResultRepository : ITestResultRepository
    {
        private readonly ToucanDbContext _context;
        public TestResultRepository(ToucanDbContext context)
        {
            this._context = context;
        }

        public async Task<TestResult> Get(long id)
        {
            return await _context.TestResults.SingleOrDefaultAsync(r => r.Id == id);
        }

        public async Task<List<TestResult>> GetAll(long testRunId)
        {
            return await _context.TestResults.Where(r => r.TestRunId == testRunId).ToListAsync();
        }

        public void Add(TestResult testResult)
        {
            _context.TestResults.Add(testResult);
            UpdateTestRun(testResult.TestRunId);
        }

        public void Update(TestResult testResult)
        {
            _context.TestResults.Update(testResult);
            UpdateTestRun(testResult.TestRunId);
        }

        public async void UpdateTestRun(long testRunId)
        {
            var testRun = await _context.TestRuns.Where(tr => tr.Id == testRunId).SingleOrDefaultAsync();
            testRun.UpdatedAt = DateTime.UtcNow;
            _context.TestRuns.Update(testRun);
        }
    }
}