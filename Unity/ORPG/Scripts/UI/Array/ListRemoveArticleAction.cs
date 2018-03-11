using QRPG.BehaviourTree;
namespace QRPG.Frame
{
    public static partial class Actions
    {
        private class ListRemoveArticleAction : BaseActionNode
        {
            protected QAritcleArray m_List;
            protected int m_Count;
            public ListRemoveArticleAction(QAritcleArray list, int count)
            {
                m_List = list;
                m_Count = count;
            }

            public override void OnTick(object input)
            {
                var info = input as IndexInfo;
                m_List.RemoveAt(info.index, m_Count);
            }
        }

        public static INode CreateListRemoveArticleAction(this QAritcleArray list, int count)
        {
            return new ListRemoveArticleAction(list, count);
        }
    }
}
