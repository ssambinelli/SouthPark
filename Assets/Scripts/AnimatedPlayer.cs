// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class AnimatedPlayer : MonoBehaviour
// {
//     public Sprite[] sprites;
//     private SpriteRenderer spriteRenderer;
//     private int frame;

//     private void Awake() 
//     {
//         spriteRenderer =  GetComponent<SpriteRenderer>();
//     }
//     private void OnEnable() 
//     {
//         Invoke (nameof(Animate), 0f);
//     }

    // private void OnDesable()
    // {
    //     CancelInvoke();
    // }

//     private void Animate()
//     {
        // transform.localPosition.y = 1f;
        // transform.localPosition.y = -1.38f;
        // transform.Rotate(new Vector3(0f, 1f, 0f));
        // transform.Rotate(new Vector3(0f, 5f, 0f) * Time.deltaTime);
        // transform.Rotate(new Vector3(0f, 0f, -5f) * Time.deltaTime);
        // frame++;

        // if (frame >= sprites.Length)
        // {
        //     frame = 0;
        // }
        // if (frame >=0 && frame < sprites.Length)
        // {
        //     spriteRenderer.sprite = sprites[frame];
        // }
//         Invoke(nameof(Animate), 1f / GameManager.Instance.gameSpeed);
//     }
// }
