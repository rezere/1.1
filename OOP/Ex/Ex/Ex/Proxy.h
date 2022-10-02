#pragma once
#include "Library.h"
using namespace std;
template <typename T>
class Proxy
{
	Library<string> lb;
	bool operation = false;
public:
	void dodaty(T item)
	{
		if (!operation)
		{
			lb.dodaty(item);
			operation = true;
		}
		else cout << endl << "End operation";
	}
	void otrymaty()
	{
		if (!operation)
		{
			lb.otrymaty();
			operation = true;
		}
		else cout << endl << "End operation";
	}
	void otrymaty_po_nomery(int nomer)
	{
		if (!operation)
		{
			lb.otrymaty_po_nomery(nomer);
			operation = true;
		}
		else cout << endl << "End operation";
	}
	void zminyty(T item)
	{
		if (!operation)
		{
			lb.zminyty(item);
			operation = true;
		}
		else cout << endl << "End operation";
	}
	void vydalyty(T item)
	{
		if (!operation)
		{
			lb.vydalyty(item);
			operation = true;
		}
		else cout << endl << "End operation";
	}
	void EndOperation()
	{
		operation = false;
	}
};

