package com.example.lection3;

import android.annotation.SuppressLint;
import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.Menu;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

@SuppressLint("NewApi")
public class MainActivity extends Activity
{
	final String TAG = "APPLICATION";
	final Context context = this;
	Intent otherActivityIntent;
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		 super.onCreate(savedInstanceState);

         setContentView(R.layout.activity_main);

         otherActivityIntent = new Intent(getApplicationContext(), OtherActivity.class);
         
         Button button = (Button) findViewById(R.id.button);
         button.setOnClickListener(new View.OnClickListener() {
             public void onClick(View v) {
                 // Perform action on click
            	 EditText editText = (EditText) findViewById(R.id.editText);
            	 String textInfo = editText.getText().toString();
            	 //Toast.makeText(context, textInfo, Toast.LENGTH_SHORT).show();
            	 
            	 otherActivityIntent.putExtra("textInfo",textInfo);
                 startActivity(otherActivityIntent);    	 
             }
         });

	}
	
	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.main, menu);
		return true;
	}
	
	@Override
	public void onStart() {
		super.onStart();
		Log.d(TAG, "onStart");
	}
	
	@Override
	public void onResume() {
		super.onResume();
		Log.d(TAG, "onResume");
	}
	
	@Override
	public void onPause() {
		super.onPause();
		Log.d(TAG, "onResume");
	}
	
	@Override
	public void onStop() {
		super.onStop();
		Log.d(TAG, "onResume");
	}
	
	@Override
	public void onDestroy() {
		super.onDestroy();
		Log.d(TAG, "onResume");
	}
		
	@Override
	protected void onActivityResult(int requestCode, int resultCode, Intent data) {
		Toast.makeText(context, String.valueOf(requestCode), Toast.LENGTH_SHORT).show();
	}
}
