using UnityEngine;
using TMPro;

public class GameView : MonoBehaviour
{
    [Header("Canvas_Static")]
    [SerializeField] private TextMeshProUGUI tmpVersion;
    [Header("Start")]
    [SerializeField] private GameObject objStart;
    [Header("Story")]
    [SerializeField] private GameObject objStory;
    [Header("Mystery")]
    [SerializeField] private GameObject objMystery;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tmpVersion.text = "version: " + Application.version;
    }

    // Start
    public void SetStart(bool isActive){
        objStart.SetActive(isActive);
    }
    public void SetStory(bool isActive){
        objStory.SetActive(isActive);
    }

    public void SetMystery(bool isActive){
        objMystery.SetActive(isActive);
    }
}
