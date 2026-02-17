using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerGeolocalizacion : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Menu()
    {
        SceneManager.LoadScene("MenuGeolocalizacion");
    }

    public void Jugar()
    {
        SceneManager.LoadScene("Geolocalizacion");
    }

    public void Instrucciones()
    {
        SceneManager.LoadScene("TutorialGeolocalizacion");
    }
}
