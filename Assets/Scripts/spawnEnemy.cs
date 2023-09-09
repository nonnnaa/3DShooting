using UnityEngine;
using UnityEngine.AI;
using System.Collections;
public class spawnEnemy : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public Transform[] enemySpawnPos;
    public int[] enemyCount; // lưu số enemy mỗi wave
    public int enemyCurrentCount;
    int count;

    public DoorManager door;
    private void Start()
    {
        enemyCurrentCount = 0;
        count = -1;
        door = GetComponent<DoorManager>();
    }
    private void Update()
    {
        if(enemyCurrentCount == 0)
        {
            count++;
            SpawnEnemy(count);
        }
    }
    void SpawnEnemy(int cnt)
    {
        enemyCurrentCount += enemyCount[cnt];
        for (int i = 0; i < enemyCount[cnt]; i++)
        {
            if (cnt < 1)
            {
                var enemy = Instantiate(enemyPrefab[0], enemySpawnPos[cnt].position, enemySpawnPos[cnt].rotation);
            }
            else if(cnt == 1 && door.check == true)
            {
                var enemy = Instantiate(enemyPrefab[1], enemySpawnPos[cnt].position, enemySpawnPos[cnt].rotation);
            }
            else
            {
                int randomNumber = Random.Range(0,1);
                var enemy = Instantiate(enemyPrefab[randomNumber], enemySpawnPos[cnt].position, enemySpawnPos[cnt].rotation);
            }
        }
    }    
}
