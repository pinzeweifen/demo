
namespace QRPG.Frame
{
    public interface IArticle
    {
        int ID { get; }
        int Price { get; }
        string Name { get; }
        string Icon { get; }
        void SetName(string name);
        void SetIcon(string icon);
        void SetPrice(int price);
        void SetID(int id);
        bool IsDataNull();
    }
}