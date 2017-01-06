using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_OfficeSpace
{
    internal class Startup
    {
        private static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var minutes = Console.ReadLine()
                                 .Split(' ')
                                 .Select(int.Parse)
                                 .ToArray();

            var dependencies = new List<int>[n];
            for (var i = 0; i < n; i++)
            {
                var taskDeps = Console.ReadLine()
                                      .Split(' ')
                                      .Select(x => int.Parse(x) - 1)
                                      .ToArray();

                if (taskDeps[0] < 0)
                {
                    dependencies[i] = null;
                }
                else
                {
                    dependencies[i] = new List<int>(taskDeps.Length);
                    dependencies[i].AddRange(taskDeps);
                }
            }

            var visited = new bool[n];
            var memoTimes = new int[n];
            var results = new int[n];
            var isCircular = false;
            for (var i = 0; i < results.Length; i++)
            {
                results[i] = GetMinTimeForTask(i, minutes, dependencies, visited, memoTimes, ref isCircular);

                if (isCircular)
                {
                    break;
                }
            }

            Console.WriteLine(isCircular ? -1 : results.Max());
        }

        private static int GetMinTimeForTask(int taskId,
                                             IReadOnlyList<int> minutes,
                                             IReadOnlyList<List<int>> dependencies,
                                             IList<bool> visited,
                                             IList<int> memoTimes,
                                             ref bool isCircular)
        {
            if (visited[taskId])
            {
                isCircular = true;
                return -1;
            }

            if (dependencies[taskId] == null)
            {
                return minutes[taskId];
            }

            if (memoTimes[taskId] > 0)
            {
                return memoTimes[taskId];
            }

            visited[taskId] = true;
            var maxTime = 0;
            foreach (var dependencyId in dependencies[taskId])
            {
                var time = GetMinTimeForTask(dependencyId, minutes, dependencies, visited, memoTimes, ref isCircular);
                if (time > maxTime)
                {
                    maxTime = time;
                }
            }

            visited[taskId] = false;
            memoTimes[taskId] = minutes[taskId] + maxTime;
            return memoTimes[taskId];
        }
    }
}
