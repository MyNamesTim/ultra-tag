using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonHandler : MonoBehaviour
{
    [SerializeField] private string controlScene = "controls";
    //add another string thing to be the play Scene
    public void loadControls()
    {
        SceneManager.LoadScene(controlScene);
    }
    public void loadGame()
    {
        //SceneManager.LoadScene(###sceneHere###);
    }
}
