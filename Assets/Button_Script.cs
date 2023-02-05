using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Button_Script : MonoBehaviour
{
    public GameObject Confirmation_Panel;
    

    public void LoadScene(string sceneName)
    {
        AudioSource ac = GetComponent<AudioSource>();
        SceneManager.LoadScene(sceneName);
       
    }

    public void ExitGame()
    {
        AudioSource ac = GetComponent<AudioSource>();
        Application.Quit();

    }

    public void enable_confirmation()
    {
        AudioSource ac = GetComponent<AudioSource>();
        Confirmation_Panel.SetActive(!Confirmation_Panel.activeSelf);
       
    }

    public void disable_confirmation()
    {
        AudioSource ac = GetComponent<AudioSource>();
        Confirmation_Panel.SetActive(!Confirmation_Panel.activeSelf);


    }
    // Start is called before the first frame update
    void Start()
    {
        Confirmation_Panel.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {


    }
}
