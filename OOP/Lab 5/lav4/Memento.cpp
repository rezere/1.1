#include "Memento.h"
Memento::Memento(Figure^ figure1, Figure^ figure2, Figure^ figure3, Figure^ figure4, Dictionary<int, Figure^>^ composite) :
	figure1(figure1), figure2(figure2), figure3(figure3), figure4(figure4) {
	if (composite != nullptr) {
		this->indludes = new bool[4];
		for (int i = 1; i < 5; i++) {
			if (composite->ContainsKey(i))
				indludes[i-1] = true;
			else
				indludes[i-1] = false;
		}
	}
}
Memento::Memento() {}