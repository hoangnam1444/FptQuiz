using System.ComponentModel.DataAnnotations;

namespace FptQuiz.Model
{
    public class MajorResult
    {
        [Key]
        public string MResultID { get; set; }
        public string ResultID { get; set; }
        public string MajorID { get; set; }
        public MajorResult()
        {

        }
    }
}
