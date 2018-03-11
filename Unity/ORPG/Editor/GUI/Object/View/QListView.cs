using UnityEditor;
using UnityEngine;

namespace QRPG.GUIEditor
{
    public class QListView : QAbstractItemView
    {
        protected int m_EditorIndex = -1;
        protected readonly string about = "HelpBox";
        protected readonly string select = "LODSliderRangeSelected";
        
        public QListView(EditorWindow window, IQObject parent = null) : base(window, parent)
        {
            onCurrentChanged += CloseEditor;
        }

        public void OpenEditor(int index)
        {
            m_EditorIndex = index;
        }

        protected override void DrawItem(Rect rect, int index)
        {
            if (Event.current.IsKeyDown(KeyCode.F2))
            {
                m_EditorIndex = m_Index;
                Event.current.Use();
            }

            var item = m_List[index];
            if (m_EditorIndex != index)
            {
                GUI.Box(rect, item.Name, m_Index != index ? about : select);
            }
            else
            {
                item.Name = GUI.TextField(rect, item.Name);
            }
        }

        /*
        protected override Rect DrawItem(float totalHeight,int index)
        {
            var item = m_List[index];
            var y = 0 != index ? totalHeight + item.Height : 0;
            var rect = new Rect(2, y, m_Rect.width - 18, item.Height);

            if (m_EditorIndex != index)
                GUI.Box(rect, item.Name, m_Index != index ? about : select);
            else
                item.Name = GUI.TextField(rect, item.Name);

            return rect;
        }*/

        private void CloseEditor(QAbstractItemView view, int index)
        {
            m_EditorIndex = -1;
        }
    }
}
