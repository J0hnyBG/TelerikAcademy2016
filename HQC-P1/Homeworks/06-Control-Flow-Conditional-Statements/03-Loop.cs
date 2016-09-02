private void Loop(int[] array, int expectedValue)
{
    bool valueFound = false;

    for (int i = 0; i < 100; i++)
    {
        if (i % 10 == 0)
        {
            Console.WriteLine(array[i]);
            if (array[i] == expectedValue)
            {
                valueFound = true;
            }
        }
        else
        {
            Console.WriteLine(array[i]);
        }
    }

    if(valueFound)
    {
        Console.WriteLine("Value Found");
    }
}