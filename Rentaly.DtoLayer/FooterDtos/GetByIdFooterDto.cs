using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentaly.DtoLayer.FooterDtos
{
    public class GetByIdFooterDto
    {
        public int FooterId { get; set; }
        public string About { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
