using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class FollowPath : MonoBehaviour
{
    public enum MovementType
    {
        Moveing,
        Lerping
    }
    public enum RotateType
    {
        Short, // ������ �������
        Smoothly // ������� �������
    }

    public MovementType type = MovementType.Moveing; // ��� ��������
    public RotateType rotateType = RotateType.Smoothly;
    public MovementPath path; // ������������ ����
    public float speed = 1f; // �������� ��������
    public float rotateSpeed = 1f; // �������� ��������
    public float maxDistance = .1f; // �� ����� ���������� ������ ��������� ������, ����� ������ ��� ��� �����

    private IEnumerator<Transform> pointInPath; // �������� �����

    private void Start()
    {
        if(path == null) // �������� ���������� �� ����
        {
            Debug.Log("�������� ����!");
            return;
        }

        pointInPath = path.GetNextPathPoint(); // ��������� � �������� � ������ MovementPath
        pointInPath.MoveNext(); // ��������� ��������� ����� � ����

        if(pointInPath.Current == null ) // ���� �� ����� � ������� �������������
        {
            Debug.Log("����� �����!");
            return;
        }

        transform.position = pointInPath.Current.position; // ������ ������ ������ �� ��������� ����� ����
    }

    private void Update()
    {
        if(pointInPath == null || pointInPath.Current == null) // �������� ���������� ����
        {
            return; // �����, ������ ��� ���� ���
        }

        if(type == MovementType.Moveing) // ���� ������ ������� ��� ��������
        {
            transform.position = Vector3.MoveTowards(transform.position, pointInPath.Current.position, Time.deltaTime * speed); // ������� ������ � ��������� �����

            RotateToPoint(rotateType);            
        }
        else if(type == MovementType.Lerping)
        {
            transform.position = Vector3.Lerp(transform.position, pointInPath.Current.position, Time.deltaTime * speed);

            RotateToPoint(rotateType);
        }

        var distanceSqure = (transform.position - pointInPath.Current.position).sqrMagnitude; // ���������, ���������� �� ������ � �����, ����� ������ ��������� � ������ �����
        if(distanceSqure < maxDistance * maxDistance) // ���������� �� �� ������, ���� ��...
        {
            pointInPath.MoveNext(); // �� ������� � ��������� �����
        }
    }
    private void RotateToPoint(RotateType type)
    {
        // ������ ������� � ������� �����
        if (type == RotateType.Short)
        {
            var dir = (pointInPath.Current.position - transform.position).normalized;
            dir.y = transform.position.y;
            transform.rotation = Quaternion.LookRotation(dir);
        }

        // ������� ������� � ������� �����
        else if (type == RotateType.Smoothly)
        {
            var dir = (pointInPath.Current.position - transform.position).normalized;
            dir.y = transform.position.y;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(dir), rotateSpeed);
        }
    }
}
