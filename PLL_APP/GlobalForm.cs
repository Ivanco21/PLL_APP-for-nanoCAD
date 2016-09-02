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

        public double inputUserTextHeight = 250;// также 250 записано здесь  this.textHeight.Text, что вероятно неправильно(дублирование). 
        HandlerPolyline ForWorkInForms = new HandlerPolyline();
        
        private void GetPL_Click(object sender, EventArgs e)
        {
            try
            {

                if (ForWorkInForms.getFromDwg() == true)
                {
                    pnlOnePnl.Enabled = true;
                    btGetPL.Text = "Полилиния выбрана!Изменить?";
                }
                else
                {
                    pnlOnePnl.Enabled = false;
                    btGetPL.Text = "Выберите полилинию";
                    MessageBox.Show("Выбрана не полилиния и не 3D полилиния!");

                }
            }
            catch (Exception ex)
            {
                // обработчик сделать чтобы ловил клики по кнопкам нано
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void vertexInTable_Click(object sender, EventArgs e)
        {
            // таблицу в чертеж
            ForWorkInForms.vertexInTableOutDwg(cbAccuracyPoint.Text);
        }

        private void numberInDwg_Click(object sender, EventArgs e)
        {
            ForWorkInForms.numberInDwg(Convert.ToInt32(inputUserTextHeight));            
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

        private void revers_Click(object sender, EventArgs e)
        {
            ForWorkInForms.reversPolyline(ForWorkInForms.plineForWork);
            pnlOnePnl.Enabled = false;
        }

        private void ExportInCsv_Click(object sender, EventArgs e)
        {
            //таблицу в файл
            ForWorkInForms.vertexInTableOutCsv(cbAccuracyPoint.Text);
        }
        
        private void segmentToLines_Click(object sender, EventArgs e)
        {
            ForWorkInForms.deletDuplicatedVertexPolyline(ForWorkInForms.plineForWork);
            pnlOnePnl.Enabled = false;
        }

              
    }
 }
