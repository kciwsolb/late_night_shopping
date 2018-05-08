using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillStartingSegment : MonoBehaviour
{
	void Update ()
    {
        if(GameManager.Instance.hasStarted)
        {
            Destroy(gameObject, 3.0f);
        }
	}
}
