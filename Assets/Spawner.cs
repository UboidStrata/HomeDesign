using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities.Solvers;
using Microsoft.MixedReality.Toolkit.Utilities;


public class Spawner : MonoBehaviour
{
    private GameObject menuPanel;
    public void Spawn()
    {
        GameObject clone1 = Instantiate(gameObject);
        clone1.AddComponent<BoxCollider>();
        clone1.AddComponent<ObjectManipulator>();
        clone1.AddComponent<NearInteractionGrabbable>();
        clone1.AddComponent<TapToPlace>();
        SolverHandler solverComponent = clone1.GetComponent<SolverHandler>();
        solverComponent.TrackedTargetType = TrackedObjectType.ControllerRay;
        menuPanel = GameObject.Find("RoomConfiguratorPanel");
        Vector3 spawnLocation = menuPanel.transform.position + transform.forward * 1.2f + transform.up*0.8f + transform.right*0.5f;
        GameObject clone2 = Instantiate(clone1, spawnLocation, Quaternion.identity);
        Destroy(clone1);
        clone2.name = gameObject.name;
        menuPanel.GetComponent<MenuManager>().AddToDestroy(clone2);
    }
}
