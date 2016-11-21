using System.Collections;
using System.Collections.Generic;

namespace SearchingHomework.Tests.TestData
{
    internal class SearchingTestDataFactory
    {
        internal static IEnumerable[] GetUnFindableData()
        {
            IList<int> ints = new List<int>()
                              {
                                  1,
                                  2,
                                  3,
                                  5,
                                  -50,
                                  500,
                                  1000,
                                  1,
                                  10,
                                  -5,
                                  50,
                                  213,
                                  123,
                                  512,
                                  666,
                                  -666,
                                  666
                              };

            object[] firstCase = { ints, 1001 };
            object[] secondCase = { ints, 667 };
            object[] thirdCase = { ints, -1 };

            IList<string> strings = new List<string>()
                                    {
                                        "T73DZcGNwg",
                                        "4tatwHAfU8",
                                        "PwGFgD6ZGS",
                                        "Ol5iCXaDNj",
                                        "K4HtOv61BZ",
                                        "P4qllcy6Wv",
                                        "xSOgt87AKu",
                                        "yCKsR3uFuO",
                                        "a0LLaASJdo",
                                        "BrV2tFGa43",
                                        "NQqb2RTR5J",
                                        "gaWu7ds3Xz",
                                        "DYaYcKSlWq",
                                        "webePXOii7",
                                        "AtpSpvzQ9I",
                                        "LBiHFK1Vw0",
                                        "cw7DpQZYCU",
                                        "F5dYHdFute",
                                        "VvTIIZQfyr",
                                        "polVff7Mth"
                                    };

            object[] firstStringCase = { strings, "Not found" };
            object[] secondStringCase = { strings, "cw7DpQZYCu" };
            object[] thirdStringCase = { strings, "P3qllcy6Wv" };

            return new IEnumerable[]
                   { firstCase, secondCase, thirdCase, firstStringCase, secondStringCase, thirdStringCase };
        }

        internal static IEnumerable[] GetFindableData()
        {
            IList<int> ints = new List<int>()
                              {
                                  1,
                                  2,
                                  3,
                                  5,
                                  -50,
                                  500,
                                  1000,
                                  1,
                                  10,
                                  -5,
                                  50,
                                  213,
                                  123,
                                  512,
                                  666,
                                  -666,
                                  666
                              };

            object[] firstCase = { ints, 1000 };
            object[] secondCase = { ints, 666};
            object[] thirdCase = { ints, 1};

            IList<string> strings = new List<string>()
                                    {
                                        "T73DZcGNwg",
                                        "4tatwHAfU8",
                                        "PwGFgD6ZGS",
                                        "Ol5iCXaDNj",
                                        "K4HtOv61BZ",
                                        "P4qllcy6Wv",
                                        "xSOgt87AKu",
                                        "yCKsR3uFuO",
                                        "a0LLaASJdo",
                                        "BrV2tFGa43",
                                        "NQqb2RTR5J",
                                        "gaWu7ds3Xz",
                                        "DYaYcKSlWq",
                                        "webePXOii7",
                                        "AtpSpvzQ9I",
                                        "LBiHFK1Vw0",
                                        "cw7DpQZYCU",
                                        "F5dYHdFute",
                                        "VvTIIZQfyr",
                                        "polVff7Mth"
                                    };

            object[] firstStringCase = { strings, "T73DZcGNwg" };
            object[] secondStringCase = { strings, "cw7DpQZYCU" };
            object[] thirdStringCase = { strings, "P4qllcy6Wv", };

            return new IEnumerable[]
                   { firstCase, secondCase, thirdCase, firstStringCase, secondStringCase, thirdStringCase };
        }
    }
}
