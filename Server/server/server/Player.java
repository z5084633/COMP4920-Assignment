import java.util.ArrayList;
import java.util.List;

public class Player {
	private String account;
	private String name;
	private int hash;
	private List<String> friends;
	public Player(String account, int hash) {
		this.hash = hash;
		this.account = account;
		friends = new ArrayList<>();
	}
	public int getHash() {
		return hash;
	}
	public String getName() {
		return name;
	}
}
