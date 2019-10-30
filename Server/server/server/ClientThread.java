

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.net.Socket;

import org.json.JSONArray;
import org.json.JSONObject;

public class ClientThread implements Runnable{
	private String threadName;
	private Socket clientSocket;
	private InputStream inputStream;
	private OutputStream outputstream;
	private Thread thread;
	
	private ServerModel serverModel;
	
	
	public ClientThread(String threadName, Socket clientSocket) {
		this.threadName = threadName;
		this.clientSocket = clientSocket;
		this.serverModel = new ServerModel("url", "dbusername", "dbpassword");
	}
	
	public void start() {
		log("Thread: " + threadName + " start.");
		if (thread == null) {
			thread = new Thread(this, threadName);
			thread.start();
		}
	}
	private void log(String string) {
		System.out.println(string);
	}
	private boolean setIOStream() {
		try {
			inputStream = clientSocket.getInputStream();
			outputstream = clientSocket.getOutputStream();
			return true;
		} catch (Exception e) {
			return false;
		}
	}
	@Override
	public void run() {
		System.out.println("Thread running");
		if (!setIOStream()) {
			//Thread end
			System.out.println("fail in set IO stream");
			return;
		}
		BufferedReader reader = new BufferedReader(new InputStreamReader(inputStream));
		while(true) {
			String str;
			try {
				str = reader.readLine();
				System.out.println("Receive: "+ str);
				JSONObject obj = new JSONObject(str);
				recv_JSONmsg(obj);
			} catch (IOException e1) {
				System.out.println("IO exception - stream may be closed. Exit the thread");
				break;
			}
		}
	}

	private void recv_JSONmsg(JSONObject obj) {
		try {
			int id = obj.getInt("id");
			switch (id) {
			case 100:
				//login
				break;
			case 101:
				//query friend list
				break;
			case 102:
				//add new friend
				break;
			case 103:
				//delete friend
				break;
			case 104:
				//send message to friend
				break;
			}
		} catch (Exception e) {
			//Nothing
		}
	}

}

