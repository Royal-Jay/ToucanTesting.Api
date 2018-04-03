using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace TucanTesting.Models
{
    public class TestIssue : BaseEntity
    {
        public long Id { get; set; }

        [Required]
        public long TestCaseId { get; set; }

        [Required]
        [StringLength(16)]
        [MinLength(3)]
        public string Reference { get; set; }

        [Required]
        [StringLength(255)]
        [MinLength(3)]
        public string Description { get; set; }
    }
}