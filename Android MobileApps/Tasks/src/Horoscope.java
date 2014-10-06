import java.io.IOException;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.HashMap;
import java.util.Map;

import org.json.JSONException;
import org.json.JSONObject;

public class Horoscope {
	private static final SimpleDateFormat dateFormat = new SimpleDateFormat("yyyy-MM-dd");
	
	Map<String, HoroscopeDetails> allHoroscopes;
	
	public Horoscope(){
		this.allHoroscopes = new HashMap<String, HoroscopeDetails>();
	}
	
	public void GetHoroscopeFrom(String url, String sign, Date targetDate) throws IOException, JSONException{
		String date = dateFormat.format(targetDate);
		String fullUrl = url + "sign=" + sign + "&date=" + date;
		
		JSONObject json = JsonReader.readJsonFromUrl(fullUrl);
	    //System.out.println(json.toString());
	    //System.out.println(json.get("horoscope"));
	    
	    //String currentSign = json.getJSONObject("horoscope").getString("sign");
	    //System.out.println(currentSign);
	    String currentHoroscope = json.getJSONObject("horoscope").getString("horoscope");
	    //System.out.println(currentHoroscope);
	    
	    HoroscopeDetails currentHoroscopeDetails = this.allHoroscopes.get(sign) != null ? this.allHoroscopes.get(sign) : new HoroscopeDetails();
	    
	    currentHoroscopeDetails.setDate(targetDate);
	    currentHoroscopeDetails.AddHoroscopes(currentHoroscope);
			    
		this.allHoroscopes.put(sign, currentHoroscopeDetails);
	}

	public Map<String, HoroscopeDetails> getAllHoroscopes() {
		return allHoroscopes;
	}

}
