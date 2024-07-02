using System;
					
public class Program
{
	public static void Main()
	{
		int[] array = {64, 34, 25, 12, 22, 11, 90};
        int n = array.Length;
		BubbleSort(array, n);
		Console.WriteLine("Sorted Array: ");
        printArray(array, n);
	}
	
	public static void BubbleSort(int[] array, int n)
	{
		int temp;
		bool swapped;
		int k = 0;
		
		for (int i = 0; i < n - 1; i++)
		{
			swapped = false;
			int jCount = 0;
			for (int j = 0; j < n - 1; j++)
				{
					if(array[j] > array[j+1])
					   {
						   //swap array[j] and array[j +1]
							Console.WriteLine("Array position " + j + " is greater than array position " + (j + 1));
							Console.WriteLine("Initiating swap");
							Console.WriteLine("Swapping array position " + j + " for array position " + (j + 1));
							temp = array[j];
							Console.WriteLine("Array position " + j + " has been moved to temp");
							Console.WriteLine("var temp value is " + temp);
							array[j] = array[j + 1];
							Console.WriteLine("Swapping the values between the array positions...");
							array[j + 1] = temp;
							Console.WriteLine("Swap successfully completed. Value " + array[j] + " is at position " + j + ". Value " + array[j+1] + " is at position " + (j + 1));
							jCount++;
					   }
					// If no two elements were
				// swapped by inner loop, then break
				if (swapped == false && jCount >= array.Length)
					break;
				}
			
				
		}
				
	}
		// Function to print an array
				public static void printArray(int[] arr, int size)
				{
					int i;
					for (i = 0; i < size; i++)
						Console.Write(arr[i] + " ");
					Console.WriteLine();
				}
}
