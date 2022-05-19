using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Team
    {
        private string name;
        private List<Person> firstTeam;
        private List<Person> reserveTeam;

        public Team(string name)
        {
           this.Name = name;
           this.FirstTeam = new List<Person>();
           this.ReserveTeam = new List<Person>();
        }

        public string Name 
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public List<Person> FirstTeam { get; private set; }
        public List<Person> ReserveTeam { get; private set; }

        public void AddPlayer(Person person)
        {
            if (person.Age < 40)
            {
                this.FirstTeam.Add(person);
            }
            else
            {
                this.ReserveTeam.Add(person);
            }
        }
    }
}
