using System;
using System.Collections.Generic;
using System.Text;

namespace ByNotice
{
    public class NoticeOption
    {
        public string Width { get; set; }

        public string CustomIconHtml { get; set; } = null;
        public string Message { get; set; }

        public string Title { get; set; }
        
        public TimeSpan KeepTime { get; set; } = TimeSpan.FromSeconds(5);

        public NoticePlacement Placement { get; set; } = NoticePlacement.TopRight;

        public IconType IconType { get; set; } = IconType.Info;

        public bool IsColorful { get; set; } = false;

        public Action<NoticeOption> OnClose = null;

        public bool IsEmphasize { get; set; } = false;

        internal string ClassName { get; set; }
    }
}
