using System.Collections;
using System.Collections.Generic;

namespace SortingHomework.Tests.TestData
{
    public class SortingTestDataFactory
    {
        public static IEnumerable[] GetData()
        {
            IList<int> edge = new List<int>() {1, 1};
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

            IList<string> strings = new List<string>()
                                    {
                                        "l",
                                        "f",
                                        "e",
                                        "a",
                                        "h",
                                        "z",
                                        "k",
                                        "c",
                                        "q",
                                        "i",
                                        "n",
                                        "t",
                                        "r",
                                        "u",
                                        "g",
                                        "l",
                                        "f",
                                        "e",
                                        "o",
                                        "w",
                                        "d",
                                        "k",
                                        "c",
                                        "q",
                                        "s",
                                        "m",
                                        "x",
                                        "r",
                                        "u",
                                        "g",
                                        "y",
                                        "p",
                                        "b",
                                        "o",
                                        "w",
                                        "d",
                                        "h",
                                        "z",
                                        "j",
                                        "s",
                                        "m",
                                        "x",
                                        "n",
                                        "t",
                                        "v",
                                        "y",
                                        "p",
                                        "b"
                                    };

            IList<decimal> decimals = new List<decimal>()
                                      {
                                          -5257.3128112597m,
                                          -8933.9266307523m,
                                          9396.6825569389m,
                                          5257.6552427524m,
                                          85.774289571933m,
                                          -6003.3709956341m,
                                          -5570.3475209506m,
                                          8019.638363872m,
                                          2483.602343911m,
                                          -8166.4899515626m,
                                          -7386.6902756884m,
                                          -3615.6248637812m,
                                          -2933.4416934642m,
                                          9409.3575219833m,
                                          -6828.5897495397m,
                                          -4397.4867125463m,
                                          8544.4483713533m,
                                          5627.31078469m,
                                          2369.8543432389m,
                                          -3839.2961091895m,
                                          883.91725606293m,
                                          -3694.3290675833m,
                                          1399.7894361651m,
                                          -7056.2396300645m,
                                          -2353.5375930232m
                                      };

            IList<Foo> foos = new List<Foo>()
                              {
                                  new Foo(1, "a"),
                                  new Foo(1, "b"),
                                  new Foo(2, "b"),
                                  new Foo(1, "b"),
                                  new Foo(100000, "z"),
                                  new Foo(1, "c"),
                                  new Foo(3, "d"),
                              };

            return new IEnumerable[] { edge, ints, strings, decimals, foos };
        }
    }
}
