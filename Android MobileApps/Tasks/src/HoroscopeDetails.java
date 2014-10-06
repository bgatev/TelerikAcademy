import java.util.ArrayList;
import java.util.Date;
import java.util.List;

public class HoroscopeDetails {
	private Date date;
	private List<String> horoscopes;
	
	public HoroscopeDetails(){
		this.horoscopes = new ArrayList<String>();
	}
	
	public Date getDate() {
		return date;
	}
	
	public void setDate(Date date) {
		this.date = date;
	}
	
	public void AddHoroscopes(String horoscope){
		this.horoscopes.add(horoscope);
	}
	
	public List<String> getHoroscopes() {
		return horoscopes;
	}
	
	@Override public String toString() {
		StringBuilder result = new StringBuilder();
		
		for(int i = 0; i < this.horoscopes.size(); i++){
			result.append(System.getProperty("line.separator"));
			result.append(i+1 + ". " + this.horoscopes.get(i));
		}
		
		return result.toString();
	}
}
