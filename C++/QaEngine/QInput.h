#pragma once

#ifndef QINPUT_H
#define QINPUT_H

#include "QNamespace.h"

class QVector2;

class QInput
{
public:
    ~QInput();

    static void InitState();
    static QVector2 getMousePos();
    static int getWheel();
    static void getMouseMsg();
    static bool getKeyDown(Qa::KeyCode key);
    static bool getKeyUp(Qa::KeyCode key);
    static bool isMouse();
    static bool getMouseButtonDown(Qa::MouseCode code);
    static bool getMouseButtonUp(Qa::MouseCode code);
    static bool getMouseDoubleClick(Qa::MouseCode code);

private:
    QInput();

private:
    static bool m_State[256];
    static MOUSEMSG m_MouseMsg;
};


#endif // !QINPUT_H

