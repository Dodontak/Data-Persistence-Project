using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class MenuUiHandler : MonoBehaviour
{
    public static string curPlayerName;
    public TMP_InputField NameInput;
    public Text bestScoreText;
    private string highScorePlayerName;
    private int highScore;
    void Awake()
    {
        Load();
        NameInput.text = curPlayerName;
        SetBestScoreText(highScorePlayerName, highScore);
    }
    public void StartNew()
    {
        curPlayerName = NameInput.text;
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // Unity 플레이어를 종료하는 원본 코드
#endif
        Save();
    }
    [System.Serializable]
    class SaveData
    {
        public string curPlayerName;
        public string highScorePlayerName;
        public int highScore;

    }
    public void Save()
    {
        SaveData data = new SaveData();
        data.curPlayerName = NameInput.text;
        data.highScorePlayerName = highScorePlayerName;
        data.highScore = highScore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void Load()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScorePlayerName = data.highScorePlayerName;
            highScore = data.highScore;
            curPlayerName = data.curPlayerName;
        }
        else
        {
            highScorePlayerName = "";
            highScore = 0;
        }
    }

    void SetBestScoreText(string name, int score)
    {
        bestScoreText.text = "Best Score\n" + name + " : " + score;
    }
}
