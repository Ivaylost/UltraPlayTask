using UltraPlayTask.Services.XmlModels;

namespace UltraPlayTask.Services.Updater.Contracts
{
    public interface ISaveItems
    {
        void Save(XmlSports xml);
    }
}
