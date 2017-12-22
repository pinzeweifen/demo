#include "stdafx.h"
#include "QVector2.h"


QVector2::QVector2()
{
}

QVector2::QVector2(int x, int y)
{
    m_X = x;
    m_Y = y;
}


QVector2::~QVector2()
{
}

int QVector2::x() const
{
    return m_X;
}

int QVector2::y() const
{
    return m_Y;
}
