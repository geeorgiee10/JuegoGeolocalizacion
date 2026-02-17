using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    public int vidas = 3;
    public int puntuacion = 0;
    public bool isGrounded;
    public TextMeshProUGUI vidastext;
    public TextMeshProUGUI puntuaciontext;

    public GameObject panelPerder;
    public GameObject panelGanar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vidastext.text = "Vidas: " + vidas;
        puntuaciontext.text = "Puntuación: " + puntuacion;
        panelPerder.SetActive(false);
        panelGanar.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            vidas--;
            vidastext.text = "Vidas: " + vidas;
            if(vidas <= 0)
            {
                Time.timeScale = 0;
                panelPerder.SetActive(true);
            }
        }

        if(other.CompareTag("Coleccionables"))
        {
            puntuacion += 10;
            puntuaciontext.text = "Puntuación: " + puntuacion;

            if(puntuacion >= 120)
            {
                Time.timeScale = 0;
                panelGanar.SetActive(true);
            }
        }
    }

    

    public void ReiniciarJuego()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);    
    }
    
    public void VolverMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
}
