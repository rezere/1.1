#pragma once
#include "Figure.h"
using namespace System::Drawing::Drawing2D;
using namespace System::Collections::Generic;

ref class Square :
	public Figure
{
public:
	void Move(int stepX, int stepY, bool withTail) override;
	Square(int x, int y, int width, int height);
	void Draw() override;
	void Refresh() override;
	void ChangeColor(Color cl) override;
	void DrawBorder( Color cl) override;
	void Draw(Color cl) override;
	void PictureBoxBordersAcquisition(bool tailed) override;
	Figure^ Clone() override;
};
