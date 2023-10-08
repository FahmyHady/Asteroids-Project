using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public static class Utility
{
    public static async void LerpPhysicsRotationOverTime(Rigidbody2D rigidbody2D, float targetRot, float duration)
    {
        float elapsed = 0;
        float startRot = rigidbody2D.rotation;
        targetRot = startRot + Mathf.DeltaAngle(startRot, targetRot);

        while (elapsed < Time.fixedDeltaTime)
        {
            elapsed += Time.fixedDeltaTime;
            rigidbody2D.SetRotation(Mathf.Lerp(startRot, targetRot, elapsed / duration));
            await Task.Yield();
        }
    }

    public static Vector3 GetRandomOffScreenPoint()
    {
        Vector3 randomPoint = Vector3.zero;
        randomPoint.z = -Camera.main.transform.position.z;
        if (Random.value > 0.5)
        {
            randomPoint.x = 1;
            randomPoint.y = Random.value;
        }
        else
        {
            randomPoint.y = 1;
            randomPoint.x = Random.value;
        }
        return Camera.main.ViewportToWorldPoint(randomPoint);
    }
    public static IEnumerator DoAfterDelay(float delay, UnityAction toDo)
    {
        yield return new WaitForSeconds(delay);
        toDo?.Invoke();
    }
}
