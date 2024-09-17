using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ParticleObserver
{
    public static Action<Vector3> ParticleSpawnEvent;

    public static void onParticleSpawnEvent(Vector3 obj)
    {
        ParticleSpawnEvent?.Invoke(obj);
    }

}
