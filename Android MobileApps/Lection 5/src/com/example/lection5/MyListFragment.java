package com.example.lection5;

import java.text.SimpleDateFormat;
import java.util.Date;

import android.app.Activity;
import android.app.Fragment;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;

public class MyListFragment extends Fragment {

private static final SimpleDateFormat dateFormat = new SimpleDateFormat("dd-MM-yyyy HH:mm");
  private OnItemSelectedListener listener;
  
  @Override
  public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
    View view = inflater.inflate(R.layout.fragment_list_overview, container, false);
    Button button = (Button) view.findViewById(R.id.button1);
    
    button.setOnClickListener(new View.OnClickListener() { 
    @Override
      public void onClick(View v) {
    	// create fake data
        Date today = new Date();    
        // Send data to Activity
        listener.onItemSelected(dateFormat.format(today));
      }
    });
    
    return view;
  }
  
  @Override
    public void onAttach(Activity activity) {
      super.onAttach(activity);
      if (activity instanceof OnItemSelectedListener) {
        listener = (OnItemSelectedListener) activity;
      } else throw new ClassCastException(activity.toString() + " must implement MyListFragment.OnItemSelectedListener");
    }
} 
