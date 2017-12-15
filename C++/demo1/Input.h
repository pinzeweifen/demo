#pragma once

#include "KeyCode.h"

class Input
{
public:
	
public:
	Input();
	~Input();
	static bool GetKeyDown(KeyCode::Code key);
	static void Update();

private:
	static char ch;
	static KeyCode keycode;
};

