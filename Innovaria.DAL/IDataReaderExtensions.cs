﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Core.DAL
{
    public static class IDataReaderExtensions
    {
        public static IEnumerable<T> Select<T>(this IDataReader reader, Func<IDataReader, T> function)
        {
            while (reader.Read())
            {
                yield return function(reader);
            }
        }
    }
}
