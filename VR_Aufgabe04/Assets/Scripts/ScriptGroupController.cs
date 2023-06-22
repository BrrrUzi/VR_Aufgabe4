using UnityEngine;

public class ScriptGroupController : MonoBehaviour
{
    public MonoBehaviour[] scriptsToDisable;

    public void DisableScripts()
    {
        foreach (MonoBehaviour script in scriptsToDisable)
        {
            script.enabled = false;
        }
    }

    public void EnableScripts()
    {
        foreach (MonoBehaviour script in scriptsToDisable)
        {
            script.enabled = true;
        }
    }
}