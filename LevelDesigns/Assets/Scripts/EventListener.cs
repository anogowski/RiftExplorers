﻿using UnityEngine;
using System;

namespace Event_System
{
    interface EventListener
    {
       void React(EventType eventType);
    }
}
