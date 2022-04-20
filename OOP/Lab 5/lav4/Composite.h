#pragma once
#include "Figure.h"
using namespace System::Collections::Generic;

ref class Composite : Figure
{
public:
	Dictionary<int, Figure^> figures;

	void Add(int key, Figure^ value) override;
	void Remove(int key) override;
	void Draw() override;
	void Move(int stepX, int stepY, bool withTail) override;
	void Refresh() override;
	void ChangeColor(Color color) override;
	void PictureBoxBordersAcquisition(bool rbTaile1) override;
	void Collisions(Color cl);
};

