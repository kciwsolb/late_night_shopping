using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CartMovement : MonoBehaviour
{
    [SerializeField] private int minX, maxX;
    [SerializeField] private float speed;
    [SerializeField] private float turnSpeed;
    [SerializeField] private Animator animator;
    [SerializeField] private Text distanceText;
    [SerializeField] private AudioSource audioSource;

    private bool audioPlaying;

    private void Update()
    {
        if(GameManager.Instance.hasStarted && !GameManager.Instance.gameOver)
        {
            animator.SetBool("running", true);
            transform.Translate(transform.forward * speed * Time.deltaTime);
            if(Input.GetButton("Move Right"))
            {
                if(transform.position.x < maxX)
                {
                    transform.Translate(transform.right * speed * Time.deltaTime);
                }
            }
            if(Input.GetButton("Move Left"))
            {
                if(transform.position.x > minX)
                {
                    transform.Translate(transform.right * -speed * Time.deltaTime);
                }
            }
            distanceText.text = "Distance: " + (int)transform.position.z;
            if(!audioPlaying)
            {
                audioSource.Play();
                audioPlaying = true;
            }
        }
        else
        {
            GameManager.Instance.finalDistance = (int)transform.position.z;
        }
    }
}
