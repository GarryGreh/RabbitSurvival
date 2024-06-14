using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPath : MonoBehaviour
{
    public enum PathTypes // вид пути: линейный или зацикленный
    {
        liner,
        loop
    }
    public PathTypes pathType; // определяет вид пути
    public int movementDirection = 1; // направление пути: 1 вперёд, -1 назад
    public int movingTo; // к какой точке двигаться
    public Transform[] PathElements; // массив точек

    public void OnDrawGizmos() // отображает линии пути
    {
        if(PathElements == null || PathElements.Length < 2) // проверяет есть ли хотя бы 2 точки пути
        {
            return;
        }
        for(var i = 1; i < PathElements.Length; i++) // прогоняет все точки массива
        {
            Gizmos.DrawLine(PathElements[i - 1].position, PathElements[i].position); // рисует линии между ними
        }
        if(pathType == PathTypes.loop) // если путь зацикленный
        {
            Gizmos.DrawLine(PathElements[0].position, PathElements[PathElements.Length - 1].position); // нарисовать точку от последней к первой точке
        }
    }

    public IEnumerator<Transform> GetNextPathPoint() // получает положение следующей точки
    {
        if(PathElements == null || PathElements.Length < 1) // проверяет, есть ли точки которым нужно проверить положение
        {
            yield break; // если нет - выход из корутины
        }
        while (true)
        {
            yield return PathElements[movingTo]; // возвращает текущее положкение точки

            if(PathElements.Length == 1) // если точка всего одна - выйти
            {
                continue;
            }
            if(pathType == PathTypes.liner) // если линия не зациклена
            {
                if(movingTo <= 0) // если двигаемся по нарастающей
                {
                    movementDirection = 1; // добавляем один к движению
                }
                else if(movingTo >= PathElements.Length - 1) // если двигаемся по убывающей
                {
                    movementDirection = -1; // убираем один из движения
                }
            }

            movingTo = movingTo + movementDirection; // диапазон движение от 1 до -1

            if (pathType == PathTypes.loop) // если линия зацклена
            {
                if(movingTo >= PathElements.Length) // если мы дошли до последней точки
                {
                    movingTo = 0; // то надо идти к первой точке, напрямую
                }
                if(movingTo < 0) // если мы дошли до первой точки, двигаясь в обратную сторону
                {
                    movingTo = PathElements.Length - 1; // то надо двинуть к последней точке
                }
            }
        }
    }
}
