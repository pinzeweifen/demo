

using UnityEditor;

public abstract class QAbstractEditorWindow {
    protected EditorWindow w;

    public QAbstractEditorWindow(EditorWindow window)
    {
        w = window;
    }

    public abstract void Update();
}
