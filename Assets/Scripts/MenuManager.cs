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
    public Camera MainCamera1;
    public Camera MainCamera2;

    
  private void Start()
    {
        MenuPanel.SetActive(true);
        SettingsPanel.SetActive(false);
        PausePanel.SetActive(false);

        // Aktywacja kamery 1 w menu
        MainCamera1.enabled = true;
        // Dezaktywacja kamery 2
        MainCamera2.enabled = false;

        isPause = false;
    }



    private void Update()
    {

        
        if (Input.GetKeyDown(KeyCode.Escape) && !isPause && !MenuPanel.activeSelf && MainCamera2.enabled && !SettingsPanel.activeSelf)
        {
            PausePanel.SetActive(true);
            //Time.timeScale = 0f;
            isPause = true;
            ButtonClick();
            ChangeCamera1();
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && isPause && !MenuPanel.activeSelf && !SettingsPanel.activeSelf)
        {
            ResumeButton();
            //ChangeCamera2();
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
        //Time.timeScale = 1f;
        isPause = false;
        ChangeCamera2();
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
        Debug.Log("Gra zosta³a rozpoczêta");
        MenuPanel.SetActive(false);

        // Aktywacja kamery 2 po naciœniêciu "Start"
        ChangeCamera2();
        ButtonClick();
        //StartCoroutine(WaitForOneSec());
    }

    private IEnumerator WaitForOneSec()
    {
        yield return new WaitForSeconds(.5f);


    }

    private void ChangeCamera1()
    {
        MainCamera1.enabled = true;
        MainCamera2.enabled = false;

    }
    private void ChangeCamera2()
    {
        MainCamera1.enabled = false;
        MainCamera2.enabled = true;
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
