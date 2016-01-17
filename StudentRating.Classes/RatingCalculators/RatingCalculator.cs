using System.Collections.Generic;
using StudentRating.Classes.Interfaces;
using StudentRating.Classes.Domain;

namespace StudentRating.Classes.RatingCalculators
{
    public class RatingCalculator : IRatingCalculator
    {
        public double CalculateRating(IEnumerable<Grade> grades)
        {
            double rating = 0;
            if (grades == null) return rating;
            foreach (var g in grades)
            {
                rating += g.Mark;
            }
            return rating;
        }
    }
}
