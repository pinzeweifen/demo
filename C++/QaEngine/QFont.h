#pragma once

#ifndef QFONT_H
#define QFONT_H

#include "QNamespace.h"

class QFont
{
public:
    QFont();
    QFont(LOGFONT & font);
    QFont(const QFont & font);
    ~QFont();

    void setWidth(LONG value);
    void setHeight(LONG value);
    void setStringAngle(LONG value);
    void setCharAngle(LONG value);
    void setThickness(LONG value);
    void setItalic(bool value = false);
    void setUnderline(bool value = false);
    void setStrikeOut(bool value = false);
    void setCharSet(Qa::TextCharset value);
    void setOutPrecision(Qa::TextPrecision value);
    void setClipPresision(Qa::TextClipPrecision value);
    void setQuality(Qa::TextQuality value);
    void setPitchAndFamily(Qa::TextPitchAndFamily value);
    void setTextName(TCHAR name[LF_FACESIZE]);

    LOGFONT * getStyle()const { return m_Style; }

    QFont operator=(const QFont & font);

    static QFont getCurrentStyle();

private:
    void copyLogFont(LOGFONT* font);

private:
    LOGFONT * m_Style;
};

#endif // !QFONT_H




