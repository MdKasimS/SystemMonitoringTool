﻿
namespace CineComplex.Classes.Base
{
    public class AServiceBase<T> : ABaseSingleton<T> where T : AServiceBase<T>, new()
    {
    }
}
