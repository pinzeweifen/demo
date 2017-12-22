#pragma once

#ifndef QBRUSH_H
#define QBRUSH_H

#include "QNamespace.h"

class QColor;
class QImage;

class QBrush
{
public:
	QBrush();
	QBrush(QColor color);
	~QBrush();

    void setStyle(Qa::BrushStyle style);
    void setHatchedStyle(Qa::BrushStyle style);
    void setTexture(const QImage& image);
    void setPattern8x8(BYTE* pattern);

	COLORREF color()const { return m_Color; }
    FILLSTYLE *getStyle()const { return m_Style; }
    BYTE *getPattern8x8()const { return m_Pattern8x8; }
    bool isDrawPattern8x8()const { return m_Pattern8x8 != nullptr; }

private:
	COLORREF m_Color;
    FILLSTYLE *m_Style;
    BYTE *m_Pattern8x8;
};

#endif // !QBRUSH_H



