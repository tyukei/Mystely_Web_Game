using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    [SerializeField] private GameView view;
    [SerializeField] private Button btnStart;
    [SerializeField] private Button btnRestart;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        btnStart.onClick.AddListener(GameStart);
        btnRestart.onClick.AddListener(GameRestart);
    }

    void GameStart(){
        view.SetStart(false);
        view.SetStory(true);
    }

    void GameRestart(){
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }
}
