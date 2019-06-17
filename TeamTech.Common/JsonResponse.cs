using System;
using System.Collections.Generic;
using System.Text;

namespace TeamTech.Common
{
    public class JsonResponse
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
        public bool Warning { get; set; }
        public object Data { get; set; }
    }
}
