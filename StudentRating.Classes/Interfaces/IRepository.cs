using System;
using System.Collections.Generic;
using StudentRating.Classes.Domain;

namespace StudentRating.Classes.Interfaces
{
    public interface IRepository
    {
        List<Grade> Grades { get; }
        IList<Course> Courses { get; }

        event Action GradesChanged;
        event Action IOExceptionOccured;

        void AddGrade(Grade grade);
        void EditGrade(Grade grade);
        void RemoveGrade(Predicate<Grade> p);

        void Save();
    }
}
