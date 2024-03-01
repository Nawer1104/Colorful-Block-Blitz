using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{
    public List<Block> blocks = new List<Block>();

    private bool isClicked;

    public bool isCompleted;

    public GameObject vfxCompleted;

    private void Start()
    {
        isClicked = false;
        isCompleted = false;
    }

    private void OnMouseDown()
    {
        if (isClicked) return;

        isClicked = true;

        foreach(Block block in blocks)
        {
            block.GoToTarget();
        }
    }

    private bool Check()
    {
        foreach (Block block in blocks)
        {
            if (!block.isReachedTarget) return false;
        }

        GameObject vfx = Instantiate(vfxCompleted, transform.position, Quaternion.identity) as GameObject;
        Destroy(vfx, 1f);

        return true;
    }

    private void Update()
    {
        if (isCompleted) return;
        isCompleted = Check();
    }
}
