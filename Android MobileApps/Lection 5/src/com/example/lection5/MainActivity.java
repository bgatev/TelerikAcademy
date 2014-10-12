package com.example.lection5;

import android.app.Activity;
import android.app.FragmentTransaction;
import android.content.Intent;
import android.os.Bundle;

public class MainActivity extends Activity implements OnSelectedListener{
    
	@Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
    }

	@Override
	public void onArticleSelected(String textToShow) {

        DetailFragment detailsFragment = (DetailFragment)getFragmentManager().findFragmentById(R.id.detailFragment);

        if (detailsFragment != null) {
        	detailsFragment.setText(textToShow);
        } 
    }	
}
