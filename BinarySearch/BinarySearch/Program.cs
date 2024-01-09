var initialArray = new long[] { 1, 9, 3, 5, 2, 0, 4, 6 };
const int numberForSearch = 0;

BinarySearch(initialArray, numberForSearch);

void BinarySearch(long[] array, long number)
{
    if (array is null)
        throw new NullReferenceException("No any element in array");
    
    if (array.Length == 0)
        throw new Exception("No any element in array");
    
    var sortedArray = array.Order().ToArray();
    Console.WriteLine($"Sorted array{Environment.NewLine}{string.Join(",",sortedArray.Select(x => x))}");
    Console.WriteLine();

    Console.WriteLine("Iterative search");
    var firstFoundIndex = FindIndexByIterativeBinarySearch(sortedArray, number);
    Console.WriteLine(firstFoundIndex == -1 ? $"No any number {number} in array" : $"Number {number} found in index {firstFoundIndex}");
    Console.WriteLine();
    
    Console.WriteLine("Recursive binary search");
    var secondFoundIndex = FindIndexByRecursiveBinarySearch(sortedArray, numberForSearch, 0, sortedArray.Length - 1);
    Console.WriteLine(secondFoundIndex == -1 ? $"No any number {number} in array" : $"Number {number} found in index {secondFoundIndex}");
}

int FindIndexByIterativeBinarySearch(long[] array, long number)
{
    var iterationCount = 0;
    var minIndex = 0;
    var maxIndex = array.Length - 1;

    while (minIndex <= maxIndex)
    {
        iterationCount++;
        
        var middleValueIndex = minIndex + (maxIndex - minIndex) / 2;
        if (number == array[middleValueIndex])
        {
            Console.WriteLine($"Iteration count : {iterationCount}");
            return middleValueIndex;
        }
        if (number < array[middleValueIndex])
        {
            maxIndex = middleValueIndex - 1;
        }
        if (number > array[middleValueIndex])
        {
            minIndex = middleValueIndex + 1;
        }
    }
    Console.WriteLine($"Iteration count : {iterationCount}");
    return -1;
}

int FindIndexByRecursiveBinarySearch(long[] array, long number, int minIndex, int maxIndex, int iterationCount = 0)
{
    iterationCount++;

    var middleValueIndex = minIndex + (maxIndex - minIndex) / 2;
    if (number == array[middleValueIndex])
    {
        Console.WriteLine($"Iteration count: {iterationCount}");
        return middleValueIndex;
    }

    if (minIndex == maxIndex)
    {
        Console.WriteLine($"Iteration count: {iterationCount}");
        return -1;
    }

    if (number < array[middleValueIndex])
        return FindIndexByRecursiveBinarySearch(array, number, minIndex, middleValueIndex - 1, iterationCount);
    if (number > array[middleValueIndex])
        return FindIndexByRecursiveBinarySearch(array, number, middleValueIndex + 1, maxIndex, iterationCount);

    return -1;
}