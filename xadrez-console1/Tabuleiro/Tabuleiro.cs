using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tabuleiro
{
     class Tabuleiro
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }

        private Peca[,] pecas;

        public Tabuleiro(int linhas, int colunas)
        {
            this.Linhas = linhas;
            this.Colunas = colunas;
            pecas = new Peca[linhas, colunas];

        }
        public Peca peca(int linha, int coluna)
        {
            return pecas[linha, coluna];
        } 

        public Peca peca(Posicao pos)
        {
            return pecas[pos.linha,pos.coluna];
        }
        public bool existePeca(Posicao pos)
        {
            validarPosicao(pos);
            return peca(pos) != null;   
        }

        public void colocarPeca(Peca p,Posicao pos)
        {
            if (existePeca(pos))
            {
                throw new TabuleiroException("Ja existe uma peça nessa posicao");
            }
            pecas[pos.linha, pos.coluna] = p;
            p.posicao = pos;
        }
        public bool posicaoValida(Posicao pos)
        {
            if (pos.linha<0 || pos.linha>=Linhas || pos.coluna<0 || pos.coluna >= Colunas) 
            { 
                return false;
            }
            return true;
        }
        public void validarPosicao(Posicao pos)
        {
        if (!posicaoValida(pos))
            {
                throw new TabuleiroException("Posiçao invalida!");

            }
        }
    }
}
