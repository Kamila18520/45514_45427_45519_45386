using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] AudioSource ButtonClickSound;

    public void LoadLevel()
    {
        ButtonClick();
        StartCoroutine(WaitForOneSec());
    }

    private IEnumerator WaitForOneSec()
    {
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene(1);
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
