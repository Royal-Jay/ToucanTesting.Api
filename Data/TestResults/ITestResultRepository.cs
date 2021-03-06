using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToucanTesting.Models;

namespace ToucanTesting.Data
{
    public interface ITestResultRepository
    {
        Task<TestResult> Get (long id);
        Task<List<TestResult>> GetAll(long testRunId);
        void Add (TestResult testResult);
        void Update(TestResult testResult);
        void UpdateTestRun(long testRunId);
    }
}