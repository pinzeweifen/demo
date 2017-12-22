#include "stdafx.h"
#include "QPen.h"
#include "QColor.h"

QPen::QPen()
{
	m_Color = BLACK;
    m_Style = new LINESTYLE;
}


QPen::QPen(const QColor color)
{
	m_Color = color.value();
    m_Style = new LINESTYLE;
}

QPen::~QPen()
{
    delete m_Style;
}

void QPen::setStyle(Qa::PenStyle style)
{
    m_PenStyle = style;
    m_Style->style = m_PenStyle | m_PenJoinStyle | m_PenCapStyle;
}

void QPen::setJoinStyle(Qa::PenJoinStyle style)
{
    m_PenJoinStyle = style;
    m_Style->style = m_PenStyle | m_PenJoinStyle | m_PenCapStyle;
}

void QPen::setCapStyle(Qa::PenCapStyle style)
{
    m_PenCapStyle = style;
    m_Style->style = m_PenStyle | m_PenJoinStyle | m_PenCapStyle;
}

void QPen::setDashPattern(const DWORD *pattern, DWORD patternCount)
{
    m_Pattern = (DWORD*)pattern;
    m_Style->puserstyle = m_Pattern;
    m_Style->userstylecount = patternCount;
}

void QPen::setWidth(int width)
{
    m_Style->thickness = width;
}
