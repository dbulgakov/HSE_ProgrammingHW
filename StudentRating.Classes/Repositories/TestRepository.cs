using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentRating.Classes.Interfaces;
using StudentRating.Classes.Domain;

namespace StudentRating.Classes.Repositories
{
    public class TestRepository : IRepository
    {
        List<Grade> _grades;
        List<Course> _courses;

        public TestRepository()
        {
            _courses = new List<Course>()
            {
                new Course("Programming", 4.15),
                new Course("Geometry and algebra", 2),
                new Course("Theoretical bases of informatics", 3.9)
            };

            _grades = new List<Grade>()
            {
                new Grade(_courses[0], 7),
                new Grade(_courses[1], 5),
                new Grade(_courses[2], 10)
            };

        }

        public List<Grade> Grades
        {
            get { return _grades;}
        }

        public List<Course> Courses
        {
            get { return _courses;}
        }

        public event Action GradesChanged;

        public void AddGrade(Grade grade)
        {
            /*
            The Id property for a new item should be set in the \AddGrade"
              method in such a way that no two items in the list have the same Id.
            */
            CheckGrage(grade);
            _grades.Add(grade);
            Save();
            GradesChanged();
        }

        public void EditGrade(Grade grade)
        {
            CheckGrage(grade);
 	        throw new NotImplementedException();
            Save();
            GradesChanged();
        }

        public void RemoveGrade(Predicate<Grade> p)
        {
 	        _grades.RemoveAll(p);
            Save();
            GradesChanged();
        }

        public void Save()
        {
        }

        private void CheckGrage(Grade grade)
        {
            if (grade == null)
            {
                throw new ArgumentNullException();
            }
            if (_grades.Any(g => g.Equals(grade)))
            {
                throw new ArgumentException();
            }
        }
    }
}
