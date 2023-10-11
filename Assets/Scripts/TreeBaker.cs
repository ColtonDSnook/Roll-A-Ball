using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class SetTerrainObstacles : Editor
{
    [MenuItem("Custom/Add NavMeshObstacles for Trees")]
    public static void AddNavMeshObstacles()
    {
        Terrain terrain = Terrain.activeTerrain;
        TreeInstance[] Obstacle = terrain.terrainData.treeInstances;
        float width = terrain.terrainData.size.x;
        float length = terrain.terrainData.size.z;
        float height = terrain.terrainData.size.y;

        Debug.Log("Terrain Size is: " + width + ", " + height + ", " + length);

        int i = 0;
        GameObject parent = new GameObject("Tree_Obstacles");

        Debug.Log("Adding " + Obstacle.Length + " NavMeshObstacle Components for Trees");
        foreach (TreeInstance tree in Obstacle)
        {
            Vector3 tempPos = new Vector3(tree.position.x * width, tree.position.y * height, tree.position.z * length);
            Quaternion tempRot = Quaternion.AngleAxis(tree.rotation * Mathf.Rad2Deg, Vector3.up);

            GameObject obs = new GameObject("Obstacle" + i);
            obs.transform.SetParent(parent.transform);
            obs.transform.position = tempPos;
            obs.transform.rotation = tempRot;

            obs.AddComponent<NavMeshObstacle>();
            NavMeshObstacle obsElement = obs.GetComponent<NavMeshObstacle>();
            obsElement.carving = true;
            obsElement.carveOnlyStationary = true;

            if (terrain.terrainData.treePrototypes[tree.prototypeIndex].prefab.GetComponent<Collider>() == null)
            {
                Debug.LogError("ERROR: There is no CapsuleCollider or BoxCollider attached to ''" + terrain.terrainData.treePrototypes[tree.prototypeIndex].prefab.name + "'' please add one of them.");
                break;
            }
            Collider coll = terrain.terrainData.treePrototypes[tree.prototypeIndex].prefab.GetComponent<Collider>();
            if (coll.GetType() == typeof(CapsuleCollider) || coll.GetType() == typeof(BoxCollider))
            {
                if (coll.GetType() == typeof(CapsuleCollider))
                {
                    CapsuleCollider capsuleColl = terrain.terrainData.treePrototypes[tree.prototypeIndex].prefab.GetComponent<CapsuleCollider>();
                    obsElement.shape = NavMeshObstacleShape.Capsule;
                    obsElement.center = capsuleColl.center;
                    obsElement.radius = capsuleColl.radius;
                    obsElement.height = capsuleColl.height;
                }
                else if (coll.GetType() == typeof(BoxCollider))
                {
                    BoxCollider boxColl = terrain.terrainData.treePrototypes[tree.prototypeIndex].prefab.GetComponent<BoxCollider>();
                    obsElement.shape = NavMeshObstacleShape.Box;
                    obsElement.center = boxColl.center;
                    obsElement.size = boxColl.size;
                }
            }
            else
            {
                Debug.LogError("ERROR: There is no CapsuleCollider or BoxCollider attached to ''" + terrain.terrainData.treePrototypes[tree.prototypeIndex].prefab.name + "'' please add one of them.");
                break;
            }

            i++;
        }
        Debug.Log("All " + Obstacle.Length + " NavMeshObstacles were successfully added to your Scene, Hooray!");
    }
}