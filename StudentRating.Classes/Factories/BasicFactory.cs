using StudentRating.Classes.Interfaces;
using StudentRating.Classes.Repositories;
using StudentRating.Classes.RatingCalculators;

namespace StudentRating.Classes.Factories
{
    public enum RepositoryType
    {
        TESTREPOSITORY,
        FILEREPOSITORY
    }

    public enum CalculatorType
    {
        RATINGCALCULATOR,
        HSERATINGCALCULATOR
    }

    public class BasicFactory
    {
        public IRepository GetRepository(RepositoryType type)
        {
            IRepository r = null;
            switch (type)
            {
                case RepositoryType.TESTREPOSITORY:
                    r = new TestRepository();
                    break;
                case RepositoryType.FILEREPOSITORY:
                    r = new FileRepository();
                    break;
                default:
                    r = new TestRepository();
                    break;
            }
            return r;
        }

        public IRatingCalculator GetCalculator(CalculatorType type)
        {
            IRatingCalculator c = null;
            switch (type)
            {
                case CalculatorType.RATINGCALCULATOR:
                    c = new RatingCalculator();
                    break;
                case CalculatorType.HSERATINGCALCULATOR:
                    c = new HseRatingCalculator();
                    break;
                default:
                    c = new RatingCalculator();
                    break;
            }
            return c;
        }
    }
}
