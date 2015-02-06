using UnityEngine;
using System.Collections;

public class PlayerDamage : MonoBehaviour {

    bool played = false;
    public static bool dead = false;
    int count = 0;


    IEnumerator playerHurt()
    {
        if (!played)
        {
            played = true;
        }
        yield return new WaitForSeconds(2f);
        played = false;
        count++;
            if (count >= 5)
            {
                dead = true;
                count = 0;
            }
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
