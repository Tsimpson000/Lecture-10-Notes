﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_10_Notes
{
    internal class BlogPost
    {
        string _header;
        string _body;
        DateTime _created;

        public BlogPost(string header, string body)
        {
            _header = header;
            _body = body;
            _created = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{_created.ToShortDateString()} - {_header}";
        }
    }
}
