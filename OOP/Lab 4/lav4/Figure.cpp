#include "Figure.h"

void Figure::Draw( Color cl) {}
void Figure::Move( int stepX, int stepY, bool withTail) {}
void Figure::ChangeColor( Color cl) {}
void Figure::Refresh() {}
void Figure::Draw() {}
void Figure::DrawBorder( Color cl) {}
void Figure::PictureBoxBordersAcquisition( bool tailed) {}
void Figure::Add(int key, Figure^ value) {}
void Figure::Remove(int key) {}
Figure^ Figure::Clone() {return this;}
void Figure::GetGraphics(Graphics^ g)
{
	this->g = g;
}
Figure::Figure()
{
	color = Color::Red;
}
Figure::Figure(int x, int y, int width, int height) :x(x), y(y), width(width), height(height)
{
	color = Color::Red;
}
void Figure::Collision(Figure^ fg1, Figure^ fg2, Color cl)
{
	if (fg1->x <= fg2->x && fg1->x + fg1->width>= fg2->x)
	{
		if (fg1->y <= fg2->y && fg1->y + fg1->height >= fg2->y)
		{
			fg1->color = fg2->color;
		}
		else if (fg1->y <= fg2->y+fg2->height && fg1->y + fg1->height >= fg2->y + fg2->height)
		{
			fg1->color = fg2->color;
		}
		
	}
	if (fg1->x <= fg2->x+fg2->width && fg1->x + fg1->width >= fg2->x + fg2->width)
	{
		if (fg1->y <= fg2->y && fg1->y + fg1->height >= fg2->y)
		{
			fg1->color = fg2->color;
		}
		else if (fg1->y <= fg2->y + fg2->height && fg1->y + fg1->height >= fg2->y + fg2->height)
		{
			fg1->color = fg2->color;
		}
	}
}