using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TankInformationCanvas : MonoBehaviour
{
    public GameObject tankInfoMenu;

    // Start is called before the first frame update
    void Start()
    {
        tankInfoMenu.SetActive(false);
    }
    public  void GoToMainMenu()
    {
        SceneManager.LoadScene("0StartMenu");
    }
    public void OpenTankInfo()
    {
        tankInfoMenu.SetActive(true);
    }
    
    public void CloseTankInfo()
    {
        tankInfoMenu.SetActive(false);
    }
}
