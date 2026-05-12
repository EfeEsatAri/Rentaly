using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentaly.DtoLayer.CarModelDtos
{
    public class CreateCarModelDto
    {
        public string ModelName { get; set; }
        public int BrandId { get; set; }
    }
}
