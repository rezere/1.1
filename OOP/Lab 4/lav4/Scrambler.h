#pragma once
#include "Memento.h"
#include <fstream>
#include <string>

ref class Scrambler
{
private:
	std::string GetStringByColor(Color color);
	Color GetColorByString(std::string color);
public:
	Memento^ memento;
	Scrambler(Memento^ memento);
	Scrambler();

	void Serialize();
	Memento^ Deserialize();
};

