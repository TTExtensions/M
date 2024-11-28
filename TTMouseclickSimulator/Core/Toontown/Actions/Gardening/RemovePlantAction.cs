using System;
using System.Text;

using TTMouseClickSimulator.Core.Actions;
using TTMouseClickSimulator.Core.Environment;

namespace TTMouseClickSimulator.Core.Toontown.Actions.Gardening;

/// <summary>
/// An action which removes a flower and confirms.
/// </summary>
public class RemovePlantAction : AbstractAction
{

    public RemovePlantAction()
    {

    }

    public override SimulatorCapabilities RequiredCapabilities
    {
        get => SimulatorCapabilities.MouseInput;
    }

    public override sealed void Run(IInteractionProvider provider)
    {
        provider.ThrowIfNotToontownRewritten(nameof(RemovePlantAction));

        // Click on the "Remove Flower" button.
        MouseHelpers.DoSimpleMouseClick(
            provider,
            new Coordinates(76, 264),
            HorizontalScaleAlignment.Left);

        provider.Wait(200);

        // Click yes
        Size newSize = new(1920, 1003);
        MouseHelpers.ChangeReferenceSize(newSize);
        MouseHelpers.DoSimpleMouseClick(
            provider,
            new Coordinates(900, 680),
            HorizontalScaleAlignment.NoAspectRatio);

        
        MouseHelpers.SetDefaultReferenceSize();

        provider.Wait(200);

    }

    public override string ToString()
    {
        return $"Removing Flower";
    }
}
