package com.example.lection11;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.Gravity;
import android.view.View;
import android.view.ViewGroup.LayoutParams;
import android.widget.Button;
import android.widget.LinearLayout;

public class MainActivity extends Activity {

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);

		final LinearLayout main = new LinearLayout(this);
		main.setOrientation(LinearLayout.VERTICAL);
		main.setGravity(Gravity.CENTER);
		main.setLayoutParams(new LayoutParams(LayoutParams.FILL_PARENT, LayoutParams.FILL_PARENT));
		
		
		final Button xmlExample = new Button(this);
		xmlExample.setLayoutParams(new LayoutParams(LayoutParams.WRAP_CONTENT, LayoutParams.WRAP_CONTENT));
		xmlExample.setText("XML Example");
        
        final Button progExample = new Button(this);
        progExample.setLayoutParams(new LayoutParams(LayoutParams.WRAP_CONTENT, LayoutParams.WRAP_CONTENT));
        progExample.setText("Prog Example");
		
        main.addView(xmlExample);
        main.addView(progExample);
        
        xmlExample.setOnClickListener(new View.OnClickListener() {
			@Override
			public void onClick(View v) {
				startActivity(new Intent(MainActivity.this, ImageExampleXML.class));
			}
		});
        
        progExample.setOnClickListener(new View.OnClickListener() {
			@Override
			public void onClick(View v) {
				startActivity(new Intent(MainActivity.this, ImageExample.class));
			}
		});
        
        setContentView(main);
	}
}
