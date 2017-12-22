#include "stdafx.h"
#include "QSprite.h"
#include "QPainter.h"
#include "QApplication.h"
#include "QVector2.h"

QSprite::QSprite(QSprite *parent)
{
    m_Parent = parent;
    qApp->addSprite(this);
}


QSprite::~QSprite()
{
}

void QSprite::move(int x, int y)
{
    m_X = x;
    m_Y = y;
}

void QSprite::resize(int width, int height)
{
    m_Width = width;
    m_Height = height;
}

int QSprite::x() const
{
    return m_X;
}

int QSprite::y() const
{
    return m_Y;
}

QVector2 QSprite::pos() const
{
    return QVector2(m_X,m_Y);
}

int QSprite::width() const
{
    return m_Width;
}

int QSprite::height() const
{
    return m_Height;
}

QVector2 QSprite::size() const
{
    return QVector2(m_Width,m_Height);
}

//‘ÀÀ„
void QSprite::update()
{
    
}

//ªÊÕº
void QSprite::onGUI()
{
}
