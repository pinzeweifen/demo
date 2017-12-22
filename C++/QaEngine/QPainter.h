#pragma once

#ifndef QPAINTER_H
#define QPAINTER_H

#include "QNamespace.h"

#define qDraw (QPainter::Instance())

class QBrush;
class QPen;
class QColor;
class QImage;
class QFont;
class QString;

class QPainter
{
public:
    ~QPainter();

    void begin();
    void end();
    void update();
    void endDrawImage();
    void beginDrawImage(QImage *image = NULL);
    void graphdeFaults();
    void update(int x, int y, int width, int height);
    
    void moveTo(int x,int y);
    void lineTo(int x, int y);
	void fillArea(int x,int y, QColor color);
    void drawCircle(int x, int y, int radius);
    void drawImage(int x, int y, QImage &image);
    void drawLine(int x1, int y1, int x2, int y2);
    void drawPolygon(POINT*points, int pointCount);
    void drawRect(int x, int y, int width, int height);
    void drawEllipse(int x, int y, int width, int height);
    void drawArc(int x, int y, int stangle, int endangle, int radius);
    void drawRoundrect(int x, int y, int width, int height, int xRadius, int yRadius);
    void drawPie(int x, int y, int width, int height, double startAngle, double endAngle);
    void drawImage(int x, int y, int width, int height, QImage&image, int imageX, int imageY);

    void drawText(TCHAR c);
    void drawText(LPCTSTR str);
    void drawText(int x, int y, TCHAR c);
    void drawText(int x, int y, LPCTSTR str);
    void drawText(int x, int y, const QString &str);
    int  drawText(RECT &rect, TCHAR c, Qa::TextFormat format);
    int  drawText(RECT &rect, LPCTSTR str, Qa::TextFormat format);

    void clearClip();
    void clearDevice();
    void clearClipContent();
    void clearCircle(int x, int y, int radius);
    void clearPolygon(POINT*points, int pointCount);
    void clearRect(int x, int y, int width, int height);
    void clearEllipse(int x, int y, int width, int height);
    void clearArc(int x, int y, int stangle, int endangle, int radius);
    void clearRoundrect(int x, int y, int width, int height, int xRadius, int yRadius);
    void clearPie(int x, int y, int width, int height, double startAngle, double endAngle);
    
    void setFont(QFont *font);
	void setPen(QPen *pen);
	void setBrush(QBrush*brush);
    void setRop2(Qa::Rop2Mode mode);
    void setBackground(QColor color);
    void setAspectratio(float x, float y);
    void setBackgroundMode(Qa::BackgroundMode mode);
    void setPolyFillMode(Qa::PolyFillMode mode);
    void setOrigin(int x, int y) { setorigin(x, y); }

    void CreateRectClip(int x, int y, int width, int height);
    void CreateEllipseClip(int x,int y, int width, int height);
    void CreatePolygonClip(POINT*points, int pointCont, Qa::PolyFillMode model);
    void CreateCombineClip(HRGN rgn1, HRGN rgn2, Qa::RGNMode mode);
    void CreateRoundRectClip(int x, int y, int width, int height, int xRadius, int yRadius);

    int getTextHeight(TCHAR c) const { return textheight(c); }
    int getTextHeight(LPCTSTR str)const{ return textheight(str); }
    int getTextWidth(TCHAR c) const { return textwidth(c); }
    int getTextWidth(LPCTSTR str)const { return textwidth(str); }
    QPen *getPen()const { return m_Pen; }
    void getAspectratio(float &x, float &y);
    QBrush *getBrush()const { return m_Brush; }
    IMAGE *getDrawDevice()const { return GetWorkingImage(); }
    Qa::Rop2Mode getRop2()const { return (Qa::Rop2Mode)getrop2(); }
    Qa::PolyFillMode getPolyFillMode()const { return (Qa::PolyFillMode)getpolyfillmode(); }
    Qa::BackgroundMode getBackgroundMode()const { return (Qa::BackgroundMode)getbkcolor(); }
    
    static QPainter *Instance() { return m_Instance; }

private:
	Qa::DrawFunction drawFunction();
    QPainter();
    
private:
	QPen * m_Pen;
    QFont *m_Font;
	QBrush * m_Brush;
    static QPainter *m_Instance;
    
};

#endif // !QPAINTER_H