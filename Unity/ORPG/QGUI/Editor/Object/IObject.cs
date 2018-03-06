using System.Collections.Generic;

namespace QGUI
{
    public interface IObject
    {
        int ID { get; }
        string Name { get; set; }
        IObject Parent { get; set; }
        List<IObject> Childs { get; }

        IObject Clone();
    }
}
