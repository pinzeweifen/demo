#include "stdafx.h"
#include "Brick.h"

Brick::Brick(int x, int y, int width, int height, COLORREF color)
{
	this->x = x;
	this->y = y;
	this->width = width;
	this->height = height;
	this->color = color;
	Update();
}

Brick::~Brick()
{
}

void Brick::move(int x, int y)
{
	Clear();
	this->x = x;
	this->y = y;
	Update();
}

void Brick::resize(int width, int height)
{
	Clear();
	this->width = width;
	this->height = height;
	Update();
}

void Brick::MoveX(int min, int max)
{
	if (direction)
	{
		move(x + speed, y);
		if (x >= max)
			direction = false;
	}
	else
	{
		move(x - speed, y);
		if (x <= min)
			direction = true;
	}
}

void Brick::MoveY(int min, int max)
{
	if (direction)
	{
		move(x, y+speed);
		if (y >= max) {
			direction = false;
		}
			
	}
	else
	{
		move(x, y-speed);
		if (y <= min)
			direction = true;
	}
}

void Brick::Update()
{
	setfillcolor(color);
	solidrectangle(x, y, x + width, y + height);
}

void Brick::Clear()
{
	clearrectangle(x, y, x + width, y + height);
}
