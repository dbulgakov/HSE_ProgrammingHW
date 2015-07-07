using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2
{
    public class Score
    {
        /// <summary>
        /// Initializes a new instance of the Score class
        /// </summary>
        /// <param name="firstScore">Score of the first opponent</param>
        /// <param name="secondScore">Score of the second opponent</param>
        /// 
        public Score(int firstScore, int secondScore)
        {
            _firstOpponent = firstScore;
            _secondOpponent = secondScore;
        }
        /// <summary>
        /// Initializes a new instance of the Score class
        /// </summary>
        public Score()
            :this(0, 0)
        {}

        private int _firstOpponent;

        /// <summary>
        /// Gets score of the first opponent
        /// </summary>
        public int FirstOpponent
        {
            get { return _firstOpponent; }
            set { _firstOpponent = value; }
        }

        private int _secondOpponent;

        /// <summary>
        /// Gets score of the second opponent
        /// </summary>
        public int SecondOpponent
        {
            get { return _firstOpponent; }
            set { _firstOpponent = value; }
        }

        public override string ToString()
        {
            return string.Format("{0}:{1}", _firstOpponent, _secondOpponent);
        }
    }
}
