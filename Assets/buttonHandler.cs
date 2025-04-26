using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonHandler : MonoBehaviour
{
    [SerializeField] private string controlScene = "controls";
    [SerializeField] private string storyScene = "story";
    //add another string thing to be the play Scene
    public void loadControls()
    {
        SceneManager.LoadScene(controlScene);
    }

    public void loadStory()
    {
        SceneManager.LoadScene(storyScene);
    }
    public void loadGame()
    {
        //SceneManager.LoadScene(###sceneHere###);
    }
}
