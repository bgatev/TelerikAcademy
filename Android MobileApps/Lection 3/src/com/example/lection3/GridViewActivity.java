package com.example.lection3;

import android.app.Activity;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.GridView;
import android.widget.Toast;

public class GridViewActivity extends Activity {
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
	    setContentView(R.layout.grid_view);

	    GridView gridview = (GridView) findViewById(R.id.grid_view);
	    gridview.setAdapter(new ImageAdapter(this));
		
		Bundle bundle = this.getIntent().getExtras();
		if (bundle != null) {	
		
		    gridview.setOnItemClickListener(new OnItemClickListener() {
		        
		    	public void onItemClick(AdapterView<?> parent, View v, int position, long id) {
		            Toast.makeText(GridViewActivity.this, "" + position, Toast.LENGTH_SHORT).show();
		        }
	
		    });
		}

	}
}
