#ifndef BRICK_H
#define BRICK_H

#include <QGraphicsRectItem>

class Brick : public QGraphicsRectItem
{
public:
    enum {Type=UserType+1};
    explicit Brick(QGraphicsScene *scene, QGraphicsItem *parent = Q_NULLPTR);
    bool Collision();
    int type() const;
private:
    int m_Hp;
    QGraphicsScene *m_Scene;
};

#endif // BRICK_H
