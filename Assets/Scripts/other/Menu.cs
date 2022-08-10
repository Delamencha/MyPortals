using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject hint;

    private void Start()
    {
        StartCoroutine(Hint());
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator Hint()
    {
        hint.SetActive(true);
        yield return new WaitForSeconds(10f);
        hint.SetActive(false);
    }

}
