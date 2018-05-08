using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapRagdoll : MonoBehaviour
{
    [SerializeField] private GameObject ragdollPrefab;

	void Update ()
    {
        if(GameManager.Instance.gameOver)
        {
            Instantiate(ragdollPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
	}
}
