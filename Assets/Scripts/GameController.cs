using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    [SerializeField] private GameView view;
    [SerializeField] private Button btnStart;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        btnStart.onClick.AddListener(GameStart);
        
    }

    void GameStart(){
        view.SetStart(false);
    }
}
