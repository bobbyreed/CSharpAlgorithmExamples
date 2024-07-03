using System;
					
public class BubbleSort
{
public static bool swapped;
	public static void Main()
	{
		int[] array = {64, 34, 25, 12, 22, 11, 90};
        int n = array.Length;
		BubbleSort(array, n);
        printArray(array, n);
	}
	
	public static void BubbleSort(int[] array, int n)
	{
		int temp;
		for (int i = 0; i < n - 1; i++)
		{
			swapped = false;
			int jCount = 0;
			for (int j = 0; j < n - 1; j++)
				{
					if(array[j] > array[j+1])
					   {
							temp = array[j];
							array[j] = array[j + 1];
							array[j + 1] = temp;
							swapped = true;
							jCount++;
					   }
					if (swapped == false && jCount >= array.Length)
					{
							break;
					}
				}	
		}			
	}
				public static void printArray(int[] arr, int size)
				{
					int i;
					for (i = 0; i < size; i++)
						Console.Write(arr[i] + " ");
					Console.WriteLine();
				}
}
