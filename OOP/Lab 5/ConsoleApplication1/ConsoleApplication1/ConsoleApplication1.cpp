#include<iostream>
#include<string.h>
#include <string>
using namespace std;
class Person
{
    string nameString;
    static string list[];
    static int next;
public:
    Person()
    {
        nameString = list[next++];
    }
    string name()
    {
        return nameString;
    }
};
string Person::list[] =
{
  "Nickolay", "Pavel", "Anton", "Vasya"
};
int Person::next = 0;
int balance = 500;

class PettyCashProtected
{
public:
    bool withdraw(int amount)
    {
        if (amount > balance)
            return false;
        balance -= amount;
        return true;
    }
    int getBalance()
    {
        return balance;
    }
};
class PettyCashOffline
{
public:
    bool withdraw(int amount)
    {
        if (amount > balance)
            return false;
        balance -= amount;
        return true;
    }
    int getBalance()
    {
        return balance;
    }
};
class PettyCash
{
    PettyCashProtected realThing;
    PettyCashOffline offlineCash;
    bool operation = false;
public:
    bool withdraw(Person& p, int amount, string type)
    {
        if(!operation)
        {
            if (p.name() == "Nickolay" || p.name() == "Pavel"
                || p.name() == "Anton")
                if(type == "online")
                {
                    operation = true;
                    return realThing.withdraw(amount);
                }
                else if(type == "offline")
                {
                    operation = true;
                    return offlineCash.withdraw(amount);
                }
            else
                return false;
        }
        else 
            cout << "Operation not end " << '\n';
    }
    void endOperation()
    {
        operation = false;
    }
    int getBalance()
    {
        if (!operation)
        {
            return realThing.getBalance();
        }
        else return -1;
    }
};

int main()
{
    PettyCash pc;
    Person workers[4];
    int amount = 100;
    if (!pc.withdraw(workers[0], amount, "online"))
        cout << "No money for " << workers[0].name() << '\n';
    else
        cout << amount << " UAH for " << workers[0].name() << '\n';
    if (pc.getBalance() == -1)
    {
        cout << "Operation not End"  <<'\n';
    }
    else
    {
        cout << "Ballans " << pc.getBalance() << '\n';
    }
    pc.endOperation();
    cout << "Ballans " << pc.getBalance() << '\n';
}