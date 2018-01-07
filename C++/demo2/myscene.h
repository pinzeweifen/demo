#ifndef MYSCENE_H
#define MYSCENE_H

#include <QGraphicsScene>
class Sphere;
class MyScene : public QGraphicsScene
{
    Q_OBJECT
public:
    explicit MyScene(QObject *parent = 0);

signals:

public slots:

protected:
    void keyPressEvent(QKeyEvent *event);
    void keyReleaseEvent(QKeyEvent *event);
    void mousePressEvent(QGraphicsSceneMouseEvent *event);
    void mouseMoveEvent(QGraphicsSceneMouseEvent *event);
    void mouseReleaseEvent(QGraphicsSceneMouseEvent *event);
    void timerEvent(QTimerEvent *event);

private:
    int m_Number;
    int m_Key;
    bool m_PressFlag=false;
    int m_TimerId;
    int m_RoleTimerId;
    QPointF m_MousePos;
    bool m_Start=false;
    Sphere *m_Sphere;
    QGraphicsRectItem *m_Role;
};

#endif // MYSCENE_H
