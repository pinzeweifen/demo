#pragma once

class Brick
{
public:
	Brick(int x, int y, int width, int height, COLORREF color);
	~Brick();
	int X()const { return x; }
	int Y()const { return y; }
	int Width()const { return width; }
	int Height()const { return height; }
	void SetSpeed(int speed) { this->speed = speed; }
	void move(int x, int y);
	void resize(int width, int height);
	void MoveX(int min, int max);
	void MoveY(int min, int max);
	void Clear();

private:
	void Update();

private:
	int x;
	int y;
	int width;
	int height;
	COLORREF color;
	int speed=0;
	bool direction=true;
};

