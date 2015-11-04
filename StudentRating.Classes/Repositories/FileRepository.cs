using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentRating.Classes.Interfaces;
using StudentRating.Classes.Domain;

namespace StudentRating.Classes.Repositories
{
    class FileRepository : IRepository
    {
        public List<Grade> Grades
        {
            get { throw new NotImplementedException(); }
        }

        public List<Course> Courses
        {
            get { throw new NotImplementedException(); }
        }

        public event Action GradesChanged;

        public void AddGrade(Grade grade)
        {
            throw new NotImplementedException();
        }

        public void EditGrade(Grade grade)
        {
            throw new NotImplementedException();
        }

        public void RemoveGrade(Predicate<Grade> p)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
