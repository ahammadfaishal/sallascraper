using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreBuilder.Core.Excavation
{
    public interface IExcavationService
    {
        Task CollectData(string targetSiteUrl);
    }
}
