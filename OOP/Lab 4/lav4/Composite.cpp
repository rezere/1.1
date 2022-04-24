#include "Composite.h"

void Composite::Add(int key, Figure^ value)
{
	figures.Add(key, value);
}
void Composite::Remove(int key)
{
	if (figures.ContainsKey(key))
		figures.Remove(key);
}

void Composite::Draw()
{
	for each (KeyValuePair<int, Figure^> item in figures)
		item.Value->Draw();
}
void Composite::Move(int stepX, int stepY, bool withTail)
{
	for each (KeyValuePair<int, Figure^> item in figures)
		item.Value->Move(stepX, stepY, withTail);
}
void Composite::Refresh()
{
	for each (KeyValuePair<int, Figure^> item in figures)
		item.Value->Refresh();
}
void Composite::ChangeColor(Color color)
{
	for each (KeyValuePair<int, Figure^> item in figures)
		item.Value->ChangeColor(color);
}
void Composite::PictureBoxBordersAcquisition(bool rbTaile)
{
	for each (KeyValuePair<int, Figure^> item in figures)
		item.Value->PictureBoxBordersAcquisition(rbTaile);
}
void Composite::Collisions(Color cl)
{
	if (figures.ContainsKey(1) && figures.ContainsKey(2))
		Figure::Collision(figures[1], figures[2],cl);
	if (figures.ContainsKey(1) && figures.ContainsKey(3))
		Figure::Collision(figures[1], figures[3], cl);
	if (figures.ContainsKey(1) && figures.ContainsKey(4))
		Figure::Collision(figures[1], figures[4], cl);
	if (figures.ContainsKey(2) && figures.ContainsKey(3))
		Figure::Collision(figures[2], figures[3], cl);
	if (figures.ContainsKey(2) && figures.ContainsKey(4))
		Figure::Collision(figures[2], figures[4], cl);
	if (figures.ContainsKey(3) && figures.ContainsKey(4))
		Figure::Collision(figures[3], figures[4], cl);

}