using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public class Count
    {
        public int minimum;
        public int maximum;

        public Count (int min, int max)
        {
            minimum = min;
            maximum = max;
        }
    }

    public int col = 50;
    public int row = 50;
    public Count EnemyCount = new Count(20, 50);
    public Count CubeCount = new Count(20, 50);
    public Count DotCount = new Count(20, 30);
    public GameObject enemy;
    public GameObject cube;
    public GameObject dot;

    private Transform boardHolder;
    private List <Vector3> gridPostions = new List<Vector3>();

    void InitializeList()
    {
        gridPostions.Clear();

        for (int x = -(col / 2 - 1); x < (col / 2 -1); x++)
        {
            for (int z = -(row / 2 - 1); z < (row / 2 - 1); z++)
            {
                gridPostions.Add(new Vector3(x, 0.5f, z));
            }
        }

    }

    Vector3 RandomPostion()
    {
        int randomIndex = Random.Range(0, gridPostions.Count);
        Vector3 randomPostion = gridPostions[randomIndex];
        gridPostions.RemoveAt(randomIndex);
        return randomPostion;
    }

    void LayoutObjectAtRandom(GameObject obj, int minimum, int maximum)
    {
        int objectCount = Random.Range(minimum, maximum+1);
        for (int i = 0; i < objectCount; i++)
        {
            Vector3 randomPostion = RandomPostion();
            Instantiate(obj, randomPostion, Quaternion.identity);
        }
    }
        


	// Use this for initialization
	void Start () {
        InitializeList();
        LayoutObjectAtRandom(enemy, EnemyCount.minimum, EnemyCount.maximum);
        LayoutObjectAtRandom(cube, CubeCount.minimum, CubeCount.maximum);
        LayoutObjectAtRandom(dot, DotCount.minimum, DotCount.maximum);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
