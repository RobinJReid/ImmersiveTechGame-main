using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour
{
    [SerializeField] TMP_Text ClipBoardText;
    [SerializeField] string Controls;
    [SerializeField] string Facilities;
    [SerializeField] string Contract;
    [SerializeField] GameObject Player;
    public void ContractText()
    {
        ClipBoardText.text = Contract;
    }
    public void FacilitiesText()
    {
        ClipBoardText.text = Facilities;
    }
    public void ControlText()
    {
        ClipBoardText.text = Controls;
    }
    public void Restart()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void StartGame()
    {
        Player.transform.position = new Vector3(-31.237f, 3.946f, -25.048f);
    }
    public void ExitGame()
    {
        Application.Quit();

    }
}
