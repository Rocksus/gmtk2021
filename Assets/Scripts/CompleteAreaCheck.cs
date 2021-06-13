using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteAreaCheck : MonoBehaviour
{
    bool levelCompleted = false;
    public NPC NPCController;
    public GameManager gameManager;

    Vector3 areaScale;

    Transform npcTransform;

    void Start()
    {
        areaScale = transform.localScale;
    }

    void Update()
    {
        if (NPCController != null && !levelCompleted)
        {
            npcTransform = NPCController.transform;
            Vector3 dist = npcTransform.position - transform.position;
            if (Mathf.Abs(dist.x) < areaScale.x && Mathf.Abs(dist.y) < areaScale.y)
            {
                levelCompleted = true;
                CompleteLevel();
            }
        }
    }

    void CompleteLevel()
    {
        gameManager.NextLevel();
    }

    public bool IsLevelCompleted()
    {
        return levelCompleted;
    }
}
