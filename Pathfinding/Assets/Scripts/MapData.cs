using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapData : MonoBehaviour {

    public int width = 10;
    public int height = 5;


	// Use this for initialization
	void Start () {

        int[,] mapInstance = MakeMap();

	}
	
	public int[,] MakeMap()
    {
        int[,] map = new int[width, height];

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                map[i, j] = 0;
            }
        }

        map[1, 0] = 1;
        map[1, 1] = 1;
        map[1, 2] = 1;
        map[3, 2] = 1;
        map[3, 3] = 1;
        map[3, 4] = 1;
        map[4, 2] = 1;
        map[5, 1] = 1;
        map[5, 2] = 1;
        map[6, 2] = 1;
        map[6, 3] = 1;
        map[8, 0] = 1;
        map[8, 1] = 1;
        map[8, 2] = 1;
        map[8, 4] = 1;  

        return map;
    }
}
