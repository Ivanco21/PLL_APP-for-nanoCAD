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



}