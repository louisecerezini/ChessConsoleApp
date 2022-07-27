using System;
using Tabuleiro;

namespace xadrez
{
    class Rei : Peca
    {
        private PartidaDeXadrez partida;

        public Rei(Tabuleiro.Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(tab, cor)
        {
            this.partida = partida;
        }
        public override string ToString()
        {
            return "R";
        }

        private bool podeMover(Posicao pos) {
            Peca p = tab.peca(pos);
            return p == null || p.cor != this.cor;
        }

        private bool testeTorreParaRoque(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p != null && p is Torre && p.cor == cor && p.qtdeMovimentos == 0; 
        }
        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.Linhas, tab.Colunas];

            Posicao pos = new Posicao(0, 0);

            // acima da posicao do rei 1 linha a menos - Marcar as 8 posiveis casas para onde o Rei pode mover 
            // Feito isso simplesmente retorno a matriz para onde o Rei pode mover. 

            pos.definirValores(posicao.linha - 1, posicao.coluna);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha,pos.coluna] = true;   
            }

            // nordeste linha -1 coluna +1 
            pos.definirValores(posicao.linha - 1, posicao.coluna +1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            // direita linha -1 coluna +1 
            pos.definirValores(posicao.linha, posicao.coluna + 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            // Sudeste linha +1 coluna +1 
            pos.definirValores(posicao.linha +1, posicao.coluna + 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            // abaixo linha +1 e mesma coluna 
            pos.definirValores(posicao.linha +1, posicao.coluna);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            // Sudoeste linha +1 coluna -1 
            pos.definirValores(posicao.linha +1, posicao.coluna - 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            // Esquerda mesma linha e coluna -1 
            pos.definirValores(posicao.linha, posicao.coluna - 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            // Noroeste linha -1 coluna -1 
            pos.definirValores(posicao.linha -1, posicao.coluna - 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            // #jogada especial roque 
            if(qtdeMovimentos == 0 && !partida.xeque )
            {
                //jogadaespecial roque pequeno 
                Posicao posT1 = new Posicao(posicao.linha, posicao.coluna + 3);
                if (testeTorreParaRoque(posT1)) {
                    Posicao p1 = new Posicao(posicao.linha, posicao.coluna + 1);
                    Posicao p2 = new Posicao(posicao.linha, posicao.coluna + 2);
                    if (tab.peca(p1)==null && tab.peca(p2)==null) {
                        mat[posicao.linha, posicao.coluna + 2] = true;
                    } 
                }
                
                    //jogadaespecial roque Grande 
                    Posicao posT2 = new Posicao(posicao.linha, posicao.coluna -4);
                    if (testeTorreParaRoque(posT2))
                    {
                        Posicao p1 = new Posicao(posicao.linha, posicao.coluna - 1);
                        Posicao p2 = new Posicao(posicao.linha, posicao.coluna - 2);
                        Posicao p3 = new Posicao(posicao.linha, posicao.coluna - 3);
                    if (tab.peca(p1) == null && tab.peca(p2) == null && tab.peca(p3) ==null)
                        {
                            mat[posicao.linha, posicao.coluna - 2] = true;
                        }
                    }
                }
            return mat;
        }

            

        }
    }


