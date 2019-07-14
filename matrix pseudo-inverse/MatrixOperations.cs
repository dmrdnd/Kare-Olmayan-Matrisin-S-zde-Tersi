using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yazlab1._2
{
    class MatrixOperations
    {
       
        double[,] tmatris;
        double[,] t_Carpimmatris;
        double[,] ters_matris;
        double[,] sonuc;
        public int topsayac=0;
        public int carsayac=0;

       
        public double[,] TersMatris(double[,] t_Carpimmatris, int satir,int sutun)
        {

            ters_matris = new double[sutun, sutun];
            for (int i = 0; i < sutun; i++)
            {
                for (int j = 0; j < sutun; j++)
                {
                    if (i == j)
                        ters_matris[i, j] = 1.0;
                    else
                        ters_matris[i, j] = 0.0;
                }
            }
            double d, k;
            for (int i = 0; i < sutun; i++)
            {
                d = t_Carpimmatris[i, i];
                for (int j = 0; j < sutun; j++)
                {
                    t_Carpimmatris[i, j] = t_Carpimmatris[i, j] / d;
                    carsayac++;
                    ters_matris[i, j] = ters_matris[i, j] / d;
                    carsayac++;
                }
                for (int x = 0; x < sutun; x++)
                {
                    if (x != i)
                    {
                        k = t_Carpimmatris[x, i];
                        for (int j = 0; j < sutun; j++)
                        {
                            t_Carpimmatris[x, j] = t_Carpimmatris[x, j] - (t_Carpimmatris[i, j] * k);
                            topsayac++;
                            carsayac++;
                            ters_matris[x, j] = ters_matris[x, j] - (ters_matris[i, j] * k);
                            topsayac++;
                            carsayac++;
                        }
                    }
                }
            }

            return ters_matris;
        }

        public double[,] Tranpose(double[,] matris, int satir, int sutun)
        {
            tmatris = new double[sutun, satir];
            for (int i = 0; i < sutun; i++)
            {
                for (int j = 0; j < satir; j++)
                {
                    tmatris[i, j] = matris[j, i];
                }
            }
            return tmatris;    
        }


    
        public double[,] TransposeTersMultiplic(double[,] ters_matris, double[,] tmatris, int satir,int sutun)
        {
            sonuc = new double[sutun, satir];
            double deger1 = 0;
            for (int i = 0; i < sutun; i++)
            {
                for (int l = 0; l < satir; l++)
                {
                    for (int j = 0; j < sutun; j++)
                    {
                        deger1 += ters_matris[i, j] * tmatris[j, l];
                        topsayac++;
                        carsayac++;
                    }
                    sonuc[i, l] = deger1;
                    deger1 = 0;

                }
            }
            return sonuc;

        }


        public double[,] TransposeMultiplic(double[,] transpose_matris, double[,] matris, int satir, int sutun)
        {
            t_Carpimmatris = new double[sutun, sutun];
            double deger1 = 0;
            for (int i = 0; i < sutun; i++)
            {
                for (int l = 0; l < sutun; l++)
                {
                    for (int j = 0; j < satir; j++)
                    {
                        deger1 += transpose_matris[i, j] * matris[j, l];
                        topsayac++;
                        carsayac++;
                    }
                    t_Carpimmatris[i, l] = deger1;
                    deger1 = 0;

                }

            }
            return t_Carpimmatris;
        }

        public double DeterminantHesap(double[,] matris)
        {
            int boyut = Convert.ToInt32(Math.Sqrt(matris.Length));
            int isaret = 1;
            double toplam = 0;
            if (boyut == 1)
                return matris[0, 0];
            for (int i = 0; i < boyut; i++)
            {
                double[,] altMatris = new double[boyut - 1, boyut - 1];
                for (int satir = 1; satir < boyut; satir++)
                {
                    for (int sutun = 0; sutun < boyut; sutun++)
                    {
                        if (sutun < i)
                            altMatris[satir - 1, sutun] = matris[satir, sutun];
                        else if (sutun > i)
                            altMatris[satir - 1, sutun - 1] = matris[satir, sutun];
                    }
                }
                if (i % 2 == 0)
                    isaret = 1;
                else
                    isaret = -1;

                toplam += isaret * matris[0, i] * (DeterminantHesap(altMatris));

            }

            return toplam;
        }

    }
}
