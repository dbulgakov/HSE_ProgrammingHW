using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;


namespace HomeWork2
{
    [DataContract]
    [KnownType(typeof(FootballMatch))]
    [KnownType(typeof(TennisMatch))]
    public class Match
    {
        /// <summary>
        /// Initializes a new instance of the Match class
        /// </summary>
        /// <param name="date">Match date</param>
        /// <param name="matchScore">Match score</param>
        public Match(DateTime date, Score matchScore)
        {
            _matchDate = date;
            _id = objectCounter;
            objectCounter++;
            _matchScore = matchScore;
        }

        /// <summary>
        /// Initializes a new instance of the Match class
        /// </summary>
        /// <param name="date">Match date</param>
        /// <param name="matchScore">Match score</param>
        /// <param name="id">Initial instance id</param>
        public Match(DateTime date, Score matchScore, int id)
        {
            if (objectCounter <= id)
            {
                objectCounter = ++id;
            }
            _matchDate = date;
            _id = objectCounter;
            objectCounter++;
            _matchScore = matchScore;
        }

        private static int objectCounter = 1;
        
        [DataMember]
        private int _id;

        /// <summary>
        /// Gets objetct's id
        /// </summary>
        public int Id
        {
            get { return _id; }
        }

        [DataMember]
        private DateTime _matchDate;
        
        /// <summary>
        /// Gets date of the match
        /// </summary>
        public DateTime MatchDate
        {
            get { return _matchDate; }
            set { _matchDate = value; }
        }

        [DataMember]
        private Score _matchScore;

        /// <summary>
        /// Gets score of the match
        /// </summary>
        public Score MatchScore
        {
            get { return _matchScore; }
            set { _matchScore = value; }
        }

        public override string ToString()
        {
            return string.Format("#{0} {1}", _id, _matchDate.ToString("d"));
        }
    }
}
