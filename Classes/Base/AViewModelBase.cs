﻿

namespace SystemMonitoringTool.Classes.Base
{
    public class AViewModelBase<T> : ABaseSingleton<T> where T : AViewModelBase<T>, new()
    {
    }
}
