public class Merge_Sort {
	public static int my_array[];

	public Merge_Sort(int array[]) {
		my_array = array;
	}

	public static void merge(int low, int mid, int high) {
		int len1 = mid - low + 1, len2 = high - mid;
		int Left[] = new int[len1];
		int Right[] = new int[len2];;
		int i, j;
	
		for(i = 0; i < len1; ++i)
			Left[i] = my_array[i + low];
	
		for(i = 0; i < len2; ++i)
			Right[i] = my_array[i + mid + 1];
	
		int ptr = low;
		i = j = 0;
	
		while(i < len1 && j < len2) {
			if(Left[i] <= Right[j])
				my_array[ptr] = Left[i++];
			else
				my_array[ptr] = Right[j++];
			++ptr;
		}
	
		while(i < len1) {
			my_array[ptr] = Left[i++];
			++ptr;
		}
	
		while(j < len2) {
			my_array[ptr] = Right[j++];
			++ptr;
		}
	}
 

	public static void merge_sort(int low, int high) {
		int mid = (low + high) / 2;
		if(low < high) {
			merge_sort(low, mid);
			merge_sort(mid + 1, high);
			merge(low, mid, high);
		}

	}

	public static void do_merge_sort() {
		int n = my_array.length; // the size of the array.
		
		// Then we create the two threads and use merge_sort function to sort them.
		Thread first = new Thread(new Runnable() {
						public void run() {
							merge_sort(0, n / 2);
						}
					});

		Thread second = new Thread(new Runnable() {
						public void run() {
							merge_sort(n / 2 + 1, n - 1);
						}
					});

		first.start();
		second.start();
		// Then we make sure that the two thrids are done before the main thread is over by using @join.
		try {
			first.join();
			second.join();
		} catch(InterruptedException e) {
			System.out.println("Something went wrong.");
		}

		// Now we got two sorted halves, so we can just merge them using a simple merge function without threading.
		merge(0, n / 2, n - 1);

	}
}
