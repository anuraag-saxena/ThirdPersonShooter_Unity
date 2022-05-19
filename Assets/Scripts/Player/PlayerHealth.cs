using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---------------------2nd Iteration --------------------------------------
// for ragdoll
public class PlayerHealth : Destructable
{
    [SerializeField] Ragdoll ragdoll;
    [SerializeField] GameObject canvas;
    public override void Die()
    {
        base.Die();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        canvas.SetActive(true);
        ragdoll.EnableRagdoll(true);
    }
}



//// -------------------- My Change ------------------------------------------
//// included both parts
//public class PlayerHealth : Destructable
//{
//    [SerializeField] Ragdoll ragdoll;
//    [SerializeField] SpawnPoint[] spawnPoints;

//    void SpawnAtNewSpawnPoint()
//    {
//        int spawnIndex = Random.Range(0, spawnPoints.Length);
//        transform.position = spawnPoints[spawnIndex].transform.position;
//        transform.rotation = spawnPoints[spawnIndex].transform.rotation;
//    }

//    public override void Die()
//    {
//        base.Die();
//        ragdoll.EnableRagdoll(true);

//        SpawnAtNewSpawnPoint();
//    }
//}




// --------------------- 1st Iteration --------------------------------------
// for spawning will work for enemies
//public class PlayerHealth : Destructable
//{
//    [SerializeField] SpawnPoint[] spawnPoints;

//    void SpawnAtNewSpawnPoint() {
//        int spawnIndex = Random.Range(0, spawnPoints.Length);
//        transform.position = spawnPoints[spawnIndex].transform.position;
//        transform.rotation = spawnPoints[spawnIndex].transform.rotation;
//    }

//    public override void Die() {
//        base.Die();
//        SpawnAtNewSpawnPoint();
//    }

//    [ContextMenu("Test Die!")]
//    void TestDie() {
//        Die();
//    }
//}
