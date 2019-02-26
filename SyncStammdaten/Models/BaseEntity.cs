using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncStammdaten.Models
{
    public class BaseEntity
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string Adress { get; set; }

        public bool IsDeleted { get; set; }
        public bool IsSynced { get; set; }
        public int Clock { get; set; }
    }
}
