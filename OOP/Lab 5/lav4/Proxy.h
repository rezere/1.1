#pragma once
#include "Controller.h"

ref class Proxy
{
public:
	static Controller^ controller;
	Proxy()
	{
		//controller = gcnew Controller();
	}
	~Proxy()
	{
		delete controller;
	}
	static void GetInstance(Graphics^ g)
	{
		controller->GetInstance(g);
	}
	void AddFigure(char type_figure, int width, int height)
	{
		controller->AddFigure(type_figure, width, height);
	}
	void ChangeShape(char type_figure)
	{
		controller->ChangeShape(type_figure);
	}
	void Move(bool isRbTailed)
	{
		controller->Move(isRbTailed);
	}
	void ChangeColor(char newColor)
	{
		controller->ChangeColor(newColor);
	}
};

