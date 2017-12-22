#pragma once
class QVector2
{
public:
    QVector2();
    QVector2(int x, int y);
    ~QVector2();

    int x()const;
    int y()const;

private:
    int m_X, m_Y;
};

