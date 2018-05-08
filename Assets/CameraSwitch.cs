using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] private Camera deathCamera;
    [SerializeField] private GameObject backgroundCanvas, scoreCanvas;
    [SerializeField] private GameObject darknessText;
    private new Camera camera;
    private float timeToActivateGameOverText;

    private void Awake()
    {
        camera = GetComponent<Camera>();
        backgroundCanvas.SetActive(true);
    }
	void Update ()
    {
        if(GameManager.Instance.gameOver) //Game Over
        {
            darknessText.SetActive(true);
            scoreCanvas.SetActive(false);
        }
        if(GameManager.Instance.gameOver || !GameManager.Instance.hasStarted) //Game Over OR Not Begun
        {
            camera.enabled = false;
            deathCamera.enabled = true;
            scoreCanvas.SetActive(false);
        }
        else //Game Begun
        {
            deathCamera.enabled = false;
            camera.enabled = true;
            backgroundCanvas.SetActive(false);
            scoreCanvas.SetActive(true);
        }
    }
}
