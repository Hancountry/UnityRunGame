using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public float zSpawn = 0;
    public float tileLength = 30;
    public int numberOfTiles = 5;
    private List<GameObject> activeTiles = new List<GameObject>();

    public Transform playerTransform;
    void Start()
    {
     
        for(int i=0; i < numberOfTiles; i++)
        {
            if (i == 0)
                SpawnTile(0); // 맨 처음에는 첫번째 타일이 나오도록 설정
            else
           
                SpawnTile(Random.Range(0, tilePrefabs.Length));
        
            
        }
       // 배열에 저장해둔 파일이 번갈아 나오도록 설정

    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform.position.z - 35 >zSpawn-(numberOfTiles * tileLength))
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length));
            DeleteTile();
        }
    }
    public void SpawnTile(int tileIndex)
    {
       GameObject go = Instantiate(tilePrefabs[tileIndex], transform.forward * zSpawn, transform.rotation);
        activeTiles.Add(go);
        zSpawn += tileLength;
    }
    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
