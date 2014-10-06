
public class Gift {
	final int StoresNumber = 5;
	private String name;
	private String[] stores;
	
	public Gift(String name){
		this.setName(name);
		this.stores = new String[StoresNumber];
	}
	
	public String[] getStores() {
		return stores;
	}
	
	public void setStores(String[] stores) {
		this.stores = stores;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}
}
