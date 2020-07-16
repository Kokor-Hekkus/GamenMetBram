using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectMarc
{
    public interface IGameEventListener<T>
    {
        void OnEventRaised(T item);
    }
}