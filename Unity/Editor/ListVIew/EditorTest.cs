using UnityEditor;

public class EditorTest : EditorWindow {

    private static QEditorListView[] l;
    [MenuItem("Tool/Test")]
    private static void Init()
    {
        var window = GetWindow<EditorTest>();
        window.Show();

        l = new QEditorListView[2];
        for (int i = 0; i < 2; i++)
        {
            l[i] = new QEditorListView(window);
            for (int j = 0; j < 10; j++)
            {
                l[i].Add(j.ToString());
            }
            l[i].IsDrag = true;
            l[i].IsEditor = true;
            l[i].EndDragEvent += window.ListViewSwap;
        }
    }

    private void OnGUI()
    {
        QEditorLayout.Horizontal(x => {
            for (int i = 0; i < 2; i++)
                l[i].Update();
        });
    }

    private void ListViewSwap(QEditorListView v, QEditorListView v2)
    {
        var tmp = v[v.Index];
        v[v.Index] = v2[v2.EndDragIndex];
        v2[v2.EndDragIndex] = tmp;
    }
}
