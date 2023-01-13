using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TitleMenu : MonoBehaviour
{
    public TMP_InputField nameInput;

    // Start is called before the first frame update
    void Start()
    {
        gameManager.instance.loadData();

    }

    public void pressStart()
    {
        gameManager.instance.userName = nameInput.text;
        SceneManager.LoadScene("main");
    }
}
