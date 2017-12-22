#include "stdafx.h"
#include "QString.h"


QString::QString()
{
    m_WStr = NULL;
}


QString::QString(const char * str)
{
    int len = MultiByteToWideChar(0, 0, str, -1, NULL, 0);
    wchar_t *dest = new wchar_t[len];
    MultiByteToWideChar(0, 0, str, -1, dest, len);
    m_WStr = dest;
}

QString::QString(const wchar_t * str)
{
    m_WStr = (wchar_t *)str;
}

QString::QString(const QString & str)
{
    m_WStr = new wchar_t[str.length()+1];
    wsprintf(m_WStr, L"%s", str.toWString());
}

QString::~QString()
{
    m_WStr = nullptr;
}

wchar_t *QString::toWString()const
{
    return m_WStr;
}

char * QString::toString()const
{
    int len = WideCharToMultiByte(CP_OEMCP, NULL, m_WStr, -1, NULL, 0, NULL, FALSE);
    char *dest = new char[len];
    WideCharToMultiByte(CP_OEMCP, NULL, m_WStr, -1, dest, len, NULL, FALSE);
    return dest;
}

int QString::length() const
{
    return wcslen(m_WStr);
}

QString QString::fromString(const char * str)
{
    int len = MultiByteToWideChar(0, 0, str, -1, NULL, 0);
    wchar_t *dest = new wchar_t[len];
    MultiByteToWideChar(0, 0, str, -1, dest, len);

    return QString(dest);
}

QString QString::fromWString(const wchar_t * str)
{
    int len = WideCharToMultiByte(CP_OEMCP, NULL, str, -1, NULL, 0, NULL, FALSE);
    char *dest = new char[len];
    WideCharToMultiByte(CP_OEMCP, NULL, str, -1, dest, len, NULL, FALSE);
    return QString(dest);
}

QString operator+(const QString & str, int num)
{
    char*buff = new char[11];
    sprintf_s(buff, 11,"%d", num);
    int len = strlen(buff);
    wchar_t *dest = new wchar_t[len+str.length()+1];
    wsprintf(dest, L"%s%d", str.toWString(), num);
    return QString(dest);
}

QString operator+(const QString & str, bool value)
{
    wchar_t *dest;
    if (value) {
        dest = new wchar_t[4 + str.length() + 1];
        wsprintf(dest, L"%s%s", str.toWString(), L"true");
    }
    else {
        dest = new wchar_t[5 + str.length() + 1];
        wsprintf(dest, L"%s%s", str.toWString(), L"false");
    }
    return QString(dest);
}
