package com.example.lection11;

import android.app.Activity;
import android.os.Bundle;
import android.view.Gravity;
import android.view.View;
import android.widget.Button;
import android.widget.LinearLayout;
import android.widget.LinearLayout.LayoutParams;

public class ImageExample extends Activity {
	
	private final String images[] = {"http://developer.android.com/images/dialog_custom.png", "http://developer.android.com/images/dialog_progress_bar.png"};
	private int i = 0;
	
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        
        final LinearLayout main = new LinearLayout(this);
        main.setOrientation(LinearLayout.VERTICAL);
        main.setGravity(Gravity.CENTER);
        main.setLayoutParams(new LayoutParams(LayoutParams.FILL_PARENT, LayoutParams.FILL_PARENT));
        
        final Button loadImage = new Button(this);
        loadImage.setLayoutParams(new LayoutParams(LayoutParams.WRAP_CONTENT, LayoutParams.WRAP_CONTENT));
        loadImage.setText("Load Image");
        
        main.addView(loadImage);
        
        final LoaderImageView image = new LoaderImageView(this, getAnImageUrl());
        image.setLayoutParams(new LayoutParams(LayoutParams.WRAP_CONTENT, LayoutParams.WRAP_CONTENT));
        
        main.addView(image);
        
        loadImage.setOnClickListener(new View.OnClickListener() {
			@Override
			public void onClick(View v) {
				image.setImageDrawable(getAnImageUrl());
			}
		});
        
        setContentView(main);
    }
    
    private String getAnImageUrl() {
		i++;
		if(i >= images.length) i = 0;
		
		return images[i];
	}
}
