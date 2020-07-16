﻿using UnityEngine;

namespace ProjectMarc
{ 
    [CreateAssetMenu(fileName = "New Void Event", menuName = "Game Events/Void Events")]
public class VoidEvent : BaseGameEvent<Void>
    {
        public void Raise() => Raise(new Void()); 
    }
}