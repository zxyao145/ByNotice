# ByNotice

[![NuGet](https://img.shields.io/nuget/v/ByNotice)](https://www.nuget.org/packages/ByNotice)

This a notification razor component for blazor. It is written entirely in C# and CSS.

Sample [https://zxyao145.github.io/ByNotice/](https://zxyao145.github.io/ByNotice/).

## Quick Start

1. Add css to the html.

```html
<link rel="stylesheet" href="/_content/ByNotice/bynotice.css" />
```

2. Add namespace declaration in "_Imports.razor".

```c#
@using ByNotice
```
3. Injection service

```c#
builder.Services.AddByNotice();
```

4. Add component "Notice" in "MainLayout.razor" (or whatever you want to use).

``` html
<Notice />
```

5. notify a message

```c#
@inject NoticeService NoticeService
    
await NoticeService.NotifyAsync(new NoticeOption()
{
    Message = "here is the message",
    Title = "here is tite"
});
```

you can use `NoticeService.NotifyInfoAsync`, `NoticeService.NotifySuccessAsync`, `NoticeService.NotifyWarningAsync`, `NoticeService.NotifyErrorAsync` method too.

Oh, you should install it first. The Nuget path is [here](https://www.nuget.org/packages/ByNotice/).

```powershell
Install-Package ByNotice
```

**Be careful**: Notice.Instance is obsolete after version 0.2.0.

result:

![quickstart](./docMedia/quickstart.jpg)

See [wiki](https://github.com/zxyao145/ByNotice/wiki) or "ByNotice.Sample" for more usage.

## Demo preview

**default style:**

default info

![default-info](./docMedia/default-info.jpg)

default success

![default-success](./docMedia/default-success.jpg)

default warning

![default-warning](./docMedia/default-warning.jpg)

default error

![default-error](./docMedia/default-error.jpg)

default none icon

![default-info](./docMedia/default-none-icon.jpg)

**colorful:**

colorful info

![colorful-info](./docMedia/colorful-info.jpg)

colorful success

![colorful-success](./docMedia/colorful-success.jpg)

colorful warning

![colorful-warning](./docMedia/colorful-warning.jpg)

colorful error

![colorful-error](./docMedia/colorful-error.jpg)


**custom width:**

![custom-width](./docMedia/custom-width.jpg)

**custom icon:**

![custom-icon](./docMedia/custom-icon.jpg)

**emphasize**

![emphasize](./docMedia/emphasize.gif)



**OnClose Hook**

![OnClose Hook](./docMedia/OnCloseHook.gif)

## Attention

Only one component instance is allowed in an application.

## Developer

zxyao

## License

MIT