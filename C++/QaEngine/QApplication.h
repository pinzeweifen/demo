#pragma once

#ifndef QAPPLICATION_H
#define QAPPLICATION_H

#include "QList.h"

#define qApp (QApplication::Instance())

class QSprite;

class QApplication
{
public:
    QApplication(int argc, char **argv);
    ~QApplication();

    int exec();
    void close();
    void resize(int width, int height);

    void addSprite(QSprite *sprite);

    const int width()const;
    const int height()const;
    HWND getHWnd();
    TCHAR* getEasyXVer()const;


    static QApplication *Instance();

private:
    bool m_Run = true;
    int m_Argc;
    char **m_Argv;
    QList<QSprite*> m_Sprites;

    static QApplication *m_Instance;
};

#endif // !QAPPLICATION_H




