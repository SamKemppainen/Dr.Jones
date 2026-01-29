using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forcefield : MonoBehaviour
{
    public GameObject ShieldEffect;
    public float tilingSpeed = 1f; // Speed of tiling animation
    private Material shieldMaterial;
    private float tilingOffset = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        ShieldEffect.SetActive(false);
        
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
        if (Input.GetKeyDown(KeyCode.F))
        {
            ShieldEffect.SetActive(!ShieldEffect.activeSelf);
        }
        
        // Continuously increase Y tiling when shield is active
        if (ShieldEffect.activeSelf && shieldMaterial != null)
        {
            tilingOffset += tilingSpeed * Time.deltaTime;
            Vector2 tiling = shieldMaterial.mainTexture.wrapMode == TextureWrapMode.Repeat ? 
                new Vector2(shieldMaterial.mainTexture.wrapModeU == TextureWrapMode.Repeat ? 1f : 1f, tilingOffset) :
                new Vector2(1f, tilingOffset);
            shieldMaterial.mainTextureScale = new Vector2(shieldMaterial.mainTextureScale.x, 1f);
            shieldMaterial.mainTextureOffset = new Vector2(shieldMaterial.mainTextureOffset.x, tilingOffset);
        }
    }
}
