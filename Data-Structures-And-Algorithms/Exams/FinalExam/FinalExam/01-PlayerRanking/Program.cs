using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01_PlayerRanking
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var game = new RankingManager();
            while (input != "end")
            {
                var splitCmd = input.Split(' ');

                switch (splitCmd[0])
                {
                    case "add":
                        // add PLAYER_NAME PLAYER_TYPE PLAYER_AGE PLAYER_POSITION
                        var name = splitCmd[1];
                        var type = splitCmd[2];
                        var age = int.Parse(splitCmd[3]);
                        var position = int.Parse(splitCmd[4]);
                        var player = new Player(name, type, age, position);
                        game.AddPlayer(player);
                        Console.WriteLine("Added player {0} to position {1}", name, position);
                        break;
                    case "find":
                        var foundPlayers = game.FindByType(splitCmd[1]);
                        if (foundPlayers == null)
                        {
                            Console.WriteLine("Type {0}: ", splitCmd[1]);
                        }
                        else
                        {
                            var playersString = string.Join("; ", foundPlayers);
                            Console.WriteLine("Type {0}: {1}", splitCmd[1], playersString);
                        }
                        break;
                    case "ranklist":
                        var from = int.Parse(splitCmd[1]);
                        var to = int.Parse(splitCmd[2]);
                        var rankList = game.Ranklist(from, to);
                        // 1. Stamat(40); 2. Pencho(33); 3. Ivan(20)
                        var sb = new StringBuilder();
                        for (int i = 0; i < rankList.Count; i++)
                        {
                            sb.Append(string.Format("{0}. {1}; ", i + 1, rankList[i]));
                        }

                        Console.WriteLine(sb.ToString().TrimEnd(' ', ';'));
                        break;
                }

                input = Console.ReadLine();
            }
        }
    }

    internal class RankingManager
    {
        private readonly IComparer<Player> nameAndAgeComparer;
        private readonly SortedDictionary<int, Player> playersByRank;
        private readonly IDictionary<string, ISet<Player>> playersByType;

        public RankingManager()
        {
            this.nameAndAgeComparer = Comparer<Player>.Create((a, b) =>
                                                              {
                                                                  var result = a.Name.CompareTo(b.Name);
                                                                  if (result == 0)
                                                                  {
                                                                      result = b.Age.CompareTo(a.Age);
                                                                  }

                                                                  if (result == 0)
                                                                  {
                                                                      result= a.Position.CompareTo(b.Position);
                                                                  }

                                                                  return result;
                                                              });
            this.playersByType = new Dictionary<string, ISet<Player>>();
            this.playersByRank = new SortedDictionary<int, Player>();
        }

        public void AddPlayer(Player player)
        {
            if (!this.playersByType.ContainsKey(player.Type))
            {
                this.playersByType[player.Type] = new SortedSet<Player>(this.nameAndAgeComparer);
            }

            this.playersByType[player.Type].Add(player);

            if (this.playersByRank.ContainsKey(player.Position))
            {
                var maxRank = this.playersByRank.Keys.Last();
                var currentPosition = player.Position;
                if (maxRank > currentPosition)
                {
                    var previous = player;
                    for (var i = currentPosition; i <= maxRank; i++)
                    {
                        this.playersByRank[i] = previous;
                        previous = player;
                    }

                    this.playersByRank.Add(maxRank + 1, player);

                    return;
                }
            }


            this.playersByRank.Add(player.Position, player);
        }

        public IList<Player> FindByType(string type)
        {
            if (this.playersByType.ContainsKey(type))
            {
                return this.playersByType[type].Take(5).ToList();
            }

            return null;
        }

        public IList<Player> Ranklist(int from = int.MinValue, int to = int.MaxValue)
        {
            from--;
            to--;
            // return this.playersByRank.Skip(from).Take(to - Math.Abs(from) + 1).ToList();
            return this.playersByRank.Where(k => k.Key >= from && k.Key <= to).Select(k => k.Value).ToList();

        }
    }

    internal class Player
    {
        public string Name;
        public string Type;
        public int Age;
        public int Position;

        public Player(string name, string type, int age, int position)
        {
            this.Name = name;
            this.Type = type;
            this.Age = age;
            this.Position = position;
        }

        public override string ToString()
        {
            return string.Format("{0}({1})", this.Name, this.Age);
        }
    }
}
