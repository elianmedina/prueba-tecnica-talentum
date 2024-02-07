using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginController : MonoBehaviour
{
    public TMP_InputField userField;
    public TMP_InputField passwordField;
    public Button loginButton;
    private const int maxCharacters = 13;

    public string currentUser = "";

    private static LoginController instance;
    private void Awake()
    {
        // Verifica si ya existe una instancia del script
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Hace que el objeto persista entre escenas
        }
        else
        {
            Destroy(gameObject); // Destruye el objeto duplicado
        }
    }
    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            userField = GameObject.FindWithTag("Username").gameObject.GetComponent<TMP_InputField>();
            passwordField = GameObject.FindWithTag("Password").gameObject.GetComponent<TMP_InputField>();
            loginButton = GameObject.FindWithTag("StartButton").gameObject.GetComponent<Button>();

            // Verificar si los campos y botón son nulos
            if (userField == null || passwordField == null || loginButton == null)
            {
                return;
            }

            // Hacer interactable el botón de inicio solo si ambos campos tienen texto
            loginButton.interactable = !string.IsNullOrEmpty(userField.text) && !string.IsNullOrEmpty(passwordField.text);

            // Asignar el método OnLoginButtonClick al botón de inicio si aún no está asignado
            if (loginButton.onClick.GetPersistentEventCount() == 0)
            {
                loginButton.onClick.AddListener(OnLoginButtonClick);
            }

            // Configurar el campo de contraseña para mostrar puntos en lugar de texto
            passwordField.contentType = TMP_InputField.ContentType.Password;

            // Establecer límites de caracteres para los campos de usuario y contraseña
            userField.characterLimit = maxCharacters;
            passwordField.characterLimit = maxCharacters;
        }
    }

    public void OnLoginButtonClick()
    {
        string username = userField.text;
        string password = passwordField.text;

        // Obtener datos del jugador del PlayerPrefs
        string savedDataJSON = PlayerPrefs.GetString(username);

        // Verificar si el usuario ya existe
        if (!string.IsNullOrEmpty(savedDataJSON))
        {
            // Cargar datos del jugador
            PlayerData playerData = JsonUtility.FromJson<PlayerData>(savedDataJSON);
            Debug.Log("Login exitoso. Cargando la siguiente escena...");

            // Aquí puedes cargar la siguiente escena o realizar otras acciones
            // Guarda el nombre de usuario en un PlayerPrefs para usarlo en la siguiente escena si es necesario
            PlayerPrefs.SetString("LoggedInUser", username);
            currentUser = userField.text;
            SceneManager.LoadScene(1);
        }
        else
        {
            Debug.LogWarning("Usuario no encontrado. Creando nuevo usuario...");

            // Crear nuevo objeto PlayerData con la posición inicial del jugador
            PlayerData newPlayerData = new PlayerData(Vector3.zero, 0, 0, 0,0);

            // Convertir PlayerData a JSON
            string newPlayerDataJSON = JsonUtility.ToJson(newPlayerData);

            // Guardar los datos del nuevo jugador en PlayerPrefs
            PlayerPrefs.SetString(username, newPlayerDataJSON);

            Debug.Log("Nuevo usuario creado. Cargando la siguiente escena...");
            currentUser = userField.text;
            SceneManager.LoadScene(1);
        }
    }
}
