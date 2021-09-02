public class Count_Sort {
  public static int my_array[];
  public static int counting[];

  public Count_Sort(int[] array) {
    my_array = array;
    counting = new int[10000];
  }

  public static void count(int start, int end) {
    for(int i = start; i <= end; ++i)
      ++counting[my_array[i]];
  }

  public static void clear() {
    for(int i = 0; i < 10000; ++i)
      counting[i] = 0;
  }
  
  public static void count_sort() {
    clear();
    int n = my_array.length; // the size of the array.
    
    // Then we create the two threads.
    Thread first = new Thread(new Runnable() {
            public void run() {
              count(0, n / 2);
            }
          });

    Thread second = new Thread(new Runnable() {
            public void run() {
              count(n / 2 + 1, n - 1);
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

    // Here is the counting sort section.
    int ptr = 0;
    for(int i = 0; i < 10000 && ptr != n; ++i) {
      while(counting[i] != 0) {
        --counting[i];
        my_array[ptr++] = i;
      }
    }


  }
}
