#include "stdafx.h"
#include "QApplication.h"
#include "QPainter.h"
#include "QString.h"
#include "QSprite.h"
#include "QInput.h"

QApplication *QApplication::m_Instance;

QApplication::QApplication(int argc, char ** argv)
{
	m_Argc = argc;
	m_Argv = argv;
	initgraph(640,480);
    m_Instance = this;
}

QApplication::~QApplication()
{
}

int QApplication::exec()
{
    int i;
    while (m_Run)
    {
#pragma region 用户输入
        QInput::getMouseMsg();
#pragma endregion

#pragma region 运算
        for (i = 0; i < m_Sprites.count(); i++) 
            m_Sprites[i]->update();
#pragma endregion

#pragma region 更新绘图设备
        qDraw->begin();
        for (i = 0; i < m_Sprites.count(); i++) {
            m_Sprites[i]->onGUI();
            qDraw->update();
        }
        qDraw->end();
#pragma endregion
    }

	closegraph();
	return 0;
}

void QApplication::close()
{
    m_Run = false;
}

void QApplication::resize(int width, int height)
{
    Resize(NULL,width, height);
}

void QApplication::addSprite(QSprite *sprite)
{
    m_Sprites.add(sprite);
}


