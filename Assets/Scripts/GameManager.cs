using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tmpVersion;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tmpVersion.text = "version: " + Application.version;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
