#pragma once
using namespace System::Drawing;
using namespace System::Drawing::Drawing2D;

ref class Figure
{
protected:
	Graphics^ g;
public:
	int width;
	int height;
	int x;
	int y;
	Color color;
	bool visible;
	bool enabled;
	char name;
	
	Figure();
	Figure(int x, int y, int width, int height);
	virtual void Draw();
	virtual void DrawBorder( Color cl);
	virtual void Move( int stepX, int stepY, bool withTail);
	virtual void Refresh();
	virtual void ChangeColor( Color cl);
	virtual void Draw(Color cl);
	virtual void PictureBoxBordersAcquisition(bool tailed);
	virtual void GetGraphics(Graphics^ g);
	static void Collision(Figure^ fg1, Figure^ fg2, Color cl);

	virtual void Add(int key, Figure^ value);
	virtual void Remove(int key);

	virtual Figure^ Clone();
};