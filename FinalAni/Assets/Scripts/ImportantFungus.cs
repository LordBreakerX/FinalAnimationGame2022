using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class ImportantFungus : MonoBehaviour
{

    playerControllerScript pcs;
    playerHealth ph;
    bool ranCollected;
    public Flowchart Fc;
    

    private void Update()
    {
        if (ph.collectedRubies > 0 && !ranCollected)
        {
            Fc.SetBooleanVariable("FirstCollect", true);
            ranCollected = true;
        }

        if (pcs.canSpikeNar)
        {
            Fc.SetBooleanVariable("SpikeNar", true);
            pcs.canSpikeNar = false;
        }

        if (pcs.canElevNar)
        {
            Fc.SetBooleanVariable("ElevNar", true);
            pcs.canElevNar = false;
        }

        if (pcs.canExNar)
        {
            Fc.SetBooleanVariable("ExNar", true);
            pcs.canExNar = false;
        }

        if (pcs.canDesNar)
        {
            Fc.SetBooleanVariable("DesNar", true);
            pcs.canDesNar = false;
        }

        if (pcs.canPorNar)
        {
            Fc.SetBooleanVariable("PorNar", true);
            pcs.canPorNar = false;
        }
    }

    private void Start()
    {
        pcs = GameObject.FindGameObjectWithTag("Player").GetComponent<playerControllerScript>();
        ph = GameObject.FindGameObjectWithTag("Player").GetComponent<playerHealth>();
    }

    public void StopWalk()
    {
        pcs.canMove = false;
    }

    public void StartWalk()
    {
        pcs.canMove = true;
    }

}
