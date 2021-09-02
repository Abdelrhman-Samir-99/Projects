public class Quick_Sort {
	public static int my_array[];

	public Quick_Sort(int array[]) {
		my_array = array;
	}

	public static int partition(int low, int high) {
		int pivot = my_array[high];
		int i = low - 1;
		for(int j = low; j < high; ++j) {
			if(my_array[j] < pivot) {
				++i;
				int temp = my_array[i];
				my_array[i] = my_array[j];
				my_array[j] = temp;
			}
		}

		int temp = my_array[i + 1];
		my_array[i + 1] = my_array[high];
		my_array[high] = temp;

		return i + 1;
	}

	public static void quick_sort(int low, int high) {
		if(low < high) {
			int index = partition(low, high);
			Thread first = new Thread(new Runnable() {
				public void run() {
					quick_sort(low, index - 1);
				}
			});
			first.start();
			quick_sort(index + 1, high);
			try {
				first.join();
			}  catch(InterruptedException e) {
				System.out.println("Something went wrong.");
			}
		}
	}
}
