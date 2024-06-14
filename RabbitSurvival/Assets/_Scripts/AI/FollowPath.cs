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
        Short, // резкий поворот
        Smoothly // плавный поворот
    }

    public MovementType type = MovementType.Moveing; // вид движения
    public RotateType rotateType = RotateType.Smoothly;
    public MovementPath path; // используемый путь
    public float speed = 1f; // скорость движения
    public float rotateSpeed = 1f; // скорость поворота
    public float maxDistance = .1f; // на какое расстояние должен подъехать объект, чтобы понять что это точка

    private IEnumerator<Transform> pointInPath; // проверка точек

    private void Start()
    {
        if(path == null) // проверка прикрепили ли путь
        {
            Debug.Log("Прикрепи путь!");
            return;
        }

        pointInPath = path.GetNextPathPoint(); // обращение к корутине в классе MovementPath
        pointInPath.MoveNext(); // получение следующей точки в пути

        if(pointInPath.Current == null ) // есть ли точка к которой передвигаться
        {
            Debug.Log("Нужны точки!");
            return;
        }

        transform.position = pointInPath.Current.position; // объект должен встать на стартовую точку пути
    }

    private void Update()
    {
        if(pointInPath == null || pointInPath.Current == null) // проверка отсутствия пути
        {
            return; // выход, потому что пути нет
        }

        if(type == MovementType.Moveing) // если выбран плавный вид движения
        {
            transform.position = Vector3.MoveTowards(transform.position, pointInPath.Current.position, Time.deltaTime * speed); // двигать объект к следующей точке

            RotateToPoint(rotateType);            
        }
        else if(type == MovementType.Lerping)
        {
            transform.position = Vector3.Lerp(transform.position, pointInPath.Current.position, Time.deltaTime * speed);

            RotateToPoint(rotateType);
        }

        var distanceSqure = (transform.position - pointInPath.Current.position).sqrMagnitude; // проверяем, достаточно ли близко к точке, чтобы начать следовать к другой точке
        if(distanceSqure < maxDistance * maxDistance) // достаточно ли мы близко, если да...
        {
            pointInPath.MoveNext(); // то двигаем к следующей точке
        }
    }
    private void RotateToPoint(RotateType type)
    {
        // резкий поворот в сторону точки
        if (type == RotateType.Short)
        {
            var dir = (pointInPath.Current.position - transform.position).normalized;
            dir.y = transform.position.y;
            transform.rotation = Quaternion.LookRotation(dir);
        }

        // плавный поворот в сторону точки
        else if (type == RotateType.Smoothly)
        {
            var dir = (pointInPath.Current.position - transform.position).normalized;
            dir.y = transform.position.y;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(dir), rotateSpeed);
        }
    }
}
