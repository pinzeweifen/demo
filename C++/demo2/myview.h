#ifndef MYVIEW_H
#define MYVIEW_H

#include <QGraphicsView>

class MyView : public QGraphicsView
{
    Q_OBJECT
public:
    explicit MyView(QGraphicsScene *scene, QWidget *parent = Q_NULLPTR);

signals:

public slots:
};

#endif // MYVIEW_H
