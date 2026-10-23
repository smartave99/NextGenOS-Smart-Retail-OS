namespace NextGenOS.Hub.Cameras;

/// <summary>How a camera is reached. A short closed list; each kind has its own way of writing the address.</summary>
public static class CameraKind
{
    /// <summary>A network camera that gives a video stream, for example <c>rtsp://192.168.1.50:554/stream1</c>.</summary>
    public const string Rtsp = "rtsp";

    /// <summary>A network camera that is found and controlled the ONVIF way, for example <c>http://192.168.1.50/onvif/device_service</c>.</summary>
    public const string Onvif = "onvif";

    /// <summary>A camera plugged into this computer; the address is the name the computer gives it.</summary>
    public const string Usb = "usb";

    /// <summary>A recorded video or a picture file on this computer (for trying things out).</summary>
    public const string File = "file";

    public static readonly IReadOnlyList<string> All = [Rtsp, Onvif, Usb, File];

    public static bool IsKnown(string? value) => value is not null && All.Contains(value);

    public static string Label(string kind) => kind switch
    {
        Rtsp => "Network camera (video stream)", Onvif => "Network camera (ONVIF)", Usb => "Camera plugged into this computer", File => "A video or picture file on this computer", _ => kind,
    };

    public static string AddressHint(string kind) => kind switch
    {
        Rtsp => "for example rtsp://192.168.1.50:554/stream1", Onvif => "for example 192.168.1.50 or http://192.168.1.50/onvif/device_service",
        Usb => "the name the computer gives the camera", File => "where the file is on this computer", _ => "",
    };
}

/// <summary>
/// What a camera may be asked to look for. A short closed list of things, never a person's face or any other way of knowing who someone is: the program does not recognise people, it counts and
/// follows anonymous things (<c>docs/VERSION-2.md</c>, "anonymous by default").
/// </summary>
public static class CameraClass
{
    public const string Person = "person";
    public const string Cart = "cart";
    public const string Basket = "basket";
    public const string Product = "product";

    public static readonly IReadOnlyList<string> All = [Person, Cart, Basket, Product];

    public static bool IsKnown(string? value) => value is not null && All.Contains(value);

    public static string Label(string value) => value switch
    {
        Person => "People (anonymous: only that someone is there)", Cart => "Trolleys", Basket => "Baskets", Product => "Products on a shelf", _ => value,
    };
}

/// <summary>How the last "can the program reach it?" check ended.</summary>
public static class CameraCheckStatus
{
    /// <summary>It answered (or the file is there). No picture was read.</summary>
    public const string Ok = "ok";

    /// <summary>It did not answer, is not where it should be, or answered from outside the shop's own network.</summary>
    public const string Failed = "failed";

    /// <summary>It cannot be checked from here (a camera plugged into this computer); it is checked when it is first used.</summary>
    public const string NotCheckable = "not-checkable";

    public static string Label(string? status) => status switch
    {
        Ok => "reached", Failed => "not reached", NotCheckable => "cannot be checked from here", _ => "not checked yet",
    };
}

/// <summary>What the owner types about a camera.</summary>
public sealed record CameraInput(string Name, string Kind, string Address, string? ZoneRef, IReadOnlyList<string> Classes, int MinConfidencePercent = CameraService.DefaultMinConfidence);

/// <summary>A camera as the screen shows it. There is never a password in it: <see cref="HasPassword"/> says only whether one is kept.</summary>
public sealed record Camera(
    long Id, string Ref, string Name, string Kind, string Address, string? ZoneRef, IReadOnlyList<string> Classes, int MinConfidencePercent, bool Enabled, bool HasPassword,
    DateTimeOffset? CheckedAt, string? CheckStatus, string? CheckNote, DateTimeOffset CreatedAt, DateTimeOffset UpdatedAt, DateTimeOffset? RetiredAt)
{
    public bool Retired => RetiredAt is not null;
}

/// <summary>The answer to "can the program reach this camera?".</summary>
public sealed record CameraCheck(string Status, string Note);
