#pragma once
#ifndef QPEN_H
#define QPEN_H

#include "QNamespace.h"
class QColor;

class QPen
{
    
public:
	QPen();
	QPen(const QColor color);
	~QPen();
	
    void setStyle(Qa::PenStyle style);
    void setJoinStyle(Qa::PenJoinStyle style);
    void setCapStyle(Qa::PenCapStyle style);
    void setDashPattern(const DWORD *pattern, DWORD patternCount);
    void setWidth(int width);

    COLORREF color()const { return m_Color; }
    LINESTYLE *getLineStyle()const { return m_Style; }

private:
	COLORREF m_Color;
    LINESTYLE *m_Style;
    Qa::PenStyle m_PenStyle = Qa::SolidLine;
    Qa::PenJoinStyle m_PenJoinStyle = Qa::BevelJoin;
    Qa::PenCapStyle m_PenCapStyle = Qa::SquareCap;
    DWORD *m_Pattern;
};

#endif // !QPEN_H



