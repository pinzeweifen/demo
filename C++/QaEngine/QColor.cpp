#include "stdafx.h"
#include "QColor.h"


QColor::QColor()
{
}


QColor::QColor(int r, int g, int b)
{
	m_Color = RGB(r, g, b);
}

QColor::QColor(COLORREF color)
{
    m_Color = color;
}

QColor::~QColor()
{
}

inline COLORREF QColor::toGRAY()
{
    return RGBtoGRAY(m_Color);
}

void QColor::toHSL(float & h, float & s, float & l)
{
    RGBtoHSL(m_Color, &h, &s, &l);
}

void QColor::toHSV(float & h, float & s, float & v)
{
    RGBtoHSL(m_Color, &h, &s, &v);
}

COLORREF QColor::toBGR()
{
    return BGR(m_Color);
}

BYTE QColor::getR() const 
{
    return GetRValue(m_Color);
}

BYTE QColor::getG() const 
{
    return GetGValue(m_Color);
}

BYTE QColor::getB() const 
{
    return GetBValue(m_Color);
}

COLORREF QColor::value() const
{
    return m_Color;
}

QColor QColor::fromHSL(float h, float s, float l)
{
    return QColor(HSLtoRGB(h,s,l));
}

QColor QColor::fromHSV(float h, float s, float v)
{
    return QColor(HSVtoRGB(h, s, v));
}
