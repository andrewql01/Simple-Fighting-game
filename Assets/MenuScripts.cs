using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuScripts : MonoBehaviour
{
    public void PlayGame()
    {
        if (PlayerScripts.player.ListOfWeapons.Count != 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
        }
        else
        {
            EditorUtility.DisplayDialog("Kup Bronie !", "Kup bronie w Shop zeby kontynuowac", "ok");
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void OpenShop()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2, LoadSceneMode.Single);
    }
    // Start is called before the first frame update
    public Button playBtn;
    public Button quitBtn;
    public Button shopBtn;
    List<Weapons> cWeapons = new List<Weapons>()
    {
        null,
        null,
        null
    };
    List<Armor> cArmors = new List<Armor>()
    {
        null,
        null
    };
    void Start()
    {
        playBtn.onClick.AddListener(PlayGame);
        quitBtn.onClick.AddListener(QuitGame);
        shopBtn.onClick.AddListener(OpenShop);
        if (PlayerScripts.player == null)
        {
            PlayerScripts.player = new PlayerScripts.Player(7, 100, cWeapons,cArmors);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
