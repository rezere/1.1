#pragma once
#include "pch.h"
#include<vector>
#include <string>
using namespace std;
template <typename T>
class Library
{
private:
    vector<T> books;
public:
    void dodaty(T item)
    {
        books.push_back(item);
    }
    void otrymaty()
    {
        for (auto ir = books.begin(); ir != books.end(); ++ir)
            cout <<endl<< *ir;
    }
    T otrymaty_po_nomery(int nomer)
    {
        return books.at(nomer);
    }
    void zminyty(T item)
    {
        string temp;
        for (auto ir = books.begin(); ir != books.end(); ++ir)
            if (*ir == item)
            {
                cout << endl << " Write new name";
                cin >> temp;
                *ir = temp;
                break;
            }
    }
    void vydalyty(T item)
    {
        for (auto ir = books.begin(); ir != books.end(); ++ir)
            if (*ir == item)
            {
                books.erase(ir);
                break;
            }
    }
};
