using System;
using System.Collection.Generic;
using DIO.Musicas.Interfaces;

namespace DIO.Musicas
{
    public class MusicaRepositorio : IRepositório<Musicas>
    {
        private List<Musicas> listaMusicas = new List<Musicas>();
        public void Atualiza(int id, Musicas objeto)
        {
            listaMusicas[id] = objeto;
        }

        public void Exclui(int id)
        {
            listaMusicas[id].Excluir();
        }

        public void Insere(Musicas objeto)
        {
            listaMusicas.Add(objeto);
        }

        public List<Musicas> Lista()
        {
            return listaMusicas;
        }

        public int ProximoId()
        {
            return listaMusicas.Count;
        }

        public Musicas RetornaPorId(int id)
        {
            return listaMusicas[id];
        }
    }
}