using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace yazlab1._2
{
    public partial class Random : Form
    {
        public Random()
        {
            InitializeComponent();
        }
        int satir, sutun;
        double[,] matris;
        double[,] tmatris;
        double[,] t_Carpimmatris;
        double[,] ters_matris;
        double[,] sozdeters_matris;

        MatrixOperations matrixoperation;
        System.Random rastgele = new System.Random();

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text="";
            CreateMatrix();
        }

        private void CreateMatrix()
        {
           
            satir = rastgele.Next(1, 6);
            sutun = rastgele.Next(1, 6);
            matris = new double[satir, sutun];
            if (satir != sutun)
            {
                for (int i = 0; i < satir; i++)
                {
                    for (int j = 0; j < sutun; j++)
                    {
                        matris[i, j] =Convert.ToDouble((1+rastgele.NextDouble()*9));
                    }
                }
                Yazdir(groupBox1, label1, matris, satir, sutun);                
            }
            else
            {
                MessageBox.Show("satir ve sutun değerleri eşit olamaz butona tekrar bas");
            }

        }
        private void Yazdir(GroupBox box, Label label, Double[,] matris, int satir, int sutun)
        {
            //label.Size = new Size(satir * 50, sutun * 50);
            for (int i = 0; i < satir; i++)
            {
                for (int j = 0; j < sutun; j++)
                {
                    label.Text = label.Text + " " + "[" + matris[i, j].ToString("0.#") + "]";
                }
                label.Text = label.Text + "\r\n";
            }
            box.Visible = true;
            label.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label2.Text = "";
            tmatris = new double[sutun,satir];
            matrixoperation = new MatrixOperations();
            tmatris = matrixoperation.Tranpose(matris, satir, sutun);
            Yazdir(transpos, label2, tmatris, sutun, satir);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label3.Text = "";
            t_Carpimmatris = new double[sutun, sutun];
            matrixoperation = new MatrixOperations();
            t_Carpimmatris = matrixoperation.TransposeMultiplic(tmatris, matris, satir, sutun);
            Yazdir(groupBox2, label3, t_Carpimmatris, sutun, sutun);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label7.Text ="";
            sozdeters_matris = new double[sutun, satir];
            matrixoperation = new MatrixOperations();
            sozdeters_matris = matrixoperation.TransposeTersMultiplic(ters_matris, tmatris, satir, sutun);
            Yazdir(groupBox5, label7, sozdeters_matris, sutun, satir);
            textBox4.Text= matrixoperation.carsayac.ToString();
            textBox3.Text= matrixoperation.topsayac.ToString();
            groupBox6.Visible = true;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            label4.Text = "";
            label6.Text = "";
            ters_matris = new double[sutun,sutun];
            matrixoperation = new MatrixOperations();
            double det=matrixoperation.DeterminantHesap(t_Carpimmatris);
            label4.Text = det.ToString();
            groupBox3.Visible = true;
            label4.Visible = true;

            if (det != 0)
            {
                ters_matris = matrixoperation.TersMatris(t_Carpimmatris, satir, sutun);
                //Yazdir(groupBox4, label6, ters_matris, sutun, sutun);
                for (int i = 0; i < sutun; i++)
                {
                    for (int j = 0; j < sutun; j++)
                    {
                        label6.Text = label6.Text + " " + "[" + ters_matris[i, j].ToString("0.###") + "]";
                    }
                    label6.Text = label6.Text + "\r\n";
                }
                groupBox4.Visible = true;
                label6.Visible = true;
                button5.Visible = true;
            }
            else
            {
                groupBox5.Visible = false;
                groupBox4.Visible = false;
                MessageBox.Show("Determinantı 0 olan matrislerin tersi bulunamaz!!");
            }
        }


    



    }
}
