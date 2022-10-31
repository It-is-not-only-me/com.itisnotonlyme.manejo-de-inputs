using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Evento generico", menuName = "Manejo de inputs/Eventos/Evento generico")]
public class EventoVector2 : ScriptableObject
{
    public event Action<Vector2> EventoActual;

    public void Invoke(Vector2 tipo) => EventoActual.Invoke(tipo);
}