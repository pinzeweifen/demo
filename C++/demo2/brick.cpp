#include "brick.h"
#include <QGraphicsScene>
Brick::Brick(QGraphicsScene *scene, QGraphicsItem *parent) : QGraphicsRectItem(parent)
{
    m_Hp = 3;
    m_Scene = scene;
    setRect(-20,-20,40,40);
    setBrush(Qt::blue);
}

bool Brick::Collision()
{
    m_Hp--;
    switch (m_Hp) {
    case 1:
        setBrush(Qt::red);
        break;
    case 2:
        setBrush(Qt::green);
        break;
    default:
        m_Scene->removeItem(this);
        return true;
    }
    return false;
}

int Brick::type() const
{
    return Type;
}
