#include <iostream>
using namespace std;

class cMax2So
{

private:

    double a;
    double b;
    double c;

public: 

    void Nhap();
    double  Max2So();
    void Xuat(double c);

};

void cMax2So::Nhap()
{

    cout << " nhap so a: "; 
    cin >> a;

    cout << " nhap so b: "; 
    cin >> b;

}

double cMax2So::Max2So()
{
    if ((a>=b))
        c=a;
    if ((b>a))
        c=b;
    return c;
}

void cMax2So::Xuat(double  c)
{
    cout << " ket qua la: " ;
    cout << c;
}

int main()
{
    cMax2So a ;
    a.Nhap();
    double  c = a.Max2So();
    a.Xuat(c);
    return 0;
}