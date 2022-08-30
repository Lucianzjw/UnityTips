using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Laser : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    [SerializeField] private GameObject[] _endPointGroup = null;

    float time = 0;
    float maxTime = 1;
    Vector3 result = new Vector3();
    List<Vector3> resultList = new List<Vector3>();


    // 设置贝塞尔插值个数
    private int _segmentNum = 50;

    private void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        DrawThreePowerCurve();
        //DrawBezierCurve();
        //DrawLaser(transform.position, _endPoint.transform.position);
    }

    Vector3[] points3;

    void DrawThreePowerCurve()
    {
        // 获取三次贝塞尔方程曲线
        points3 = Bezier.GetThreePowerBeizerList(_endPointGroup[0].transform.position,
            _endPointGroup[1].transform.position, _endPointGroup[2].transform.position,
            _endPointGroup[3].transform.position, _segmentNum);
        // 设置 LineRenderer 的点个数，并赋值点值
        _lineRenderer.positionCount = (_segmentNum);
        _lineRenderer.SetPositions(points3);

    }

    /// <summary>
    /// 画一条两点直接的射线
    /// </summary>
    /// <param name="startPoint">起始点</param>
    /// <param name="endPoint">结束点</param>
    void DrawLaser(Vector3 startPos, Vector3 endPos)
    {
        //Laser startposition
        _lineRenderer.SetPosition(0, startPos);
        //Laser endposition
        _lineRenderer.SetPosition(1, endPos);
    }

    /// <summary>
    /// 画三阶贝塞尔曲线
    /// 一阶贝塞尔曲线：B(t) = (1 - t) * _checkpointGroup[0] + t*p1，t ∈[0, 1]；
    /// 二阶贝塞尔曲线：B(t) = (1 - t)^2_checkpointGroup[0] + 2t(1 - t)p1 + t^2_checkpointGroup[3]，t∈ [0, 1]；
    /// 三阶贝塞尔曲线：B(t) = _checkpointGroup[0](1 - t)^3 + 3P1t(1 - t)^2 + 3_checkpointGroup[3]t^2(1 - t) + p3t^3，t∈[0, 1]；
    /// </summary>
    void DrawBezierCurve()
    {
        /*
        Debug.Log(11111);
        float timeLerp = Mathf.Lerp(0, 1, time / maxTime);
        result.x = Mathf.Pow(1 - timeLerp, 3) * _checkpointGroup[0].x + 
                   3 * timeLerp * Mathf.Pow(1 - timeLerp, 2) * _checkpointGroup[1].x +
                   3 * (1 - timeLerp) * Mathf.Pow(timeLerp, 2) * _checkpointGroup[2].x +
                   Mathf.Pow(timeLerp, 3) * _checkpointGroup[3].x;
        result.y = Mathf.Pow(1 - timeLerp, 3) * _checkpointGroup[0].y + 
                   3 * timeLerp * Mathf.Pow(1 - timeLerp, 2) * _checkpointGroup[1].y +
                   3 * (1 - timeLerp) * Mathf.Pow(timeLerp, 2) * _checkpointGroup[2].y +
                   Mathf.Pow(timeLerp, 3) * _checkpointGroup[3].y;
        result.z = Mathf.Pow(1 - timeLerp, 3) * _checkpointGroup[0].z + 
                   3 * timeLerp * Mathf.Pow(1 - timeLerp, 2) * _checkpointGroup[1].z +
                   3 * (1 - timeLerp) * Mathf.Pow(timeLerp, 2) * _checkpointGroup[2].z +
                   Mathf.Pow(timeLerp, 3) * _checkpointGroup[3].z;
        resultList.Add(result);
        time += Time.deltaTime;
        
        _lineRenderer.positionCount = resultList.ToArray ().Length;
        if (_lineRenderer.positionCount >= 2) 
        {
            _lineRenderer.SetPositions(resultList.ToArray ()); 
        }
    }
    */
    }
}