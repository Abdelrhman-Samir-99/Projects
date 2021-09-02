import java.util.Arrays;

public class Binary_Search {
	// Variables section.
	public static int my_array[];
	public static boolean found;

	// Constructor.
	public Binary_Search(int array[]) {
		my_array = array;
		found = false;
		Arrays.sort(my_array);
	}

	public static boolean searching(int value, int start, int end) {
		// normal binary search.
		
		while(start <= end) {
			int mid = (start + end) / 2;
			if(my_array[mid] == value) {
				found = true;
				return true;
			}
			
			if(my_array[mid] > value) {
				end = mid - 1;
			}
			else {
				start = mid + 1;
			}
		}
		return false;
	}

	public static boolean do_search(int value) {
		// Making sure that found is false.
		found = false;
		int n = my_array.length;

		// Then we create the two threads.
		Thread first = new Thread(new Runnable() {
						public void run() {
							found |= searching(value, 0, n / 2);
						}
					});

		Thread second = new Thread(new Runnable() {
						public void run() {
							found |= searching(value, n / 2 + 1, n - 1);
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

		return found;
	}
}
