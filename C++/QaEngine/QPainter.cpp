#include "stdafx.h"
#include "QPainter.h"
#include "QPen.h"
#include "QBrush.h"
#include "QColor.h"
#include "QImage.h"
#include "QFont.h"
#include "QString.h"

QPainter *QPainter::m_Instance = new QPainter();

QPainter::QPainter()
{
}

QPainter::~QPainter()
{
}

void QPainter::beginDrawImage(QImage * image)
{
    if(image != NULL)
        SetWorkingImage(image->getImage());
    else
        SetWorkingImage(NULL);
}

void QPainter::endDrawImage()
{
    SetWorkingImage(NULL);
}

void QPainter::begin()
{
    BeginBatchDraw();
}

void QPainter::end()
{
    EndBatchDraw();
}

void QPainter::update()
{
    FlushBatchDraw();
}

void QPainter::update(int x, int y, int width, int height)
{
    FlushBatchDraw(x, y, x + width, y + height);
}

void QPainter::moveTo(int x, int y)
{
    moveto(x, y);
}

void QPainter::lineTo(int x, int y)
{
    lineto(x, y);
}

void QPainter::drawImage(int x, int y, QImage &image)
{
    putimage(x, y, image.getImage(), image.getMask());
}

void QPainter::drawImage(int x, int y, int width, int height, QImage& image, int imageX, int imageY)
{
    putimage(x, y, width, height, image.getImage(), imageX, imageY);
}

void QPainter::drawText(TCHAR c)
{
    outtext(c);
}

void QPainter::drawText(LPCTSTR str)
{
    outtext(str);
}

void QPainter::drawText(int x, int y, TCHAR c)
{
    outtextxy(x, y, c);
}

void QPainter::drawText(int x, int y, LPCTSTR str)
{
    outtextxy(x, y, str);
}

void QPainter::drawText(int x, int y, const QString & str)
{
    outtextxy(x, y, str.toWString());
}

int QPainter::drawText(RECT & rect, TCHAR c, Qa::TextFormat format)
{
    return drawtext(c, &rect, format);
}

int QPainter::drawText(RECT & rect, LPCTSTR str, Qa::TextFormat format)
{
    return drawtext(str, &rect, format);
}

void QPainter::drawLine(int x1, int y1, int x2, int y2)
{
    line(x1, y1, x2, y2);
}

