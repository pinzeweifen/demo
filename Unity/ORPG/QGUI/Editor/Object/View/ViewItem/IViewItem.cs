
using UnityEngine;

namespace QGUI
{
    public interface IViewItem
    {
        string Name { get; set; }
        float Height { get; set; }
        //Vector2 Size { get; set; }
        void Update(Rect rect);
        IViewItem Clone();
    }
}
