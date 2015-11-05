using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            foreach (var g in grades)
            {
                rating += g.Mark * g.Course.Credits;
            }
            return rating;
        }
    }
}
