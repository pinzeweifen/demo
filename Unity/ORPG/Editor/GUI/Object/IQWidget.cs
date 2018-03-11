
using UnityEngine;

namespace QRPG.GUIEditor
{
    public interface IQWidget
    {
        Vector2 Size { get; }
        Vector2 Pos { get; }
        Vector2 GlobalPos { get; }
        float X { get; }
        float Y { get; }
        float Width { get; }
        float Height { get; }
        float GlobalX { get; }
        float GlobalY { get; }

        void Move(float x, float y);
        void Move(Vector2 pos);
        void Resize(Vector2 size);
        void Resize(float width, float height);
        void SetGeometry(Rect rect);
        Rect GetGeometry();

        void Hide();
        void Show();
        void Close();


        void OnGUI(Event current,object value=null);
    }
}
