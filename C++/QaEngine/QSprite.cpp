#include "stdafx.h"
#include "QSprite.h"
#include "QPainter.h"
#include "QApplication.h"
#include "QVector2.h"
#include "QInput.h"
#include "QString.h"

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

void QSprite::update()
{
    OnUpdate();
}

void QSprite::drawGUI()
{
    OnGUI();
}

//运算
void QSprite::OnUpdate()
{
    if (QInput::getKeyDown(Qa::KeyCode::Key_0)) {
        qDraw->drawText(10, 10, QString("按下了0"));
    }
    else if (QInput::getKeyUp(Qa::KeyCode::Key_0)) {
        qDraw->drawText(100, 10, QString("松开了0"));
    }
    if (QInput::isMouse()) {
        QInput::getMouseMsg();
        qDraw->clearRect(50, 50, 150, 150);
        qDraw->drawText(100, 100, QString("") + QInput::getWheel());
    }

}

//绘图
void QSprite::OnGUI()
{
}
