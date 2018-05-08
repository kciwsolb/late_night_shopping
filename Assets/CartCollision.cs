using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CartCollision : MonoBehaviour
{
    [SerializeField] private int maxHits;
    [SerializeField] private GameObject brokenCartPrefab;
    [SerializeField] private Text hitText;

    private int hitCount;
    private float timeLastHit;

    private void Start()
    {
        hitText.text = "Health: " + (maxHits + 1);
    }

    private void OnCollisionEnter(Collision collision)
    {
        ObstacleBreak obstacleBreak = collision.gameObject.GetComponentInChildren<ObstacleBreak>();
        if(obstacleBreak)
        {
            obstacleBreak.Break();
            if(timeLastHit != 0)
            {
                if(Time.time - timeLastHit >= 0.25f)
                {
                    timeLastHit = Time.time;
                    hitCount++;
                    CheckHitCount();
                    hitText.text = "Health: " + (maxHits - hitCount + 1);
                }
            }
            else
            {
                timeLastHit = Time.time;
                hitCount++;
                CheckHitCount();
                hitText.text = "Health: " + (maxHits - hitCount + 1);
            }
        }
    }

    private void CheckHitCount()
    {
        if(hitCount > maxHits)
        {
            GameManager.Instance.gameOver = true;
            gameObject.GetComponent<Collider>().enabled = false;
            Instantiate(brokenCartPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
