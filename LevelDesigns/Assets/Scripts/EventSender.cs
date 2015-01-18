using UnityEngine;
using System;
using System.Collections.Generic;

namespace EventSystem
{
    class EventSender : MonoBehaviour
    {
        List<EventListener> listeners = new List<EventListener>();

        public void Subscribe(EventListener l)
        {
            listeners.Add(l);
        }


        public void SendEvent(EventType type)
        {
            foreach (EventListener item in listeners)
            {
                item.React(type);
            }
        }

    }
}

