# CustomShapeWpfButton
Custom shaped button for Wpf application.

It gives access to 5 buttons, one in the center and 4 around it.

You can customize the radius, the colors... I try to fit to my needs first.
To add it, simply write this :

//defines the text values for the buttons.
var values = new Dictionary<Position, string>
{
    { Position.Right, "Right" },
    { Position.Left, "Left" },
    { Position.Top, "Top" },
    { Position.Bottom, "Bottom" },
    { Position.Center, "Split" }
};
//basic constructor, with every properties to override to your tastes.
ArcButton arcButton = new ArcButton(230, values);

You have 5 click events to bind to :
arcButton.LeftClick
arcButton.RightClick
arcButton.TopClick
arcButton.BottomClick
arcButton.CenterClick

![screenshot arcbutton](https://raw.github.com/Crmbl/CustomShapeWpfButton/master/screenshot.PNG)