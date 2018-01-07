#include "sphere.h"
#include <QDebug>
Sphere::Sphere(qreal speed, QGraphicsItem *parent):QGraphicsEllipseItem(parent)
{
    m_Angle = 0;
    m_Speed = speed;
}

void Sphere::Rotate(int angle)
{
    m_Angle = (angle + m_Angle) %360;
    m_Matrix.rotate(angle);
    this->setMatrix(m_Matrix);
}

void Sphere::Move()
{
    m_Matrix.rotate(0);
    m_Matrix.translate(0,-m_Speed);
    this->setMatrix(m_Matrix);

    if(collidingItems().count()>0){
        auto itemRect = collidingItems().at(0)->boundingRect();
        auto itemPos = collidingItems().at(0)->pos();
        int tmp;
        if(pos().x() < itemPos.x())
            tmp = 180-m_Angle;
        else if(pos().x() > itemPos.x()+itemRect.width())
            tmp = 360-m_Angle;
        else if(pos().y() < itemPos.y())
            tmp = 270-m_Angle;
        else
            tmp = 90-m_Angle;

        Rotate( 180-(90-tmp)*2);
    }
}
