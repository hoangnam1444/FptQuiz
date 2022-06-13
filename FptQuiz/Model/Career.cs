using System.ComponentModel.DataAnnotations;

namespace FptQuiz.Model
{
    public class Career
    {
        [Key]
        public string CareerID { get; set; }
        public string CareerName { get; set; }
        public string MajorID { get; set; }
    }
}
