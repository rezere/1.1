package com.example.lab_2;

import androidx.appcompat.app.AppCompatActivity;
import androidx.constraintlayout.widget.ConstraintLayout;

import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

public class MainActivity extends AppCompatActivity {

    EditText editText;
    TextView textView;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        //setContentView(R.layout.activity_main);

        ConstraintLayout constraintLayout = new ConstraintLayout(this);
        textView = new TextView(this);
        textView.setId(View.generateViewId());
        ConstraintLayout.LayoutParams textViewLayout =  new ConstraintLayout.LayoutParams(
                ConstraintLayout.LayoutParams.MATCH_CONSTRAINT, ConstraintLayout.LayoutParams.WRAP_CONTENT
        );
        textViewLayout.topToTop = ConstraintLayout.LayoutParams.PARENT_ID;
        textViewLayout.leftToLeft = ConstraintLayout.LayoutParams.PARENT_ID;
        textViewLayout.rightToRight = ConstraintLayout.LayoutParams.PARENT_ID;
        textView.setLayoutParams(textViewLayout);
        constraintLayout.addView(textView);

        editText = new EditText(this);
        editText.setId(View.generateViewId());
        editText.setHint("Введите имя");
        ConstraintLayout.LayoutParams editTextLayout =  new ConstraintLayout.LayoutParams(
                ConstraintLayout.LayoutParams.MATCH_CONSTRAINT, ConstraintLayout.LayoutParams.WRAP_CONTENT
        );
        editTextLayout.topToBottom = textView.getId();
        editTextLayout.leftToLeft = ConstraintLayout.LayoutParams.PARENT_ID;
        editTextLayout.rightToRight = ConstraintLayout.LayoutParams.PARENT_ID;
        editText.setLayoutParams(editTextLayout);
        constraintLayout.addView(editText);

        Button button = new Button(this);
        button.setText("Ввод");
        ConstraintLayout.LayoutParams buttonLayout =  new ConstraintLayout.LayoutParams(
                ConstraintLayout.LayoutParams.WRAP_CONTENT, ConstraintLayout.LayoutParams.WRAP_CONTENT
        );
        buttonLayout.topToBottom = editText.getId();
        buttonLayout.leftToLeft = ConstraintLayout.LayoutParams.PARENT_ID;
        button.setLayoutParams(buttonLayout);
        constraintLayout.addView(button);

        button.setOnClickListener(new View.OnClickListener() {
            public void onClick(View v) {

                textView.setText("Привет , " + editText.getText());
            }
        });

        setContentView(constraintLayout);
    }
}