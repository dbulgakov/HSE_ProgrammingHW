using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRating.Classes.Domain
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Credits { get; set; }

        public Course(string name, double credits)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Course name cannot be empty");
            if (credits <= 0)
                throw new ArgumentException("Credits for the course should be a positive number");
            Name = name;
            Credits = credits;
        }

        public override bool Equals(object obj)
        {
            Course course = obj as Course;
            if (course == null)
                return false;
            else
                return Name.Equals(course.Name);
        }
    }
}
