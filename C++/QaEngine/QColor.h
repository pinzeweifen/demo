#pragma once
#ifndef QCOLOR_H
#define QCOLOR_H

class QColor
{
public:
	QColor();
	QColor(int r, int g, int b);
    QColor(COLORREF color);
	~QColor();

    COLORREF toGRAY();
    void toHSL(float &h, float &s, float &l);
    void toHSV(float &h, float &s, float &v);
    COLORREF toBGR();

    BYTE getR()const;
    BYTE getG()const;
    BYTE getB()const;
    COLORREF value()const;

    static QColor fromHSL(float h, float s, float l);
    static QColor fromHSV(float h, float s, float v);

private:
	COLORREF m_Color;
};

#endif // !QCOLOR_H



