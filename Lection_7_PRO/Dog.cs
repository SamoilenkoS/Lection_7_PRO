using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lection_7_PRO
{
    public class Dog
    {
        private static int _dogsCount = 0;
        private string _name;

        public Dog()
        {
            DogsCount++;
            Name = "Default name";
        }

        public Dog(string name)
        {
            DogsCount++;
            Name = name;
        }

        public Dog(int age, string name)
        {
            DogsCount++;
        }

        public static int DogsCount
        {
            get
            {
                return _dogsCount;
            }
            private set
            {
                _dogsCount = value;
            }
        }

        public string Name//ILDASM
        {
            get => _name;
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _name = value;
                }
                else
                {
                    throw new ArgumentException("Invalid name!");
                }
            }
        }

        public string Nickname { get; set; }

        public string DoSong()
        {
            return $"Wof-wof {Name}!";
        }
    }
}
