using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime? CreateAt { get; set; }
        public int CreateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public int? UpdateBy { get; set; }
    }
}
