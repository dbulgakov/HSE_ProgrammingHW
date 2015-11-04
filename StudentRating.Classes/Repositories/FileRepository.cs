using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentRating.Classes.Interfaces;
using StudentRating.Classes.Domain;
using StudentRating.Classes.DataProcessors;

namespace StudentRating.Classes.Repositories
{
    public class FileRepository : IRepository
    {
        private List<Grade> _grades;
        private IList<Course> _courses;
        private int _gradeIdCounter;
        private XmlFileProcessor _fileprocessor;
        private string _filePath = "data.xml";

        public FileRepository()
        {
            _fileprocessor = new XmlFileProcessor(_filePath);
            try
            {
                _grades = _fileprocessor.Read();
                _courses = new List<Course>();
                _grades.ForEach(g => _courses.Add(g.Course));
            }
            catch
            {
                HandleIOException();
            }
            
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
            try
            {
                _fileprocessor.Write(_grades);
            }
            catch
            {
                HandleIOException();
            }
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

        private void HandleIOException()
        {
            if (_fileprocessor.Stream != null)
            {
                _fileprocessor.Stream.Close();
            }
            if (IOExceptionOccured != null)
            {
                IOExceptionOccured();
            }
        }
    }
}
