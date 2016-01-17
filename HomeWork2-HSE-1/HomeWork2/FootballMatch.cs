using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace HomeWork2
{
    [DataContract]
    class FootballMatch:Match
    {
        /// <summary>
        /// Initializes a new instance of the FootballMatch class 
        /// </summary>
        /// <param name="date">Match date</param>
        /// <param name="matchScore">Match score</param>
        /// <param name="firstTeamName"><First team name/param>
        /// <param name="secondTeamName">Second team name</param>
        /// 
        public FootballMatch(DateTime date, Score matchScore, string firstTeamName, string secondTeamName)
            : base(date, matchScore)
        {
            _firstTeamName = firstTeamName;
            _secondTeamName = secondTeamName;
        }

        /// <summary>
        /// Initializes a new instance of the FootballMatch class 
        /// </summary>
        /// <param name="date">Match date</param>
        /// <param name="matchScore">Match score</param>
        /// <param name="id">Initial instance id</param>
        /// <param name="firstTeamName">First team name</param>
        /// <param name="secondTeamName">Second team name</param>
        /// 
        public FootballMatch(DateTime date, Score matchScore, int id, string firstTeamName, string secondTeamName)
            : base(date, matchScore, id)
        {
            _firstTeamName = firstTeamName;
            _secondTeamName = secondTeamName;
        }

        [DataMember]
        private string _firstTeamName;

        /// <summary>
        /// Gets the name of the first team
        /// </summary>
        public string FirstTeamName
        {
            get { return _firstTeamName; }
            set { _firstTeamName = value; }
        }

        [DataMember]
        private string _secondTeamName;

        /// <summary>
        /// Gets the name of the second team
        /// </summary>
        public string SecondTeamName
        {
            get { return _secondTeamName; }
            set { _secondTeamName = value; }
        }

        public override string ToString()
        {
            return String.Format("{0} Футбольный матч {1} против {2} Счет {3}", base.ToString(), _firstTeamName, _secondTeamName, MatchScore);
        }
    }
}
