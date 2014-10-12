package com.example.lection4;

import android.support.v7.app.ActionBarActivity;
import android.content.Context;
import android.os.Bundle;
import android.view.Gravity;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup.LayoutParams;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.ImageButton;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.PopupWindow;
import android.widget.TextView;

public class MainActivity extends ActionBarActivity implements OnClickListener{

	final Context context = this;
	TextView text1, text2, text3;
	Boolean isButtonClicked = false;
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		
		ImageView sample0 = (ImageView)findViewById(R.id.imageView1);
		ImageView sample1 = (ImageView)findViewById(R.id.imageView2);
		ImageView sample2 = (ImageView)findViewById(R.id.imageView3);
		
		text1 = (TextView)findViewById(R.id.editText1);
		text2 = (TextView)findViewById(R.id.editText2);
		text3 = (TextView)findViewById(R.id.editText3);
		
		text1.setVisibility(View.GONE);
		text2.setVisibility(View.GONE);
		text3.setVisibility(View.GONE);
		
		sample0.setOnClickListener(this);
		sample1.setOnClickListener(this);
		sample2.setOnClickListener(this);
		
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.main, menu);
		return true;
	}

	@Override
	public boolean onOptionsItemSelected(MenuItem item) {
		// Handle action bar item clicks here. The action bar will
		// automatically handle clicks on the Home/Up button, so long
		// as you specify a parent activity in AndroidManifest.xml.
		int id = item.getItemId();
		if (id == R.id.action_settings) {
			return true;
		}
		return super.onOptionsItemSelected(item);
	}

	@Override
	public void onClick(View view) {
	    if (view.getId() == R.id.imageView1) {
	    	if (!isButtonClicked){
		    	text1.setVisibility(View.VISIBLE);
		    	isButtonClicked = true;
	    	}
	    	else {
	    		text1.setVisibility(View.GONE);
	    		isButtonClicked = false;
	    	}
	    }
	    else if (view.getId() == R.id.imageView2) {
	    	if (!isButtonClicked){
		    	text2.setVisibility(View.VISIBLE);
		    	isButtonClicked = true;
	    	}
	    	else {
	    		text2.setVisibility(View.GONE);
	    		isButtonClicked = false;
	    	}
	    }
	    else if (view.getId() == R.id.imageView3) {
	    	if (!isButtonClicked){
		    	text3.setVisibility(View.VISIBLE);
		    	isButtonClicked = true;
	    	}
	    	else {
	    		text3.setVisibility(View.GONE);
	    		isButtonClicked = false;
	    	}
	    }
	    else {
	    	text1.setVisibility(View.GONE);
			text2.setVisibility(View.GONE);
			text3.setVisibility(View.GONE);
	    }
	  }
}
