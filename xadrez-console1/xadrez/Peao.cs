using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tabuleiro;
using xadrez;

namespace xadrez
{
    internal class Peao : Peca
    {
        private PartidaDeXadrez partida;
        public Peao(Tabuleiro.Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(tab, cor)
        {
            this.partida = partida;
        }
        public override string ToString()
        {
            return "P";
        }

        private bool existeInimigos(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p != null && p.cor != cor;
        }
        private bool livre(Posicao pos)
        {
            return tab.peca(pos) == null;
        }
        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.Linhas, tab.Colunas];

            Posicao pos = new Posicao(0, 0);

            if (cor == Cor.Branca)
            {
                pos.definirValores(posicao.linha - 1, posicao.coluna);
                if (tab.posicaoValida(pos) && livre(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.definirValores(posicao.linha - 2, posicao.coluna);
                if (tab.posicaoValida(pos) && livre(pos) && qtdeMovimentos == 0)
                {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.definirValores(posicao.linha - 1, posicao.coluna - 1);
                if (tab.posicaoValida(pos) && existeInimigos(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.definirValores(posicao.linha - 1, posicao.coluna + 1);
                if (tab.posicaoValida(pos) && existeInimigos(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }

                // #jogadaespecial en passant 
                if (posicao.linha == 3)
                {
                    Posicao esquerda = new Posicao(posicao.linha, posicao.coluna - 1);
                    if (tab.posicaoValida(esquerda) && existeInimigos(esquerda) && tab.peca(esquerda) == partida.vulneravelEnPassant)
                    {
                        {
                            mat[esquerda.linha, esquerda.coluna] = true;
                        }

                        // #jogadaespecial en passant 
                        if (posicao.linha == 3)
                        {
                            Posicao direita = new Posicao(posicao.linha, posicao.coluna + 1);
                            if (tab.posicaoValida(direita) && existeInimigos(direita) && tab.peca(direita) == partida.vulneravelEnPassant)
                            {
                                {
                                    mat[direita.linha -1, direita.coluna] = true;
                                }


                            }
                            else
                            {
                                pos.definirValores(posicao.linha + 1, posicao.coluna);
                                if (tab.posicaoValida(pos) && livre(pos))
                                {
                                    mat[pos.linha, pos.coluna] = true;
                                }
                                pos.definirValores(posicao.linha + 1, posicao.coluna - 1);
                                if (tab.posicaoValida(pos) && livre(pos) && existeInimigos(pos))
                                {
                                    mat[pos.linha, pos.coluna] = true;
                                }
                                pos.definirValores(posicao.linha + 1, posicao.coluna + 1);
                                if (tab.posicaoValida(pos) && livre(pos) && qtdeMovimentos == 0)
                                {
                                    mat[pos.linha, pos.coluna] = true;
                                }
                            }
                            // #jogadaespecial en passant 
                            if (posicao.linha == 4)
                            {
                                esquerda = new Posicao(posicao.linha, posicao.coluna - 1);
                                if (tab.posicaoValida(esquerda) && existeInimigos(esquerda) && tab.peca(esquerda) == partida.vulneravelEnPassant)
                                {
                                    {
                                        mat[esquerda.linha +1, esquerda.coluna] = true;
                                    }

                                    // #jogadaespecial en passant 
                                    if (posicao.linha == 3)
                                    {
                                        direita = new Posicao(posicao.linha, posicao.coluna +1);
                                        if (tab.posicaoValida(direita) && existeInimigos(direita) && tab.peca(direita) == partida.vulneravelEnPassant)
                                        {
                                            {
                                                mat[direita.linha +1, direita.coluna] = true;
                                            }




                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return mat;
        }
    }
}
















