﻿using TTMouseClickSimulator.Core.Environment;

namespace TTMouseClickSimulator.Core.Toontown.Actions;

public static class MouseHelpers
{
    public static Size ReferenceWindowSize = new(1600, 1151);

    public static void ChangeReferenceSize(Size newSize)
    {
        ReferenceWindowSize = newSize;
    }

    public static void SetDefaultReferenceSize()
    {
        Size newSize = new(1600, 1151);
        ReferenceWindowSize = newSize;
    }

    public static void DoSimpleMouseClick(
        IInteractionProvider provider,
        Coordinates coords,
        HorizontalScaleAlignment align = HorizontalScaleAlignment.Center,
        int buttonDownDuration = 150)
    {
        var pos = provider.GetCurrentWindowPosition();
        coords = pos.ScaleCoordinates(
            coords,
            ReferenceWindowSize,
            align);

        provider.MoveMouse(coords);
        provider.PressMouseButton();
        provider.Wait(buttonDownDuration);
        provider.ReleaseMouseButton();
    }
}
