package com.example.lection3;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.widget.TextView;
import android.widget.Toast;

public class OtherActivity extends Activity
{
	final Context context = this;
	Intent gridViewActivityIntent;
	
	private void initializeComponent() {

	}
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_other);
		
		String textFromMain = "";
		Bundle bundle = this.getIntent().getExtras();
		if (bundle != null) {
		    textFromMain = bundle.getString("textInfo");
		}

		Toast.makeText(context, textFromMain, Toast.LENGTH_SHORT).show();
		
		gridViewActivityIntent = new Intent(getApplicationContext(), GridViewActivity.class);
		
		gridViewActivityIntent.putExtra("isGridOK","Grid is OK");
		startActivity(gridViewActivityIntent);
	}

}
