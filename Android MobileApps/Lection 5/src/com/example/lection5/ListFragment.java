package com.example.lection5;

import android.app.Activity;
import android.app.Fragment;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

public class ListFragment extends Fragment {
	OnSelectedListener mCallback;

	ListView listView;
	
	@Override
    public void onAttach(Activity activity) {
        super.onAttach(activity);
        
        // This makes sure that the container activity has implemented
        // the callback interface. If not, it throws an exception
        try {
            mCallback = (OnSelectedListener) activity;
        } catch (ClassCastException e) {
            throw new ClassCastException(activity.toString() + " must implement OnSelectedListener");
        }
    }

	@Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
	    // TODO Auto-generated method stub
		View view = inflater.inflate(R.layout.fragment_item_list, container, false);
		initializeComponents(view);
	    
		return view;
    }
  
	private void initializeComponents(View view) {
		listView = (ListView)view.findViewById(R.id.list);
		
		
        String[] productNames = new String[] { "Product 0", "Product 1", "Product 2", "Product 3", "Product 4" }; 

        ArrayAdapter<String> adapter = new ArrayAdapter<String>(getActivity(), android.R.layout.simple_list_item_1, android.R.id.text1, productNames);
        
        // Assign adapter to ListView
        listView.setAdapter(adapter); 
        
		listView.setOnItemClickListener(new OnItemClickListener() {

			@Override
			public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
				// ListView Clicked item index
                int itemPosition = position;
                
                // ListView Clicked item value
                String itemValue = (String) listView.getItemAtPosition(position);
                   
                 // Show Alert 
                String textToShow = "Item: " + itemValue + "\nID: " + itemPosition;
                //Toast.makeText(getActivity(), textToShow, Toast.LENGTH_LONG).show();
                mCallback.onArticleSelected(textToShow);
			}
		});
	}
} 
