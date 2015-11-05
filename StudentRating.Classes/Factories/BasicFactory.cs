using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentRating.Classes.Interfaces;
using StudentRating.Classes.Repositories;
using StudentRating.Classes.RatingCalculators;

namespace StudentRating.Classes.Factories
{
    public class BasicFactory
    {
        public IRepository GetRepository()
        {
            return new FileRepository();
        }

        public IRatingCalculator GetCalculator()
        {
            return new HseRatingCalculator();
        }
    }
}
