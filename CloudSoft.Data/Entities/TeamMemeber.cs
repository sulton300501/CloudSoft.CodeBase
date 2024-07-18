using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSoft.Data.Entities
{
    public class TeamMemeber
    {
        public long Id { get; set; }
        public short Age { get; set; }
        public long MemberRoleId { get; set; }
        public string Description { get; set; }
        public string PicturePath { get; set; }
        public MemberRole MemberRole { get; set; }

    }
}
