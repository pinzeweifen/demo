using UnityEditor;
using UnityEngine;

namespace QGUI
{
    public class QListWidget : QAbstractItemView
    {
        public QListWidget(EditorWindow window, IObject parent = null) : base(window, parent)
        {
        }
        /*
        protected override Rect DrawItem(float totalHeight, int index)
        {
            var item = m_List[index];
            var rect = new Rect(0, totalHeight + item.Height, m_Rect.width - 20, item.Height);

            item.Update(rect);

            return rect;
        }
        */
        protected override void DrawItem(Rect rect, int index)
        {
            m_List[index].Update(rect);
        }
    }
}
