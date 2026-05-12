using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Rentaly.EntityLayer.Entities
{
    public class Questions
    {
        public int QuestionsId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
