using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Multicad;
using Multicad.Geometry;
using Multicad.DatabaseServices;
using Multicad.DatabaseServices.StandardObjects;


namespace PLL_APP
{ 
    class OnePolylineSelector
    {
        DbPolyline plineGetFromUser;
        bool correctlyGet;
        bool closedPl;
        int plVertexCount;
        public OnePolylineSelector()
        {
           getOnePlFromDwg();
           closedPl = plineGetFromUser.Polyline.ClosedLogically;
           plVertexCount = plineGetFromUser.Polyline.Vertices.Count;
        }

        public event EventHandler<UserEventArgsOnePlProp> sendDataOnePlInForm;

        public void DoEventSendDataOnePlInForm()
        {
            if (sendDataOnePlInForm != null)
                sendDataOnePlInForm(this, new UserEventArgsOnePlProp(plineGetFromUser, correctlyGet, closedPl, plVertexCount));
        }
        void getOnePlFromDwg()
        {
            try
            {
                // Выбор  объекта, и проверка что это полилиния 
                Multicad.McObjectId idSelected = McObjectManager.SelectObject("Выберите полилинию ");
                Multicad.McObject targetPl = idSelected.GetObject();

                Polyline3d testPL = new Polyline3d();

                if (targetPl is DbPolyline || Object.ReferenceEquals(targetPl.GetType(), testPL.GetType()))
                {
                    this.plineGetFromUser = targetPl as DbPolyline;
                    this.correctlyGet = true;
                }
                else
                {
                    this.correctlyGet = false;
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }             
        }
     }
    class OneObjSelector
    {
        DbGeometry fromUserSelect;
        McBlockRef blockUserSelect;
        bool correctlyGet;

        public OneObjSelector()
        {
           getOneObgFromDwg();      
        }

        public event EventHandler<UserEventArgsOneObjProp> sendDataOneObjInForm;

        public void DoEventSendDataOneObjInForm()
        {
            if (sendDataOneObjInForm != null)
                sendDataOneObjInForm(this, new UserEventArgsOneObjProp(fromUserSelect, blockUserSelect, correctlyGet));
        }


        private void getOneObgFromDwg()
        {
            try
            {
                
                Multicad.McObjectId idSelected = McObjectManager.SelectObject("Выберите объект для расстановки");
                Multicad.McObject targetObj = idSelected.GetObject();

                if (targetObj is DbGeometry)
                {
                    this.fromUserSelect = targetObj as DbGeometry;
                    this.correctlyGet = true;
                }
                else if(targetObj is McBlockRef)
                {
                    this.blockUserSelect = targetObj as McBlockRef;
                    this.correctlyGet = true;                   
                }
                else
                {
                    this.correctlyGet = false;
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }             
        }


    }
}
