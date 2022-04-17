#include "Square.h"
Figure^ Square::Clone() {
	Figure^ fig = gcnew Square(this->x + this->width + 10, this->y + 490, this->width, this->height);
	fig->color = this->color;
	fig->enabled = this->enabled;
	fig->visible = this->visible;
	fig->GetGraphics(this->g);
	return fig;
}
Square::Square(int x, int y, int width, int height)
	: Square::Figure(x, y, width, height) {
	enabled = false;
	visible = true;
	this->x = x - width - 10;
	this->y = y - 490;
	name = 'S';
}
void Square::Draw()
{
	array<Point>^ arrP = {
		Point(x, y),
		Point(x + width, y),
		Point(x + width, y + height),
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
void Square::Move(int stepX, int stepY, bool withTail)
{
	stepX=-2;
	stepY=1;
	if (withTail)
	{
		if (visible)
		{
			DrawBorder( color);
			Draw( color);
			x += stepX;
			y += stepY;
			Draw();
			if (enabled)
				DrawBorder( Color::Blue);
		}
		else
		{
			if (enabled)
			{
				DrawBorder( SystemColors::Control);
				x += stepX;
				y += stepY;
				DrawBorder( Color::Blue);
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
			DrawBorder( SystemColors::Control);
			Draw( SystemColors::Control);
			x += stepX;
			y += stepY;
			Draw();
			if (enabled)
				DrawBorder( Color::Blue);
		}
		else
		{
			if (enabled)
			{
				DrawBorder( SystemColors::Control);
				x += stepX;
				y += stepY;
				DrawBorder( Color::Blue);
			}
			else
			{
				x += stepX;
				y += stepY;
			}
		}
	}
}
void Square::Draw( Color cl)
{
	array<Point>^ arrP = {
		Point(x, y),
		Point(x + width, y),
		Point(x + width, y + height),
		Point(x, y + height)
	};
	g->FillPolygon(gcnew SolidBrush(cl), arrP);
}
void Square::Refresh()
{
	Draw(SystemColors::Control);
	DrawBorder( SystemColors::Control);
}
void Square::ChangeColor( Color cl)
{
	color = cl;
	Draw();
}
void Square::DrawBorder( Color cl)
{
	array<Point>^ arrP = {
		Point(x, y),
		Point(x + width, y),
		Point(x + width, y + height),
		Point(x, y + height)
	};
	g->DrawPolygon(gcnew Pen(cl, 2.0f), arrP);
}
void Square::PictureBoxBordersAcquisition(bool tailed)
{
	if (x < 0)
	{
		if (visible)
		{
			DrawBorder( color);
			if (!tailed)
			{
				Draw( SystemColors::Control);
				DrawBorder( SystemColors::Control);
			}
		}
		else
			DrawBorder( SystemColors::Control);
		x = 719;
	}
	if (y < 0)
	{
		if (visible)
		{
			DrawBorder( color);
			if (!tailed)
			{
				Draw( SystemColors::Control);
				DrawBorder( SystemColors::Control);
			}
		}
		else
			DrawBorder( SystemColors::Control);
		y = 419;
	}
	if (x + width > 800)
	{
		if (visible)
		{
			DrawBorder( color);
			if (!tailed)
			{
				Draw( SystemColors::Control);
				DrawBorder( SystemColors::Control);
			}
		}
		else
			DrawBorder( SystemColors::Control);
		x = 1;
	}
	if (y + height > 500)
	{
		if (visible)
		{
			DrawBorder( color);
			if (!tailed)
			{
				Draw( SystemColors::Control);
				DrawBorder(SystemColors::Control);
			}
		}
		else
			DrawBorder( SystemColors::Control);
		y = 1;
	}
}