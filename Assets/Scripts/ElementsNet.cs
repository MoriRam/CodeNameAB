﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OculusSampleFramework;
using Mirror;

public class ElementsNet : NetworkBehaviour
{
    [SyncVar] public Elements m_elemType = Elements.Air;
    [SyncVar] public uint m_ownerId;
    public bool m_used = false;

    ColorGrabbable m_grabbable;


    public ColorGrabbable GetColorGrabbable()
    {
        return m_grabbable;
    }


    public override void OnStartClient()
    {
        //GameMan.s_instance.RegisterNewTool2(this, hasAuthority);
    }


    public override void OnStartServer()
    {
        //JowLogger.Log($"{gameObject} OnStartServer @ {Time.fixedTime}s.");
    }


    // Start is called before the first frame update but after OnStartXXX
    void Start()
    {
        m_grabbable = GetComponent<ColorGrabbable>();
        m_used = false;
        //JowLogger.Log($"ElementsNet Start ++++++++++ {m_elemType}, netId {netId}, hasAuthority {hasAuthority}, avatarAuthority {GameMan.s_instance.GetLocalPlayer().hasAuthority}");
        ChangeType(m_elemType, GameMan.s_instance.m_CubesElemMats[(int)m_elemType]);
        PlayerControlMirror localPlr = GameMan.s_instance.GetLocalPlayer();
        if (localPlr.netId == m_ownerId)
        {
            localPlr.m_myElems.Add(this);
            JowLogger.Log($"\t ++++++++++ Add elem to player {localPlr.name}, count {localPlr.m_myElems.Count}");
        }
    }


    public void ChangeType(Elements newType, Material newMat)
    {
        m_elemType = newType;
        Renderer rndr = GetComponent<Renderer>();
        if (rndr)
        {
            rndr.material = newMat;
        }

        //m_grabbable.UpdateColor();
    }


    private void FixedUpdate()
    {
        if (m_grabbable.m_lastGrabbed != 0.0f)
        {
            TriggerElement();
            m_grabbable.m_lastGrabbed = 0.0f;
        }
    }


    // Trigger this element
    public void TriggerElement()
    {
        Vector3 eyePos = GameMan.s_instance.m_cameraRig.transform.position;
        float dist = transform.position.y - eyePos.y;

        if (dist > 1.0f)
        {
            GameMan.s_instance.TriggerElement(this);
            m_used = true;

            StartCoroutine(DelayedFall(3.0f));
        }
    }


    // Remove this object from the scene
    private void OnDestroy()
    {
        Destroy(gameObject);
    }


    // Make it fall after waitSec
    public IEnumerator DelayedFall(float waitSec)
    {
        yield return new WaitForSeconds(waitSec);

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.useGravity = true;
    }
}