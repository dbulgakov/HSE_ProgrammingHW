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
        private List<Course> _courses;
        private int _gradeIdCounter;
        private XmlFileProcessor _fileprocessor;
        private string _filePath = "data.xml";

        public FileRepository()
        {
            _fileprocessor = new XmlFileProcessor(_filePath);
            _grades = _fileprocessor.Read();
            _courses = new List<Course>();
            _grades.ForEach(g => _courses.Add(g.Course));
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
            _fileprocessor.Write(_grades);
        }
    }
}
