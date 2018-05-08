using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    public int finalDistance;
    public float timeTo1, timeTo2, timeTo3;

    [SerializeField] private Text distanceText;

    private void EnforceSingleton()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public int difficulty;
    public bool gameOver, hasStarted;

    private void Awake()
    {
        EnforceSingleton();
        difficulty = 0;
        gameOver = false;
    }

    private void Update()
    {
        if(Input.GetButtonDown("Start"))
        {
            if(!hasStarted)
            {
                hasStarted = true;
                timeTo1 = Time.time + 10.0f;
                timeTo2 = Time.time + 45.0f;
                timeTo3 = Time.time + 90.0f;
            }
            if(gameOver)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        if(hasStarted)
        {
            if(Time.time >= timeTo1)
            {
                difficulty = 1;
            }
            if(Time.time >= timeTo2)
            {
                difficulty = 2;
            }
            if(Time.time >= timeTo3)
            {
                difficulty = 3;
            }
        }
        if(gameOver)
        {
            distanceText.text = "Distance: " + finalDistance;
        }
    }
}
