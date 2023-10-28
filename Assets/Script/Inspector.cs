using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inspector : MonoBehaviour
{
    [SerializeField] private GameObject prefabSpawn0;
    [SerializeField] private GameObject prefabSpawn1;
    [SerializeField] private GameObject prefabSpawn2;
    [SerializeField] private GameObject prefabSpawn3;
    [SerializeField] private GameObject prefabSpawn4;

    [SerializeField] private GameObject Enemy;

    private GameObject childs;
    private int difficulty = 1;
    private GameObject ObjectCreateEnemy;
    private bool[,] ObjectCreateEnemyLast = new bool[7,3] { { false, false, false }, { false, false, false },{ false, false, false }, 
        { false, false, false }, { false, false, false }, { false, false, false }, { false, false, false }, };


    private GameObject[] Spawn = new GameObject[5];

    private int lastPrefab;
    private Vector3 UPPrefabPosition;

    private Vector3 NewSpawnPosition;

    [SerializeField] private Text text;

    private int score;


    void Start()
    {
        Spawn[0] = prefabSpawn0;
        Spawn[1] = prefabSpawn1;
        Spawn[2] = prefabSpawn2;
        Spawn[3] = prefabSpawn3;
        Spawn[4] = prefabSpawn4;

        lastPrefab = 0;
        UPPrefabPosition = Spawn[4].transform.position;

        score = 0;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateSpan()
    {
            score += 70;
            GameObject lastSpawn = Spawn[lastPrefab];
            NewSpawnPosition = new Vector3(UPPrefabPosition.x - 14f, UPPrefabPosition.y + 7f, 0);
            lastSpawn.transform.position = NewSpawnPosition;
            ObjectCreateEnemy = lastSpawn;
            UPPrefabPosition = Spawn[lastPrefab].transform.position;
            lastPrefab++;
            if (lastPrefab > 4) 
            { 
                
                lastPrefab = 0; 
            
            }
        text.text = score.ToString();
        CreateEnemy();
        difficulty++;
        if (difficulty > 14) difficulty = 14;
    }

    public void CreateEnemy()
    {
        

        for (int i = 0; i < difficulty; i++)
        {
            int posEnemyRand = 2;
            int stepNumberRand = 0;

            do
            {
                ObjectCreateEnemyLast[stepNumberRand, posEnemyRand] = true;
                posEnemyRand = Random.Range(0, 2);
                stepNumberRand = Random.Range(1, 6);

            }
            while (ObjectCreateEnemyLast[stepNumberRand, posEnemyRand] == true);

            childs = ObjectCreateEnemy.transform.GetChild(stepNumberRand).gameObject;
            childs = childs.transform.GetChild(posEnemyRand).gameObject;
            Transform CreateEnemyPos = childs.transform;

            Instantiate(Enemy, CreateEnemyPos.position, Quaternion.identity);
        }
        ObjectCreateEnemyLast = new bool[7, 3] { { false, false, false }, { false, false, false },{ false, false, false },
        { false, false, false }, { false, false, false }, { false, false, false }, { false, false, false }, };
    }
}
