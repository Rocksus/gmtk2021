using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorneredAreaCheck : MonoBehaviour
{
    bool cornered = false;
    public NPC NPCController;

    Vector3 areaScale;

    Transform npcTransform;

    void Start()
    {
        Gizmos.color = new Color(0.0f, 1.0f, 0.0f);
        areaScale = transform.localScale;
    }

    void OnDrawGizmosSelected()
    {
        // Orange
        Gizmos.color = new Color(1.0f, 0.5f, 0.0f);
        Gizmos.DrawWireCube(transform.position, areaScale);
    }

    void Update()
    {
        if (NPCController != null && !cornered)
        {
            npcTransform = NPCController.transform;
            Vector3 dist = (npcTransform.position - transform.position) * 2f;
            if (Mathf.Abs(dist.x) < areaScale.x && Mathf.Abs(dist.y) < areaScale.y)
            {
                cornered = true;
                SetCornered();
            }
        }
    }

    void SetCornered()
    {
        NPCController.SetCornered();
    }
}
