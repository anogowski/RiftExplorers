﻿using UnityEngine;
using System.Collections;

public class HookshotInstuctions : DisplayText 
{

	// Use this for initialization
	void Start ()
    {
	    textToDisplay += "X Button:\tPick Up\n";
        textToDisplay += "Right Trigger:\tFire\n";
        textToDisplay += "Aim for the red hookloops";
	}

}
