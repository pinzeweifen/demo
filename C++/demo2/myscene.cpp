#include <QGraphicsSceneMouseEvent>
#include <QGraphicsRectItem>
#include <QKeyEvent>
#include <QDebug>
#include "myscene.h"
#include "sphere.h"
#include "brick.h"

MyScene::MyScene(QObject *parent) : QGraphicsScene(parent)
{
    m_TimerId = 0;
    m_Number = 50;

    auto rect = new QGraphicsRectItem;
    rect->setRect(0,0,800,10);
    rect->setPos(-400,-311.5);
    this->addItem(rect);
    rect = new QGraphicsRectItem;
    rect->setRect(0,0,10,600);
    rect->setPos(-411.5,-300);
    this->addItem(rect);
    rect = new QGraphicsRectItem;
    rect->setRect(0,0,10,600);
    rect->setPos(402,-300);
    this->addItem(rect);


    m_Role = new QGraphicsRectItem;
    m_Role->setData(0,QVariant("obj"));
    m_Role->setRect(-30,-30,60,60);
    m_Role->setPos(0,270);
    this->addItem(m_Role);


    m_Sphere = new Sphere(10);
    m_Sphere->setRect(-10,-10,20,20);
    m_Sphere->setPos(0,270);
    this->addItem(m_Sphere);

    for(int i=0;i<m_Number;i++){
        auto brick = new Brick(this);
        brick->setPos(rand()%750-350,rand()%500-295);
        addItem(brick);
    }
}

void MyScene::keyPressEvent(QKeyEvent *event)
{
    if(!event->isAutoRepeat()&&!m_PressFlag){
        m_PressFlag=true;
        m_Key = event->key();
        m_RoleTimerId = startTimer(30);
    }
}

void MyScene::keyReleaseEvent(QKeyEvent *event)
{
    if(m_PressFlag&&!event->isAutoRepeat()){
        m_PressFlag=false;
        killTimer(m_RoleTimerId);
    }
}

void MyScene::mousePressEvent(QGraphicsSceneMouseEvent *event)
{
    m_MousePos = event->scenePos();
    if(abs(m_MousePos.x() - m_Sphere->pos().x())< m_Sphere->boundingRect().width()*0.5
            && abs(m_MousePos.y() - m_Sphere->pos().y()) < m_Sphere->boundingRect().height()*0.5)
        m_Start = true;
}

void MyScene::mouseMoveEvent(QGraphicsSceneMouseEvent *event)
{
    if(m_Start)
        m_Sphere->setPos(event->scenePos());
}

void MyScene::mouseReleaseEvent(QGraphicsSceneMouseEvent *event)
{
    if(m_Start){
        auto endPos = event->scenePos();
        auto a = (m_MousePos.y()-endPos.y());
        auto b = abs(m_MousePos.x())-abs(endPos.x());
        auto c = sqrt(pow(a,2)+pow(b,2));
        auto angle = asin(a/c);

        if(endPos.x()<0)
            angle=-angle;

        m_Sphere->Rotate(180/3.1415*angle);
        m_TimerId = startTimer(30);
        m_Start = false;
    }
}

void MyScene::timerEvent(QTimerEvent *event)
{
    if(event->timerId() == m_TimerId){
        m_Sphere->Move();
        auto items = m_Sphere->collidingItems();
        if(items.count()>0){
            auto data = items.at(0)->data(0);
            if(data.toString() == "obj"){
                killTimer(m_TimerId);
                m_TimerId = 0;
                m_Sphere->setPos(m_Role->pos().x(),m_Role->pos().y());
            }
            auto item = items.at(0);
            if(item->type() == Brick::Type){
                auto brick = qgraphicsitem_cast<Brick*>(item);
                if(brick->Collision()){
                    m_Number--;
                    if(!m_Number)
                        this->addText("Game Victory");
                }
            }
        }
        if(m_Sphere->pos().y()>height()*0.5)
            this->addText("GameOver");
    }
    if(event->timerId() == m_RoleTimerId){
        switch(m_Key){
        case Qt::Key_Left:
            m_Role->moveBy(-10,0);
            break;
        case Qt::Key_Right:
            m_Role->moveBy(10,0);
        }
        if(m_TimerId==0){
            m_Sphere->setPos(m_Role->pos().x(),m_Role->pos().y());
        }
    }
}
