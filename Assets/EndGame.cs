using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public bool Restart = false;

    private void Update()
    {
        if (Restart)
        {
            SceneManager.LoadScene(0);
        }
    }
}
