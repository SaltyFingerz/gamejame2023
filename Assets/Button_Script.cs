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
        AudioSource ac = GetComponent<AudioSource>();
       
    }

    public void ExitGame()
    {
        Application.Quit();
        AudioSource ac = GetComponent<AudioSource>();
        
    }

    public void enable_confirmation()
    {
        Confirmation_Panel.SetActive(!Confirmation_Panel.activeSelf);

        AudioSource ac = GetComponent<AudioSource>();
       
    }

    public void disable_confirmation()
    {
        Confirmation_Panel.SetActive(!Confirmation_Panel.activeSelf);
        AudioSource ac = GetComponent<AudioSource>();
      
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
