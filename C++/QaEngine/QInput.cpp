#include "stdafx.h"
#include "QInput.h"
#include "QVector2.h"

bool QInput::m_State[256];
MOUSEMSG QInput::m_MouseMsg;

QInput::QInput()
{
    for (int i = 0; i < 256; i++) {
        m_State[i] = false;
    }
}


QInput::~QInput()
{
}

QVector2 QInput::getMousePos()
{
    return QVector2(m_MouseMsg.x,m_MouseMsg.y);
}

int QInput::getWheel()
{
    return m_MouseMsg.wheel/120;
}

void QInput::getMouseMsg()
{
    if(MouseHit())
        m_MouseMsg = GetMouseMsg();
}

bool QInput::getKeyDown(Qa::KeyCode key)
{
    if (!m_State[key]) {
        if (GetAsyncKeyState(key) & 0x8000)
        {
            return m_State[key] = true;
        }
    }
    return false;
}

bool QInput::getKeyUp(Qa::KeyCode key)
{
    if (m_State[key]) {
        if (!(GetAsyncKeyState(key) & 0x8000)) 
        {
            m_State[key] = false;
            return true;
        }
    }
    return false;
}

bool QInput::isMouse()
{
    return MouseHit();
}

bool QInput::getMouseButtonDown(Qa::MouseCode code)
{
    switch (code)
    {
    case Qa::MouseLeftButton:
        return m_MouseMsg.uMsg == WM_LBUTTONDOWN;
    case Qa::MouseMiddleButton:
        return m_MouseMsg.uMsg == WM_MBUTTONDOWN;
    case Qa::MouseRightButton:
        return m_MouseMsg.uMsg == WM_RBUTTONDOWN;
    }
    return false;
}

bool QInput::getMouseButtonUp(Qa::MouseCode code)
{
    switch (code)
    {
    case Qa::MouseLeftButton:
        return m_MouseMsg.uMsg == WM_LBUTTONUP;
    case Qa::MouseMiddleButton:
        return m_MouseMsg.uMsg == WM_MBUTTONUP;
    case Qa::MouseRightButton:
        return m_MouseMsg.uMsg == WM_RBUTTONUP;
    }
    return false;
}

bool QInput::getMouseDoubleClick(Qa::MouseCode code)
{
    switch (code)
    {
    case Qa::MouseLeftButton:
        return m_MouseMsg.uMsg == WM_LBUTTONDBLCLK;
    case Qa::MouseMiddleButton:
        return m_MouseMsg.uMsg == WM_MBUTTONDBLCLK;
    case Qa::MouseRightButton:
        return m_MouseMsg.uMsg == WM_RBUTTONDBLCLK;
    }
    return false;
}
