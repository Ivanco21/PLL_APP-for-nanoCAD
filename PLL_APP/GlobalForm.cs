using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Globalization;

using Multicad;
using Multicad.DatabaseServices;
using Multicad.Geometry;
using Multicad.Runtime;
using Multicad.DatabaseServices.StandardObjects;
using Multicad.Symbols.Tables;

namespace PLL_APP
{
    public partial class GlobalForm : Form
    {
       
        public GlobalForm()
        {
            InitializeComponent();
        }
        HandlerPolyline onePl;
        dynamic geomUserSelect;

        public double inputUserTextHeight = 250;// также 250 записано здесь  this.textHeight.Text, что вероятно неправильно(дублирование).      
        public double MaxLenghtSegPl = 50;
        public bool delSoursePl = false;
        public double inputUserStartNumber = 1;  
      
        private void GetPL_Click(object sender, EventArgs e)
        {
            OnePolylineSelector onePl = new OnePolylineSelector();
            onePl.sendDataOnePlInForm += new EventHandler<UserEventArgsOnePlProp>(other_sendDataOnePlInForm);
            onePl.DoEventSendDataOnePlInForm();
 
        }

        private void other_sendDataOnePlInForm(object sender, UserEventArgsOnePlProp e)
        {
            if(e.CorrectlyGet == true)
            {
                pnlOnePnl.Enabled = true;
                btGetPL.Text = "Полилиния выбрана!Изменить?";

                // ренумерация вершин только для замкнутых линий                
                if (e.ClosedPl == false)
                {
                    gbRenumerateVertexPl.Enabled = false;// ренумерация вершин только для замкнутых линий
                }
                else
                {
                    gbRenumerateVertexPl.Enabled = true;
                    DomainUpDown.DomainUpDownItemCollection vertexCollection = this.dmUpDwnVertexInPl.Items;

                    for (int i = 1; i <= e.PlVertexCount; i++)
                    {
                        vertexCollection.Add(i);
                    }
                    dmUpDwnVertexInPl.Text = "1"; // инциализация начальной вершины, для выбора
                }
            }
            else
            {
                pnlOnePnl.Enabled = false;
                btGetPL.Text = "Выберите полилинию";
                MessageBox.Show("Выбрана не полилиния и не 3D полилиния!");
                return;
            }

            HandlerPolyline onePolyline = new HandlerPolyline(e.PlineGetFromUser);
            onePl = onePolyline;
        }

        private void vertexInTable_Click(object sender, EventArgs e)
        {
            onePl.vertexInTableOutDwg(cbAccuracyPoint.Text);
        }

        private void numberInDwg_Click(object sender, EventArgs e)
        {
            //если пользователь не ввел стартовое значение нумерации то оно =1, если же ввел передаем его из формы 
            if (cbStartNumerateAbout.Checked == false)
            {
               onePl.numberInDwg(Convert.ToInt32(inputUserTextHeight),1);  
          
            }
            else
            {
                onePl.numberInDwg(Convert.ToInt32(inputUserTextHeight),Convert.ToInt32(inputUserStartNumber));  
            }
                    
        }
     
        private void textHeight_TextChanged(object sender, EventArgs e)
        {
            //проверка что вводится число!
           string inputTextHeight = tbTextHeight.Text;
           string decimal_sep = NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;
           inputTextHeight = tbTextHeight.Text.Replace(".", decimal_sep);// явная замена на точку (NumberDecimalSeparator - точка по умолчанию) возможно можно лучше сделать
           inputTextHeight = tbTextHeight.Text.Replace(",", decimal_sep);

            bool res = double.TryParse(inputTextHeight,out inputUserTextHeight);

              if (res == false)
              {
                  lbTextHeight.Text = "Введите число!";
                  lbTextHeight.ForeColor = Color.Red;
                  btNumberVertInDwg.Enabled = false;
              }
             else
              {
                  lbTextHeight.Text = "Высота текста";
                  lbTextHeight.ForeColor = Color.Black;
                  btNumberVertInDwg.Enabled = true;
              }
        }
        private void cbStartNumerateAbout_CheckedChanged(object sender, EventArgs e)
        {
            if (cbStartNumerateAbout.Checked == true)
            {
                tbStartNumerateNumber.ReadOnly = false;
                tbStartNumerateNumber.Text = "";
                btNumberVertInDwg.Enabled = true;
            }
            else
            {             
                tbStartNumerateNumber.ReadOnly = true;
                tbStartNumerateNumber.Text = "";
                btNumberVertInDwg.Enabled = true;
            }
           

        }
        private void tbStartNumerateNumber_TextChanged(object sender, EventArgs e)
        {
            if (cbStartNumerateAbout.Checked == true)
            {
                //проверка что вводится число!
                string inputStartNum = tbStartNumerateNumber.Text;
                string decimal_sep = NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;
                inputStartNum = tbStartNumerateNumber.Text.Replace(".", decimal_sep);// явная замена на точку (NumberDecimalSeparator - точка по умолчанию) возможно можно лучше сделать
                inputStartNum = tbStartNumerateNumber.Text.Replace(",", decimal_sep);

                bool res = double.TryParse(inputStartNum, out inputUserStartNumber);

                if (res == false)
                {
                    tbStartNumerateNumber.Text = "Введите число!";
                    tbStartNumerateNumber.ForeColor = Color.Red;
                    btNumberVertInDwg.Enabled = false;
                }
                else
                {
                    inputUserStartNumber = Convert.ToInt32(tbStartNumerateNumber.Text);
                    tbStartNumerateNumber.ForeColor = Color.Black;
                    btNumberVertInDwg.Enabled = true;
                }
            }         
        }                  

