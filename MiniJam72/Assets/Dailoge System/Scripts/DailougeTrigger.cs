using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailougeTrigger : MonoBehaviour
{
	public dailougeScript Hell;
	public DailougeDisplayer Devil;  
	
	private void OnTriggerEnter(Collider other)
    {
		if(other.gameObject.tag.Equals("Player")) 
		{
			Devil.StartDailougeScript(Hell);
		}
	}

}
