#pragma once


#ifndef QLIST_H
#define QLIST_H

template<class T>
class QList
{
    struct Date {
        T value;
        Date *next;
        Date *previous;
        Date(T v, Date*n = NULL, Date*p = NULL):value(v), next(n), previous(p) {}
    };
public:
    QList()
    {
        m_Date = new Date(NULL);
        m_Date->next = m_Date;
        m_Date->previous = m_Date;
    }
    ~QList()
    {
        clear();
        delete m_Date;
    }

    void add(T value)
    {
        m_Count++;
        auto end = m_Date->next;
        end->next = new Date(value, m_Date, end);
        m_Date->previous = end->next;

    }
    void clear()
    {
        Date *p = m_Date->next;
        while (p != m_Date)
        {
            auto tmp = p;
            p->next;
            delete tmp;
        }
        m_Date->next = m_Date;
        m_Date->previous = m_Date;
    }
    void remove(T value)
    {
        int i = 0;

        for (Date *p = m_Date->next; p != m_Date; p = p->next)
        {
            if (p->value == value)
            {
                p->next->previous = p->previous;
                p->previous->next = p->next;
                delete p;
                return;
            }
        }
    }
    void removeAt(int index)
    {
        int i = 0;
        for (Date *p = m_Date->next; p != m_Date; p = p->next)
        {
            if (index == i++)
            {
                p->next->previous = p->previous;
                p->previous->next = p->next;
                delete p;
                return;
            }
        }
    }
    const int &count()const
    {
        return m_Count;
    }

    T operator[](int index) 
    {
        if (index >= m_Count)
            return NULL;

        int i = 0;

        for (Date *p = m_Date->next; p != m_Date; p = p->next)
        {
            if (index == i++)
                return p->value;
        }

        return NULL;
    }

private:
    int m_Count=0;
    Date * m_Date = NULL;
};

#endif // !QLIST_H

