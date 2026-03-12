using UnityEngine;

public abstract class State
{
    public abstract State Act();

    protected void PerformDestroy(GameObject obj)
    {
        if (Application.isPlaying)
        {
            Object.Destroy(obj);
        }
        else
        {
            Object.DestroyImmediate(obj);
        }
    }
}
