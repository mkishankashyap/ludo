using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GridManager : MonoBehaviour
{
    readonly private int rows = 15, cols = 15;
    [SerializeField] private Tile _tilePrefab;
    [SerializeField] private  Circle _circlePrefab;
    [SerializeField] private Transform _cam;

    void GenerateGrid() {
        for ( int r=0; r<rows; r++ ) {

            for ( int c =0; c<cols; c++ ) {
                var spawnedTile = Instantiate(_tilePrefab, new Vector3(r, c), Quaternion.identity);
                spawnedTile.name = $"Tile {r} {c}";

                
                if ( r == 10 && c == 10 ) {
                    var spawnedCircle = Instantiate(_circlePrefab, new Vector3(r, c, 2), Quaternion.identity);
                    spawnedCircle.GetComponent<SpriteRenderer>().color = Color.red;
                } else 
                if ( 
                    (r>=9 && r<=14 && (c==9 || c==14))
                    || ((r==9 || r==14) && c>=9 && c<=14)
                     ) { // Quad 1
                    spawnedTile.GetComponent<SpriteRenderer>().color = Color.red;
                } else if ( r>=0 && r<=5 && c>=9 && c<=15 ) { // Quad 2
                    spawnedTile.GetComponent<SpriteRenderer>().color = Color.green;
                } else if ( r>=0 && r<=5 && c>=0 && c<=5 ) {
                    spawnedTile.GetComponent<SpriteRenderer>().color = Color.blue;
                } else if ( r>=9 && r<=15 && c>=0 && c<=5 ) {
                    spawnedTile.GetComponent<SpriteRenderer>().color = Color.yellow;
                }
                
            }
        }
        _cam.transform.position = new Vector3((float)rows / 2 - 0.5f, (float)cols / 2 - 0.5f, -10);
        
    }
    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();
    // Update is called once per frame
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
