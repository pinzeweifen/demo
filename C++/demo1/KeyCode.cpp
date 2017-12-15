#include "stdafx.h"
#include "KeyCode.h"

KeyCode::KeyCode()
{
	k = KeyCode::None;
}

void KeyCode::SetKey(char ch)
{
	k = (Code)ch;
}

void KeyCode::SetKey(Code code)
{
	k = code;
}

KeyCode::Code KeyCode::operator=(const KeyCode keycode)
{
	return keycode.k;
}

bool KeyCode::operator==(Code code)
{
	return k == code;
}
