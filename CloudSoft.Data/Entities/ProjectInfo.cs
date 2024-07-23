using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSoft.Data.Entities
{
    public class ProjectInfo
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }
        public List<ExtensionsName> Extensions { get; set; }
    }
}
