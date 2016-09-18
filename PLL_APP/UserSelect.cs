using System;
using System.Collections.Generic;

using Multicad;
using Multicad.Geometry;
using Multicad.DatabaseServices;
using Multicad.DatabaseServices.StandardObjects;


namespace PLL_APP
{ 
    partial class HandlerPolyline
    { 
       static DbPolyline plineGetFromUser = new DbPolyline();
        public bool getFromDwg()
        {
            // Выбор  объекта, и проверка что это полилиния 
            Multicad.McObjectId idSelected = McObjectManager.SelectObject("Выберите полилинию ");
            Multicad.McObject targetPl = idSelected.GetObject();

            Polyline3d testPL = new Polyline3d();

            // передаем в форму true или false для обеспечения логики работы 
            if (targetPl is DbPolyline || Object.ReferenceEquals(targetPl.GetType(), testPL.GetType()))
            {    
              plineGetFromUser = targetPl as DbPolyline;
              return true;
            }
            else
            {
                return false;
            }
        }
     }
}
