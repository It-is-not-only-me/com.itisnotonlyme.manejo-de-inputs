using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Evento generico", menuName = "Eventos/Evento generico")]
public class Evento<TTipo> : ScriptableObject
{
    public event Action<TTipo> EventoActual;

    public void Invoke(TTipo tipo) => EventoActual.Invoke(tipo);
}

