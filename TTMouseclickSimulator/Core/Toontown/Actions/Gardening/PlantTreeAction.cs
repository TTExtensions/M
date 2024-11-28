using System;
using System.Text;

using TTMouseClickSimulator.Core.Actions;
using TTMouseClickSimulator.Core.Environment;

namespace TTMouseClickSimulator.Core.Toontown.Actions.Gardening;

/// <summary>
/// An action which plants a cupcake tree.
/// </summary>
public class PlantTreeAction : AbstractAction
{


    public PlantTreeAction()
    {

    }

    public override SimulatorCapabilities RequiredCapabilities
    {
        get => SimulatorCapabilities.MouseInput;
    }

    public override sealed void Run(IInteractionProvider provider)
    {
        provider.ThrowIfNotToontownRewritten(nameof(PlantTreeAction));

        // Click on the "Plant Flower" button.
        MouseHelpers.DoSimpleMouseClick(
            provider,
            new Coordinates(76, 264),
            HorizontalScaleAlignment.Left);

        provider.Wait(200);

        // Click on the cupcake
        // Reference size is the Client window coordinates on Auto Hot Key Window Spy
        Size newSize = new(1920, 1003);
        MouseHelpers.ChangeReferenceSize(newSize);
        MouseHelpers.DoSimpleMouseClick(
            provider,
            new Coordinates(640, 550),
            HorizontalScaleAlignment.NoAspectRatio);
        // Reset to default scale so other actions still work
        MouseHelpers.SetDefaultReferenceSize();

        provider.Wait(200);

    }

    public override string ToString()
    {

        return $"Planting cupcake tree";
    }
}
