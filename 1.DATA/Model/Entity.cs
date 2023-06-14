using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DATA.Model
{
    public class Entity
    {
        public Guid Id { get; set; }
        public Guid CreateByUserId { get; set; }
        public Guid? UpdateByUserId { get; set; }
        public Guid? DeleteByUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool? isDelete { get; set; }
    }
}
