using System;
using System.Collections.Generic;

using Multicad.DatabaseServices.StandardObjects;


namespace PLL_APP
{ 

  class UserEventArgsOnePlProp:EventArgs
  {
      public readonly DbPolyline PlineGetFromUser;
      public readonly bool CorrectlyGet;
      public readonly bool ClosedPl;
      public readonly int PlVertexCount;

      public UserEventArgsOnePlProp(DbPolyline plineGetFromUser, bool correctlyGet, bool closedPl, int plVertexCount)
      {
          PlineGetFromUser = plineGetFromUser;
          CorrectlyGet = correctlyGet;
          ClosedPl = closedPl;
          PlVertexCount = plVertexCount; 
      }

  }
  class UserEventArgsOneObjProp : EventArgs
  {
      public readonly DbGeometry ObjFromUser;
      public readonly McBlockRef BlockUserSelect;
      public readonly bool CorrectlyGet;

      public UserEventArgsOneObjProp(DbGeometry objFromUser,McBlockRef blockUserSelect, bool correctlyGet)
      {
          ObjFromUser = objFromUser;
          CorrectlyGet = correctlyGet;
          BlockUserSelect = blockUserSelect;
      }

  }



}