using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.Mp
{
    /// <summary>
    /// 
    /// </summary>
    public class KFMessage
    {
        /// <summary>
        /// 
        /// </summary>
        public string touser { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string msgtype { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Text text { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Image image { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Voice voice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Video video { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Music music { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public News news { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public wxcard wxcard { get; set; }

    }


}
