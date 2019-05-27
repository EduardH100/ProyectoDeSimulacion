using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonInicio : MonoBehaviour
{
    public Button btnInicio;

    // Start is called before the first frame update
    void Start()
    {
        Button btnInicio = GetComponent<Button>();
        btnInicio.onClick.AddListener(irAlJuego);


    }

    public void irAlJuego()
    {
        Application.LoadLevel("miniGame");

    }

    public void IrACreditos()
    {
        Application.LoadLevel("creditos");
    }
}
