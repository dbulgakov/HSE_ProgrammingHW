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
        private List<Grade> _grades;
        private IList<Course> _courses;
        private int _gradeIdCounter;

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

            _gradeIdCounter = 0;
        }

        public List<Grade> Grades
        {
            get { return _grades;}
        }

        public IList<Course> Courses
        {
            get { return _courses;}
        }

        public event Action GradesChanged;
        public event Action IOExceptionOccured;

        public void AddGrade(Grade grade)
        {
            CheckGrade(grade);
            if (_grades.Any(g => g.Equals(grade)))
            {
                throw new ArgumentException();
            }

            grade.Id = _gradeIdCounter++;
            _grades.Add(grade);
            Save();
            GradesChangedRun();
        }

        public void EditGrade(Grade grade)
        {
            CheckGrade(grade);
            int tmpIndex = _grades.FindIndex(g => g.Course.Equals(grade.Course));
            _grades[tmpIndex] = grade;
            Save();
            GradesChangedRun();
        }

        public void RemoveGrade(Predicate<Grade> p)
        {
 	        _grades.RemoveAll(p);
            Save();
            GradesChangedRun();
        }

        public void Save()
        {
        }

        private void CheckGrade(Grade grade)
        {
            if (grade == null)
            {
                throw new ArgumentNullException();
            }
        }

        private void GradesChangedRun() 
        {
            if (GradesChanged != null)
            {
                GradesChanged();
            }
        }
    }
}
