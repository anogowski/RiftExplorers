using UnityEngine;
using System;

namespace EventSystem
{
    interface EventListener
    {
        void React(EventType eventType);
    }
}


