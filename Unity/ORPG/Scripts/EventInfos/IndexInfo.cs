
using QRPG.BehaviourTree;

namespace QRPG.Frame
{
    public class IndexInfo : IEventInfo
    {
        public int index;

        public IndexInfo(int index)
        {
            this.index = index;
        }
    }
}

