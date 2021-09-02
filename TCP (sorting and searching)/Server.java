import java.io.InputStreamReader;
import java.io.BufferedReader;
import java.net.ServerSocket;
import java.io.PrintWriter;
import java.io.IOException;
import java.net.Socket;
import java.io.File;

public class Server extends Thread {
	private static final int PORT = 9090;
	public static int my_array[];
	public static PrintWriter out;
	public static BufferedReader input;
	public static String sort_types[] = {"1- Quick sort ", "2- Merge sort ", "3- Count sort"};
	public static String searching_types[] = {"1- Binary search ", "2- Sequential search"};
	
	public static void main(String[] args) throws IOException {
		ServerSocket listener = new ServerSocket(PORT);
		Socket my_Client = listener.accept();

		// true to always flush the buffer after filling it.
		// responsible for sending the input to the client.
		out = new PrintWriter(my_Client.getOutputStream(), true);
		input = new BufferedReader(new InputStreamReader( my_Client.getInputStream()));

		while(true) {
			// sending data to the client.
			
			out.println("Server says: What do you want ? 1- sort. 2- search. 3- exit.");

			int Index = Integer.parseInt(input.readLine());
			if(Index == 1) {
				// Reading the input from the client side.
				read();

				while(true) {
					// Knowing what kind of sort the client wants.
					out.println("Server says: Enter the ID of the sort type you want: ");
					String sent = "";
					for(int i = 0; i < 3; ++i)
						sent += sort_types[i];
					out.println(sent);

					int ID = Integer.parseInt(input.readLine());
					if(ID == 1) {
						Quick_Sort qs = new Quick_Sort(my_array);
						qs.quick_sort(0, my_array.length - 1);
					}
					else if(ID == 2) {
						Merge_Sort ms = new Merge_Sort(my_array);
						ms.do_merge_sort();
					}
					else if(ID == 3) {
						Count_Sort cs = new Count_Sort(my_array);
						cs.count_sort();
					}
					else {
						out.println("Server says: Enter a valid ID you dummy.");
						continue;
					}
					show();
					break;
				}
			}
			else if(Index == 2) {
				read();
				boolean found = false;
				
				while(true) {
					// Knowing what kind of search the client wants.
					out.println("Server says: Enter the ID of the search type you want: ");
					String sent = "";
					for(int i = 0; i < 2; ++i)
						sent += searching_types[i];
					out.println(sent);

					int ID = Integer.parseInt(input.readLine());
					
					out.println("Server says: Enter the value of the item you want to search: ");
					int value = Integer.parseInt(input.readLine());

					if(ID == 1) {
						Binary_Search bs = new Binary_Search(my_array);
						found = bs.do_search(value);	
					}
					else if(ID == 2) {
						Sequential_Search sq = new Sequential_Search(my_array);
						found = sq.do_search(value);
					}
					else {
						out.println("Server says: Enter a valid ID you dummy.");
						continue;
					}
					break;
				}

				if(found)
					out.println("Server says: This item is in the array.");
				else
					out.println("Server says: This item is not in the array.");
				
			}
			else if(Index == 3) {
				break;
			}
			else {
				out.println("Enter a valid choice you idiot.");
			}
		}
		my_Client.close();
		listener.close();
	}

	public static void read() throws IOException {
		int n = -1;
		while(n < 2) {
			out.println("Server says: Enter the size of the array and it must be greater than 1.");
			n = Integer.parseInt(input.readLine());
			if(n < 2) {
				out.println("Server says: you are idiot, n < 2.");
			}
			else {
				break;
			}
		}
		my_array = new int[n];
		out.println("Server says: Enter the items of the array now.");
		for(int i = 0; i < n; ++i)
			my_array[i] = Integer.parseInt(input.readLine());
	}

	public static void show() {
		int n = my_array.length;
		for(int i = 0; i < n; ++i)
			out.println(my_array[i]);
	}
}
