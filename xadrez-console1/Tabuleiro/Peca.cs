﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tabuleiro
{
    class Peca
    {
    public Posicao posicao { get; set; }
    public Cor cor { get; set; }
    public int qtdeMovimentos { get; protected set; }
    public Tabuleiro tab { get; protected set; }
    public Peca(Tabuleiro tab, Cor cor)
        {
            this.posicao = null;
            this.tab = tab;
            this.cor = cor;
            this.qtdeMovimentos = 0;
        }
    }
}
