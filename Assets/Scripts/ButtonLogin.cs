using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLogin : MonoBehaviour
{
    private void Start()
    {
       
        LoginController _loginController = FindObjectOfType<LoginController>();

        if (_loginController != null)
        {
            Button miBoton = GetComponent<Button>();
            miBoton.onClick.AddListener(_loginController.OnLoginButtonClick);
        }
        else
        {
            Debug.LogWarning("No se encontró el objeto _loginController en la escena.");
        }
    }

}
