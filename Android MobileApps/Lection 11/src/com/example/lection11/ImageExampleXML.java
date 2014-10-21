package com.example.lection11;

import android.app.Activity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

public class ImageExampleXML extends Activity {
	
	private final String images[] = {"http://developer.android.com/images/dialog_custom.png", "http://developer.android.com/images/dialog_progress_bar.png"};
	private int i = 0;
	
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        final Button loadImage = (Button) findViewById(R.id.button);
        
        final LoaderImageView image = (LoaderImageView) findViewById(R.id.loaderImageView);
        
        loadImage.setOnClickListener(new View.OnClickListener() {
			@Override
			public void onClick(View v) {
				image.setImageDrawable(getAnImageUrl());
			}
		});
    }
    
    private String getAnImageUrl() {
		i++;
		if(i >= images.length) i = 0;
		
		return images[i];
	}
}
