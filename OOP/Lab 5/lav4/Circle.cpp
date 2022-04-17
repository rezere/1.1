#include "Circle.h"
#include <cmath>  
Figure^ Circle::Clone() {
	Figure^ fig = gcnew Circle(this->x + this->width + 10, this->y + 490, this->width, this->height);
	fig->color = this->color;
	fig->enabled = this->enabled;
	fig->visible = this->visible;
	fig->GetGraphics(this->g);
	return fig;
}
Circle::Circle(int x, int y, int width, int height)
	: Circle::Figure(x, y, width, height) {
	enabled = false;
	visible = true;
	this->x = x - width - 10;
	this->y = y - 490;
	name = 'C';
}
void Circle::Draw()
{
	if (!enabled)
	{
		g->DrawEllipse(gcnew Pen(SystemColors::Control,2.0f), x, y, width, height);
	}
	g->FillEllipse(gcnew SolidBrush(color), x, y, width, height);
	if (enabled)
	{
		g->DrawEllipse(gcnew Pen(Color::Blue,2.0f), x, y, width, height);
	}
}
void Circle::Draw(Color cl)
{
	g->FillEllipse(gcnew SolidBrush(cl), x,y,width,height);
}
void Circle::DrawBorder(Color cl)
{
	g->DrawEllipse(gcnew Pen(cl, 2.0f), x, y, width, height);
}
void Circle::PictureBoxBordersAcquisition(bool tailed)
{
	if (x < 0)
	{
		if (visible)
		{
			DrawBorder(color);
			if (!tailed)
			{
				Draw(SystemColors::Control);
				DrawBorder(SystemColors::Control);
			}
		}
		else
			DrawBorder(SystemColors::Control);
		x = 719;
	}
	if (y < 0)
	{
		if (visible)
		{
			DrawBorder(color);
			if (!tailed)
			{
				Draw(SystemColors::Control);
				DrawBorder(SystemColors::Control);
			}
		}
		else
			DrawBorder(SystemColors::Control);
		y = 419;
	}
	if (x + width > 800)
	{
		if (visible)
		{
			DrawBorder(color);
			if (!tailed)
			{
				Draw(SystemColors::Control);
				DrawBorder(SystemColors::Control);
			}
		}
		else
			DrawBorder(SystemColors::Control);
		x = 1;
	}
	if (y + height > 500)
	{
		if (visible)
		{
			DrawBorder(color);
			if (!tailed)
			{
				Draw(SystemColors::Control);
				DrawBorder(SystemColors::Control);
			}
		}
		else
			DrawBorder(SystemColors::Control);
		y = 1;
	}
}
void Circle::ChangeColor(Color cl)
{
	color = cl;
	Draw();
}
void Circle::Refresh()
{
	Draw(SystemColors::Control);
	DrawBorder(SystemColors::Control);
}
void Circle::Move(int stepX, int stepY, bool withTail)
{
	stepX = 2;
	stepY = 1;
	if (withTail)
	{
		if (visible)
		{
			DrawBorder(color);
			Draw(color);
			x += stepX;
			y += stepY;
			Draw();
			if (enabled)
				DrawBorder(Color::Blue);
		}
		else
		{
			if (enabled)
			{
				DrawBorder(SystemColors::Control);
				x += stepX;
				y += stepY;
				DrawBorder(Color::Blue);
			}
			else
			{
				x += stepX;
				y += stepY;
			}
		}
	}
	else
	{
		if (visible)
		{
			DrawBorder(SystemColors::Control);
			Draw(SystemColors::Control);
			x += stepX;
			y += stepY;
			Draw();
			if (enabled)
				DrawBorder(Color::Blue);
		}
		else
		{
			if (enabled)
			{
				DrawBorder(SystemColors::Control);
				x += stepX;
				y += stepY;
				DrawBorder(Color::Blue);
			}
			else
			{
				x += stepX;
				y += stepY;
			}
		}
	}
}