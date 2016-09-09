public void PrintStatistics(double[] arr, int count)
{
    double max = Double.MinValue;
    for ( int i = 0; i < count; i++ )
    {
        if ( arr[i] > max )
        {
            max = arr[i];
        }
    }

    PrintMax(max);

    double min = Double.MaxValue;
    for ( int i = 0; i < count; i++ )
    {
        if ( arr[i] < min )
        {
            min = arr[i];
        }
    }

    PrintMin(min);

    double sum = 0;
    for ( int i = 0; i < count; i++ )
    {
        sum += arr[i];
    }

    PrintAvg(sum / count);
}