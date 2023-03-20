using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackToMenuScripts : MonoBehaviour
{
    public Button button;
    public void BackToMenu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
