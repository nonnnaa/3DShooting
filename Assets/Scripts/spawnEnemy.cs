using UnityEngine;
using UnityEngine.AI;
using System.Collections;
public class spawnEnemy : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Vector3[] enemyPos;
    public int[] enemyCount;
    public int enemyCurrentCount;
    public Vector3 enemyCurrentPos;
    private void Start()
    {
        
    }
    private void Update()
    {
        
    }


    void checkEnemyCount()
    {
        for(int i=0; i<enemyCount.Length; i++)
        {
            if(enemyCurrentCount < 0)
            {
                enemyCurrentCount = enemyCount[i];
                enemyCurrentPos = enemyPos[i];
                SpawnEnemy(enemyCurrentPos, enemyCurrentCount);
            }
        }
    }

    void SpawnEnemy(Vector3 pos, int count)
    {
        for(int i=0; i<count; i++)
        {
            //Invoke("spawn", 3f, );
        }
        
    }
    void spawn()
    {
        //GameObject enemy = Instantiate(enemyPrefab, pos, Quaternion.identity);
    }
    
}
