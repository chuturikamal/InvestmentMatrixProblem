using System;
using Investment.MatrixConversion.Business.Models;

namespace Investment.MatrixConversion.Business.Util
{
	public class StaticCollection
	{
		public static int Size{get; set;}
       
        public static Response GenRes(int? value = null, String? cause = null, bool success = true)
        {
            Response response = new Response()
            {
                Value = value.GetValueOrDefault(),
                Cause = cause,
                Success = success
            };
            return response;
        }
    }
}

