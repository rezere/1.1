#include <vector>
#include <iostream>
#include <cstdlib>
#include <cmath>
#include <cstring>
const float P = 0.5;
using namespace std;


struct snode
{
    int value;
    snode** forw;
    snode(int level, int& value)
    {
        forw = new snode * [level + 1];
        memset(forw, 0, sizeof(snode*) * (level + 1));
        this->value = value;
    }
    ~snode()
    {
        delete[] forw;
    }
};

struct skiplist
{
    snode* header;
    int value;
    int level;
    int max_level;
    int mode;
    skiplist()
    {
        max_level = 20;
        header = new snode(max_level, value);
        level = 0;
        mode = 0;
    }
    ~skiplist()
    {
        delete header;
    }
    void display();
    bool contains(int&);
    void insert_element(int&,int);
    void delete_element(int&);
    void copy(skiplist& target);
    void clear();
    int random_level();
    int getCount();
    void updateLevels(int);
};

void skiplist::display()
{
    if (header->forw[0] == NULL) {
        cout << endl << "List empty";
    }
    else {
        for (int i = 0; i <= level; i++) {
            const snode* x = header->forw[i];
            cout << "level " << i << " : ";
            while (x != NULL)
            {
                cout << x->value;
                x = x->forw[i];
                if (x != NULL)
                    cout << " -> ";
            }
            cout << endl;
        }
    }
}


bool skiplist::contains(int& s_value)
{
    snode* x = header;
    for (int i = level; i >= 0; i--)
    {
        while (x->forw[i] != NULL && x->forw[i]->value < s_value)
        {
            x = x->forw[i];
        }
    }
    x = x->forw[0];
    return x != NULL && x->value == s_value;
}

void skiplist::copy(skiplist& target) {
    target.level = level;
    snode* x = header;
    snode** update = new snode * [max_level + 1];
    memset(update, 0, sizeof(snode*) * (max_level + 1));
    for (int i = level; i >= 0; i--)
    {
        update[i] = x->forw[i];
    }
    snode** newupdate = new snode * [max_level + 1];
    memset(newupdate, 0, sizeof(snode*) * (max_level + 1));
    
    int counter = 0;
    while (update[0] != NULL) {
        int lvl = 0;
        for (int i = 1; i <= level; i++) {
            if (update[i] != NULL) {
                if (update[i]->value == update[0]->value) lvl++;
            }
        }
        snode* newNode = new snode(lvl, update[0]->value);
        for (int i = 0; i <= lvl; i++) {
            if (newupdate[i] == NULL) {
                newupdate[i] = newNode;
                target.header->forw[i] = newupdate[i];
            }
            else {
                newupdate[i]->forw[i] = newNode;
                newupdate[i] = newupdate[i]->forw[i];
            }
            update[i] = update[i]->forw[i];
        }
        counter++;
    }
}

void skiplist::clear() {
    while (header->forw[0] != NULL) {
        delete_element(header->forw[0]->value);
    }
}

int skiplist::getCount() {
    int count = 0;
    snode* x = header->forw[0];
    while (x != NULL) {
        count++;
        x = x->forw[0];
    }
    return count;
}

void skiplist::updateLevels(int max) {
    if (max != max_level) {
        snode* x = header->forw[0];
        vector<int> values;
        while (x != NULL) {
            values.push_back(x->value);
            x = x->forw[0];
        }
        clear();
        max_level = max;
        delete header;
        header = new snode(max_level, value);
        for (int i = 0; i < values.size(); i++) {
            insert_element(values[i], i + 1);
        }
    }
}

