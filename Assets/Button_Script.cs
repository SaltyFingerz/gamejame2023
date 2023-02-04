using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Button_Script : MonoBehaviour
{
    public GameObject Confirmation_Panel;

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void enable_confirmation()
    {
        Confirmation_Panel.SetActive(true);
    }

    public void disable_confirmation()
    {
        Confirmation_Panel.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {


    }
}
