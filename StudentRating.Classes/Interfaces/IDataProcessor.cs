using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentRating.Classes.Domain;

namespace StudentRating.Classes.Interfaces
{
    public interface IDataProcessor
    {
        void Write(List<Grade> data);
        List<Grade> Read();
    }
}
