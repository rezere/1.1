package com.example.lab3;
import android.os.Bundle;
import android.view.animation.Animation;
import android.view.animation.AnimationUtils;
import android.widget.ImageView;
import androidx.appcompat.app.AppCompatActivity;

public class MainActivity extends AppCompatActivity{

    @Override

    protected void onCreate (Bundle savedInstanceState) { super.onCreate (savedInstanceState);

        setContentView (R.layout.activity_main);

// Отримуємо посилання на зображення сонця
ImageView sunImageView = (ImageView) findViewById (R.id.sun);

// Анімація для сходу сонця
Animation sunRiseAnimation = AnimationUtils.loadAnimation (this, R.anim.sun_rise);

// Підключаємо анімацію до фотографіїView
   sunImageView.startAnimation (sunRiseAnimation);

    }
}