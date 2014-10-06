import static java.lang.System.out;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.StringWriter;
import java.nio.charset.StandardCharsets;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.HashMap;
import java.util.Map;
import java.util.Random;
import java.util.Scanner;

import org.json.JSONException;

public class Program {

	private static final SimpleDateFormat dateFormat = new SimpleDateFormat("dd/MM/yyyy");
	private static final Date invalidDate = new Date(0);
	
	public static String ReverseString(String input){
		String result = "";
	    
	    for (int i = input.length() - 1; i > -1; i--)
	    {
	        result += input.charAt(i);
	    }
	    
	    return result;
	}
	
	public static Map CountWords(String input){	
		String[] allWordsString = input.split(" ");
		
		Map<String, Object> allWords = new HashMap<String, Object>();
		
		for(int i = 0; i < allWordsString.length; i++){			
			if (allWords.get(allWordsString[i]) != null) {
				int counter = (int) allWords.get(allWordsString[i]);
				allWords.put(allWordsString[i], counter + 1);
			}
			else allWords.put(allWordsString[i], 1);
		}
		
		return allWords;
	}
	
	public static String ReadFileAsString(String filename) throws FileNotFoundException, IOException{
		FileInputStream fileInput = new FileInputStream(new File(filename));
		
        java.util.Scanner scanner = new java.util.Scanner(fileInput,StandardCharsets.UTF_8.name()).useDelimiter("\r");
        String result = "";
        while (scanner.hasNext()){
        	result += scanner.next();
        }
        
        scanner.close();
        
        return result;
	}
	
	private static final Date fromString(String input) {
        try {
            return dateFormat.parse(input);
        } catch(ParseException e) {
        	e.printStackTrace();
        	return invalidDate;
        }
    }
	
	public static void main(String[] args) throws IOException, JSONException {
		/*
		//Task 1
		Scanner reader = new Scanner(System.in);
		
	    System.out.println("Input String: ");
	    String input = reader.nextLine();
	    	    
	    out.println(ReverseString(input));
	    
	    //Task 2
	    String stringFromFile = "";
		try {
			stringFromFile = ReadFileAsString("Radius.txt");
		} catch (FileNotFoundException e) {
			e.printStackTrace();
		} catch (IOException e) {
			e.printStackTrace();
		}
	    
	    Map<String, Object> myWords = CountWords(stringFromFile);
	    
	    for (Map.Entry<String, Object> entry : myWords.entrySet()) {
	        String key = entry.getKey();
	        Object value = entry.getValue();
	        
	        out.println(key + " -> " + value);
	    }
	    
	    //Task 3
	    Date[] importantDates = {
	            fromString("01/01/2015"),
	            fromString("25/12/2014"),
	            fromString("14/02/2014")
	        };
	    Gift[] allGifts = {
	    		new Gift("pen"),
	    		new Gift("car"),
	    		new Gift("bicycle"),
	    		new Gift("computer")
	    	};
	    
	    String[] penStores = {"Metro", "Billa", "Carefour", "Bai-Pesho's Shop"};
	    String[] carStores = {"BalkanStar", "AutoFrance", "AutoMotor", "Porsche BG"};
	    String[] bicycleStores = {"Sport Depot", "Mariika's Shop"};
	    String[] computerStores = {"Technomarket", "Technopolis", "Most"};
	    
	    allGifts[0].setStores(penStores);
	    allGifts[1].setStores(carStores);
	    allGifts[2].setStores(bicycleStores);
	    allGifts[3].setStores(computerStores);
	    
	    Human pesho = new Human("Pesho");
	    pesho.setBirthDay(fromString("03/10/2014"));
	    
	    Date today = new Date();
	    
	    Random random = new Random();
	    
	    for(int i = 0; i < importantDates.length; i++){    	
	    	if ( ( dateFormat.format(today).compareTo(dateFormat.format(pesho.getBirthDay())) == 0 ) || 
	    			( dateFormat.format(today).compareTo(dateFormat.format(importantDates[i])) == 0) ){
	    		
	    		//send pesho a present
	    		int randomGiftIndex = random.nextInt(allGifts.length);
	    		Gift peshoGift = allGifts[randomGiftIndex];

	    		int randomStoreIndex = random.nextInt(peshoGift.getStores().length);
	    		String peshoGiftStore = peshoGift.getStores()[randomStoreIndex];
	    		
	    		out.println(String.format("%s received %s from %s", pesho.getName(), peshoGift.getName(), peshoGiftStore));
	    		break;
	    	}
	    }
	    
		//Task 4
		Horoscope mine = new Horoscope();
		Date horoscopeDate = fromString("02/10/2014");
		Date horoscopeDate1 = fromString("02/08/2014");
		String sign = "Aries";
		
		mine.GetHoroscopeFrom("http://widgets.fabulously40.com/horoscope.json?", sign, horoscopeDate);
		mine.GetHoroscopeFrom("http://widgets.fabulously40.com/horoscope.json?", sign, horoscopeDate1);
		Map<String, HoroscopeDetails> allHoroscopes = mine.getAllHoroscopes();
		
		for(int i = 0; i < allHoroscopes.size(); i++){
			out.println(String.format("%s %s %s", sign, dateFormat.format(horoscopeDate).toString(), allHoroscopes.get(sign).toString()));
		}
		
	    //Task 5
	    Inventory store = new Inventory("Warehouse");
	    Product salt = new Product(1, 1.1, 4);
	    Product pepper = new Product(2, 1.6, 2);
	    
	    store.AddProduct(salt);
	    out.println(store.GetSummaryValue());
	    
	    store.AddProduct(pepper);
	    out.println(store.GetSummaryValue());
	    */
		
		//Task 6
		
		
		
		
	}

}
