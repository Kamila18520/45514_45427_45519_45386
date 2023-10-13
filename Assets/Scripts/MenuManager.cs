using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/*-------------------------------------------------------------------------------
 Na ESC Pauza
2x ESC Play

-------------------------------------------------------------------------------*/
public class MenuManager : MonoBehaviour
{
    [SerializeField] AudioSource ButtonClickSound;
    [SerializeField] GameObject MenuPanel;
    [SerializeField] GameObject SettingsPanel;
    [SerializeField] GameObject PausePanel;
    //[SerializeField] GameObject BackToMenu;
    private bool isPause;

    private void Start()
    {
        MenuPanel.SetActive(true);
        SettingsPanel.SetActive(false);
        PausePanel.SetActive(false);    




        isPause = false;
    }



    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape) && !isPause && !MenuPanel.activeSelf)
        {
            PausePanel.SetActive(true);
            Time.timeScale = 0f;
            isPause = true;
            ButtonClick();
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && isPause && !MenuPanel.activeSelf)
        {
            ResumeButton();
        }
    }

    public void MenuPanelOn()
    {
        isPause = false;
        MenuPanel.SetActive(true);
        PausePanel.SetActive(false);
        ButtonClick();
    }

    public void ResumeButton()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1f;
        isPause = false;
        ButtonClick();
    }

    //Metoda dla przycisku BACK na panelu settings
    public void BackButton()
    {
        if(isPause) 
        { 
            SettingsPanel.SetActive(false);
            PausePanel.SetActive(true);
        }
        else 
        {
            SettingsPanel.SetActive(false);
            MenuPanel.SetActive(true);
        
        }

        ButtonClick();

    }

    public void SettingsPanelOn()
    {
        SettingsPanel.SetActive(true);
        PausePanel.SetActive(false);
        ButtonClick();

    }
    public void LoadLevel()
    {
        ButtonClick();
        StartCoroutine(WaitForOneSec());
    }

    private IEnumerator WaitForOneSec()
    {
        yield return new WaitForSeconds(.5f);
        MenuPanel.SetActive(false);
       // SceneManager.LoadScene(1);
    }




    public void ExitGame()
    {
        Debug.Log("Gra zakoñczona"); 
        Application.Quit(); // Wyjœcie z gry
    } 
    
    public void ButtonClick()
    {
        ButtonClickSound.Play();
    }
}
