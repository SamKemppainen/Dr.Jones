using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forcefield3 : MonoBehaviour
{
    public GameObject ShieldEffect;
    public float tilingSpeed = 1f; // Speed of tiling animation
    private Material shieldMaterial;
    private float tilingOffset = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        ShieldEffect.SetActive(true);
        
        // Get the material from the ShieldEffect's renderer
        Renderer renderer = ShieldEffect.GetComponent<Renderer>();
        if (renderer != null)
        {
            shieldMaterial = renderer.material;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            ShieldEffect.SetActive(!ShieldEffect.activeSelf);
        }
        
        // Continuously increase X and Y tiling when shield is active
        if (ShieldEffect.activeSelf && shieldMaterial != null)
        {
            tilingOffset += tilingSpeed * Time.deltaTime;
            shieldMaterial.mainTextureOffset = new Vector2(tilingOffset, tilingOffset);
        }
    }
}
