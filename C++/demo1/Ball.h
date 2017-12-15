#pragma once
class Ball
{
public:

public:

	Ball(int x, int y, int radius, COLORREF color);
	~Ball() {}
	int X()const { return x; }
	int Y()const { return y; }
	int Radius()const { return radius; }
	void ReversalX() { speedX = -speedX; }
	void ReversalY() { speedY = -speedY; }
	void SetRadius(int radius);
	void SetColor(COLORREF color);
	void SetSpeed(int speed);
	void Move(int minX, int maxX, int minY);
	bool ComputeCollision(int x, int y, int width, int height);
	bool IsVertical(int x, int width);

private:
	int x = 0;
	int y = 0;
	int radius = 1;
	COLORREF color;
	int speedX;
	int speedY;
	int speed;
	bool clockwise = false;
	void move(int x, int y);
	void Update();
	void Clear();
};

