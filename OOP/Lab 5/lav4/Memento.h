#pragma once
#include "Composite.h"
ref class Memento
{
public:
	Figure^ figure1;
	Figure^ figure2;
	Figure^ figure3;
	Figure^ figure4;
	bool *indludes;

	Memento(Figure^ figure1, Figure^ figure2, Figure^ figure3, Figure^ figure4, Dictionary<int, Figure^>^ composite);
	Memento();
};

