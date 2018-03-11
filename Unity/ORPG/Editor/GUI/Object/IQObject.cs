using System.Collections.Generic;

namespace QRPG.GUIEditor
{
    public interface IQObject
    {
        int ID { get; }
        string Name { get; set; }
        IQObject Parent { get; set; }
        List<IQObject> Childs { get; }

        IQObject Clone();
    }
}
