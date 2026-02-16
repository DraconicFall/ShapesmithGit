using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void reload()
    {
        EnemyScript.numOfEnemies = 0;
        EnemyScript.playerWon = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
