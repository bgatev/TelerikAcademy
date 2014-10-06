import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;


public class Inventory {
	private String name;
	private List<Product> products;
	
	public Inventory(String name){
		this.name = name;
		this.products = new ArrayList<Product>();
	}
	
	public void AddProduct(Product product){
		this.products.add(product);
	}
	
	public double GetSummaryValue(){
		double sum = 0;
		Iterator productsIterator = products.iterator();
		
		while(productsIterator.hasNext()) {
			sum += ((Product)productsIterator.next()).GetValue();
        }

		return sum;
	}
}
