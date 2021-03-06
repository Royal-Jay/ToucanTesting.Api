using System.Collections.Generic;
using System.Threading.Tasks;
using ToucanTesting.Models;

namespace ToucanTesting.Data
{
    public interface IExpectedResultRepository
    {
        Task<ExpectedResult> Get (long id);
        Task<List<ExpectedResult>> GetAll(long testCaseId);
        void Add (ExpectedResult expectedResult);

        void Update (ExpectedResult expectedResult);
        void Remove (ExpectedResult expectedResult);
    }
}