using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRating.Classes.Domain
{
    public class Grade
    {
        public int Id { get; set; }
        public Course Course { get; set; }
        public int Mark { get; set; }

        public Grade()
        {
            Course = null;
            Mark = 0;
        }

        public Grade(Course course, int mark)
        {
            Course = course;
            Mark = mark;
        }

        public override bool Equals(object obj)
        {
            var grade = obj as Grade;
            if (grade == null)
                return false;
            else
                return Course == grade.Course;
        }
    }
}
