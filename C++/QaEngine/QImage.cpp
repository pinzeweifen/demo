#include "stdafx.h"
#include "QImage.h"
#include "QString.h"
#include "QNamespace.h"
#include "QColor.h"

QImage::QImage()
{
    m_Mask = SRCCOPY;
}

QImage::QImage(IMAGE image)
{
    m_Image = &image;
    m_Buffer = GetImageBuffer(m_Image);
    m_Width = m_Image->getwidth();
    m_Height = m_Image->getheight();
}

QImage::~QImage()
{
    delete m_Image;
    delete m_Buffer;
}

bool QImage::load( QString fileName)
{
    loadimage(m_Image, fileName.toWString());
    if (m_Image->getwidth() > 0) {
        m_Buffer = GetImageBuffer(m_Image);
        m_Width = m_Image->getwidth();
        m_Height = m_Image->getheight();
        return true;
    }
    
    return false;
}

bool QImage::load(const char * fileName)
{
    return load(QString(fileName));
}

void QImage::save(QString fileName)
{
    if(m_Image->getwidth() >0)
        saveimage(fileName.toWString(),m_Image);
    else
        saveimage(fileName.toWString());
}

void QImage::saveToImage(int x, int y, int width, int height)
{
    getimage(m_Image, x, y, width, height);
}

QImage QImage::rotate(double angle)
{
    IMAGE image;
    rotateimage(&image, m_Image, PI / 180 * angle, BLACK, true);
    return QImage(image);
}

void QImage::setMask(DWORD mask)
{
    m_Mask = mask;
}

void QImage::setSize(int width, int height)
{
    m_Image->Resize(width, height);
}

void QImage::setPixel(int x, int y, COLORREF color)
{
    m_Buffer[x + m_Width * y] = color;
}

void QImage::setColor(int x, int y, QColor color)
{
    m_Buffer[x + m_Width * y] = color.value();
}

void QImage::setColor(int x, int y, int r, int g, int b)
{
    m_Buffer[x + m_Width * y] = RGB(r, g, b);
}

COLORREF QImage::getPixel(int x, int y)
{
    return m_Buffer[x + m_Width * y];
}

QColor QImage::getColor(int x, int y)
{
    return QColor(m_Buffer[x + m_Width * y]);
}
