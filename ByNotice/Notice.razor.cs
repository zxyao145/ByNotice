using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ByNotice
{
    public sealed partial class Notice
    {
        protected override void OnInitialized()
        {
            Instance = this;
        }

        public static Notice Instance { get; private set; }


        private List<NoticeOption> _topRightNoticeItems = new List<NoticeOption>();

        private List<NoticeOption> _topLeftNoticeItems = new List<NoticeOption>();
        private List<NoticeOption> _bottomLeftNoticeItems = new List<NoticeOption>();
        private List<NoticeOption> _bottomRightNoticeItems = new List<NoticeOption>();


        public async Task NotifyAsync(NoticeOption option)
        {
            switch (option.Placement)
            {
                case NoticePlacement.TopLeft:
                    _topLeftNoticeItems.Add(option);
                    break;
                case NoticePlacement.BottomLeft:
                    _bottomLeftNoticeItems.Add(option);
                    break;
                case NoticePlacement.BottomRight:
                    _bottomRightNoticeItems.Add(option);
                    break;
                default:
                    _topRightNoticeItems.Add(option);
                    break;
            }

            StateHasChanged(); 
            await Remove(option);
        }

        private async Task Remove(NoticeOption option)
        {
            if (option.KeepTime.TotalMilliseconds > 0)
            {
                await Task.Delay(option.KeepTime);
                await RemoveChild(option);
            }
        }

        private Task RemoveChild(NoticeOption option)
        {
            //avoid use do click and option.KeepTime toggle twice
            if (string.IsNullOrEmpty(option.ClassName))
            {
                option.ClassName = $"{_classPrefix}-fade-out";
                StateHasChanged();
                option.OnClose?.Invoke(option);
                
                switch (option.Placement)
                {
                    case NoticePlacement.TopLeft:
                        _topLeftNoticeItems.Remove(option);
                        break;
                    case NoticePlacement.BottomLeft:
                        _bottomLeftNoticeItems.Remove(option);
                        break;
                    case NoticePlacement.BottomRight:
                        _bottomRightNoticeItems.Remove(option);
                        break;
                    default:
                        _topRightNoticeItems.Remove(option);
                        break;
                }
                //when next notice item fade out or add new notice item, item will toggle StateHasChanged
                //but if width is not  the default width, StateHasChanged
                if (!string.IsNullOrEmpty(option.Width))
                {
                    StateHasChanged();
                }
            }

            return Task.CompletedTask;
        }
    }
}
