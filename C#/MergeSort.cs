using System;

class MergeSort {

    // Merges two subarrays of []arr.
    // First subarray is arr[l..m]
    // Second subarray is arr[m+1..r]
    public static void merge(int[] array, int l, int m, int r)
    {
        // Find sizes of two
        // subarrays to be merged
        int n1 = m - l + 1;
        int n2 = r - m;

        // Create temp arrays
        int[] L = new int[n1];
        int[] R = new int[n2];
        int i, j;

        // Copy data to temp arrays
        for (i = 0; i < n1; ++i)
            L[i] = array[l + i];
        for (j = 0; j < n2; ++j)
            R[j] = array[m + 1 + j];

        // Merge the temp arrays

        // Initial indexes of first
        // and second subarrays
        i = 0;
        j = 0;

        // Initial index of merged
        // subarray array
        int k = l;
        while (i < n1 && j < n2) {
            if (L[i] <= R[j]) {
                array[k] = L[i];
                i++;
            }
            else {
                array[k] = R[j];
                j++;
            }
            k++;
        }

        // Copy remaining elements
        // of L[] if any
        while (i < n1) {
            array[k] = L[i];
            i++;
            k++;
        }

        // Copy remaining elements
        // of R[] if any
        while (j < n2) {
            array[k] = R[j];
            j++;
            k++;
        }
    }

    // Main function that
    // sorts array[l..r] using
    // merge()
    public static void sort(int[] array, int l, int r)
    {
        if (l < r) {

            // Find the middle point
            int m = l + (r - l) / 2;

            // Sort first and second halves
            sort(array, l, m);
            sort(array, m + 1, r);

            // Merge the sorted halves
            merge(array, l, m, r);
        }
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
        sort(array, 0, array.Length - 1);
        Console.WriteLine("\nSorted array is");
        printArray(array);
    }
}
