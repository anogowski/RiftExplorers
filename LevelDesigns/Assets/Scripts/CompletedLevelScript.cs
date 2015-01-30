using UnityEngine;
using System.Collections;

public class CompletedLevelScript : MonoBehaviour {
    public static bool completed = false;
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.name.Equals("OVRPlayer") && !completed)
        {
            AudioManager.Instance.PlaySounds(Sounds.WaterTempleComplete, SoundActions.Play, this.transform.position);
            Debug.Log("Complete");
            completed = true;
        }
    }
}
