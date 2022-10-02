#include "pch.h"
#include<vector>
#include <string>
#include <iostream>
#include "Proxy.h"
using namespace System;
using namespace std;

int main()
{
    Proxy<string> *pr = new Proxy<string>();
    int k;
    while (true)
    {
        cout << endl << "1.Add";
        cout << endl << "2.See book";
        cout << endl << "3.See to number";
        cout << endl << "4.Rename";
        cout << endl << "5. Delete";
        cout << endl << "6. End Operation";
        cin >> k;
        switch (k)
        {
        case 1:
        {
            string add;
            cout << endl << "Add name book: ";
            cin >> add;
            pr->dodaty(add);
            break;
        }
        case 2:
        {
            pr->otrymaty();
            break;
        }
        case 3:
        {
            int number;
            cout << endl << "Write number: ";
            cin >> number;
            pr->otrymaty_po_nomery(number);
            break;
        }
        case 4:
        {
            string name;
            cout << endl << "Write name book for delete: ";
            cin >> name;
            pr->zminyty(name);
            break;
        }
        case 5:
        {
            string name;
            cout << endl << "Write name book for delete: ";
            cin >> name;
            pr->vydalyty(name);
            break;
        }
        case 6:
        {
            pr->EndOperation();
            break;
        }
        default:
            break;
        }
    }
    return 0;
}
