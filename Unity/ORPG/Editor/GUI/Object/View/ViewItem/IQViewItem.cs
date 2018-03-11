
using UnityEngine;

namespace QRPG.GUIEditor
{
    public interface IQViewItem
    {
        string Name { get; set; }
        float Height { get; set; }
        //Vector2 Size { get; set; }
        void Update(Rect rect);
        IQViewItem Clone();
    }
}
