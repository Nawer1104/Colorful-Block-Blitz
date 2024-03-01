using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public List<Blocks> blocks;

    private bool isLevelCompleted;

    private float countDelay = 2f;

    private void Start()
    {
        isLevelCompleted = false;
    }

    private void Update()
    {
        if (isLevelCompleted) return;

        countDelay -= Time.deltaTime;

        if (countDelay <= 0)
        {
            isLevelCompleted = CheckLevelCompleted();

            if (isLevelCompleted)
            {
                GameManager.Instance.CheckLevelUp();
            }

            countDelay = 2f;
        }
    }

    private bool CheckLevelCompleted()
    {
        foreach (Blocks block in blocks)
        {
            if (!block.isCompleted) return false;
        }

        return true;
    }

    public static List<GameObject> GetAllChilds(GameObject Go)
    {
        List<GameObject> list = new List<GameObject>();
        for (int i = 0; i < Go.transform.childCount; i++)
        {
            list.Add(Go.transform.GetChild(i).gameObject);
        }
        return list;
    }
}
