using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace HomeWork2
{
    [DataContract]
    class TennisMatch:Match
    {
        /// <summary>
        /// Initializes a new instance of the TennisMatch class 
        /// </summary>
        /// <param name="date">Match date</param>
        /// <param name="matchScore">Match score</param>
        /// <param name="firstPlayerName">First player name</param>
        /// <param name="secondPlayerName">Second player name</param>
        public TennisMatch(DateTime date, Score matchScore, string firstPlayerName, string secondPlayerName)
            : base(date, matchScore)
        {
            _firstPlayerName = firstPlayerName;
            _secondPlayerName = secondPlayerName;
        }

        /// <summary>
        /// Initializes a new instance of the TennisMatch class
        /// </summary>
        /// <param name="date">Match date</param>
        /// <param name="matchScore">Match score</param>
        /// <param name="id">Initial instance id</param>
        /// <param name="firstPlayerName">First player name</param>
        /// <param name="secondPlayerName">Second player name</param>
        public TennisMatch(DateTime date, Score matchScore, int id, string firstPlayerName, string secondPlayerName)
            : base(date, matchScore, id)
        {
            _firstPlayerName = firstPlayerName;
            _secondPlayerName = secondPlayerName;
        }

        [DataMember]
        private string _firstPlayerName;
        
        /// <summary>
        /// Gets the name of the first player
        /// </summary>
        public string FirstPlayerName
        {
            get { return _firstPlayerName; }
            set { _firstPlayerName = value; }
        }

        [DataMember]
        private string _secondPlayerName;

        /// <summary>
        /// Gets name of the second player
        /// </summary>
        public string SecondPlayerName
        {
            get { return _secondPlayerName; }
            set { _secondPlayerName = value; }
        }

        public override string ToString()
        {
            return String.Format("{0} Теннисный матч {1} против {2} Счет {3}", base.ToString(), _firstPlayerName, _secondPlayerName, MatchScore);
        }
    }
}
