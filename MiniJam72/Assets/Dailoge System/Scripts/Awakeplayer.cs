using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Awakeplayer : MonoBehaviour
{
    // Start is called before the first frame update
    public dailougeScript Hell;
	public DailougeDisplayer Devil;  
	
	void Awake()
    {
        Devil.StartDailougeScript(Hell);
    }

    
}
