using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace ToucanTesting.Models
{
    public class TestModule : BaseEntity
    {
        public long Id { get; set; }
        [Required]
        public long TestSuiteId { get; set; }
        [Required]
        [StringLength(255)]
        [MinLength(3)]
        public string Name { get; set; }
        [Required]
        public bool IsEnabled { get; set; }
        public ICollection<TestCase> TestCases { get; set; }
        public TestModule()
        {
            TestCases = new Collection<TestCase>();
        }
    }
}