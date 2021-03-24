using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Image))]
public class StarAnimator : MonoBehaviour
{
    Animator animator;
    Image image;
    [SerializeField]
    private Sprite ActiveStar;
    [SerializeField]
    private Sprite InactiveStar;

    void Start()
    {
        animator = GetComponent<Animator>();
        image = GetComponent<Image>();
    }

    public void PlayDisableAnimation()
    {
        this.animator.Play("RedStar");
    }

    public void ChangeSpriteToInactive()
    {
        this.image.sprite = InactiveStar;
    }

    public void ChangeSpriteToActive()
    {
        this.image.sprite = ActiveStar;
    }
}