void QPainter::drawPie(int x, int y, int width, int height, double startAngle, double endAngle)
{
	auto tmp = drawFunction();
	switch (tmp) {
    case Qa::Fill: fillpie(x, y, x + width, y + height,startAngle, endAngle); break;
	case Qa::Line: arc(x, y, x + width, y + height, startAngle, endAngle); break;
	case Qa::Solid:solidpie(x, y, x + width, y + height, startAngle, endAngle); break;
	}
	
}

 void QPainter::drawArc(int x, int y, int stangle, int endangle, int radius)
{
	arc(x - radius, y - radius, x + radius, y + radius, stangle / 180.0*PI, endangle / 180.0*PI);
}

 void QPainter::drawCircle(int x, int y, int radius)
 {
	 auto tmp = drawFunction();
	 switch (tmp) {
	 case Qa::Fill:	fillcircle(x, y, radius);break;
	 case Qa::Line:	circle(x, y, radius);break;
	 case Qa::Solid:solidcircle(x, y, radius); break;
	 } 
 }

 void QPainter::drawEllipse(int x, int y, int width, int height)
 {
	 auto tmp = drawFunction();
	 switch (tmp) {
	 case Qa::Fill:	fillellipse(x, y, x + width, y + height); break;
	 case Qa::Line:	ellipse(x, y, x + width, y + height); break;
	 case Qa::Solid:solidellipse(x, y, x + width, y + height); break;
	 }
 }

 void QPainter::drawRect(int x, int y, int width, int height)
 {
	 auto tmp = drawFunction();
	 switch (tmp) {
	 case Qa::Fill:	fillrectangle(x, y, x + width, y + height); break;
	 case Qa::Line:	rectangle(x, y, x + width, y + height); break;
	 case Qa::Solid:solidrectangle(x, y, x + width, y + height); break;
	 }
 }

 void QPainter::drawPolygon(POINT * points, int pointCount)
 {
	 auto tmp = drawFunction();
	 switch (tmp) {
	 case Qa::Fill:	fillpolygon(points, pointCount); break;
	 case Qa::Line:	polygon(points, pointCount); break;
	 case Qa::Solid:solidpolygon(points, pointCount); break;
	 }
 }

 void QPainter::drawRoundrect(int x, int y, int width, int height, int xRadius, int yRadius)
 {
	 auto tmp = drawFunction();
	 switch (tmp) {
	 case Qa::Fill:	fillroundrect(x, y, x + width, y + height,xRadius, yRadius); break;
	 case Qa::Line:	roundrect(x, y, x + width, y + height, xRadius, yRadius); break;
	 case Qa::Solid:solidroundrect(x, y, x + width, y + height, xRadius, yRadius); break;
	 }
 }

 //Color diffusion meets boundary color stop diffusion
 void QPainter::fillArea(int x, int y, QColor boundary)
 {
	 floodfill(x, y, boundary.value());
 }

 void QPainter::clearClip()
 {
     setcliprgn(NULL);
 }

 void QPainter::clearDevice()
 {
     cleardevice();
 }

 void QPainter::clearClipContent()
 {
     clearcliprgn();
 }

 void QPainter::clearPie(int x, int y, int width, int height, double startAngle, double endAngle)
 {
     clearpie(x, y, x + width, y + height, startAngle, endAngle);
 }

 void QPainter::clearArc(int x, int y, int stangle, int endangle, int radius)
 {
     clearpie(x - radius, y - radius, x + radius, y + radius, stangle / 180.0*PI, endangle / 180.0*PI);
 }

 void QPainter::clearCircle(int x, int y, int radius)
 {
      clearcircle(x, y, radius);
 }

 void QPainter::clearEllipse(int x, int y, int width, int height)
 {
     clearellipse(x, y, width + x, y + height);
 }

 void QPainter::clearPolygon(POINT * points, int pointCount)
 {
     clearpolygon(points, pointCount);
 }

 void QPainter::clearRect(int x, int y, int width, int height)
 {
     clearrectangle(x, y, x + width, y + height);
 }

 void QPainter::clearRoundrect(int x, int y, int width, int height, int xRadius, int yRadius)
 {
     clearroundrect(x, y, x + width, y + height, xRadius, yRadius);
 }

 void QPainter::setFont(QFont * font)
 {
     m_Font = font;
     settextstyle(font->getStyle());
 }

 void QPainter::setPen(QPen * pen)
 {
	 m_Pen = pen;
     settextcolor(pen->color());
	 setlinecolor(pen->color());
     setlinestyle(pen->getLineStyle());
 }

 void QPainter::setBrush(QBrush * brush)
 {
	 m_Brush = brush;
	 setfillcolor(brush->color());
     if (brush->isDrawPattern8x8()) {
         setfillstyle(brush->getPattern8x8());
     }
     else {
         setfillstyle(brush->getStyle());
     }
 }

 void QPainter::setBackground(QColor color)
 {
     setbkcolor(color.value());
 }

 void QPainter::setBackgroundMode(Qa::BackgroundMode mode)
 {
     setbkmode(mode);
 }

 void QPainter::setPolyFillMode(Qa::PolyFillMode mode)
 {
     setpolyfillmode(mode);
 }

 void QPainter::CreateRectClip(int x, int y, int width, int height)
 {
     HRGN rgn = CreateRectRgn(x, y, x + width, y + height);
     setcliprgn(rgn);
     DeleteObject(rgn);
 }

 void QPainter::CreateEllipseClip(int x, int y, int width, int height)
 {
     HRGN rgn = CreateEllipticRgn(x, y, x + width, y + height);
     setcliprgn(rgn);
     DeleteObject(rgn);
 }

 void QPainter::CreatePolygonClip(POINT * points, int pointCont, Qa::PolyFillMode model)
 {
     HRGN rgn = CreatePolygonRgn(points, pointCont, model);
     setcliprgn(rgn);
     DeleteObject(rgn);
 }

 void QPainter::CreateCombineClip(HRGN rgn1, HRGN rgn2, Qa::RGNMode mode)
 {
     HRGN rgn = NULL;
     int tmp = CombineRgn(rgn, rgn1, rgn2, mode);
     if (tmp != ERROR || tmp != NULLREGION)
     {
         setcliprgn(rgn);
         DeleteObject(rgn);
     }
 }

 void QPainter::CreateRoundRectClip(int x, int y, int width, int height, int xRadius, int yRadius)
 {
     HRGN rgn = CreateRoundRectRgn(x, y, x + width, y + height, xRadius, yRadius);
     setcliprgn(rgn);
     DeleteObject(rgn);
 }

 void QPainter::setRop2(Qa::Rop2Mode mode)
 {
     setrop2(mode);
 }

 void QPainter::setAspectratio(float x, float y)
 {
     setaspectratio(x, y);
 }

 void QPainter::getAspectratio(float & x, float & y)
 {
     getaspectratio(&x, &y);
 }

 Qa::DrawFunction QPainter::drawFunction()
 {
	 if (m_Pen != nullptr && m_Brush != nullptr)
		 return Qa::Fill;
	 else if (m_Pen != nullptr && m_Brush == nullptr)
		 return Qa::Line;
	 else if (m_Pen == nullptr && m_Brush != nullptr)
		 return Qa::Solid;
	 return Qa::None;
 }
