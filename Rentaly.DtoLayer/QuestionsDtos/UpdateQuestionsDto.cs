using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentaly.DtoLayer.QuestionsDtos
{
    public class UpdateQuestionsDto
    {
        public int QuestionsId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
