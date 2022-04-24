#include "Controller.h"
#include "Scrambler.h"
#include "Memento.h"
Controller::Controller(Graphics^ g) : g(g) {}
Controller::Controller(){}

Controller^ Controller::GetInstance(Graphics^ g) {
	if (instance==nullptr){
		instance = gcnew Controller(g);
	}
	return instance;
}

void Controller::AddFigure(char type_figure,int width,int height){
	if (figure1 == nullptr)
	{
		switch (type_figure)
		{
		case 'S':
			figure1 = gcnew Square(width, height, 80, 80);
			break;
		case 'T':
			figure1 = gcnew Triangle(width, height, 80, 80);
			break;
		case 'C':
			figure1 = gcnew Circle(width, height, 80, 80);
			break;
		case 'R':
			figure1 = gcnew Rhombus(width, height, 80, 80);
			break;
		}
		figure1->GetGraphics(g);
		figure1->Draw();
	}
	else if (figure2 == nullptr)
	{
		switch (type_figure)
		{
		case 'S':
			figure2 = gcnew Square(width, height + 100, 80, 80);
			break;
		case 'T':
			figure2 = gcnew Triangle(width, height + 100, 80, 80);
			break;
		case 'C':
			figure2 = gcnew Circle(width, height + 100, 80, 80);
			break;
		case 'R':
			figure2 = gcnew Rhombus(width, height + 100, 80, 80);
			break;
		}
		figure2->GetGraphics(g);
		figure2->Draw();
	}
	else if (figure3 == nullptr)
	{
		switch (type_figure)
		{
		case 'S':
			figure3 = gcnew Square(width, height + 200, 80, 80);
			break;
		case 'T':
			figure3 = gcnew Triangle(width, height + 200, 80, 80);
			break;
		case 'C':
			figure3 = gcnew Circle(width, height + 200, 80, 80);
			break;
		case 'R':
			figure3 = gcnew Rhombus(width, height + 200, 80, 80);
			break;
		}
		figure3->GetGraphics(g);
		figure3->Draw();
	}
	else if (figure4 == nullptr)
	{
		switch (type_figure)
		{
		case 'S':
			figure4 = gcnew Square(width, height + 300, 80, 80);
			break;
		case 'T':
			figure4 = gcnew Triangle(width, height + 300, 80, 80);
			break;
		case 'C':
			figure4 = gcnew Circle(width, height + 300, 80, 80);
			break;
		case 'R':
			figure4 = gcnew Rhombus(width, height + 300, 80, 80);
			break;
		}
		figure4->GetGraphics(g);
		figure4->Draw();
	}
}
void Controller::ChangeShape(char type_figure) {
	for (int i = 1; i < 5; i++)
	{
		if (composite.figures.ContainsKey(i))
		{
			int X = 90;
			int Y = 490;
			Color xtraColor = composite.figures[i]->color;
			composite.figures[i]->DrawBorder(SystemColors::Control);
			composite.figures[i]->Draw(SystemColors::Control);
			switch (i)
			{
			case 1:
				figure1 = composite.figures[i];
				X += figure1->x;
				Y += figure1->y;
				switch (type_figure)
				{
				case 'S':
					figure1 = gcnew Square(X, Y, 80, 80);
					figure1->color = xtraColor;
					figure1->enabled = true;
					figure1->GetGraphics(g);
					composite.figures[1] = figure1->Clone();
					break;
				case 'T':
					figure1 = gcnew Triangle(X, Y, 80, 80);
					figure1->color = xtraColor;
					figure1->enabled = true;
					figure1->GetGraphics(g);
					composite.figures[1] = figure1->Clone();
					break;
				case 'C':
					figure1 = gcnew Circle(X, Y, 80, 80);
					figure1->color = xtraColor;
					figure1->enabled = true;
					figure1->GetGraphics(g);
					composite.figures[1] = figure1->Clone();
					break;
				case 'R':
					figure1 = gcnew Rhombus(X, Y, 80, 80);
					figure1->color = xtraColor;
					figure1->enabled = true;
					figure1->GetGraphics(g);
					composite.figures[1] = figure1->Clone();
					break;
				}
				break;
			case 2:
				figure2 = composite.figures[i];
				X += figure2->x;
				Y += figure2->y;
				switch (type_figure)
				{
				case 'S':
					figure2 = gcnew Square(X, Y, 80, 80);
					figure2->color = xtraColor;
					figure2->enabled = true;
					figure2->GetGraphics(g);
					composite.figures[2] = figure2->Clone();
					break;
				case 'T':
					figure2 = gcnew Triangle(X, Y, 80, 80);
					figure2->color = xtraColor;
					figure2->enabled = true;
					figure2->GetGraphics(g);
					composite.figures[2] = figure2->Clone();
					break;
				case 'C':
					figure2 = gcnew Circle(X, Y, 80, 80);
					figure2->color = xtraColor;
					figure2->enabled = true;
					figure2->GetGraphics(g);
					composite.figures[2] = figure2->Clone();
					break;
				case 'R':
					figure2 = gcnew Rhombus(X, Y, 80, 80);
					figure2->color = xtraColor;
					figure2->enabled = true;
					figure2->GetGraphics(g);
					composite.figures[2] = figure2->Clone();
					break;
				}
				break;
			case 3:
				figure3 = composite.figures[i];
				X += figure3->x;
				Y += figure3->y;
				switch (type_figure)
				{
				case 'S':
					figure3 = gcnew Square(X, Y, 80, 80);
					figure3->color = xtraColor;
					figure3->enabled = true;
					figure3->GetGraphics(g);
					composite.figures[3] = figure3->Clone();
					break;
				case 'T':
					figure3 = gcnew Triangle(X, Y, 80, 80);
					figure3->color = xtraColor;
					figure3->enabled = true;
					figure3->GetGraphics(g);
					composite.figures[3] = figure3->Clone();
					break;
				case 'C':
					figure3 = gcnew Circle(X, Y, 80, 80);
					figure3->color = xtraColor;
					figure3->enabled = true;
					figure3->GetGraphics(g);
					composite.figures[3] = figure3->Clone();
					break;
				case 'R':
					figure3 = gcnew Rhombus(X, Y, 80, 80);
					figure3->color = xtraColor;
					figure3->enabled = true;
					figure3->GetGraphics(g);
					composite.figures[3] = figure3->Clone();
					break;
				}
				break;
			case 4:
				figure4 = composite.figures[i];
				X += figure4->x;
				Y += figure4->y;
				switch (type_figure)
				{
				case 'S':
					figure4 = gcnew Square(X, Y, 80, 80);
					figure4->color = xtraColor;
					figure4->enabled = true;
					figure4->GetGraphics(g);
					composite.figures[4] = figure4->Clone();
					break;
				case 'T':
					figure4 = gcnew Triangle(X, Y, 80, 80);
					figure4->color = xtraColor;
					figure4->enabled = true;
					figure4->GetGraphics(g);
					composite.figures[4] = figure4->Clone();
					break;
				case 'C':
					figure4 = gcnew Circle(X, Y, 80, 80);
					figure4->color = xtraColor;
					figure4->enabled = true;
					figure4->GetGraphics(g);
					composite.figures[4] = figure4->Clone();
					break;
				case 'R':
					figure4 = gcnew Rhombus(X, Y, 80, 80);
					figure4->color = xtraColor;
					figure4->enabled = true;
					figure4->GetGraphics(g);
					composite.figures[4] = figure4->Clone();
					break;
				}
				break;
			}
		}
	}
	composite.Draw();
}
void Controller::Delete() {
	for (int i = 1; i < 5; i++)
	{
		if (composite.figures.ContainsKey(i))
		{
			composite.figures.Remove(i);
			switch (i)
			{
			case 1:
			{
				figure1->Draw(SystemColors::Control);
				figure1->DrawBorder(SystemColors::Control);
				figure1 = nullptr;
				break;
			}
			case 2:
			{
				figure2->Draw(SystemColors::Control);
				figure2->DrawBorder(SystemColors::Control);
				figure2 = nullptr;
				break;
			}
			case 3:
			{
				figure3->Draw(SystemColors::Control);
				figure3->DrawBorder(SystemColors::Control);
				figure3 = nullptr;
				break;
			}
			case 4:
			{
				figure4->Draw(SystemColors::Control);
				figure4->DrawBorder(SystemColors::Control);
				figure4 = nullptr;
				break;
			}
			default:
				break;
			}
		}
	}
}
void Controller::Refresh(int width, int height) {
	composite.Refresh();
	for (int i = 1; i < 5; i++)
	{
		if (composite.figures.ContainsKey(i))
		{
			switch (i)
			{
			case 1:
				switch (figure1->name)
				{
				case 'S':
					figure1 = gcnew Square(width, height, 80, 80);
					figure1->enabled = true;
					figure1->GetGraphics(g);
					composite.figures[1] = figure1->Clone();
					break;
				case 'T':
					figure1 = gcnew Triangle(width, height, 80, 80);
					figure1->enabled = true;
					figure1->GetGraphics(g);
					composite.figures[1] = figure1->Clone();
					break;
				case 'C':
					figure1 = gcnew Circle(width, height, 80, 80);
					figure1->enabled = true;
					figure1->GetGraphics(g);
					composite.figures[1] = figure1->Clone();
					break;
				case 'R':
					figure1 = gcnew Rhombus(width, height, 80, 80);
					figure1->enabled = true;
					figure1->GetGraphics(g);
					composite.figures[1] = figure1->Clone();
					break;
				}
				break;
			case 2:
				switch (figure2->name)
				{
				case 'S':
					figure2 = gcnew Square(width, height + 100, 80, 80);
					figure2->GetGraphics(g);
					figure2->enabled = true;
					composite.figures[2] = figure2->Clone();
					break;
				case 'T':
					figure2 = gcnew Triangle(width, height + 100, 80, 80);
					figure2->GetGraphics(g);
					figure2->enabled = true;
					composite.figures[2] = figure2->Clone();
					break;
				case 'C':
					figure2 = gcnew Circle(width, height + 100, 80, 80);
					figure2->GetGraphics(g);
					figure2->enabled = true;
					composite.figures[2] = figure2->Clone();
					break;
				case 'R':
					figure2 = gcnew Rhombus(width, height + 100, 80, 80);
					figure2->GetGraphics(g);
					figure2->enabled = true;
					composite.figures[2] = figure2->Clone();
					break;
				}
				break;
			case 3:
				switch (figure3->name)
				{
				case 'S':
					figure3 = gcnew Square(width, height + 200, 80, 80);
					figure3->GetGraphics(g);
					figure3->enabled = true;
					composite.figures[3] = figure3->Clone();
					break;
				case 'T':
					figure3 = gcnew Triangle(width, height + 200, 80, 80);
					figure3->GetGraphics(g);
					figure3->enabled = true;
					composite.figures[3] = figure3->Clone();
					break;
				case 'C':
					figure3 = gcnew Circle(width, height + 200, 80, 80);
					figure3->GetGraphics(g);
					figure3->enabled = true;
					composite.figures[3] = figure3->Clone();
					break;
				case 'R':
					figure3 = gcnew Rhombus(width, height + 200, 80, 80);
					figure3->GetGraphics(g);
					figure3->enabled = true;
					composite.figures[3] = figure3->Clone();
					break;
				}
				break;
			case 4:
				switch (figure4->name)
				{
				case 'S':
					figure4 = gcnew Square(width, height + 300, 80, 80);
					figure4->GetGraphics(g);
					figure4->enabled = true;
					composite.figures[4] = figure4->Clone();
					break;
				case 'T':
					figure4 = gcnew Triangle(width, height + 300, 80, 80);
					figure4->GetGraphics(g);
					figure4->enabled = true;
					composite.figures[4] = figure4->Clone();
					break;
				case 'C':
					figure4 = gcnew Circle(width, height + 300, 80, 80);
					figure4->GetGraphics(g);
					figure4->enabled = true;
					composite.figures[4] = figure4->Clone();
					break;
				case 'R':
					figure4 = gcnew Rhombus(width, height + 300, 80, 80);
					figure4->GetGraphics(g);
					figure4->enabled = true;
					composite.figures[4] = figure4->Clone();
					break;
				}
				break;
			}
		}
	}
	composite.Draw();
}
void Controller::Move(bool isRbTailed) {
	composite.Move(0, 0, isRbTailed);
	composite.Collisions(Color::Black);
	composite.PictureBoxBordersAcquisition(isRbTailed);
}
void Controller::Clear() {
	g->Clear(SystemColors::Control);
	figure1 = nullptr;
	figure2 = nullptr;
	figure3 = nullptr;
	figure4 = nullptr;

}
void Controller::ChangeColor(char newColor) {
	switch (newColor)
	{
	case 'R':
		composite.ChangeColor(Color::Red);
		break;
	case 'A':
		composite.ChangeColor(Color::Aqua);
		break;
	case 'Y':
		composite.ChangeColor(Color::Yellow);
		break;
	case 'P':
		composite.ChangeColor(Color::Pink);
		break;
	case 'G':
		composite.ChangeColor(Color::Green);
		break;
	case 'B':
		composite.ChangeColor(Color::Black);
		break;
	case 'M':
		composite.ChangeColor(Color::Magenta);
		break;
	case 'C':
		composite.ChangeColor(Color::Cyan);
		break;
	case ' ':
		composite.ChangeColor(Color::Blue);
		break;
	default:
		break;

	}
}
void Controller::ChangeEnabled(int index, bool checkBoxChecked) {
	switch (index) {
	case 1:
		if (figure1 != nullptr)
		{
			figure1->enabled = checkBoxChecked;
			if (figure1->enabled)
			{
				if (composite.figures.ContainsKey(1))
					return;
				composite.Add(1, figure1->Clone());
				figure1->Draw();
				figure1->DrawBorder(Color::Blue);
			}
			else
			{
				if (!composite.figures.ContainsKey(1))
				{
					return;
				}
				figure1 = composite.figures[1];
				figure1->DrawBorder(SystemColors::Control);
				composite.Remove(1);
			}
		}
		break;
	case 2:
		if (figure2 != nullptr)
		{
			figure2->enabled = checkBoxChecked;
			if (figure2->enabled)
			{
				if (composite.figures.ContainsKey(2))
					return;
				composite.Add(2, figure2->Clone());
				figure2->Draw();
				figure2->DrawBorder(Color::Blue);
			}
			else
			{
				if (!composite.figures.ContainsKey(2))
				{
					return;
				}
				figure2 = composite.figures[2];
				figure2->DrawBorder(SystemColors::Control);
				composite.Remove(2);
			}
		}
		break;
	case 3:
		if (figure3 != nullptr)
		{
			figure3->enabled = checkBoxChecked;
			if (figure3->enabled)
			{
				if (composite.figures.ContainsKey(3))
					return;
				composite.Add(3, figure3->Clone());
				figure3->Draw();
				figure3->DrawBorder(Color::Blue);
			}
			else
			{
				if (!composite.figures.ContainsKey(3))
				{
					return;
				}
				figure3 = composite.figures[3];
				figure3->DrawBorder(SystemColors::Control);
				composite.Remove(3);
			}
		}
		break;
	case 4:
		if (figure4 != nullptr)
		{
			figure4->enabled = checkBoxChecked;
			if (figure4->enabled)
			{
				if (composite.figures.ContainsKey(4))
					return;
				composite.Add(4, figure4->Clone());
				figure4->Draw();
				figure4->DrawBorder(Color::Blue);
			}
			else
			{
				if (!composite.figures.ContainsKey(4))
				{
					return;
				}
				figure4 = composite.figures[4];
				figure4->DrawBorder(SystemColors::Control);
				composite.Remove(4);
			}
		}
		break;
	default:
		break;
	}
}
void Controller::ChangeVisability(bool rBtnChecked) {
	for (int i = 1; i < 5; i++)
	{
		if (composite.figures.ContainsKey(i))
		{
			composite.figures[i]->visible = rBtnChecked;
		}
	}
	composite.Draw();
}
Memento^ Controller::Save() {
	Dictionary<int, Figure^>^ xtra = gcnew Dictionary<int, Figure^>(4);
	for (int i = 1; i < 5; i++) {
		if (composite.figures.ContainsKey(i)) {
			xtra->Add(i, composite.figures[i]);
		}
	}

	return gcnew Memento(!composite.figures.ContainsKey(1) && figure1 != nullptr ? figure1 : figure1 == nullptr ? nullptr : composite.figures[1],
		!composite.figures.ContainsKey(2) && figure2 != nullptr ? figure2 : figure2 == nullptr ? nullptr : composite.figures[2],
		!composite.figures.ContainsKey(3) && figure3 != nullptr ? figure3 : figure3 == nullptr ? nullptr : composite.figures[3],
		!composite.figures.ContainsKey(4) && figure4 != nullptr ? figure4 : figure4 == nullptr ? nullptr : composite.figures[4],
		xtra);
}
void Controller::Upload(Memento^ data) {
	Clear();
	for (int i = 1; i < 5; i++)
	{
		composite.Remove(i);
	}
	figure1 = data->figure1;
	figure2 = data->figure2;
	figure3 = data->figure3;
	figure4 = data->figure4;
	if (figure1 != nullptr)
		figure1->GetGraphics(g);
	if (figure2 != nullptr)
		figure2->GetGraphics(g);
	if (figure3 != nullptr)
		figure3->GetGraphics(g);
	if (figure4 != nullptr)
		figure4->GetGraphics(g);
	for (int i = 0; i < 4; i++) {
		switch (i) {
		case 0:
			if (data->indludes[i])
				composite.Add(i+1, figure1->Clone());
			else
				composite.Remove(i);
			break;
		case 1:
			if (data->indludes[i])
				composite.Add(i+1, figure2->Clone());
			else
				composite.Remove(i);
			break;
		case 2:
			if (data->indludes[i])
				composite.Add(i+1, figure3->Clone());
			else
				composite.Remove(i);
			break;
		case 3:
			if (data->indludes[i])
				composite.Add(i+1, figure4->Clone());
			else
				composite.Remove(i);
			break;
		}
	}

	if (figure1 != nullptr)
		figure1->Draw();
	if (figure2 != nullptr)
		figure2->Draw();
	if (figure3 != nullptr)
		figure3->Draw();
	if (figure4 != nullptr)
		figure4->Draw();
}
void Controller::FixTrouble() {
	for (int i = 1; i < 5; i++)
	{
		if (!composite.figures.ContainsKey(i)) {
			switch (i)
			{
			case 1:
				figure1->DrawBorder(SystemColors::Control);
					break;
			case 2:
				figure2->DrawBorder(SystemColors::Control);
				break;
			case 3:
				figure3->DrawBorder(SystemColors::Control);
				break;
			case 4:
				figure4->DrawBorder(SystemColors::Control);
				break;
			default:
				break;
			}

		}
	}
}