int main()
{
    skiplist ss;
    skiplist copy;
    int ans, n,b;
    while (true)
    {
        cout << "1.Insert " << endl;
        cout << "2.Delete " << endl;
        cout << "3.Search " << endl;
        cout << "4.Cout " << endl;
        cout << "5.Copy " << endl;
        cout << "6.Clear " << endl;
        cout << "7.Change deep " << endl;
        cout << "8.Exit " << endl;
        cout << "Enter variant: ";
        cin >> ans;
        switch (ans)
        {
        case 1:
            cout << "1 - random pos / 2 - algorithm: ";
            cin >> b;
            cout << "Enter element ";
            cin >> n;
            if (b == 1) {
                ss.insert_element(n,-1);
            }
            else 
            {
                ss.insert_element(n, 0);
            }
            break;
        case 2:
            cout << "Enter the element ";
            cin >> n;
            if (!ss.contains(n))
            {
                cout << "Element not found" << endl;
                break;
            }
            ss.delete_element(n);
            if (!ss.contains(n))
                cout << "Element Deleted" << endl;
            break;
        case 3:
            cout << "Enter the element: ";
            cin >> n;
            if (ss.contains(n))
                cout << "Element " << n << " is in the list" << endl;
            else
                cout << "Element not found" << endl;
        case 4:
            cout << "The List is: " << endl;
            ss.display();
            break;
        case 5:
            ss.copy(copy);
            cout << "The List is: " << endl;
            copy.display();
            copy.clear();
            break;
        case 6:
            ss.clear();
            cout << "List cleared" << endl;
            break;
        case 7:
            cout << "Select max level type 1 - constant/ 2 - max(20)/ 3- function: ";
            cin >> n;
            switch (n) {
            case 1:
                cout << "Enter the element to be inserted: ";
                cin >> n;
                ss.updateLevels(n);
                break;
            case 2:
                ss.updateLevels(20);
                break;
            case 3:
                int count = ss.getCount();
                n = 1;
                for (int i = 2; i < 20; i++) {
                    if (count > pow(2, i)) n++;
                }
                ss.updateLevels(n+1);
                break;
            }
            break;
        case 8:
            exit(1);
            break;
        default:
            cout << "Wrong Choice" << endl;
        }
    }
    return 0;
}


float frand()
{
    return (float)rand() / RAND_MAX;
}


int skiplist::random_level()
{
    static bool first = true;
    if (first)
    {
        srand((unsigned)time(NULL));
        first = false;
    }
    float random = frand();
    int lvl = (int)(log(random) / log(1. - P));
    cout << endl << "lvl = " << lvl << " frand = " << random << "log = " << (1. -P) << endl;
    return lvl < max_level ? lvl : max_level;
}


void skiplist::insert_element(int& value, int first)
{
    if (first == 0) {
        mode = 0;
        snode* x = header->forw[0];
        vector<int> values;
        if (!contains(value)) {
            bool inserted = false;
            while (x != NULL) {
                if (x->value > value && inserted == false) {
                    values.push_back(value);
                    inserted = true;
                }
                values.push_back(x->value);
                x = x->forw[0];
            }
            if(inserted == false) values.push_back(value);
            clear();
            for (int i = 0; i < values.size(); i++) {
                insert_element(values[i], i + 1);
            }
        }
        else {
            cout << endl << "Element exist";
        }
    }
    else 
    {
        mode = -1;
        snode* x = header;
        snode** update = new snode *[max_level + 1];
        memset(update, 0, sizeof(snode*) * (max_level + 1));
        for (int i = level; i >= 0; i--)
        {
            while (x->forw[i] != NULL && x->forw[i]->value < value)
            {
                x = x->forw[i];
            }
            update[i] = x;
        }
        x = x->forw[0];
        if (x == NULL || x->value != value)
        {
            int lvl = 0;
            if(first == -1) lvl = random_level();
            else {
                for (int i = 1; i < max_level; i++) {
                    if (first % (int)pow(2, i) == 0) lvl = i;
                }
            }
            if (lvl > level)
            {
                for (int i = level + 1; i <= lvl; i++)
                {
                    update[i] = header;
                }
                level = lvl;
            }
            x = new snode(lvl, value);
            for (int i = 0; i <= lvl; i++)
            {
                x->forw[i] = update[i]->forw[i];
                update[i]->forw[i] = x;
            }
        }
    }
}


void skiplist::delete_element(int& value)
{
    snode* x = header;
    snode** update = new snode * [max_level + 1];
    memset(update, 0, sizeof(snode*) * (max_level + 1));
    for (int i = level; i >= 0; i--)
    {
        while (x->forw[i] != NULL && x->forw[i]->value < value)
        {
            x = x->forw[i];
        }
        update[i] = x;
    }
    x = x->forw[0];
    if (x->value == value)
    {
        for (int i = 0; i <= level; i++)
        {
            if (update[i]->forw[i] != x)
                break;
            update[i]->forw[i] = x->forw[i];
        }
        delete x;
        while (level > 0 && header->forw[level] == NULL)
        {
            level--;
        }
    }
}



