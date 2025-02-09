﻿using System;
using Masini;
using Clienti;
using Tranzactii;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace NivelAccesDate
{
    //clasa AdministrareStudenti_FisierText implementeaza interfata IStocareData
    public class AdministrareMasini_FisierText : IStocareDate
    {
        string NumeFisier { get; set; }

        public AdministrareMasini_FisierText (string numeFisier)
        {
            this.NumeFisier = numeFisier;
            Stream sFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            sFisierText.Close();
        }
        public void SaveMasini(ListaMasini lista)
        {
            try
            {
                Stream sFisierText = File.Open(NumeFisier, FileMode.Create);
                sFisierText.Close();
                List<masina> l = lista.show();
                //instructiunea 'using' va apela la final swFisierText.Close();
                //al doilea parametru setat la 'true' al constructorului StreamWriter indica modul 'append' de deschidere al fisierului
                foreach(masina m in l)
                {
                    using (StreamWriter swFisierText = new StreamWriter(NumeFisier, true))
                    {
                        swFisierText.WriteLine(m.scriere_inFisier());
                    }
                }
            }
            catch (IOException eIO)
            {
                throw new Exception("Eroare la deschiderea fisierului. Mesaj: " + eIO.Message);
            }
            catch (Exception eGen)
            {
                throw new Exception("Eroare generica. Mesaj: " + eGen.Message);
            }
        }

        public ListaMasini GetMasini()
        {
            ListaMasini masini_dinFisier = new ListaMasini();
            try
            {
                // instructiunea 'using' va apela sr.Close()
                using (StreamReader sr = new StreamReader(NumeFisier))
                {
                    string line;

                    //citeste cate o linie si creaza un obiect de tip Student pe baza datelor din linia citita
                    while ((line = sr.ReadLine()) != null)
                    {
                        masina masinaDinFisier = new masina(line);
                        masini_dinFisier.addFile(masinaDinFisier);
                    }
                }
            }
            catch (IOException eIO)
            {
                throw new Exception("Eroare la deschiderea fisierului. Mesaj: " + eIO.Message);
            }
            catch (Exception eGen)
            {
                throw new Exception("Eroare generica. Mesaj: " + eGen.Message);
            }

            return masini_dinFisier;
        }
        public ListaClienti GetClienti()
        {
            throw new Exception("Optiunea GetMasini nu este implementata");
        }
        public void SaveClienti(ListaClienti lista)
        {
            throw new Exception("Optiunea SaveMasini nu este implementata");
        }
        public ListaTranzactii GetTranzactii(ListaMasini masini, ListaClienti clienti)
        {
            throw new Exception("Optiunea GetMasini nu este implementata");
        }
        public void SaveTranzactii(ListaTranzactii lista)
        {
            throw new Exception("Optiunea SaveMasini nu este implementata");
        }
    }
}
