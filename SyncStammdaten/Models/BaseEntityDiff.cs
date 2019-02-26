using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncStammdaten.Models
{
    public class BaseEntityDiff
    {
        [Key]
        public string Id { get; set; }
        public int Clock { get; set; }
        public string Json { get; set; }
    }
}
