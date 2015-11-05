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
