using System.Collections.Generic;
using UnityEngine;

namespace ItIsNotOnlyMe.ManejoDeInputs
{
    [CreateAssetMenu(fileName = "Manejo de inputs", menuName = "Manejo de inputs/Manejo de inputs")]
    public class MenejoDeInputs : ScriptableObject
    {
        [System.Serializable]
        private struct Intercambio
        {
            public EventoActivacion EventoIntercambio;
            public InputSO GrupoInput;
        }

        [SerializeField] private List<Intercambio> _intercambios = new List<Intercambio>();
        private List<Intercambio> _intercambiosHechos = new List<Intercambio>();

        private Dictionary<int, InputSO> _inputsIntercambiables = new Dictionary<int, InputSO>();


        private void OnEnable()
        {
            foreach (Intercambio intercambio in _intercambios)
            {
                if (intercambio.EventoIntercambio == null || intercambio.GrupoInput == null)
                    continue;

                int identificacion = intercambio.EventoIntercambio.Id();
                _inputsIntercambiables[identificacion] = intercambio.GrupoInput;

                intercambio.EventoIntercambio.EventoActual += LlamarNuevoInput;
                _intercambiosHechos.Add(intercambio);
            }
        }

        private void OnDisable()
        {
            foreach (Intercambio intercambio in _intercambiosHechos)
            {
                intercambio.EventoIntercambio.EventoActual -= LlamarNuevoInput;
            }

            _intercambiosHechos.Clear();
            _inputsIntercambiables.Clear();
        }

        private void LlamarNuevoInput(int identificacion, bool activar)
        {
            if (!_inputsIntercambiables.ContainsKey(identificacion))
                return;

            InputSO grupoInput = _inputsIntercambiables[identificacion];

            if (activar)
                grupoInput.Activar();
            else
                grupoInput.Desactivar();
        }
    }
}
