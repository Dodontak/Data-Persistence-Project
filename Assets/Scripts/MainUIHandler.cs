using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainUIHandler : MonoBehaviour
{
    public void BackToManu()
    {
        SceneManager.LoadScene(0);
    }
}
