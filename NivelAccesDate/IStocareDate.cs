﻿using Masini;
using Clienti;
using System;
using System.Collections.Generic;
using System.Text;

namespace NivelAccesDate
{
    public interface IStocareDate
    {
        void SaveMasini(ListaMasini lista);
        public ListaMasini GetMasini();
        void SaveClienti(ListaClienti lista);
        public ListaClienti GetClienti();

    }
}
