using System;
using System.Collections.Generic;
using DIO.Series.Interfaces;

namespace DIO.Series.classes
{
    public class FilmeRepositorio : IRepositorio<Filme>
    {
        private List<Filme> listaFilme = new List<Filme>();

        //Lista filme recomendados ao usuario.
        private List<Filme> filmeIndicacoes = new List<Filme>();

        //Declarando os filmes recomendados.
        private Filme OsIntocaveis = new Filme(0, (Genero) 5, "Os Intocaveis", "Philippe (François Cluzet), um refinado multimilionário tetraplégico francês, precisa de um auxiliar de enfermagem para o apoiar nas suas atividades rotineiras. Um senegalês radicado nos subúrbios de Paris, que não tem qualquer formação para tal se candidata para o cargo. O então contratado Driss (Omar Sy), com seus métodos nada ortodoxos faz Philippe ter prazer pela vida novamente.", 2011);

        private Filme BuscaImplacavel = new Filme(1, (Genero)12, "Busca Implacável", "Agente do governo deixa o emprego para passar mais tempo com a filha que teve com sua ex-mulher. Para sobreviver, começa a trabalhar como segurança particular. Quando sua filha lhe pede autorização para viajar a Paris com uma amiga, ele nega, mas ela desobedece a proibição, e logo ambas desaparecem.", 2008);

        //Insere os filmes na lista filmeIndicacoes
        public void InserirFilmeRecomendado()
        {
            filmeIndicacoes.Add(OsIntocaveis);
            filmeIndicacoes.Add(BuscaImplacavel);
        }

        //Retorna os filmes recomendados.
        public Filme RetornaRecomendado(int id)
        {
            return filmeIndicacoes[id];
        }

        public void Atualiza(int id, Filme objeto)
        {
            listaFilme[id] = objeto;
        }

        public void Exclui(int id)
        {
            listaFilme[id].Excluir();
        }

        public void Insere(Filme objeto)
        {
            listaFilme.Add(objeto);
        }

        public List<Filme> Lista()
        {
            return listaFilme;
        }

        public int ProximoId()
        {
            return listaFilme.Count;
        }

        public Filme RetornaPorId(int id)
        {
            return listaFilme[id];
        }
    }
}
