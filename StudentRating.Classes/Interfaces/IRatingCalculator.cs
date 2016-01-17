using System.Collections.Generic;
using StudentRating.Classes.Domain;

namespace StudentRating.Classes.Interfaces
{
    public interface IRatingCalculator
    {
        double CalculateRating(IEnumerable<Grade> grades);
    }
}
