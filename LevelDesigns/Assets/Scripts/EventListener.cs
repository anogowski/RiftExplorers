using UnityEngine;
using System.Collections;

public class EventListener : MonoBehaviour
{
   public Events e;
    public EventListener(Events events)
    {
        e = events;
    }

     public static void fireEvent(EventListener el)
    {
         switch (el.e)
        {
            case Events.Death:
                 
                break;
            case Events.CheckPoint:
                
                break;
            default:
                break;
        }
    }

}
