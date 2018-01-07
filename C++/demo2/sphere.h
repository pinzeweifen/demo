#ifndef SPHERE_H
#define SPHERE_H

#include <QGraphicsEllipseItem>

class Sphere : public QGraphicsEllipseItem
{
public:
    explicit Sphere(qreal speed, QGraphicsItem *parent = Q_NULLPTR);
    void Rotate(int angle);
    void Move();

private:
    qreal m_Speed;
    int m_Angle;
    QMatrix m_Matrix;
};

#endif // SPHERE_H
