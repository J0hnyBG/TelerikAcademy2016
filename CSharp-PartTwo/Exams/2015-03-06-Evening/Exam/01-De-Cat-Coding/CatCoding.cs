using System;

    class CatCoding
    {
    private static readonly char[] BaseDigitsArray = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

    static void Main()
    {
        string[] catNumbers = Console.ReadLine().Split(' ');

        foreach ( var catNumber in catNumbers )
        {
            ulong numberInDecimal = GetNumberInDecimal(catNumber);
            string s = ConvertToBase(numberInDecimal);
            Console.Write("{0} ",s );
        }
    }

    private static string ConvertToBase(ulong value)
    {
        var result = string.Empty;

        do
        {
            result = BaseDigitsArray[value % 26] + result;
            value = value / 26;
        } while ( value != 0 );

        return result;
    }

    private static ulong GetNumberInDecimal(string input)
    {
        ulong result = 0;
        foreach ( var digit in input )
        {
            result = (ulong)(digit - 'a') + result * 21;
        }

        return result;
    }

}

