#pragma once

#ifndef QSPRITE_H
#define QSPRITE_H

class QPainter;
class QVector2;

class QSprite
{
public:
    QSprite(QSprite *parent);
    ~QSprite();

    void move(int x, int y);
    void resize(int width, int height);

    int x()const;
    int y()const;
    QVector2 pos()const;
    int width()const;
    int height()const;
    QVector2 size()const;

    void update();
    void onGUI();

private:

private:
    int m_X;
    int m_Y;
    int m_Width;
    int m_Height;
    QSprite *m_Parent;
};

#endif // !QSPRITE_H





