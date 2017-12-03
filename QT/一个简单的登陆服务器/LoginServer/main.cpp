#include "loginserver.h"
#include <QApplication>

int main(int argc, char *argv[])
{
    QApplication a(argc, argv);
    LoginServer w;
    w.show();

    return a.exec();
}
