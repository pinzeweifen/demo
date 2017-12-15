#pragma once

class KeyCode
{
public:
	KeyCode();
	enum Code
	{
		None=-10000,
		Up = 72,
		Down = 80,
		Left = 75,
		Right = 77
	};
	void SetKey(char ch);
	void SetKey(Code code);
	Code operator = (const KeyCode keycode);
	bool operator==( Code code);
private:
	Code k;
};
