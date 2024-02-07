using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public class PlayerData
{
    public Vector3 playerPosition;
    public int espada;
    public int martillo;
    public int superior;
    public int botas;

    public PlayerData(Vector3 position, int estadoEspada, int estadoMartillo, int estadoSuperior, int estadoBotas)
    {
        playerPosition = position;
        espada = estadoEspada;
        martillo = estadoMartillo;
        superior = estadoSuperior;
        botas = estadoBotas;
    }
}


public class SceneController : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isPaused = false;
    public TMP_Text userNameText;

    private Dictionary<string, PlayerData> playerDictionary = new Dictionary<string, PlayerData>();

    public GameObject[] objetos;

    public GameObject Player;
    
    public PlayerController playerController;

    public SlotsController slotsController;

    public InventoryController inventoryController;
    public Item[] items;

    public GameObject[] SuperiorCubierto;

    public GameObject BotasCubierto;

    public GameObject Espada;

    public GameObject Martillo;

    void Start()
    {
        
        ResumeGame();
 
        LoginController loginController = FindObjectOfType<LoginController>();

        if (loginController != null)
        {    
            string username = loginController.currentUser;
            userNameText.text = username;
            LoadPlayerData();
        }
        else
        {
            Debug.LogWarning("LoginController no encontrado");
        }
        
    }
    void Update()
    {
       
            if (Input.GetKeyUp(KeyCode.Escape))
            {
            if (!isPaused)
            {
                if (!playerController.onInventory)
                {
                    PauseGame();
                }
                else
                {
                    playerController.CloseInventory();
                }
                
            }
            else
            {
                ResumeGame();
            }
         } 
    }

    void PauseGame()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        isPaused = true;
        Cursor.visible = true;
    }

    void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        isPaused = false;
        Cursor.visible = false;
    }

    public void onResumeButton()
    {
        ResumeGame();
    }

    public void onMainMenuButton()
    {
        SceneManager.LoadScene("Login");
    }
    public void SavePlayerData()
    {
        string username = userNameText.text;
        int _estadoEspada = 0;
        int _estadoMartillo = 0;
        int _estadoSuperior = 0;
        int _estadoBotas = 0;

        slotsController.SlotsReview();

        for (int i = 0; i < slotsController.childSlotNames.Length; i++)
        {
            if (i == 0)
            {
                if (slotsController.childSlotNames[i].Equals("Espada"))
                {
                    _estadoEspada = i+1;
                }
                if (slotsController.childSlotNames[i].Equals("Martillo"))
                {
                    _estadoMartillo = i + 1;
                }
                if (slotsController.childSlotNames[i].Equals("Superior"))
                {
                    _estadoSuperior = i + 1;
                }
                if (slotsController.childSlotNames[i].Equals("Botas"))
                {
                    _estadoBotas = i + 1;
                }
            }
            else if(i == 1)
            {
                if (slotsController.childSlotNames[i].Equals("Espada"))
                {
                    _estadoEspada = i + 1;
                }
                if (slotsController.childSlotNames[i].Equals("Martillo"))
                {
                    _estadoMartillo = i + 1;
                }
                if (slotsController.childSlotNames[i].Equals("Superior"))
                {
                    _estadoSuperior = i + 1;
                }
                if (slotsController.childSlotNames[i].Equals("Botas"))
                {
                    _estadoBotas = i + 1;
                }
            }
            else if (i == 2)
            {
                if (slotsController.childSlotNames[i].Equals("Espada"))
                {
                    _estadoEspada = i + 1;
                }
                if (slotsController.childSlotNames[i].Equals("Martillo"))
                {
                    _estadoMartillo = i + 1;
                }
                if (slotsController.childSlotNames[i].Equals("Superior"))
                {
                    _estadoSuperior = i + 1;
                }
                if (slotsController.childSlotNames[i].Equals("Botas"))
                {
                    _estadoBotas = i + 1;
                }
            }
            else if (i == 3)
            {
                if (slotsController.childSlotNames[i].Equals("Espada"))
                {
                    _estadoEspada = i + 1;
                }
                if (slotsController.childSlotNames[i].Equals("Martillo"))
                {
                    _estadoMartillo = i + 1;
                }
                if (slotsController.childSlotNames[i].Equals("Superior"))
                {
                    _estadoSuperior = i + 1;
                }
                if (slotsController.childSlotNames[i].Equals("Botas"))
                {
                    _estadoBotas = i + 1;
                }
            }
            else if (i == 4)
            {
                if (slotsController.childSlotNames[i].Equals("Espada"))
                {
                    _estadoEspada = i + 1;
                }
                if (slotsController.childSlotNames[i].Equals("Martillo"))
                {
                    _estadoMartillo = i + 1;
                }
                if (slotsController.childSlotNames[i].Equals("Superior"))
                {
                    _estadoSuperior = i + 1;
                }
                if (slotsController.childSlotNames[i].Equals("Botas"))
                {
                    _estadoBotas = i + 1;
                }
            }
            else if (i == 5)
            {
                if (slotsController.childSlotNames[i].Equals("Espada"))
                {
                    _estadoEspada = i + 1;
                }
                if (slotsController.childSlotNames[i].Equals("Martillo"))
                {
                    _estadoMartillo = i + 1;
                }
                if (slotsController.childSlotNames[i].Equals("Superior"))
                {
                    _estadoSuperior = i + 1;
                }
                if (slotsController.childSlotNames[i].Equals("Botas"))
                {
                    _estadoBotas = i + 1;
                }
            }
            else if (i == 6)
            {
                if (slotsController.childSlotNames[i].Equals("Espada"))
                {
                    _estadoEspada = i + 1;
                }
                if (slotsController.childSlotNames[i].Equals("Martillo"))
                {
                    _estadoMartillo = i + 1;
                }
                if (slotsController.childSlotNames[i].Equals("Superior"))
                {
                    _estadoSuperior = i + 1;
                }
                if (slotsController.childSlotNames[i].Equals("Botas"))
                {
                    _estadoBotas = i + 1;
                }
            }
            else if (i == 7)
            {
                if (slotsController.childSlotNames[i].Equals("Espada"))
                {
                    _estadoEspada = i + 1;
                }
                if (slotsController.childSlotNames[i].Equals("Martillo"))
                {
                    _estadoMartillo = i + 1;
                }
                if (slotsController.childSlotNames[i].Equals("Superior"))
                {
                    _estadoSuperior = i + 1;
                }
                if (slotsController.childSlotNames[i].Equals("Botas"))
                {
                    _estadoBotas = i + 1;
                }
            }

        }

            // Crear o actualizar los datos del jugador en el diccionario
            PlayerData playerData = new PlayerData(Player.transform.position, _estadoEspada,_estadoMartillo,_estadoSuperior,_estadoBotas);
        playerDictionary[username] = playerData;

        // Convertir PlayerData a JSON y guardar en PlayerPrefs
        string json = JsonUtility.ToJson(playerData);
        Debug.Log(json);
        PlayerPrefs.SetString(username, json);
        PlayerPrefs.Save();

        Debug.Log("Succesfully saved data");
    }
    // Método para cargar los datos del jugador
    public void LoadPlayerData()
    {
        string username = userNameText.text;

        // Obtener los datos guardados del jugador de PlayerPrefs
        string savedDataJSON = PlayerPrefs.GetString(username);

        if (!string.IsNullOrEmpty(savedDataJSON))
        {
            // Convertir JSON a PlayerData y guardar en el diccionario
            PlayerData playerData = JsonUtility.FromJson<PlayerData>(savedDataJSON);
            playerDictionary[username] = playerData;

            // Aplicar los datos cargados al jugador
            Player.GetComponent<CharacterController>().enabled = false;
            Player.transform.position = playerData.playerPosition;
            

            if(playerData.espada != 0)
            {
                Destroy(objetos[0]);

                if(playerData.espada == 1)
                {
                    inventoryController.AddItemForSpecificSlot(items[0], 0);
                }
                else if (playerData.espada == 2)
                {
                    inventoryController.AddItemForSpecificSlot(items[0], 1);
                }
                else if (playerData.espada == 3)
                {
                    inventoryController.AddItemForSpecificSlot(items[0], 2);
                }
                else if (playerData.espada == 4)
                {
                    inventoryController.AddItemForSpecificSlot(items[0], 3);
                }
                else if (playerData.espada == 5)
                {
                    inventoryController.AddItemForSpecificPlayerSlot(items[0], 0);
                    Espada.SetActive(true);
                }
            }

            if (playerData.martillo != 0)
            {
                Destroy(objetos[1]);

                if (playerData.martillo == 1)
                {
                    inventoryController.AddItemForSpecificSlot(items[1], 0);
                }
                else if (playerData.martillo == 2)
                {
                    inventoryController.AddItemForSpecificSlot(items[1], 1);
                }
                else if (playerData.martillo == 3)
                {
                    inventoryController.AddItemForSpecificSlot(items[1], 2);
                }
                else if (playerData.martillo == 4)
                {
                    inventoryController.AddItemForSpecificSlot(items[1], 3);
                }
                else if (playerData.martillo == 5)
                {
                    inventoryController.AddItemForSpecificPlayerSlot(items[1], 0);
                    Martillo.SetActive(true);
                }
            }

            if (playerData.superior != 0)
            {
                Destroy(objetos[2]);

                if (playerData.superior == 1)
                {
                    inventoryController.AddItemForSpecificSlot(items[2], 0);
                }
                else if (playerData.superior == 2)
                {
                    inventoryController.AddItemForSpecificSlot(items[2], 1);
                }
                else if (playerData.superior == 3)
                {
                    inventoryController.AddItemForSpecificSlot(items[2], 2);
                }
                else if (playerData.superior == 4)
                {
                    inventoryController.AddItemForSpecificSlot(items[2], 3);
                }
                else if (playerData.superior == 6)
                {
                    inventoryController.AddItemForSpecificPlayerSlot(items[2], 1);
                    for(int i = 0; i < SuperiorCubierto.Length; i++)
                    {
                        SuperiorCubierto[i].SetActive(true);
                    }
                }
            }

            if (playerData.botas != 0)
            {
                Destroy(objetos[3]);

                if (playerData.botas == 1)
                {
                    inventoryController.AddItemForSpecificSlot(items[3], 0);
                }
                else if (playerData.botas == 2)
                {
                    inventoryController.AddItemForSpecificSlot(items[3], 1);
                }
                else if (playerData.botas == 3)
                {
                    inventoryController.AddItemForSpecificSlot(items[3], 2);
                }
                else if (playerData.botas == 4)
                {
                    inventoryController.AddItemForSpecificSlot(items[3], 3);
                }
                else if (playerData.botas == 6)
                {
                    inventoryController.AddItemForSpecificPlayerSlot(items[3], 1);
                    BotasCubierto.SetActive(true);
                }
            }

            Debug.Log("Loaded player position for user " + username + ": " + playerData.playerPosition);
            Player.GetComponent<CharacterController>().enabled = true;
        }
        else
        {
            Debug.Log("No player data found for user " + username);
        }
    }

}
