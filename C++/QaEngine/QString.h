#pragma once

#ifndef QSTRING_H
#define QSTRING_H

class QString
{
public:
    QString();
    QString(const char* str);
    QString(const wchar_t *str);
    QString(const QString &str);
    ~QString();

    wchar_t *toWString()const;
    char* toString()const;
    int length()const;

    friend QString operator+(const QString & str, int num);
    friend QString operator+(const QString & str, bool value);

    static QString fromString(const char*str);
    static QString fromWString(const wchar_t*str);

private:
    wchar_t *m_WStr ;
};

#endif // !QSTRING_H



