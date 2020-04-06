using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {

            if (Students.Count < 5)
            {

                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            }

            foreach (var student in Students)
            {
                Students.OrderByDescending(g => g.AverageGrade);
                var num = Students.Where(f => f.AverageGrade > averageGrade).Count();
                if (num == 0)
                    return 'A';
                else if (num == 1)
                    return 'B';
                else if (num == 2)
                    return 'C';
                else if (num == 3)
                    return 'D';
            }

            return 'F';

        }

    }
}
