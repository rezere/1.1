#include "Scrambler.h"
#include "Square.h"
#include "Circle.h"
#include "Rhombus.h"
#include "Triangle.h"
Scrambler::Scrambler(Memento^ memento) : memento(memento){}
Scrambler::Scrambler() {}

std::string Scrambler::GetStringByColor(Color color) {
	if (color == Color::Red)
	{
		return "Red";
	}
	if (color == Color::Green)
	{
		return "Green";
	}
	if (color == Color::Pink)
	{
		return "Pink";
	}
	if (color == Color::Aqua)
	{
		return "Aqua";
	}
	if (color == Color::Yellow)
	{
		return "Yellow";
	}
	if (color == Color::Black)
	{
		return "Black";
	}
	if (color == Color::Magenta)
	{
		return "Magenta";
	}
	if (color == Color::Cyan)
	{
		return "Cyan";
	}
	if (color == Color::Blue)
	{
		return "Blue";
	}
	return "this color not be";
}

Color Scrambler::GetColorByString(std::string color) {
	if (color == "Red")
	{
		return Color::Red;
	}
	if (color == "Green")
	{
		return Color::Green;
	}
	if (color ==  "Pink")
	{
		return Color::Pink;
	}
	if (color == "Aqua")
	{
		return Color::Aqua;
	}
	if (color == "Yellow")
	{
		return Color::Yellow;
	}
	if (color == "Black")
	{
		return Color::Black;
	}
	if (color == "Magenta")
	{
		return Color::Magenta;
	}
	if (color == "Cyan")
	{
		return Color::Cyan;
	}
	if (color == "Blue")
	{
		return Color::Blue;
	}
	return Color::Red;
}

void Scrambler::Serialize() {
	std::ofstream out("Memento.secret");
	if (memento->figure1 != nullptr) {
		out << memento->figure1->width << " "
			<< memento->figure1->height << " "
			<< memento->figure1->x << " "
			<< memento->figure1->y << " "
			<< GetStringByColor(memento->figure1->color) << " "
			<< memento->figure1->visible << " "
			<< memento->figure1->enabled << " "
			<< memento->figure1->name << std::endl;
	}
	else {
		out << "1 " << "1 " << "1 " << "1 " << "1 " << "1 " << "1 " << "1"<< std::endl;
	}
	if (memento->figure2 != nullptr) {
		out << memento->figure2->width << " "
			<< memento->figure2->height << " "
			<< memento->figure2->x << " "
			<< memento->figure2->y << " "
			<< GetStringByColor(memento->figure2->color) << " "
			<< memento->figure2->visible << " "
			<< memento->figure2->enabled << " "
			<< memento->figure2->name << std::endl;
	}
	else {
		out << "1 " << "1 " << "1 " << "1 " << "1 " << "1 " << "1 " << "1" << std::endl;
	}
	if (memento->figure3 != nullptr) {
		out << memento->figure3->width << " "
			<< memento->figure3->height << " "
			<< memento->figure3->x << " "
			<< memento->figure3->y << " "
			<< GetStringByColor(memento->figure3->color) << " "
			<< memento->figure3->visible << " "
			<< memento->figure3->enabled << " "
			<< memento->figure3->name << std::endl;
	}
	else {
		out << "1 " << "1 " << "1 " << "1 " << "1 " << "1 " << "1 " << "1" << std::endl;
	}
	if (memento->figure4 != nullptr) {
		out << memento->figure4->width << " "
			<< memento->figure4->height << " "
			<< memento->figure4->x << " "
			<< memento->figure4->y << " "
			<< GetStringByColor(memento->figure4->color) << " "
			<< memento->figure4->visible << " "
			<< memento->figure4->enabled << " "
			<< memento->figure4->name << std::endl;
	}
	else {
		out << "1 " << "1 " << "1 " << "1 " << "1 " << "1 " << "1 " << "1" << std::endl;
	}
	for (int i = 0; i < 4; i++)
	{
		if(i!=3)
			out << memento->indludes[i]<<" ";
		else
			out << memento->indludes[i];
	}
}
Memento^ Scrambler::Deserialize() {
	int width, height, x, y;
	char name;
	std::string color;
	bool enabled, visible;
	bool* includes = new bool[4];
	Figure^ figure;

	Memento^ memento = gcnew Memento();

	int counter = 0;
	std::ifstream in("Memento.secret");

	while (in >> width >> height >> x >> y >> color >> visible >> enabled >> name) {
		if (width == height == x == y == 1){
			counter++;
			continue;
		}
		switch (name)
		{
		case 'S':
			figure = gcnew Square(0, 0, 0, 0);
			break;
		case 'T':
			figure = gcnew Triangle(0, 0, 0, 0);
			break;
		case 'R':
			figure = gcnew Rhombus(0, 0, 0, 0);
			break;
		case 'C':
			figure = gcnew Circle(0, 0, 0, 0);
			break;
		}
		figure->width = width;
		figure->height = height;
		figure->x = x;
		figure->y = y;
		figure->color = GetColorByString(color);
		figure->visible = visible;
		figure->enabled = enabled;
		figure->name = name;
		switch (counter)
		{
		case 0:
			memento->figure1 = figure;
		case 1:
			memento->figure2 = figure;
		case 2:
			memento->figure3 = figure;
		case 3:
			memento->figure4 = figure;
		}
		counter++;

	}
	includes[0] = width;
	includes[1] = height;
	includes[2] = x;
	includes[3] = y;

	memento->indludes = includes;
	return memento;
}