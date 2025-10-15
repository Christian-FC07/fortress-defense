using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Goto_Shop : MonoBehaviour
{
    public static bool press = false;
    public static bool press2 = false;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Menu Atlas Test")
        {
            Debug.Log("Shop Scene Loaded!");
            StartCoroutine(WaitAndFindHomeMenu());
        }
    }

    private IEnumerator WaitAndFindHomeMenu()
    {
        yield return new WaitForSeconds(0.5f);  

        GameObject homeMenu = GameObject.Find("HomeMenu-PC");
        if (homeMenu != null)
        {
            Debug.Log("Home Menu Found");
            var script = homeMenu.GetComponent<MainMenuHomeScene>();
            if (script != null)
            {
                script.Store(true);
                Debug.Log("Store function called!");
            }
            else
            {
                Debug.LogWarning("Script with Store() not found on HomeMenu-PC!");
            }
        }
        else
        {
            Debug.LogWarning("GameObject 'HomeMenu-PC' not found in scene!");
        }
    }

    public void ShopOpener()
    {
        Debug.Log("Opening Shop Scene...");
        SceneManager.LoadScene("Menu Atlas Test");
    }

    public void GoShopPressed()
    {
        press = true;
        press2 = true;
        Debug.Log("pressed");
        Time.timeScale = 1;
        ShopOpener();
    }
}
