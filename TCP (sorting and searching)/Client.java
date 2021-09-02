import java.io.InputStreamReader;
import java.io.BufferedReader;
import java.io.PrintWriter;
import java.io.IOException;
import java.net.Socket;

public class Client {
  private static final String Server_IP = "127.0.0.1";
  private static final int Server_PORT = 9090;
  public static BufferedReader client_in;
  public static BufferedReader input;
  public static PrintWriter out;
  
  public static void main(String[] args) throws IOException {
    // This line establish the connection of the server.
    Socket socket = new Socket(Server_IP, Server_PORT);

    // Should be now something like (Console.ReadLine()) but to take input from server side.
    input = new BufferedReader(new InputStreamReader( socket.getInputStream()));

    // To talk the input from the console.
    client_in = new BufferedReader(new InputStreamReader(System.in));
    
    out = new PrintWriter(socket.getOutputStream(), true); // To talk to the server.

    
    get_response(); 

    int which_Choice = send_response(); // the ID choice the client made.

    if(which_Choice == 3) { // which means exit.
      socket.close();
      System.exit(0);
    }
  
    get_response();
    int n = send_response(); // number of items in the array.
    
    get_response();
    
    for(int i = 0; i < n; ++i)
      send_response();

    get_response(); // which sort OR search algorithm.
    get_response();

    send_response();

    if(which_Choice == 2) {
      get_response();
      send_response(); // if it's searching, then this is the value we will look for.
      get_response(); // the answer.
    }
    else {
      // if it was sorting.
      for(int i = 0; i < n; ++i)
        get_response();
    }
    
    socket.close();
    System.exit(0);
  }

  public static void get_response() throws IOException {
    // Getting the response and showing it to the client.
    String response = input.readLine();
    System.out.println(response);
  }

  public static int send_response() throws IOException {
    int number = Integer.parseInt(client_in.readLine());
    out.println(number);
    return number;
  }
}
