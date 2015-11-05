using System.Collections.Generic;
using System.Linq;
using StudentRating.Classes.Interfaces;
using StudentRating.Classes.Domain;

namespace StudentRating.Classes.RatingCalculators
{
    public class HSE_RatingCalculator : IRatingCalculator
    {
        public double CalculateRating(IEnumerable<Grade> grades)
        {
            double rating = 0;
            if (grades == null) return rating;
            return grades.Sum(g => g.Mark*g.Course.Credits);
        }
    }
}
