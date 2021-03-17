﻿using UnityEngine;

public class EnemyParts : MonoBehaviour
{
    private Unit[] partesDoInimigo;

    public GameObject[] directionalTilemap;
    
    public string facingDirection;
    
    void Start()
    {
        partesDoInimigo = gameObject.GetComponentsInChildren<Unit>();

        partesDoInimigo[0] = partesDoInimigo[1];
        partesDoInimigo[1] = partesDoInimigo[2];
        partesDoInimigo[2] = partesDoInimigo[3];
        partesDoInimigo[3] = partesDoInimigo[4];
        partesDoInimigo[4] = partesDoInimigo[5];
        
        for (int i = 0; i < partesDoInimigo.Length; i++)
        {
            Debug.Log(partesDoInimigo[i]);
        }
    }
    
    void Update()
    {
        for (int x = 0; x < partesDoInimigo.Length; x++)
        {
            if (partesDoInimigo[x].GetComponent<Unit>().currentHP <= 0)
            {
                partesDoInimigo[x].GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 1);
            }
        }

        SetEnemyPartsPositions();
    }

    public Unit[] ReturnAllEnemyParts()
    {
        return partesDoInimigo;
    }

    private void SetEnemyPartsPositions()
    {
        switch (facingDirection)
        {
            case "RIGHT":
                MoveTowards(partesDoInimigo[0], new Vector3(0, 0.5f, 0));
                MoveTowards(partesDoInimigo[1], new Vector3(1, 0, 0));
                MoveTowards(partesDoInimigo[2], new Vector3(-1, 0, 0));
                MoveTowards(partesDoInimigo[3], new Vector3(0, -0.5f, 0));
                MoveTowards(partesDoInimigo[4], new Vector3(-1, 0.5f, 0));
                directionalTilemap[0].SetActive(true);
                directionalTilemap[1].SetActive(false);
                directionalTilemap[2].SetActive(false);
                directionalTilemap[3].SetActive(false);
            break;
            case "UP":
                MoveTowards(partesDoInimigo[0], new Vector3(-1, 0, 0));
                MoveTowards(partesDoInimigo[1], new Vector3(0, 0.5f, 0));
                MoveTowards(partesDoInimigo[2], new Vector3(0, -0.5f, 0));
                MoveTowards(partesDoInimigo[3], new Vector3(1, 0, 0));
                MoveTowards(partesDoInimigo[4], new Vector3(-1, -0.5f, 0));
                directionalTilemap[0].SetActive(false);
                directionalTilemap[1].SetActive(true);
                directionalTilemap[2].SetActive(false);
                directionalTilemap[3].SetActive(false);
            break;
            case "LEFT":
                MoveTowards(partesDoInimigo[0], new Vector3(0, -0.5f, 0));
                MoveTowards(partesDoInimigo[1], new Vector3(-1, 0, 0));
                MoveTowards(partesDoInimigo[2], new Vector3(1, 0, 0));
                MoveTowards(partesDoInimigo[3], new Vector3(0, 0.5f, 0));
                MoveTowards(partesDoInimigo[4], new Vector3(1, -0.5f, 0));
                directionalTilemap[0].SetActive(false);
                directionalTilemap[1].SetActive(false);
                directionalTilemap[2].SetActive(true);
                directionalTilemap[3].SetActive(false);
            break;
            case "DOWN":
                MoveTowards(partesDoInimigo[0], new Vector3(1, 0, 0));
                MoveTowards(partesDoInimigo[1], new Vector3(0, -0.5f, 0));
                MoveTowards(partesDoInimigo[2], new Vector3(0, 0.5f, 0));
                MoveTowards(partesDoInimigo[3], new Vector3(-1, 0, 0));
                MoveTowards(partesDoInimigo[4], new Vector3(1, 0.5f, 0));
                directionalTilemap[0].SetActive(false);
                directionalTilemap[1].SetActive(false);
                directionalTilemap[2].SetActive(false);
                directionalTilemap[3].SetActive(true);
            break;
        }
    }

    private void MoveTowards(Unit obj, Vector3 posToGo)
    {
        obj.transform.localPosition = posToGo;
    }
}
