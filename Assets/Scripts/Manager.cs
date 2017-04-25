using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour {

    public Text points;
    public Camera cam;
    public GameObject guiGameOver;

    private int currentPoints = 0;
    private bool canPlay = false;

    private static Manager _instance;
    public static Manager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(Manager)) as Manager;
            }

            return _instance;
        }
    }

    // Use this for initialization
	void Start () {
		//Level generator
	}

    public void UpdatePoints()
    {
        currentPoints += 1;
        points.text = currentPoints.ToString();

        //generate new level piece here
    }

    public bool CanPlay()
    {
        return canPlay;
    }

    public void StartPlay()
    {
        canPlay = true;
    }

    public void GameOver()
    {

        cam.GetComponent<CameraLookAt>().enabled = false;
        GuiGameOver();
    }

    void GuiGameOver()
    {
        guiGameOver.SetActive(true);
    }

    public void PlayAgain()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);

    }

    public void Quit()
    {
        Application.Quit();
    }
}