        private void revers_Click(object sender, EventArgs e)
        {
            onePl.reversPolyline();
            pnlOnePnl.Enabled = false;
            btGetPL.Text = "Выберите полилинию";
        }

        private void ExportInCsv_Click(object sender, EventArgs e)
        {
           onePl.vertexInTableOutCsv(cbAccuracyPoint.Text);
        }
        
        private void segmentToLines_Click(object sender, EventArgs e)
        {
            onePl.deletDuplicatedVertexPolyline();
            pnlOnePnl.Enabled = false;
            btGetPL.Text = "Выберите полилинию";
        }

        private void tbTolerance_TextChanged(object sender, EventArgs e)
        {
            //проверка что вводится число!
            string inputMaxLenghtSegPl = tbTolerance.Text;
            string decimal_sep = NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;
            inputMaxLenghtSegPl = tbTolerance.Text.Replace(".", decimal_sep);// явная замена на точку (NumberDecimalSeparator - точка по умолчанию) возможно можно лучше сделать
            inputMaxLenghtSegPl = tbTolerance.Text.Replace(",", decimal_sep);

            bool res = double.TryParse(inputMaxLenghtSegPl, out MaxLenghtSegPl);

            if (res == false)
            {
                lbTolerance.Text = "Введите число!";
                lbTolerance.ForeColor = Color.Red;
                btRedusePl.Enabled = false;
            }
            else
            {
                lbTolerance.Text = "Максимальная длинна сегмента";
                lbTolerance.ForeColor = Color.Black;
                btRedusePl.Enabled = true;
            }

        }
        private void cbDelSoursePl_CheckedChanged(object sender, EventArgs e)
        {
            delSoursePl = cbDelSoursePl.Checked;  
        }
        private void btFitPl_Click(object sender, EventArgs e)         
        {
            onePl.fitPolyline(MaxLenghtSegPl, delSoursePl);
            pnlOnePnl.Enabled = false;
            btGetPL.Text = "Выберите полилинию";
        }

        private void btnRenumVertexInPl_Click(object sender, EventArgs e)
        {
            onePl.renumerateVertex(Convert.ToInt32(dmUpDwnVertexInPl.Text));
        }

        private void btnGetObj_Click(object sender, EventArgs e)
        {
            OneObjSelector objForPlace = new OneObjSelector();
            objForPlace.sendDataOneObjInForm += new EventHandler<UserEventArgsOneObjProp>(other_sendDatObjPlInForm);
            objForPlace.DoEventSendDataOneObjInForm();
        }

        private void other_sendDatObjPlInForm(object sender, UserEventArgsOneObjProp e)
        {
            if (e.CorrectlyGet == true)
            {
                btnPlaceGeom.Enabled = true;
                btnGetObj.Text = "Выбрано!Изменить?";
            }
            else
            {
                btnGetObj.Text = "Выберите объект";
                MessageBox.Show("Выбран не поддерживаемый тип ");
                return;
            }

                geomUserSelect = e.ObjFromUser;      
        }

        private void btnPlaceGeom_Click(object sender, EventArgs e)
        {
            ObjPlaced place = new ObjPlaced(geomUserSelect, onePl);
            place.geometryPlaceToPlVertex();
        }

        private void linkMoney_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://money.yandex.ru/to/41001456523527");
        }

       
    }
 }
