using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodingTest.Entity
{
    public class BaseEntity
    {
        [Key]
        public string Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public string CreatedById { get; set; }
        public string ModifiedById { get; set; }

        public virtual void InitiliazeData(string creator)
        {
            Id = Guid.NewGuid().ToString();
            CreatedById = creator;
            CreatedDate = DateTime.Now;
            ModifiedById = creator;
            ModifiedDate = DateTime.Now;
            IsActive = true;
        }
    }
}
