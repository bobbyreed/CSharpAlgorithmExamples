using System;

class MergeSortwithExplanations {

    void merge(int[] array, int l, int m, int r)
    {
        // Find sizes of two
        // subarrays to be merged 
        int n1 = m - l + 1;
        int n2 = r - m;
		Console.WriteLine("First subarray size is " + n1 + ". Setting int n1 to " + n1);
		Console.WriteLine("Second subarray size is " + n2 + ". Setting int n2 to " + n2);

        Console.WriteLine("Creating temporary arrays to hold L and R subarrays of array.");
		// Create temp arrays
        int[] L = new int[n1];
        int[] R = new int[n2];
		
		Console.WriteLine("Temporary arrays created. Array L has a size of " + n1 + " and Array R has a size of " + n2);
        Console.WriteLine("Creating ints i and j to use in for loops");
		int i, j;		

        // Copy data to temp arrays
        for (i = 0; i < n1; ++i)
		{
			L[i] = array[l + i];
			Console.WriteLine("Setting L[" + i + "] to array[l + i] = " + (l + i));
		}
        for (j = 0; j < n2; ++j)
		{
            R[j] = array[m + 1 + j];
			Console.WriteLine("Setting R[" + j + "] to array[m + 1 + j] = " + (m + 1 + j));
		}
        // Merge the temp arrays

        // Initial indexes of first
        // and second subarrays
        i = 0;
        j = 0;
		Console.WriteLine("Setting the indexes of the first and second subarrays to i = " + i + " and j = " + j);

        // Initial index of merged
        // subarray array 
        int k = l;
		Console.WriteLine("Setting the index of the merged subarray array to k = " + k);
        Console.WriteLine("Starting while loop... /nwhile loop continues so long as i (index of the first subarray) and j (index of the second subarray) are smaller than than there initial sizes (n1 and n2)");
		while (i < n1 && j < n2) {
            if (L[i] <= R[j]) {
				Console.WriteLine("Since L[" + i + "] <= R[" + j + "], setting array[" + k + "] to L[" + i + "].");
                array[k] = L[i];
				Console.WriteLine("Increasing i by 1...");
                i++;
				Console.WriteLine("i = " + i);
            }
            else {
				Console.WriteLine("Since L[" + i + "] > R[" + j + "], setting array[" + k + "] to R[" + j + "].");
                array[k] = R[j];
				Console.WriteLine("Increasing j by 1...");
                j++;
				Console.WriteLine("j = " + j);
            }
            k++;
			Console.WriteLine("k has increased by 1. k = " + k);
        }

        // Copy remaining elements
        // of L[] if any
		Console.WriteLine("Copying any remaining elements in L[]...");
        while (i < n1) {
			Console.WriteLine("Since i < n1 (" + i + " < " + n1 + "), setting array[" + k + "] to L[" + i + "].");
            array[k] = L[i];
			Console.WriteLine("Increasing i by 1...");
            i++;
			Console.WriteLine("i = " + i);
			Console.WriteLine("Increasing k by 1...");
            k++;
			Console.WriteLine("k = " + k);
        }

        // Copy remaining elements
        // of R[] if any
		Console.WriteLine("Copying any remaining elements in R[]...");
        while (j < n2) {
			Console.WriteLine("Since j < n2 (" + j + " < " + n2 + "), setting array[" + k + "] to R[" + j + "].");
            array[k] = R[j];
			Console.WriteLine("Increasing j by 1...");
            j++;
			Console.WriteLine("j = " + j);
            Console.WriteLine("Increasing k by 1...");
            k++;
			Console.WriteLine("k = " + k);
        }
    }

    // Main function that
    // sorts array[l..r] using
    // merge()
    void sort(int[] array, int l, int r)
    {
		Console.WriteLine("Sorting array:");
        if (l < r) {
		Console.WriteLine("subarray l is less than subarray r so...");
            // Find the middle point
            int m = l + (r - l) / 2;
			Console.WriteLine("The middle point of array is " + m);

            // Sort first and second halves
			Console.WriteLine("Sorting first and second halves...");
			Console.WriteLine("");
            sort(array, l, m);
            sort(array, m + 1, r);

            // Merge the sorted halves
			Console.WriteLine("Merging the sorted halves...");
			Console.WriteLine("");
            merge(array, l, m, r);
        }
		else
			Console.WriteLine("Array is sorted");
    }

    // A utility function to
    // print array of size n
    static void printArray(int[] array)
    {
        int n = array.Length;
        for (int i = 0; i < n; ++i)
            Console.Write(array[i] + " ");
        Console.WriteLine();
    }

    // Driver code
    public static void Main()
    {
        int[] array = { 38, 27, 43, 3, 9, 82, 10 };
        Console.WriteLine("Given array is");
        printArray(array);
		Console.WriteLine("");
        MergeSort ob = new MergeSort();
        ob.sort(array, 0, array.Length - 1);
        Console.WriteLine("\nSorted array is");
        printArray(array);
    }
}
