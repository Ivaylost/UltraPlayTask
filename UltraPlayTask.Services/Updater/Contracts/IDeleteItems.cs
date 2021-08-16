using System;
using System.Collections.Generic;
using System.Text;
using UltraPlayTask.Services.XmlModels;

namespace UltraPlayTask.Services.Updater.Contracts
{
    public interface IDeleteItems
    {
        void Delete(XmlSports xml);
    }
}
