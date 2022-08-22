using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;
using NavMeshBuilder = UnityEngine.AI.NavMeshBuilder;

// Build and update a localized navmesh from the sources marked by NavMeshSourceTag
[DefaultExecutionOrder(-102)]
public class LocalNavMeshBuilder : MonoBehaviour
{
    // The center of the build
    public Transform m_Tracked;

    // The size of the build bounds
    public Vector3 m_Size = new Vector3(80.0f, 20.0f, 80.0f);

    NavMeshData m_NavMesh;
    AsyncOperation m_Operation;
    NavMeshDataInstance m_Instance;

    /// 네비 메시 빌드에 쓰일 Source
    List<NavMeshBuildSource> m_Sources = new List<NavMeshBuildSource>();

    /// <summary>
    /// 시작과 함께 비동기로 네비메시를 계속 업데이트해준다.
    /// </summary>
    /// <returns></returns>
    IEnumerator Start()
    {
        while (true)
        {
            UpdateNavMesh(true);
            yield return m_Operation;
        }
    }

    void OnEnable()
    {
        // Construct and add navmesh
        m_NavMesh = new NavMeshData();
        m_Instance = NavMesh.AddNavMeshData(m_NavMesh);
        if (m_Tracked == null)
            m_Tracked = transform;
        UpdateNavMesh(false);
    }

    void OnDisable()
    {
        // Unload navmesh and clear handle
        m_Instance.Remove();
    }

    /// <summary>
    /// 네비 메시를 동기/비동기로 업데이트한다.
    /// </summary>
    /// <param name="asyncUpdate">비동기 업데이트를 사용할 지 여부</param>
    void UpdateNavMesh(bool asyncUpdate = false)
    {
        NavMeshSourceTag.Collect(ref m_Sources);
        var defaultBuildSettings = NavMesh.GetSettingsByID(0);
        var bounds = QuantizedBounds();

        if (asyncUpdate)
        {
            // 비동기로 네비메시를 업데이트한다.
            m_Operation = NavMeshBuilder.UpdateNavMeshDataAsync(m_NavMesh, defaultBuildSettings, m_Sources, bounds);
        }
        else
        {
            // 해당 프레임에 즉시 네비메시를 업데이트한다.
            NavMeshBuilder.UpdateNavMeshData(m_NavMesh, defaultBuildSettings, m_Sources, bounds);
        }
    }

    /// <summary>
    /// 바운드를 구하기 위한 함수
    /// </summary>
    /// <param name="v"></param>
    /// <param name="quant"></param>
    /// <returns></returns>
    static Vector3 Quantize(Vector3 v, Vector3 quant)
    {
        float x = quant.x * Mathf.Floor(v.x / quant.x);
        float y = quant.y * Mathf.Floor(v.y / quant.y);
        float z = quant.z * Mathf.Floor(v.z / quant.z);
        return new Vector3(x, y, z);
    }

    /// <summary>
    /// 네비메시 빌더의 바운드를 구한다.
    /// </summary>
    /// <returns></returns>
    Bounds QuantizedBounds()
    {
        // Quantize the bounds to update only when theres a 10% change in size
        var center = m_Tracked ? m_Tracked.position : transform.position;
        return new Bounds(Quantize(center, 0.1f * m_Size), m_Size);
    }

    /// <summary>
    /// NavMesh 빌더의 바운드 영역을 그려준다.
    /// </summary>
    void OnDrawGizmosSelected()
    {
        if (m_NavMesh)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(m_NavMesh.sourceBounds.center, m_NavMesh.sourceBounds.size);
        }

        Gizmos.color = Color.yellow;
        var bounds = QuantizedBounds();
        Gizmos.DrawWireCube(bounds.center, bounds.size);

        Gizmos.color = Color.green;
        var center = m_Tracked ? m_Tracked.position : transform.position;
        Gizmos.DrawWireCube(center, m_Size);
    }
}