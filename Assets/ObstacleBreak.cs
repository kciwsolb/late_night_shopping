using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBreak : MonoBehaviour {

    [SerializeField] private GameObject brokenPrefab;

    public void Break()
    {
        gameObject.GetComponent<Collider>().enabled = false;
        Instantiate(brokenPrefab, transform.position, Quaternion.identity).transform.SetParent(transform.parent);
        Destroy(gameObject);
    }
}
