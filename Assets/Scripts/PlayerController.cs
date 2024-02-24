using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{

    private Animator animator;
    [SerializeField] private Button Select_Dance_1;
    [SerializeField] private Button Select_Dance_2;
    [SerializeField] private Button Select_Dance_3;
    [SerializeField] private Button Accept;
    void Start()
    {
        GameObject player = GameObject.Find("player");

          animator = player.GetComponent<Animator>();
    }

    public void Dance_1_Selected()
    {
        
        if (animator != null)
        {
            animator.SetBool("b_House_Dance", false);
            animator.SetBool("b_HipHop_Dance", true);
            animator.SetBool("b_Macarena_Dance", false);
            
        }
    }
   public void Dance_2_Selected()
    { 
        if (animator != null)
        {
            animator.SetBool("b_House_Dance", false);
            animator.SetBool("b_HipHop_Dance", false);
            animator.SetBool("b_Macarena_Dance", true);
            
        }
    }
    public void Dance_3_Selected()
    {
        if (animator != null)
        {
            animator.SetBool("b_House_Dance", true);
            animator.SetBool("b_HipHop_Dance", false);
            animator.SetBool("b_Macarena_Dance", false);
        }
         
    }

    public void AcceptChanges()
    {
         SceneManager.LoadScene("Shooting");
    }

}
