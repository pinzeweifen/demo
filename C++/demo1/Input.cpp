#include "stdafx.h"
#include "Input.h"


Input::Input()
{
}


Input::~Input()
{
}

 char Input::ch;
 KeyCode Input::keycode;
bool Input::GetKeyDown(KeyCode::Code key)
{
	return keycode == key;
}

void Input::Update()
{
	keycode.SetKey(KeyCode::None);
	if (_kbhit())
	{
		ch = _getch();
		if (ch < 0) {
			ch = _getch();
		}
		keycode.SetKey(ch);
	}
}
