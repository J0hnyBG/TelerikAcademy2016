using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01_UnitsOfWork
{
    internal class Startup
    {
        private const string EndCommand = "end";
        private const string AddCommand = "add";
        private const string RemoveCommand = "remove";
        private const string FindCommand = "find";
        private const string PowerCommand = "power";
        private static readonly Game game = new Game();

        private static void Main()
        {
            var input = Console.ReadLine();
            var output = new StringBuilder();
            while (input != EndCommand)
            {
                string result = ProcessCommand(input);
                output.AppendLine(result);

                input = Console.ReadLine();
            }

            Console.WriteLine(output.ToString());
        }

        private static string ProcessCommand(string command)
        {
            var splitCommand = command.Split(' ');
            var commandName = splitCommand[0];
            var result = string.Empty;
            switch (commandName)
            {
                case AddCommand:
                    var unitName = splitCommand[1];
                    var unitType = splitCommand[2];
                    var unitAttack = int.Parse(splitCommand[3]);
                    var unit = new Unit(unitName, unitType, unitAttack);
                    if (game.Add(unit))
                    {
                        result = string.Format("SUCCESS: {0} added!", unitName);
                    }
                    else
                    {
                        result = string.Format("FAIL: {0} already exists!", unitName);
                    }
                    break;
                case RemoveCommand:
                    unitName = splitCommand[1];
                    if (game.Remove(unitName))
                    {
                        result = string.Format("SUCCESS: {0} removed!", unitName);

                    }
                    else
                    {
                        result = string.Format("FAIL: {0} could not be found!", unitName);
                    }
                    break;
                case FindCommand:
                    unitType = splitCommand[1];
                    var filteredUnits = game.FindByType(unitType);

                    result = BuildMultipleUnitsResult(filteredUnits);
                    break;
                case PowerCommand:
                    var numberOfUnits = int.Parse(splitCommand[1]);
                    filteredUnits = game.MostPowerful(numberOfUnits);
                    result = BuildMultipleUnitsResult(filteredUnits);
                    break;
                default:
                    throw new ArgumentException("Invalid command!");
            }
            return result;
        }

        private static string BuildMultipleUnitsResult(IEnumerable<Unit> units)
        {
            var result = "RESULT: " + string.Join(", ", units);
            return result;
        }
    }

    internal class Unit : IComparable<Unit>
    {
        private string name;
        private string type;
        private int attack;

        public Unit(string name, string type, int attack)
        {
            this.Name = name;
            this.Type = type;
            this.Attack = attack;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (value.Length < 1 || value.Length > 30)
                {
                    throw new ArgumentException();
                }

                this.name = value;
            }
        }

        public string Type
        {
            get { return this.type; }
            set
            {
                if (value.Length < 1 || value.Length > 40)
                {
                    throw new ArgumentException();
                }

                this.type = value;
            }
        }

        public int Attack
        {
            get { return this.attack; }
            set
            {
                if (value < 100 || value > 1000)
                {
                    throw new ArgumentOutOfRangeException();
                }

                this.attack = value;
            }
        }

        public int CompareTo(Unit other)
        {
            var result = this.Attack.CompareTo(other.Attack) * -1;
            if (result == 0)
            {
                result = this.Name.CompareTo(other.Name);
            }

            return result;
        }

        public override string ToString()
        {
            return string.Format("{0}[{1}]({2})", this.Name, this.Type, this.Attack);
        }
    }

    internal class Game
    {
        private readonly IDictionary<string, Unit> unitsByName;
        private readonly IDictionary<string, SortedSet<Unit>> unitsByType;
        private readonly ISet<Unit> unitsByAttack;

        public Game()
        {
            this.unitsByAttack = new SortedSet<Unit>();
            this.unitsByName = new Dictionary<string, Unit>();
            this.unitsByType = new Dictionary<string, SortedSet<Unit>>();
        }

        public bool Add(Unit unit)
        {
            if (this.unitsByName.ContainsKey(unit.Name))
            {
                return false;
            }

            this.unitsByName[unit.Name] = unit;

            if (!this.unitsByType.ContainsKey(unit.Type))
            {
                this.unitsByType[unit.Type] = new SortedSet<Unit>();
            }

            this.unitsByType[unit.Type].Add(unit);

            this.unitsByAttack.Add(unit);

            return true;
        }

        public IEnumerable<Unit> FindByType(string type)
        {
            if (!this.unitsByType.ContainsKey(type))
            {
                return Enumerable.Empty<Unit>();
            }

            return this.unitsByType[type].Take(10);
        }

        public IEnumerable<Unit> MostPowerful(int numberOfUnits)
        {
            return this.unitsByAttack.Take(numberOfUnits);
        }

        public bool Remove(string name)
        {
            if (!this.unitsByName.ContainsKey(name))
            {
                return false;
            }

            var unitByName = this.unitsByName[name];

            this.unitsByName.Remove(name);

            var unitsWithSameType = this.unitsByType[unitByName.Type];

            unitsWithSameType.Remove(unitByName);

            this.unitsByAttack.Remove(unitByName);

            return true;
        }
    }
}
