public class Sequential_Search extends Thread {
	// Variables sections. 
	public static int my_array[];
	public static boolean found;

	// Constructor.
	public Sequential_Search(int array[]) {
		my_array = array;
		found = false;
	};


	// Searching function for each part.
	public static boolean searching(int value, int start, int end) {
		for(int i = start; i <= end && found == false; ++i) {
			System.out.println(my_array[i]);
			if(my_array[i] == value) {
				found = true;
				return true;
			}
		}
		return false;
	}
	
	public static boolean do_search(int value) {
		// We consider this function as our main function.
		found = false; // We make sure that @found is false.
		int n = my_array.length; // the size of the array.
		
		System.out.println("Something is WRONG");
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
					
		first.start(); // starting the threads.
		second.start();
		
		// Then we make sure that the two thrids are done before the main thread is over by using @join.
		try {
			first.join();
			second.join();
		} catch(InterruptedException e) {
			System.out.println("Something went wrong.");
		}

		return found; // If the value was found then @found should be true.
	}
}
