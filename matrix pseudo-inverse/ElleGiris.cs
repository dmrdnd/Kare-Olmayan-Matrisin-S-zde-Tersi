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
    public partial class ElleGiris : Form
    {
        public ElleGiris()
        {
            InitializeComponent();
        }

        int satir;
        int sutun;
        double[,] matris;
        double[,] tmatris;
        double[,] t_Carpimmatris;
        double[,] ters_matris;
        double[,] sozdeters_matris;
        MatrixOperations matrixoperation;

        private void button1_Click(object sender, EventArgs e)
        {
            label3.Text = "";
            CreateMatrix();
        }

        private void CreateMatrix()
        {
            label3.Text = "";
            string rakam1;
            double rakam=0;
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("satir ve sutun değerlerini giriniz");

            }
            else
            {
                satir = int.Parse(textBox1.Text);
                sutun = int.Parse(textBox2.Text);

                matris = new double[satir, sutun];
                if (satir > 5 || sutun > 5 || satir == sutun)
                {
                    MessageBox.Show("Satir ve sutun değerleri aynı ve 5 den büyük olamaz!!");
                }
                else
                {
                    for (int i = 0; i < satir; i++)
                    {
                        for (int j = 0; j < sutun; j++)
                        {
                            rakam1= Interaction.InputBox("Matrisin " + (i + 1) + ".satır" + (j + 1) + ".sütun değerini gir", "", "", 10, 10);
                            //rakam = Convert.ToDouble(rakam1);
                            rakam =Convert.ToDouble(rakam1);

                         /*   if(Convert.rakam1> 64 &&Convert.ToInt32(rakam1)< 91 ||Convert.ToInt32(rakam1)> 96 &&Convert.ToInt32(rakam1)< 123 )
                            {
                                MessageBox.Show("Lütfen 1 ve 9 arasında bir sayı giriniz");
                            }
                            else 
                            */if (rakam>= 10 || rakam< 1 || rakam == null)
                            {
                                MessageBox.Show("Yalnız rakam girişi");
                            }
                            else
                            {
                                rakam = Convert.ToDouble(rakam1);
                                matris[i, j] = rakam;
                           }                            
                            
                        }
                    }
                    Yazdir(groupBox1, label3, matris, satir, sutun);
                }
            }
            textBox1.Text = "";
            textBox2.Text = "";

        }
        private void Yazdir(GroupBox box, Label label, Double[,] matris, int satir, int sutun)
        {
           // label.Size = new Size(satir * 50, sutun * 50);
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
            label4.Text = "";
            tmatris = new double[sutun, satir];
            matrixoperation = new MatrixOperations();
            tmatris = matrixoperation.Tranpose(matris, satir, sutun);
            Yazdir(transpos, label4, tmatris, sutun, satir);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label5.Text = "";
            t_Carpimmatris = new double[sutun, sutun];
            matrixoperation = new MatrixOperations();
            t_Carpimmatris = matrixoperation.TransposeMultiplic(tmatris, matris, satir, sutun);
            Yazdir(groupBox2, label5, t_Carpimmatris, sutun, sutun);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label6.Text = "";
            ters_matris = new double[sutun,sutun];
            matrixoperation = new MatrixOperations();
            double det= matrixoperation.DeterminantHesap(t_Carpimmatris);
            label7.Text = det.ToString();
            groupBox4.Visible = true;
            label7.Visible = true;

            if (det != 0.0)
            {
                ters_matris = matrixoperation.TersMatris(t_Carpimmatris, satir, sutun);
                //Yazdir(groupBox3, label6,ters_matris ,sutun, sutun);
                for (int i = 0; i < sutun; i++)
                {
                    for (int j = 0; j < sutun; j++)
                    {
                        label6.Text = label6.Text + " " + "[" + ters_matris[i, j].ToString("0.##") + "]";
                    }
                    label6.Text = label6.Text + "\r\n";
                }
                groupBox3.Visible = true;
                label6.Visible = true;
                button5.Visible = true;
            }
            else
            {
                groupBox3.Visible = false;
                groupBox5.Visible = false;
                MessageBox.Show("Determinantı 0 olan matrislerin tersi bulunamaz!!");
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            label9.Text = "";
            sozdeters_matris = new double[sutun, satir];
            matrixoperation = new MatrixOperations();
            sozdeters_matris = matrixoperation.TransposeTersMultiplic(ters_matris, tmatris, satir, sutun);
            Yazdir(groupBox5,label9,sozdeters_matris,sutun,satir);
            textBox4.Text = matrixoperation.carsayac.ToString();
            textBox3.Text = matrixoperation.topsayac.ToString();
            groupBox6.Visible = true;

        }


        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
