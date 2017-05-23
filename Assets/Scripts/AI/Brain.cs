using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain : MonoBehaviour 
{
	[HideInInspector]
	public Entity entity;


    [HideInInspector]
    public bool IsBusy = false;


	public virtual void Tick()
	{
		
	}

}
