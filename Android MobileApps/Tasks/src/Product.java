
public class Product {
	private double price;
	private int id;
	private int quantity;
	
	public Product(int id, double price, int quantity){
		this.id = id;
		if (price < 0) this.price = 0.01;
		else this.price = price;
		
		if (quantity < 1) this.quantity = 1;
		else this.quantity = quantity;
	}
	
	public void AddQuantity(int quantity){
		this.quantity += quantity;
	}
	
	public void ChangePrice(double price){
		this.price = price;
	}
	
	public double GetValue(){
		return this.quantity * this.price;
	}
}
