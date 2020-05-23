using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMap : MonoBehaviour
{
    public Transform tilePrefab;
    public Vector2 mapSize;
    public Transform obstaclePrefab;

    //grid outline
    [Range(0, 1)]
    public float oL;
    [Range(0, 63)]
    public int obstacles;

    //list of every tile
    List<Coord> tileCoords;
    // queue of arranged tiles
    Queue<Coord> arrTiles;
    public int seed;
    //int obstacles;


    void Start()
    {
        GenMap();
        //seed = 0;
        //obstacles = 20;
    }

    public void GenMap()
    {


        tileCoords = new List<Coord>();
        for (int x = 0; x <= mapSize.x; x++)
        {
            for (int y = 0; y <= mapSize.y; y++)
            {
                tileCoords.Add(new Coord(x, y));
            }
        }

        arrTiles = new Queue<Coord>(WallArray.WArray(tileCoords.ToArray(), seed));

        string holderName = "Generated Map";
        if (transform.Find(holderName))
        {
            DestroyImmediate(transform.Find(holderName).gameObject);

        }


        Transform mapHolder = new GameObject(holderName).transform;
        mapHolder.parent = transform;


        for (int x = 0; x <= mapSize.x; x++)
        {
            for (int y = 0; y <= mapSize.y; y++)
            {
                Vector3 tilePosition = CoordToPos(x, y);
                Transform newTile = Instantiate(tilePrefab, tilePosition, Quaternion.Euler(Vector3.right * 90)) as Transform;
                newTile.localScale = Vector3.one * (1 - oL);
                newTile.parent = mapHolder;
            }
        }


        
        for (int j = 0; j < obstacles; j++)
        {
            Coord rndCord = GetRandomCoord();
            //obstacle position
            Vector3 obsPos = CoordToPos(rndCord.x, rndCord.y);
            Transform newObs = Instantiate(obstaclePrefab, obsPos + Vector3.down * .95f, Quaternion.identity) as Transform;
            newObs.parent = mapHolder;
        }
    }

    //translate coords to position
    public Vector3 CoordToPos(int _x, int _y)
    {
        return new Vector3(-mapSize.x / 2  + _x, 0, -mapSize.y / 2  + _y);

    }

    public Coord GetRandomCoord()
    {
        Coord randCrd = arrTiles.Dequeue();
        arrTiles.Enqueue(randCrd);
        return randCrd;
    }

    public struct Coord {
        public int x;
        public int y;
        public Coord(int _x, int _y)
        {
            x = _x;
            y = _y;

        }

    }
   
}
