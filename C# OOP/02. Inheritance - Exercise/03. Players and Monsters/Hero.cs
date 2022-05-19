using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters
{
    public class Hero
    {
        public string username { get; set; }
        public int level { get; set; }

        public Hero(string username, int level)
        {
            this.Username = username;
            this.Level = level;
        }
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }

        public int Level
        {
            get
            {
                return level;
            }
            set
            {
                level = value;
            }
        }
        public override string ToString()
        {
            return $"Type: {this.GetType().Name} Username: {this.Username} Level: {this.Level}";
        }
    }

}
