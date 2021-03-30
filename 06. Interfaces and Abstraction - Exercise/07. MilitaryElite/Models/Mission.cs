using System;
using System.Collections.Generic;
using System.Text;

using MilitaryElite.Contracts;
using MilitaryElite.Exceptions;

namespace MilitaryElite.Models
{
    public class Mission : IMission
    {
        private State state;
        public Mission(string codeName, string state)
        {
            this.CodeName = codeName;
            this.State = this.TryParseState(state);
        }

        public string CodeName { get; private set; }

        public State State
        {
            get
            {
                return this.state;
            }
            set
            {       
                this.state = value;
            }
        }

        public void CompleteMission()
        {
            if (this.State == State.Finished)
            {
                throw new InvalidMissionException();
            }
            this.State = State.Finished;
            //IMission missionToComplete = this.missions.FirstOrDefault(x => x.CodeName == mission.CodeName);
            //missionToComplete.State = State.Finished;
        }

        private State TryParseState(string stateString)
        {
            State state;
            bool parsed = Enum.TryParse<State>(stateString, out state);

            if (!parsed)
            {
                throw new InvalidMissionStateException();
            }

            return state;
        }

        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.State}";
        }

    }
}
