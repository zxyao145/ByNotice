# ByNotice

![Nuget](https://img.shields.io/nuget/v/ByNotice)

This a notification razor component for blazor. It is written entirely in C# and CSS.

## Quick Start

1. Add css to the html.

```html
<link rel="stylesheet" href="/_content/ByNotice/bynotice.css" />
```

2. Add namespace declaration in "_Imports.razor".

```c#
@using ByNotice
```
2. Add component "Notice" in "MainLayout.razor" (or whatever you want to use).

``` html
<Notice />
```

3. notify a message

```c#
await Notice.Instance.NotifyAsync(new NoticeOption()
{
    Message = "here is the message",
    Title = "here is tite"
});
```

Oh, you should install it first. Nuget path is [here](https://www.nuget.org/packages/ByNotice/).

```powershell
Install-Package ByNotice
```

result:

![quickstart](./docMedia/quickstart.jpg)

See wiki or "ByNotice.Sample" for more usage.

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

![OnClose Hook](./docMedia/OnClose Hook.gif)

## Attention

Only one component instance is allowed in an application.

## Developer

zxyao

## License

MIT