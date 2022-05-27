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
    PettyCashOffline   offlineCash;
    bool operation = false;
public:
    bool withdraw(Person& p, int amount)
    {
        if(!operation)
        {
            if (p.name() == "Nickolay" || p.name() == "Pavel"
                || p.name() == "Anton")
                return realThing.withdraw(amount);
            else
                return false;
        }
        else 
            cout << "Operation not end" << '\n';
    }
    int getBalance()
    {
        return realThing.getBalance();
    }
};

int main()
{
    PettyCash pc;
    Person workers[4];
    for (int i = 0, amount = 100; i < 4; i++, amount += 100)
        if (!pc.withdraw(workers[i], amount))
            cout << "No money for " << workers[i].name() << '\n';
        else
            cout << amount << " UAH for " << workers[i].name() << '\n';
    cout << " His balance is " << pc.getBalance() << '\n';
}
