#include "stdafx.h"
#include "Ball.h"

Ball::Ball(int x, int y, int radius, COLORREF color)
{
	this->x = x;
	this->y = y;
	this->radius = radius;
	this->color = color;
	Update();
}

void Ball::SetRadius(int radius)
{
	Clear();
	this->radius = radius;
	Update();
}

void Ball::SetColor(COLORREF color)
{
	Clear();
	this->color = color;
	Update();
}

void Ball::SetSpeed(int speed) 
{
	this->speed = speed;
	speedX = speed; 
	speedY = -speed;
}

void Ball::Move(int minX, int maxX, int minY)
{
	if (x >= maxX- radius || x <= minX+radius)
		speedX = -speedX;
	if (y <= minY + radius) 
		speedY = -speedY;
	move(x + speedX, y + speedY);
}

bool Ball::ComputeCollision(int x, int y, int width, int height)
{
	int x1 = x - radius-1;
	int y1 = y - radius-1;
	int w1 = x + width + radius+1;
	int h1 = y + height + radius+1;

	return this->x >= x1 && this->x <= w1 && this->y >= y1 && this->y <= h1;
}

bool Ball::IsVertical(int x, int width)
{
	return this->x >= x && this->x <= x + width;
}

inline void Ball::move(int x, int y)
{
	Clear();
	this->x = x;
	this->y = y;
	Update();
}

void Ball::Update()
{
	setfillcolor(color);
	solidcircle(x, y, radius);
}

void Ball::Clear()
{
	clearcircle(x, y, radius);
}

