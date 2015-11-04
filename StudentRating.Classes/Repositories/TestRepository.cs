using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentRating.Classes.Interfaces;

namespace StudentRating.Classes.Repositories
{
    class TestRepository : IRepository
    {
        public List<Domain.Grade> Grades
        {
	        get { throw new NotImplementedException(); }
        }

        public List<Domain.Course> Courses
        {
	        get { throw new NotImplementedException(); }
        }

        public event Action GradesChanged;

        public void AddGrade(Domain.Grade grade)
        {
 	        throw new NotImplementedException();
        }

        public void EditGrade(Domain.Grade grade)
        {
 	        throw new NotImplementedException();
        }

        public void RemoveGrade(Predicate<Domain.Grade> p)
        {
 	        throw new NotImplementedException();
        }

        public void Save()
        {
 	        throw new NotImplementedException();
        }
    }
}
