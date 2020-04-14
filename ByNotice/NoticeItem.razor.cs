using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace ByNotice
{
    public sealed partial class NoticeItem
    { 
        [Parameter]
        public NoticeOption Option { get; set; }

        [Parameter]
        public EventCallback<NoticeOption> Close { get; set; }

        private string GetIcon()
        {
            if (string.IsNullOrWhiteSpace(Option.CustomIconHtml)
             || Option.CustomIconHtml == string.Empty)
            {
                switch (Option.IconType)
                {
                    case IconType.Info:
                        return $"<span class='{_classPrefix}-info'><svg viewBox=\"64 64 896 896\" focusable=\"false\" class=\"\" data-icon=\"info-circle\" width=\"1em\" height=\"1em\" fill=\"currentColor\" aria-hidden=\"true\"><path d=\"M512 64C264.6 64 64 264.6 64 512s200.6 448 448 448 448-200.6 448-448S759.4 64 512 64zm0 820c-205.4 0-372-166.6-372-372s166.6-372 372-372 372 166.6 372 372-166.6 372-372 372z\"></path><path d=\"M464 336a48 48 0 1096 0 48 48 0 10-96 0zm72 112h-48c-4.4 0-8 3.6-8 8v272c0 4.4 3.6 8 8 8h48c4.4 0 8-3.6 8-8V456c0-4.4-3.6-8-8-8z\"></path></svg></span>";

                    case IconType.Success:
                        return $"<span class='{_classPrefix}-success'><svg viewBox=\"64 64 896 896\" focusable=\"false\" class=\"\" data-icon=\"check-circle\" width=\"1em\" height=\"1em\" fill=\"currentColor\" aria-hidden=\"true\"><path d=\"M699 353h-46.9c-10.2 0-19.9 4.9-25.9 13.3L469 584.3l-71.2-98.8c-6-8.3-15.6-13.3-25.9-13.3H325c-6.5 0-10.3 7.4-6.5 12.7l124.6 172.8a31.8 31.8 0 0051.7 0l210.6-292c3.9-5.3.1-12.7-6.4-12.7z\"></path><path d=\"M512 64C264.6 64 64 264.6 64 512s200.6 448 448 448 448-200.6 448-448S759.4 64 512 64zm0 820c-205.4 0-372-166.6-372-372s166.6-372 372-372 372 166.6 372 372-166.6 372-372 372z\"></path></svg></span>";

                    case IconType.Warning:
                        return $"<span class='{_classPrefix}-warning'><svg viewBox=\"64 64 896 896\" focusable=\"false\" class=\"\" data-icon=\"warning\" width=\"1em\" height=\"1em\" fill=\"currentColor\" aria-hidden=\"true\"><path d=\"M464 720a48 48 0 1096 0 48 48 0 10-96 0zm16-304v184c0 4.4 3.6 8 8 8h48c4.4 0 8-3.6 8-8V416c0-4.4-3.6-8-8-8h-48c-4.4 0-8 3.6-8 8zm475.7 440l-416-720c-6.2-10.7-16.9-16-27.7-16s-21.6 5.3-27.7 16l-416 720C56 877.4 71.4 904 96 904h832c24.6 0 40-26.6 27.7-48zm-783.5-27.9L512 239.9l339.8 588.2H172.2z\"></path></svg></span>";

                    case IconType.Error:
                        return $"<span class='{_classPrefix}-error'><svg viewBox=\"64 64 896 896\" focusable=\"false\" class=\"\" data-icon=\"close-circle\" width=\"1em\" height=\"1em\" fill=\"currentColor\" aria-hidden=\"true\"><path d=\"M685.4 354.8c0-4.4-3.6-8-8-8l-66 .3L512 465.6l-99.3-118.4-66.1-.3c-4.4 0-8 3.5-8 8 0 1.9.7 3.7 1.9 5.2l130.1 155L340.5 670a8.32 8.32 0 00-1.9 5.2c0 4.4 3.6 8 8 8l66.1-.3L512 564.4l99.3 118.4 66 .3c4.4 0 8-3.5 8-8 0-1.9-.7-3.7-1.9-5.2L553.5 515l130.1-155c1.2-1.4 1.8-3.3 1.8-5.2z\"></path><path d=\"M512 65C264.6 65 64 265.6 64 513s200.6 448 448 448 448-200.6 448-448S759.4 65 512 65zm0 820c-205.4 0-372-166.6-372-372s166.6-372 372-372 372 166.6 372 372-166.6 372-372 372z\"></path></svg></span>";
                    default:
                        return "";
                }
            }
            else
            {
                switch (Option.IconType)
                {
                    case IconType.Info:
                        return $"<span class='{_classPrefix}-info'>{Option.CustomIconHtml}</span>";

                    case IconType.Success:
                        return $"<span class='{_classPrefix}-success'>{Option.CustomIconHtml}</span>";

                    case IconType.Warning:
                        return $"<span class='{_classPrefix}-warning'>{Option.CustomIconHtml}</span>";

                    case IconType.Error:
                        return $"<span class='{_classPrefix}-error'>{Option.CustomIconHtml}</span>";
                    default:
                        return $"<span class='{_classPrefix}-custom'>{Option.CustomIconHtml}</span>";
                }
            }
        }

        private string GetFadeIn()
        {
            var placement = Option.Placement.ToString().EndsWith("Right")
                ? "right"
                : "left";

            if (Option.IsEmphasize)
            {
                return "emphasize-" + placement;
            }
            return placement;
        }

        private string BuildClassName()
        {
            var classNames = new List<string>()
            {
                $"{_classPrefix}-item"
            };

            if (Option.IsColorful)
            {
                classNames.Add($"{_classPrefix}-item-" + Option.IconType.ToString().ToLower());
            }
            classNames.Add($"{_classPrefix}-fade-in-" + GetFadeIn());

            classNames.Add(Option.ClassName);

            return string.Join(" ", classNames);
        }
        private Dictionary<string, object> BuildStyle()
        {
            if (string.IsNullOrWhiteSpace(Option.Width)
            || Option.Width == string.Empty)
            {
                return new Dictionary<string, object>();
            }
            return new Dictionary<string, object>()
            {
                {"style", $"width:{Option.Width};"}
            };
        }

        private async Task RemoveSelf()
        {
            if (Close.HasDelegate)
            {
                await Close.InvokeAsync(Option);
            }
        }


    }
}
