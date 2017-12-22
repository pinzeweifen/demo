#include "stdafx.h"
#include "QBrush.h"
#include "QColor.h"
#include "QImage.h"

QBrush::QBrush()
{
	m_Color = BLACK;
    m_Style = new FILLSTYLE;
}

QBrush::QBrush(QColor color)
{
	m_Color = color.value();
    m_Style = new FILLSTYLE;
}

QBrush::~QBrush()
{
    delete m_Style;
}

void QBrush::setStyle(Qa::BrushStyle style)
{
    m_Style->style = style;
}

void QBrush::setHatchedStyle(Qa::BrushStyle style)
{
    m_Style->hatch = style;
}

void QBrush::setTexture(const QImage & image)
{
    m_Style->ppattern = image.getImage();
}

void QBrush::setPattern8x8(BYTE * pattern)
{
    m_Pattern8x8 = pattern;
}
