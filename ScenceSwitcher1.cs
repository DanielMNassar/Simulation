using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour
{
    public string sceneName = "";
    void OnEnable()
    {
        GetComponent<Button>().onClick.AddListener(LoadSampleScene);
    }

    public void LoadSampleScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadSecondScene()
    {
        SceneManager.LoadScene("scenes1");
    }
}
