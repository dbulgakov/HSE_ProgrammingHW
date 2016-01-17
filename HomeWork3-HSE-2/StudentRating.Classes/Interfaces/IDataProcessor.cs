using System.Collections.Generic;
using StudentRating.Classes.Domain;

namespace StudentRating.Classes.Interfaces
{
    public interface IDataProcessor
    {
        void Write(List<Grade> data);
        List<Grade> Read();
    }
}
