using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] public TMP_InputField nameInput;
    [SerializeField] public TextMeshProUGUI highScoreInfo;

    // Start is called before the first frame update
    void Start()
    {
        highScoreInfo.text = "High Score: " + MainGameManager.Instance.highScoreName
            + " : " + MainGameManager.Instance.highScore;
        nameInput.text = MainGameManager.Instance.playerName;
        nameInput.onEndEdit.AddListener(NewPlayerName);
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }

    public void NewPlayerName(string name)
    {
        MainGameManager.Instance.playerName = name;
    }
}
