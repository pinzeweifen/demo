#pragma once

#ifndef QIMAGE_H
#define QIMAGE_H

class QString;
class QColor;

class QImage
{
public:
    QImage();
    QImage(IMAGE image);
    ~QImage();

    bool load( QString fileName);
    bool load(const char* fileName);
    void save(QString fileName);
    void saveToImage(int x, int y, int width, int height);
    QImage rotate(double angle);

    void setMask(DWORD mask);
    void setSize(int width, int height);
    void setPixel(int x, int y, COLORREF color);
    void setColor(int x, int y, QColor color);
    void setColor(int x, int y, int r, int g, int b);

    COLORREF getPixel(int x, int y);
    QColor getColor(int x, int y);
    DWORD getMask()const { return m_Mask; }
    int getWidth()const { return m_Width; }
    int getHeight()const { return m_Height; }
    IMAGE *getImage()const { return m_Image; }
    DWORD *bits() { return m_Buffer; }
    const DWORD *bits()const { return m_Buffer; }

private:
    IMAGE * m_Image = new IMAGE;
    DWORD m_Mask;
    DWORD *m_Buffer=NULL;
    int m_Width;
    int m_Height;
};

#endif // !QIMAGE_H

