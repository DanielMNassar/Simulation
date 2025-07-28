
using UnityEngine;

public class PlayerSaveHandler : MonoBehaviour
{
    public int currentLevel = 1;
    public int coinsCollected = 0;

    void Start()
    {
        LoadGame();
    }

    public void SaveGame()
    {
        SaveData data = new SaveData
        {
            playerPosX = transform.position.x,
            playerPosY = transform.position.y,
            playerPosZ = transform.position.z,
            currentLevel = currentLevel,
            coinsCollected = coinsCollected
        };

        SaveManager.Save(data);
    }

    public void LoadGame()
    {
        SaveData data = SaveManager.Load();
        transform.position = new Vector3(data.playerPosX, data.playerPosY, data.playerPosZ);
        currentLevel = data.currentLevel;
        coinsCollected = data.coinsCollected;
    }
}
