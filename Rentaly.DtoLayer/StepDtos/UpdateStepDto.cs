using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentaly.DtoLayer.StepDtos
{
    public class UpdateStepDto
    {
        public int StepId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
