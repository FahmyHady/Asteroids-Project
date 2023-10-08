using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class DefaultShipDeathBehaviour : IDieBehaviour
{

    ShipHealthComponent shipHealthComponent;
    public DefaultShipDeathBehaviour(ShipHealthComponent shipHealthComponent)
    {

        this.shipHealthComponent = shipHealthComponent;
    }

    public async void Die()
    {

        if (shipHealthComponent.NumberOfLives > 0)
        {
            Kill();
            SimplifiedEventManager.PlayerDeath.Invoke(shipHealthComponent.NumberOfLives);
            await Task.Delay(2000);
            shipHealthComponent.Reset();
            shipHealthComponent.StartCoroutine(GiveInvulerability(shipHealthComponent.InvulnerabilityDurationOnDeath));
            shipHealthComponent.ShipRB.simulated = true;
        }
        else
        {
            Kill();
            await Task.Delay(2000);
            Time.timeScale = 0;
            SimplifiedEventManager.PlayerDeath.Invoke(shipHealthComponent.NumberOfLives);
        }

    }
    void Kill()
    {
        shipHealthComponent.ShipRB.simulated = false;
        shipHealthComponent.NumberOfLives--;
        shipHealthComponent.Ship3DModel.SetActive(false);
        GameObject.Instantiate(shipHealthComponent.DeathVFX, shipHealthComponent.transform.position, Quaternion.identity);
    }
    IEnumerator GiveInvulerability(float duration)
    {
        float elapsed = 0;
        float flashFrequency = 0.1f;
        float nextFlashTimeStamp = Time.time + flashFrequency;
        shipHealthComponent.Invulnerable = true;
        ToggleColliders(false);
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;

            if (Time.time > nextFlashTimeStamp)
            {
                shipHealthComponent.Ship3DModel.SetActive(true);
                yield return new WaitForSeconds(flashFrequency);
                shipHealthComponent.Ship3DModel.SetActive(false);
                elapsed += flashFrequency;
                nextFlashTimeStamp = Time.time + flashFrequency;
            }
            yield return null;
        }
        shipHealthComponent.Ship3DModel.SetActive(true);
        shipHealthComponent.Invulnerable = false;
        ToggleColliders(true);

    }
    void ToggleColliders(bool flag)
    {
        foreach (var collider in shipHealthComponent.PhysicsColliders)
        {
            collider.enabled = flag;
        }
    }
}