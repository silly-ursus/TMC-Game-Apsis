using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private float distance = 3f;
    [SerializeField] private LayerMask objectLayerMask;
    private PlayerUI playerUI;
    private StarterAssets.StarterAssetsInputs inputManager; //InputManager in Tutorial
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<StarterAssets.StarterAssetsInputs>().cam;
        playerUI = GetComponent<PlayerUI>();
        inputManager = GetComponent<StarterAssets.StarterAssetsInputs>();
    }

    // Update is called once per frame
    void Update()
    {
        playerUI.UpdateText(string.Empty);
        //creates a ray at the center of the camera, shooting outwards infinitely
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitInfo;
        if(Physics.Raycast(ray, out hitInfo, distance, objectLayerMask)){
            if(hitInfo.collider.GetComponent<Interactable>() != null){
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                playerUI.UpdateText(interactable.promptMessage);
                if(Input.GetKeyDown(KeyCode.E)){
                    interactable.BaseInteract();
                    playerUI.ToolTip(string.Empty);
                }
                if(Input.GetKeyDown(KeyCode.I)){
                    //open inventory screen
                }
            }
        }
    }
}
