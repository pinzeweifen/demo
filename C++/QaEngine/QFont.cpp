#include "stdafx.h"
#include "QFont.h"

QFont::QFont()
{
}

QFont::QFont(LOGFONT & font)
{
    copyLogFont(&font);
}

QFont::QFont(const QFont & font)
{
    copyLogFont(font.getStyle());
}

QFont::~QFont()
{
    delete m_Style;
}

void QFont::setWidth(LONG value)
{
    m_Style->lfWidth = value;
}

void QFont::setHeight(LONG value)
{
    m_Style->lfHeight = value;
}

void QFont::setStringAngle(LONG value)
{
    m_Style->lfEscapement = value;
}

void QFont::setCharAngle(LONG value)
{
    m_Style->lfOrientation = value;
}

void QFont::setThickness(LONG value)
{
    m_Style->lfWeight = value;
}

void QFont::setItalic(bool value)
{
    m_Style->lfItalic = value;
}

void QFont::setUnderline(bool value)
{
    m_Style->lfUnderline = value;
}

void QFont::setStrikeOut(bool value)
{
    m_Style->lfStrikeOut = value;
}

void QFont::setCharSet(Qa::TextCharset value)
{
    m_Style->lfCharSet = value;
}

void QFont::setOutPrecision(Qa::TextPrecision value)
{
    m_Style->lfOutPrecision = value;
}

void QFont::setClipPresision(Qa::TextClipPrecision value)
{
    m_Style->lfClipPrecision = value;
}

void QFont::setQuality(Qa::TextQuality value)
{
    m_Style->lfQuality = value;
}

void QFont::setPitchAndFamily(Qa::TextPitchAndFamily value)
{
    m_Style->lfPitchAndFamily = value;
}

void QFont::setTextName(TCHAR name[LF_FACESIZE])
{
    wsprintf(m_Style->lfFaceName, L"%s", name);
}

QFont QFont::operator=(const QFont & font)
{
    if (this != &font) {
        copyLogFont(font.getStyle());
    }
    return *this;
}

QFont QFont::getCurrentStyle()
{ 
    LOGFONT font;
    gettextstyle(&font);
    return QFont(font);
}

void QFont::copyLogFont(LOGFONT * font)
{
    m_Style = new LOGFONT;
    m_Style->lfCharSet = font->lfCharSet;
    m_Style->lfClipPrecision = font->lfClipPrecision;
    m_Style->lfEscapement = font->lfEscapement;
    m_Style->lfHeight = font->lfHeight;
    m_Style->lfItalic = font->lfItalic;
    m_Style->lfOrientation = font->lfOrientation;
    m_Style->lfOutPrecision = font->lfOutPrecision;
    m_Style->lfPitchAndFamily = font->lfPitchAndFamily;
    m_Style->lfQuality = font->lfQuality;
    m_Style->lfStrikeOut = font->lfStrikeOut;
    m_Style->lfUnderline = font->lfUnderline;
    m_Style->lfWeight = font->lfWeight;
    m_Style->lfWidth = font->lfWidth;
    wsprintf(m_Style->lfFaceName, L"%s", font->lfFaceName);
}
