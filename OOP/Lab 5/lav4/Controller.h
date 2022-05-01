#pragma once
#include "Figure.h"
#include "Composite.h"
#include "Square.h"
#include "Rhombus.h"
#include "Triangle.h"
#include "Circle.h"
#include "Memento.h"
#include <string>
ref class Controller
{
public:
	Graphics^ g;
	Figure^ figure1;
	Figure^ figure2;
	Figure^ figure3;
	Figure^ figure4;
	Composite composite;
	static Controller^ instance;
	Controller();
	Controller(Graphics^ g);
	static Controller^ GetInstance(Graphics^ g);
	void AddFigure(char type_figure, int width, int height);
	void ChangeShape(char type_figure);
	void Refresh(int width, int height);
	void Move(bool isRbTailed);
	void ChangeColor(char newColor);
	void Delete();
	void Clear();
	void ChangeEnabled(int index, bool checkBoxChecked);
	void ChangeVisability(bool rBtnChecked);
	Figure^ GetFigure1() { return figure1; };
	Figure^ GetFigure2() { return figure2; };
	Figure^ GetFigure3() { return figure3; };
	Figure^ GetFigure4() { return figure4; };
	Memento^ Save();
	void Upload(Memento^ data);
	void FixTrouble();
};

