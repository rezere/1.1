#include "Triangle.h"
Figure^ Triangle::Clone() {
	Figure^ fig = gcnew Triangle(this->x + this->width + 10, this->y + 490, this->width, this->height);
	fig->color = this->color;
	fig->enabled = this->enabled;
	fig->visible = this->visible;
	fig->GetGraphics(this->g);
	return fig;
}
Triangle::Triangle(int x, int y, int width, int height)
	: Triangle::Figure(x, y, width, height) {
	enabled = false;
	visible = true;
	this->x = x - width - 10;
	this->y = y - 490;
	name = 'T';
}
void Triangle::Draw()
{
	array<Point>^ arrP = {
		Point(x + width/2, y),
		Point(x + width, y+height),
		Point(x, y + height)
	};
	if (!enabled)
	{
		g->DrawPolygon(gcnew Pen(SystemColors::Control, 2.0f), arrP);
	}
	g->FillPolygon(gcnew SolidBrush(color), arrP);
	if (enabled)
	{
		g->DrawPolygon(gcnew Pen(Color::Blue, 2.0f), arrP);
	}


}
void Triangle::Move(int stepX, int stepY, bool withTail)
{
	stepX = 2;
	stepY = 2;
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
void Triangle::Draw(Color cl)
{
	array<Point>^ arrP = {
		Point(x + width / 2, y),
		Point(x + width, y + height),
		Point(x, y + height)
	};
	g->FillPolygon(gcnew SolidBrush(cl), arrP);
}
void Triangle::Refresh()
{
	Draw(SystemColors::Control);
	DrawBorder(SystemColors::Control);
}
void Triangle::ChangeColor(Color cl)
{
	color = cl;
	Draw();
}
void Triangle::DrawBorder(Color cl)
{
	array<Point>^ arrP = {
		Point(x + width / 2, y),
		Point(x + width, y + height),
		Point(x, y + height)
	};
	g->DrawPolygon(gcnew Pen(cl, 2.0f), arrP);
}
void Triangle::PictureBoxBordersAcquisition(bool tailed)
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