using UnityEngine;
using UnityEngine.SceneManagement;

public class backButton : MonoBehaviour
{
    [SerializeField] private string menuScene = "intro";
    public void loadMenu()
    {
        SceneManager.LoadScene(menuScene);
    }
}
