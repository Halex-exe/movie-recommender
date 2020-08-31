using System.ComponentModel;

namespace MachineLearning.Models
{
    public class MovieModel
    {
        [DisplayName("User ID")]
        public float UserId { get; set; }

        [DisplayName("Movie ID")]
        public float MovieId { get; set; }

        public float Label;

        public double Ratings { get; set; }

        public bool IsRecommended { get; set; }
    }
}