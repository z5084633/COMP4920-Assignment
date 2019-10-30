import java.sql.*;
import java.util.*;
public class ServerModel {
	private Map<String, Player> players;
	private Connection conn;
	private Statement statement;
	public ServerModel(String url, String username, String password) {
		try {
			conn = DriverManager.getConnection(url, username, password);
			statement = conn.createStatement();
		} catch (SQLException e) {
			
		}
		
		players = new java.util.HashMap<String, Player>();
	}
	static private int serverCode = 12345;
	static private int hashServerClient(String clientCode) {
		return 1;
	}
	public int login(String account, String password) {
		ResultSet rs;
		try {
			rs = statement.executeQuery(
					"select nickName from accounts where account = " + account + " and password = " + password);
			if (rs.getFetchSize() > 0) {
				int hash = hashServerClient(account);
				this.players.put(account, new Player(account, hash));
				return hash;
			} else {
				return -1;
			}
		} catch (SQLException e) {
			return -1;
		}
	}
	public boolean logout(int clientCode, String account) {
		Player player = players.get(account);
		if (player.getHash() != clientCode) {
			return false;
		} else {
			players.remove(account);
			return true;
		}
	}
	
	public void getFriendList(int clientCode, String account) {
		Player player = players.get(account);
		if (player.getHash() != clientCode) {
		} else {
		
		}
	}
	public void addNewFriend(int clientCode, String account, String friend) {
		Player player = players.get(account);
		if (player.getHash() != clientCode) {
		} else {
			ResultSet rs;
			try {
				rs = statement.executeQuery(
						"insert into friends (account_from, account_to) values (" + account + ", " + friend + ")");
			} catch (SQLException e) {
			}
		}
		
	}
	public void deleteFriend(int clientCode, String account, String friend) {
		Player player = players.get(account);
		if (player.getHash() != clientCode) {
		} else {
			ResultSet rs;
			try {
				rs = statement.executeQuery(
						"delete from friends where account_from = " + account + " and account_to = " + friend);
			} catch (SQLException e) {
			}
		}
	}
	public void sendMessage(int clientCode, String account, String friend, String message) {
		
	}
}
