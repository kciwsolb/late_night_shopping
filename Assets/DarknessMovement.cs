using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarknessMovement : MonoBehaviour
{ 
    [SerializeField] private float speed;
    [SerializeField] private GameObject deathCam;
    [SerializeField] private SegmentSpawner segmentSpawner;
    [SerializeField] GameObject gameOverText;

    private void Update()
    {
        if(GameManager.Instance.hasStarted)
        {
            transform.Translate(transform.forward * speed * Time.deltaTime);
        }
        if(deathCam.transform.position.z - transform.position.z <= 1.0f)
        {
            segmentSpawner.DestroyAllSegments();
            gameOverText.SetActive(true);
        }
    }
}
